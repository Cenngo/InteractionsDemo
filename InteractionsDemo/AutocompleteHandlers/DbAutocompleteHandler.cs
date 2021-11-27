using Discord;
using Discord.Interactions;

namespace InteractionsDemo
{
    public class DbAutocompleteHandler : AutocompleteHandler
    {
        public PerfectlyRealisticDB Db { get; set; }

        public override Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
        {
            try
            {
                var value = autocompleteInteraction.Data.Current.Value as string;

                if (string.IsNullOrEmpty(value))
                    return Task.FromResult(AutocompletionResult.FromSuccess());

                var matches = Db.Items.Where(x => x.Name.StartsWith(value));
                return Task.FromResult(AutocompletionResult.FromSuccess(matches.Select(x => new AutocompleteResult(x.Name, x.Id.ToString()))));
            }
            catch (Exception ex)
            {
                return Task.FromResult(AutocompletionResult.FromError(ex));
            }
        }

        protected override string GetLogString(IInteractionContext context) => $"Accessing DB from {context.Guild}-{context.Channel}";
    }
}
