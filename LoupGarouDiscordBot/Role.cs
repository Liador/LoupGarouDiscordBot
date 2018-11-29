using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class Role
    {
        string name;
        string description;
        string help;
        string team;
        int weight;

        public Role()
        {

        }

        public Role(string n, string d, string h, string t, int w)
        {
            Name = n;
            Description = d;
            Help = h;
            Team = t;
            Weight = w;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Help { get => help; set => help = value; }
        public string Team { get => team; set => team = value; }
        public int Weight { get => weight; set => weight = value; }
    }
}
