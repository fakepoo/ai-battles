using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Game
{
    public class Grid
    {
        public List<Point> ShotLocations { get; set; }
        public List<Ship> Ships { get; set; }

        public Grid()
        {
            ShotLocations = new List<Point>();
            Ships = new List<Ship>();
        }

        public Point[] Hits
        {
            get
            {
                return ShotLocations.Where(gl => BattleshipGame.GetShipAtLocation(this, gl) != null).ToArray();
            }
        }

        public Point[] Misses
        {
            get
            {
                return ShotLocations.Where(gl => BattleshipGame.GetShipAtLocation(this, gl) == null).ToArray();
            }
        }

        public Ship[] SunkenShips
        {
            get
            {
                return Ships.Where(s => BattleshipGame.IsShipSunk(this, s)).ToArray();
            }
        }

        public Ship[] UnsunkenShips
        {
            get
            {
                return Ships.Where(s => !BattleshipGame.IsShipSunk(this, s)).ToArray();
            }
        }

    }
}
