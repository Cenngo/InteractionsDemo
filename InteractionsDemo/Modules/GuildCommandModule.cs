using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    [Group("guild-commands", "Guild commands")]
    [DontAutoRegister]
    public class GuildCommandModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("you-cant-execute-this", "You are not allowed to execute this command")]
        public async Task CannotExecuteThis()
        {
            await RespondAsync("Hi");
        }
    }
}
