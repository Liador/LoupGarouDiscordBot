using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class WerewolfGame
    {
        const int VOYANTE = 0;
        const int LG = 1;
        const int MAGICIEN = 2;
        const int SORCIERE = 3;
        const int CHASSEUR = 4;
        const int SV = 5;
        const int CUPIDON = 6;
        int numberOfPlayers;
        List<Player> players;

        public int NumberOfPlayers { get => numberOfPlayers; set => numberOfPlayers = value; }

        public WerewolfGame()
        {
            NumberOfPlayers = 0;
            players = new List<Player>();
        }

        public WerewolfGame(int number)
        {
            players = new List<Player>();
            for(int i = 0; i < number; i++)
            {
                addNewPlayer();
            }
        }

        public void startGame()
        {
            createComp();
            printComp();
        }

        public void addNewPlayer()
        {
            NumberOfPlayers++;
            players.Add(new Player());
        }

        public void addNewPlayer(string mention, string username)
        { 
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Mention == mention)
                {
                    throw new Exception("Vous vous êtes déjà enregistré pour cette partie");
                }
            }
            NumberOfPlayers++;
            players.Add(new Player(username, mention));
        }

        private void createComp()
        {
            int werewolfWeight = NumberOfPlayers / 6 + 1;
            int numberOfRolesAdded=0;

            players.Add(new Player("nom",Program.Roles[SORCIERE],true, false, false));
            numberOfRolesAdded++;
            players.Add(new Player("nom", Program.Roles[VOYANTE], true, false, false));
            numberOfRolesAdded++;
            players.Add(new Player("nom", Program.Roles[CHASSEUR], true, false, false));
            numberOfRolesAdded++;

            for (int i = werewolfWeight; i > 0; i-- )
            {
                players.Add(new Player("nom", Program.Roles[LG], true, false, false));
                numberOfRolesAdded++;
            }

            for (int i = NumberOfPlayers- numberOfRolesAdded; i > 0; i--)
            {
                players.Add(new Player("nom", Program.Roles[SV], true, false, false));
                numberOfRolesAdded++;
            }
        }

        public void printComp()
        {
            for (int i = players.Count-1; i >=0; i--)
            {
                Console.WriteLine(i+players[i].Role.Name);
            }
        }
    }
}
