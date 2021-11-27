using Discord.Interactions;
using Discord.WebSocket;
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
            await _commands.AddModulesAsync(Assembly.GetExecutingAssembly(), _services);
            _discord.InteractionCreated += InteractionCreated;
            _discord.ButtonExecuted += ButtonExecuted;
            _discord.Ready += Ready;
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
            var ctx = new SocketInteractionContext(_discord, arg);
            await _commands.ExecuteCommandAsync(ctx, _services);
        }

        private async Task RegisterCommands()
        {
            await _commands.RegisterCommandsToGuildAsync(_configuration.GetValue<ulong>("test_guild"));
        }
    }
}
