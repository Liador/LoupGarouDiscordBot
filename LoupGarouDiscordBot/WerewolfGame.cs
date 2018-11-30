using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LoupGarouDiscordBot
{
    class WerewolfGame
    {
        WerewolfCommunication com;
        const int VOYANTE = 0;
        const int LG = 1;
        const int MAGICIEN = 2;
        const int SORCIERE = 3;
        const int CHASSEUR = 4;
        const int SV = 5;
        const int CUPIDON = 6;
        int[] firstNightOrder = new int[] { 6 };
        int[] nightOrder = new int[] { 0, 2, 1, 3 };
        int numberOfPlayers;
        List<Player> players;

        public int NumberOfPlayers { get => numberOfPlayers; set => numberOfPlayers = value; }

        public WerewolfGame()
        {
            NumberOfPlayers = 0;
            players = new List<Player>();
        }

        public WerewolfGame(object chanID)
        {
            NumberOfPlayers = 0;
            players = new List<Player>();
            com = new WerewolfCommunication(chanID);
        }

        public WerewolfGame(int number)
        {
            players = new List<Player>();
            for(int i = 0; i < number; i++)
            {
                addNewPlayer("@you", "youuu");
            }
        }

        public async Task startGame()
        {
            if (numberOfPlayers<6)
            {
                throw new Exception("Pas assez de joueurs, vous n'êtes que " + numberOfPlayers+" joueur"+((numberOfPlayers>1)?"s":"")+" et il faut au minimum être 6.");
            }
            shufflePlayers();
            createComp();
            sendComp();
            printComp();
            await playFirstNight();
        }

        private void sendComp()
        {
            throw new NotImplementedException();
        }

        private async Task playFirstNight()
        {
            await com.sendMessage(Texts.VillageFallsAsleep);
        }

        public void addNewPlayer(Discord.IUser us)
        {
            NumberOfPlayers++;
            players.Add(new Player(us));
        }

        public void addNewPlayer(string mention, string username)
        { 
            /***for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Mention == mention)
                {
                    throw new Exception("Vous vous êtes déjà enregistré pour cette partie");
                }
            }*/
            NumberOfPlayers++;
            players.Add(new Player(username, mention));
        }

        private void createComp()
        {
            int werewolfWeight = NumberOfPlayers / 6 + 1;
            int numberOfRolesAdded=0;

            players[numberOfRolesAdded].Role = Program.Roles[SORCIERE];
            numberOfRolesAdded++;
            players[numberOfRolesAdded].Role = Program.Roles[VOYANTE];
            numberOfRolesAdded++;
            players[numberOfRolesAdded].Role = Program.Roles[CHASSEUR];
            numberOfRolesAdded++;

            for (int i = 0; i < werewolfWeight; i++ )
            {
                players[numberOfRolesAdded].Role = Program.Roles[LG];
                numberOfRolesAdded++;
            }
            
            for (int i = NumberOfPlayers- numberOfRolesAdded; i > 0; i--)
            {
                players[numberOfRolesAdded].Role = Program.Roles[SV];
                numberOfRolesAdded++;
            }
        }

        private void shufflePlayers()
        {
            Player temp = new Player();
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = players.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                temp = players[k];
                players[k] = players[n];
                players[n] = temp;
            }
        }

        public void printComp()
        {
            for (int i = players.Count-1; i >=0; i--)
            {
                Console.WriteLine(i + ":" + players[i].Name + "->" + players[i].Role.Name);
            }
        }
    }
}
