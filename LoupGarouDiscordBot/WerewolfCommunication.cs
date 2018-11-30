using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using System.Threading.Tasks;
using Discord.Commands;

namespace LoupGarouDiscordBot
{
    class WerewolfCommunication
    {
        ulong defaultChannelId;
        Discord.WebSocket.ISocketMessageChannel defaultChan;
        public WerewolfCommunication(object chan)
        {
            defaultChan = chan as Discord.WebSocket.ISocketMessageChannel;
        }

        public async Task sendMessage(string message)
        {
            await defaultChan.SendMessageAsync(message);
        }
    }
}
