using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class SignupModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("enroll", "Print an enrollment form")]
        public async Task EnrollmentForm(ITextChannel textChannel, string applicationId)
        {
            await RespondAsync(":thumbsup:", ephemeral: true);

            await textChannel.SendMessageAsync("Click to sign up: ", component: new ComponentBuilder().WithButton("Accept", $"enroll:{applicationId}", ButtonStyle.Success).Build());
        }

        // Wild card match can be extracted from custom id, great for creating pinned messsages
        [ComponentInteraction("enroll:*")]
        public async Task HandleEnrollment(string applicationId)
        {
            await RespondAsync($"You signed up for: {applicationId}");
        }
    }
}
