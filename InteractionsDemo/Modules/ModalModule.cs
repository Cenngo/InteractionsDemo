using Discord;
using Discord.Interactions;

namespace InteractionsDemo.Modules
{
    public class ModalModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("signup", "Create a new account.")]
        public async Task Command()
        {
            //Respond using the RespondWithModalAsync extension method of Interaction Service
            //await Context.Interaction.RespondWithModalAsync<SubmissionForm>("signup:" + Context.User.Id.ToString());

            //or respond with a dynamically created modal
            var modal = new ModalBuilder("Sign Up", "signup:" + Context.User.Id.ToString())
                .AddTextInput("Name", "name", maxLength: 40)
                .AddTextInput("Surname", "surname", maxLength: 40)
                .Build();

            await Context.Interaction.RespondWithModalAsync(modal);
        }

        [ModalInteraction("signup:*")]
        public async Task SignUp(string userId, SubmissionForm form)
        {
            await RespondAsync($"{MentionUtils.MentionUser(ulong.Parse(userId))} just signed up: {form.Name} {form.Surname} {form.AdditionalInfo}", ephemeral: true);
        }

        public class SubmissionForm : IModal
        {
            public string Title => "Sign Up";

            [ModalTextInput("name", maxLength: 40)]
            public string Name { get; set; }

            [ModalTextInput("surname", maxLength: 40)]
            public string Surname { get; set; }

            [ModalTextInput("additional_info", TextInputStyle.Paragraph, maxLength: 1000)]
            [RequiredInput(false)]
            [InputLabel("Additional Information")]
            public string AdditionalInfo { get; set; } = "N/A";
        }
    }
}
