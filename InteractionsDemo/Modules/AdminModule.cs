using Discord;
using Discord.Interactions;

namespace InteractionsDemo
{
    [RequireAdmin]
    public class GuildAdminModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("add-role", "Add a role to this guild")]
        public async Task AddRole(string name)
        {
            await Context.Guild.CreateRoleAsync(name, GuildPermissions.None, Color.Red, false, null);
        }
    }
}
