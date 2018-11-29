using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LoupGarouDiscordBot
{
    class Program
    {
        public DiscordSocketClient _client;
        public string commandPrefix = "$";
        private static List<Role> roles;
        private CommandHandler handler;
        private static WerewolfGame game;

        internal static List<Role> Roles { get => roles; set => roles = value; }
        internal static WerewolfGame Game { get => game; set => game = value; }

        public static void Main(string[] args)
           => new Program().MainAsync().GetAwaiter().GetResult();


        private Task CreateRoles()
        {
            Roles = new List<Role>();
            Roles.Add(new Role("voyante", "villageois qui peut regarder secrètement la carte d'un autre joueur toutes les nuits.", "à votre tour, indiquez un joueur au MJ pour qu'il vous révèle son identité.", "v", 1));
            Roles.Add(new Role("loup-garou", "joueur dont le but est de tuer tous les villageois sans se faire démasquer", "à votre tour, indiquez un joueur au MJ le dévorer durant la nuit si les autres loup garous sont d'accord.", "l", 1));
            Roles.Add(new Role("magicien", "villageois qui peut montrer secrètement la carte d'un autre joueur à un autre joueur toutes les nuits.", "à votre tour, indiquez deux joueurs au MJ pour qu'il révèle l'identité du premier au second.", "v", 1));
            Roles.Add(new Role("sorcière", "villageois qui peut utiliser une potion de vie ou de mort durant la partie", "à votre tour, indiquez un joueur au MJ si vous voulez utiliser 0 , 1 ou 2 potions. (utilisez la commande vie ou mort + numéro du joueur)", "v", 1));
            Roles.Add(new Role("chasseur", "villageois qui peut, lors de sa mort, tuer la personne de son choix.", "à votre mort, indiquez un joueur au MJ pour que ce dernier vous accompagne dans la mort.", "v", 1));
            Roles.Add(new Role("simple villageois", "villageois qui ne fait rien durant la nuit et vote durant la journée.", "soyez attentif durant les débats pour essayer de deviner qui pourrait être un loup-garou.", "v", 1));
            Roles.Add(new Role("cupidon", "villageois qui, lors de la première nuit, désigne deux amoureux dont le sort sera lié pour le reste de la partie.", "regardez bien le comportement du couple, n'hésitez pas à porter le blâme sur l'un des deux s'ils vous semblent suspect.", "v", 1));
            return Task.CompletedTask;
        }
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task MainAsync()
        {
            
            _client = new DiscordSocketClient();
            handler = new CommandHandler(_client);
            _client.Log += Log;

            await handler.InitCommands(commandPrefix);
            string token = ""; // Remember to keep this private!
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("D:\\TokenLG.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    //Console.WriteLine(line);
                    token = line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            await _client.LoginAsync(TokenType.Bot, token);
            await CreateRoles();
            await _client.StartAsync();



            //_client.MessageReceived += MessageReceived;

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
    }
}