using Discord;
using Discord.Interactions;

namespace InteractionsDemo
{
    public class RequireAdmin : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            if (context.User is IGuildUser guildUser && guildUser.GuildPermissions.Administrator)
                return Task.FromResult(PreconditionResult.FromSuccess());
            else
                return Task.FromResult(PreconditionResult.FromError("You are not authorized to execute this command"));
        }
    }
}
