using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Game
{
    public static class GameConstants
    {
        public const int GridColumns = 10;
        public const int GridRows = 10;

        public static Random RandomNumberGenerator;

        static GameConstants()
        {
            RandomNumberGenerator = new Random();
        }
    }
}
