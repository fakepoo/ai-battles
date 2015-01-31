using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Game
{
    public class Ship
    {
        public ShipType ShipType { get; set; }
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }

        public IEnumerable<Point> GridLocations
        {
            get
            {
                return BattleshipGame.GetGridLocations(StartLocation, EndLocation);
            }
        }
    }
}
