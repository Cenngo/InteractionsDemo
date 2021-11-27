using Discord;
using Discord.Interactions;

namespace InteractionsDemo.Modules
{
    public class NotificationsModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("notifications", "Print a notification selector dialog")]
        public async Task NotificationsSelector(ITextChannel textChannel)
        {
            await RespondAsync(":thumbsup:", ephemeral: true);

            var targets = Enum.GetNames<NotificationTargets>();

            var selectMenuBuilder = new SelectMenuBuilder("notifications", new(), "Select some roles", targets.Count(), 1);

            foreach (var target in targets)
                selectMenuBuilder.AddOption(target, target);

            await textChannel.SendMessageAsync("Select some roles:", component: new ComponentBuilder().WithSelectMenu(selectMenuBuilder).Build());
        }

        [ComponentInteraction("notifications")]
        public async Task HandleNotificationRoles(string[] values)
        {
            await RespondAsync("You selected: " + string.Join(", ", values));
        }
    }
}
