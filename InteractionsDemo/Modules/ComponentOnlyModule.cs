using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class ComponentOnlySupportModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("update-message", "Print update demo")]
        public async Task UpdateMessage()
        {
            await RespondAsync("Haven't updated yet.", components: new ComponentBuilder().WithButton("Update this message", "update-message").Build());
        }
    }

    // This module musn't used to handle any other command type
    public class ComponentOnlyModule : InteractionModuleBase<SocketInteractionContext<SocketMessageComponent>>
    {
        [ComponentInteraction("update-message")]
        public async Task UpdateMessage()
        {
            await Context.Interaction.UpdateAsync(msg => msg.Content = $"Updated at {DateTime.Now}");
        }
    }
}
