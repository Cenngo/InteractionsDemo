using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class ContextCommandsModule : InteractionModuleBase<SocketInteractionContext>
    {
        [UserCommand("Say Hello")]
        public async Task SayHello(IUser user)
        {
            await RespondAsync($"Hello, {user.Mention}");
        }

        [MessageCommand("Delete")]
        public async Task DeleteMessage(IMessage message)
        {
            await RespondAsync(":thumbsup:", ephemeral: true);
            await message.DeleteAsync();
        }
    }
}
