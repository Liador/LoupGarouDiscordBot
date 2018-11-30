using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class Role
    {
        int id;
        string name;
        string description;
        string help;
        string team;
        int weight;
        int numberMax;
        int numberAdded;

        public Role()
        {

        }

        public Role(int id ,string n, string d, string h, string t, int w , int max, int added)
        {
            this.id = id;
            Name = n;
            Description = d;
            Help = h;
            Team = t;
            Weight = w;
            numberMax = max;
            NumberAdded = added;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Help { get => help; set => help = value; }
        public string Team { get => team; set => team = value; }
        public int Weight { get => weight; set => weight = value; }
        public int NumberMax { get => numberMax; }
        public int NumberAdded { get => numberAdded; set => numberAdded = value; }
        public int Id { get => id; }
    }
}
