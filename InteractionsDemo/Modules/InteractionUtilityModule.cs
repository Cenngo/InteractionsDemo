using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class InteractionUtilityModule : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService InteractionService { get; set; }

        [SlashCommand("install-commands", "Install guild specific commands")]
        public async Task AddCommands()
        {
            await RespondAsync(":thumbsup:", ephemeral: true);
            await InteractionService.AddModulesToGuildAsync(Context.Guild, false, InteractionService.GetModuleInfo<GuildCommandModule>());
        }

        [SlashCommand("confirm", "Prints a confirmation dialog")]
        public async Task Confirm()
        {
            await DeferAsync();

            var response = await InteractionUtility.ConfirmAsync(Context.Client, Context.Channel, TimeSpan.FromSeconds(30));

            await FollowupAsync($"You responded with {response}");
        }
    }
}
