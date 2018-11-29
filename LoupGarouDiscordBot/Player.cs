using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class Player
    {
        string name;
        Role role;
        bool alive;
        bool captain;
        bool infected;

        public Player()
        {

        }

        public Player (string n, Role r, bool a, bool c, bool i)
        {
            Name = n;
            Role = r;
            Alive = a;
            Captain = c;
            Infected = i;
        }

        public string Name { get => name; set => name = value; }
        public bool Alive { get => alive; set => alive = value; }
        public bool Captain { get => captain; set => captain = value; }
        public bool Infected { get => infected; set => infected = value; }
        internal Role Role { get => role; set => role = value; }
    }
}
