using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class NullableModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("optional-timespan", "optinal TimeSpan")]
        public async Task NullableTypeConverterCheck(TimeSpan? timeSpan = null)
        {
            if (timeSpan == null)
                await RespondAsync("input is empty");
            else
                await RespondAsync("timespan: {}")
        }
    }
}
