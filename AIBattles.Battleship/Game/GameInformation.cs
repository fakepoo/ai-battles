using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Game
{
    public class GameInformation
    {
        public int GameId { get; set; }
        public PlayerGrid[] PlayerGrids { get; set; }

        // Action history?
    }

    public class PlayerGrid
    {
        public string PlayerName { get; set; }
        public Point[] Hits { get; set; }
        public Point[] Misses { get; set; }
        public Ship[] SunkenShips { get; set; }

        // This is private information
        public Ship[] UnsunkenShips { get; set; }
    }
}
