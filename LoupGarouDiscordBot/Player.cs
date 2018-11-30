using System;
using System.Collections.Generic;
using System.Text;
using Discord;

namespace LoupGarouDiscordBot
{
    class Player
    {
        string name;
        string mention;
        Role role;
        bool alive;
        bool captain;
        bool infected;
        Discord.IUser user;

        public Player()
        {

        }

        public Player(Discord.IUser us)
        {
            User = us;
            Name = User.Username;
            Mention = User.Mention;
            alive = true;
            captain = false;
            infected = false;
        }

        public Player(string n, string m)
        {
            Name = n;
            Mention = m;
            alive = true;
            captain = false;
            infected = false;
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
        public string Mention { get => mention; set => mention = value; }
        public IUser User { get => user; set => user = value; }
        internal Role Role { get => role; set => role = value; }
    }
}
