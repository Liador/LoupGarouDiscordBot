using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class WerewolfGame
    {
        int numberOfPlayers;
        List<Role> players;
        public WerewolfGame()
        {
            numberOfPlayers = 0;
        }

        public WerewolfGame(int number)
        {
            numberOfPlayers = number;
        }

        public void startGame()
        {

        }

        public void addNewPlayer()
        {
            numberOfPlayers++;
        }

        private void createComp()
        {
            int werewolfWeight = numberOfPlayers / 6 + 1;
            int numberOfRolesAdded=0;

            //players.Add();
        }
    }
}
