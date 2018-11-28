using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace LoupGarouDiscordBot
{
    class CommandHandler
    {
        private DiscordSocketClient _client;
        private CommandService _service;
        private readonly IServiceCollection _map = new ServiceCollection();
        private IServiceProvider _services = new ServiceCollection().BuildServiceProvider();
        private CommandService _commands = new CommandService();
        private string commandPrefix;

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;

            _service = new CommandService();
            _service.Log += Log;

            _service.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            try
            {
                if (s.Channel is IDMChannel)
                {
                    if (!s.Author.IsBot)
                    {
                        var context = new SocketCommandContext(_client, msg);

                        int argPos = 0;
                        if (msg.HasStringPrefix(commandPrefix, ref argPos))
                        {
                            var result = await _service.ExecuteAsync(context, argPos, _services);

                            if (!result.IsSuccess /*&& result.Error != CommandError.UnknownCommand*/)
                            {
                                await context.Channel.SendMessageAsync(result.ErrorReason);
                            }
                        }
                    }
                }
                else
                {
                    if (s.Channel.Id == 516972665261785099 || s.Channel.Id == 340938722830712842)
                    {
                        if (!s.Author.IsBot)
                        {
                            var context = new SocketCommandContext(_client, msg);

                            int argPos = 0;
                            if (msg.HasStringPrefix(commandPrefix, ref argPos))
                            {
                                var result = await _service.ExecuteAsync(context, argPos, _services);

                                if (!result.IsSuccess /*&& result.Error != CommandError.UnknownCommand*/)
                                {
                                    await context.Channel.SendMessageAsync(result.ErrorReason);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
        public async Task InitCommands(string prefix)

        {
            commandPrefix = prefix;
            _services = _map.BuildServiceProvider();

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandAsync;

        }
    }
}
