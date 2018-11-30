using System;
using System.Collections.Generic;
using System.Text;

namespace LoupGarouDiscordBot
{
    class Texts
    {
        private static string villageFallsAsleep = "La nuit tombe sur le village, tout le monde s'endort";
        private static string lGWin = "Les loups-garous ont gagné la partie";
        private static string villageWin = "Les villageois ont gagné la partie";

        public static string VillageFallsAsleep { get => villageFallsAsleep; set => villageFallsAsleep = value; }
        public static string LGWin { get => lGWin; set => lGWin = value; }
        public static string VillageWin { get => villageWin;  set => villageWin = value; }
    }
}
