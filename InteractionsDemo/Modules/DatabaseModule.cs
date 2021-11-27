using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class DatabaseModule : InteractionModuleBase<SocketInteractionContext>
    {
        public PerfectlyRealisticDB Db { get; set; }

        [SlashCommand("get-db-item", "Get an item from the database")]
        public async Task GetDbItem([Autocomplete(typeof(DbAutocompleteHandler))] string guid)
        {
            if (Guid.TryParse(guid, out var id))
            {
                await DeferAsync();

                var item = Db.Items.FirstOrDefault(x => x.Id == id);

                await RespondAsync($"{item.Id} : {item.Name}");
            }
            else
                await RespondAsync($"{guid} is not a valid GUID");
        }
    }
}
