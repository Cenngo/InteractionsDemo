using Discord;
using Discord.Interactions;

namespace InteractionsDemo.Modules
{
    public class AttachmentModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("echo-attachment", "Respond with an attachment.")]
        public async Task EchoAttachment(IAttachment attachment)
        {
            await RespondAsync(attachment.Url);
        }
    }
}
