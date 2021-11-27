using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class CustomTypeConvertersModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("get-permissions", "Get permissions of a user or a role")]
        public async Task GuildPermissions(GuildPermissions permissions)
        {
            var permissionsStr = string.Join("\n", permissions.ToList().Select(x => Regex.Replace(x.ToString(), "(?<=[a-z])(?=[A-Z])", " ")));
            await RespondAsync(permissionsStr);
        }

        [SlashCommand("fav-animal", "Select your favourite animal")]
        public async Task FavAnimal(Animals animal = Animals.Default)
        {
            if (animal == Animals.Default)
                await RespondAsync("You don't have a favourite animal");
            else
                await RespondAsync($"You favourite animal is {animal}");
        }
    }
}
