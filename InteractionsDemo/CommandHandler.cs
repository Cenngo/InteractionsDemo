using Discord.Interactions;
using Discord.WebSocket;
using InteractionsDemo.Modules;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo
{
    public class CommandHandler
    {
        private readonly InteractionService _commands;
        private readonly DiscordSocketClient _discord;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _services;

        public CommandHandler(InteractionService commands, DiscordSocketClient discord, IConfiguration configuration, IServiceProvider services)
        {
            _commands = commands;
            _discord = discord;
            _configuration = configuration;
            _services = services;
        }

        public async Task Initialize()
        {
            try
            {
                await _commands.AddModulesAsync(Assembly.GetExecutingAssembly(), _services);
                _discord.InteractionCreated += InteractionCreated;
                _discord.ButtonExecuted += ButtonExecuted;
                _discord.Ready += Ready;
                _commands.SlashCommandExecuted += _commands_SlashCommandExecuted;
                _commands.AutocompleteHandlerExecuted += _commands_AutocompleteHandlerExecuted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Task _commands_AutocompleteHandlerExecuted(IAutocompleteHandler arg1, Discord.IInteractionContext arg2, IResult arg3)
        {
            return Task.CompletedTask;
        }

        private Task _commands_SlashCommandExecuted(SlashCommandInfo arg1, Discord.IInteractionContext arg2, IResult arg3)
        {
            return Task.CompletedTask;
        }

        // Generic variants of interaction contexts can be used to create interaction specific modules, but you need to make sure that the destination command resides in a module
        // with the matching context type. See -> ComponentOnlyModule
        private async Task ButtonExecuted(SocketMessageComponent arg)
        {
            var ctx = new SocketInteractionContext<SocketMessageComponent>(_discord, arg);
            await _commands.ExecuteCommandAsync(ctx, _services);
        }

        private async Task Ready()
        {
            await RegisterCommands();
            _discord.Ready -= Ready;
        }

        private async Task InteractionCreated(SocketInteraction arg)
        {
            try
            {
                var ctx = new SocketInteractionContext(_discord, arg);
                var result = await _commands.ExecuteCommandAsync(ctx, _services);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task RegisterCommands()
        {
            try
            {
                await _commands.RegisterCommandsToGuildAsync(895219656883859456, true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
