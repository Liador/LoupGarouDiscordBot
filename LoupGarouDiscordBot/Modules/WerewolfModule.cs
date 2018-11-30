using System;
using Discord.Commands;
using System.Threading.Tasks;

namespace LoupGarouDiscordBot.Modules
{
    public class WerewolfModule : ModuleBase<SocketCommandContext>
    {
        public WerewolfModule()
        {
        }

        [Command("Infos", RunMode = RunMode.Async)]
        public async Task LGInfos()
        {
            await Context.Channel.SendMessageAsync(
                "NewGame : crée une nouvelle partie à laquelle les joueurs peuvent s'inscrire. " + System.Environment.NewLine +
                "Reg : permet de s'enregistrer auprès du bot pour jouer à la partie en cours de création." + System.Environment.NewLine +
                "Start : commence une partie avec le joueurs inscrits. " + System.Environment.NewLine +
                "Stop : interrompt la partie en cours." + System.Environment.NewLine +
                "" + System.Environment.NewLine +
                "" + System.Environment.NewLine +
                "" + System.Environment.NewLine +
                "" + System.Environment.NewLine +
                "" + System.Environment.NewLine +
                "" + System.Environment.NewLine
                );
        }

        [Command("Reg", RunMode = RunMode.Async)]
        public async Task register()
        {
            //Program.Game.addNewPlayer(Context.Message.Author.Mention, Context.Message.Author.Username);
            try
            {
                Program.Game.addNewPlayer(Context.Message.Author);
                await Context.Channel.SendMessageAsync("Vous vous êtes bien enregistré");
            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync(e.Message);
            }
        }

        [Command("New", RunMode = RunMode.Async)]
        public async Task newGame()
        {
            Program.Game = new WerewolfGame(Context.Channel);
            await Context.Channel.SendMessageAsync("Une nouvelle partie a été créée. Vous devez vous enregistrer pour y participer. Une fois tous les joueurs enregistrés, lancez la partie avec LGStart");
        }

        [Command("Start", RunMode = RunMode.Async)]
        public async Task startGame()
        {
            await Program.Game.startGame();
            await Context.Channel.SendMessageAsync("La partie commence avec " + Program.Game.NumberOfPlayers + " joueurs.");
            try
            {
                
            }
            catch(Exception e)
            {
                await Context.Channel.SendMessageAsync(e.Message);
            }
            
        }

        [Command("Stop", RunMode = RunMode.Async)]
        public async Task cancelGame()
        {
            await Context.Channel.SendMessageAsync("La partie a bien été arretée.");
        }

        /**
         * [Command("LGStart", RunMode = RunMode.Async)]
        public async Task start([Remainder] string numberOfPlayers)
        {
            int number;
            try
            {
                number = Convert.ToInt32(numberOfPlayers);
                await Context.Channel.SendMessageAsync("Une partie pour " + numberOfPlayers + " joueurs va être commencée");

            }
            catch(Exception e)
            {
                Console.WriteLine(DateTime.Now +"   ERROR: "+e.Message + "\nfrom: "+ Context.User.Username +"\nmessage: "+ Context.Message );
                await Context.Channel.SendMessageAsync("Les paramètres entrés sont incorrects. Tapez LGInfos pour plus de détails.");
            } 
        }
    */
    }
}
 