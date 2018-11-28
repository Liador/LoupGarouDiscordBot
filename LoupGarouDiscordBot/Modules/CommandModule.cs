using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace LoupGarouDiscordBot.Modules
{
    public class CommandModule : ModuleBase<SocketCommandContext>
    {
        public CommandModule()
        {
        }

        [Command("help", RunMode = RunMode.Async)]
        public async Task join()
        {
            await Context.Channel.SendMessageAsync("Helping...\n but try the \"commands\" command ;) ");
        }

        [Command("commands", RunMode = RunMode.Async)]
        public async Task commandList()
        {
            await Context.Channel.SendMessageAsync("Les commandes doivent commencer par le préfixe du bot \nHelp : essaye de vous aider \ncommands : affiche la liste des commandes \nping : à tester \nInfos : affiche les commandes pour jouer au loup-garou ainsi que les infos nécessaires au jeu." );
            //await Context.Channel.SendMessageAsync(Context.Guild.Id.ToString());
            //await Context.Message.ModifyAsync(Action<Discord.MessageProperties>);

        }

        [Command("ping", RunMode = RunMode.Async)]
        public async Task ping()
        {
            await Context.Channel.SendMessageAsync("pong!");
        }

        [Command("ping2", RunMode = RunMode.Async)]
        public async Task truePing()
        {
            await Context.Channel.SendMessageAsync(Context.Message.Timestamp - DateTime.Now + " ms");
        }
    }
}
