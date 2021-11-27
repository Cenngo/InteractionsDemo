using Discord;
using Discord.Interactions;

namespace InteractionsDemo
{
    public class GuildPermissionsTypeConverter : TypeConverter<GuildPermissions>
    {
        public override ApplicationCommandOptionType GetDiscordType() => ApplicationCommandOptionType.Mentionable;

        public override Task<TypeConverterResult> ReadAsync(IInteractionContext context, IApplicationCommandInteractionDataOption option, IServiceProvider services)
        {
            switch (option.Value)
            {
                case IGuildUser guildUser:
                    return Task.FromResult(TypeConverterResult.FromSuccess(guildUser.GuildPermissions));
                case IRole role:
                    return Task.FromResult(TypeConverterResult.FromSuccess(role.Permissions));
                default:
                    return Task.FromResult(TypeConverterResult.FromError(InteractionCommandError.ConvertFailed, option.Value.ToString() + " is not a Guild Role or Guild User"));
            }
        }

        public override void Write(ApplicationCommandOptionProperties properties, IParameterInfo parameter)
        {
            properties.Description = "This description is added dynamically.";
        }
    }
}
