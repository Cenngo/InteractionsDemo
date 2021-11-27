using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InteractionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            using var services = ConfigureServices();

            var client = services.GetRequiredService<DiscordSocketClient>();
            var commands = services.GetRequiredService<InteractionService>();
            var config = services.GetRequiredService<IConfiguration>();
            var handler = services.GetRequiredService<CommandHandler>();

            // Registering a concrete type TypeConverter
            commands.AddTypeConverter<GuildPermissions>(new GuildPermissionsTypeConverter());

            handler.Initialize();

            await client.LoginAsync(Discord.TokenType.Bot, config["token"]);

            client.Log += (msg) =>
            {
                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;
            };

            commands.Log += (msg) =>
            {
                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;
            };

            await client.StartAsync();
            await Task.Delay(Timeout.Infinite);
        }

        static ServiceProvider ConfigureServices() =>
            new ServiceCollection()
            .AddSingleton<IConfiguration>(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<InteractionService>()
            .AddSingleton<CommandHandler>()
            .AddSingleton<PerfectlyRealisticDB>()
            .BuildServiceProvider();
    }
}