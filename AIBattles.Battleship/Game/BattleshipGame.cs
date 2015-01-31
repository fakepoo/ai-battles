using AIBattles.Battleship.PlayerProxies;
using AIBattles.Core;
using AIBattles.Core.Game;
using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Game
{
    public class BattleshipGame : AIBattlesGame
    {
        public Grid[] PlayerGrids { get; set; }

        public BattleshipGame(IEnumerable<BattleshipAutomatedPlayerProxy> players) : base(players)
        {
            PlayerGrids = players.Select(p => new Grid()).ToArray();
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(string serializedGame)
        {
            throw new NotImplementedException();
        }

        public override IGameStatus ProcessGameStep()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Point> GetGridLocations(Point startLocation, Point endLocation)
        {
            var locations = new List<Point>();

            if (startLocation.X == endLocation.X)
            {
                // Vertical
                // Make sure the startPoint is below the endPoint
                if (startLocation.Y > endLocation.Y)
                {
                    int tempCol = startLocation.X;
                    int tempRow = startLocation.Y;
                    startLocation.X = endLocation.X;
                    startLocation.Y = endLocation.Y;
                    endLocation.X = tempCol;
                    endLocation.Y = tempRow;
                }

                for (int row = startLocation.Y; row <= endLocation.Y; row++)
                {
                    locations.Add(new Point(startLocation.X, row));
                }
            }
            else if (startLocation.Y == endLocation.Y)
            {
                // Horizontal
                // Make sure the startPoint is below the endPoint
                if (startLocation.X > endLocation.X)
                {
                    int tempCol = startLocation.X;
                    int tempRow = startLocation.Y;
                    startLocation.X = endLocation.X;
                    startLocation.Y = endLocation.Y;
                    endLocation.X = tempCol;
                    endLocation.Y = tempRow;
                }

                for (int col = startLocation.X; col <= endLocation.X; col++)
                {
                    locations.Add(new Point(col, startLocation.Y));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("endLocation", "startLocation and endLocation must for either a horizontal or vertical line.");
            }

            return locations;
        }

        public static void ValidateGridLocation(Point location)
        {
            if (location.X < 0 || location.X >= GameConstants.GridColumns)
            {
                throw new ArgumentOutOfRangeException("location.X", string.Format("location.X must be in the range of 0 to {0}", GameConstants.GridColumns));
            }
            if (location.Y < 0 || location.Y >= GameConstants.GridRows)
            {
                throw new ArgumentOutOfRangeException("location.Y", string.Format("location.Y must be in the range of 0 to {0}", GameConstants.GridRows));
            }
        }

        public static Ship GetShipAtLocation(Grid grid, Point location)
        {
            foreach (var ship in grid.Ships)
            {
                var shipLocations = GetGridLocations(ship.StartLocation, ship.EndLocation);
                if (shipLocations.Contains(location))
                {
                    return ship;
                }
            }

            return null;
        }

        public static bool IsShipSunk(Grid grid, Ship ship)
        {
            var shipLocations = GetGridLocations(ship.StartLocation, ship.EndLocation);
            return grid.ShotLocations.Intersect(shipLocations).Count() == shipLocations.Count();
        }

        public static bool HasIntersection(Ship a, Ship b)
        {
            var aLocations = GetGridLocations(a.StartLocation, a.EndLocation);
            var bLocations = GetGridLocations(b.StartLocation, b.EndLocation);
            return aLocations.Intersect(bLocations).Any();
        }

        // The board will get drawn like this:
        //
        // Player 1 Name
        // Legend: sunken(X), hit (+), miss (-), ship(O)
        //     0 1 2 3 4 5 6 7 8 9
        //   ---------------------
        // 0 |             - 
        // 1 | + + O O O
        // 2 |
        // 3 |   O
        // 4 |   O   O O O
        // 5 |   + - -
        // 6 |   O   -
        // 7 |
        // 8 |                   X
        // 9 | -   -             X 
        //   ---------------------
        //
        // Player 2 Name
        // Legend: sunken(X), hit (+), miss (-), ship(O)
        //     0 1 2 3 4 5 6 7 8 9
        //   ---------------------
        // 0 |             - 
        // 1 | + + O O O
        // 2 |
        // 3 |   O
        // 4 |   O   O O O
        // 5 |   + - -
        // 6 |   O   -
        // 7 |
        // 8 |                   X
        // 9 | -   -             X 
        //   ---------------------
        public string DrawFromGameInformation()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < this.PlayerGrids.Length; i++)
            {
                var grid = this.PlayerGrids[i];
                var player = this.Players[i];

                // Player name
                builder.AppendLine(player.Name);
                builder.AppendLine("Legend: hit(X), unhit(O), miss (+)");
                builder.AppendLine("    0 1 2 3 4 5 6 7 8 9");
                builder.AppendLine("  ---------------------");
                for (int row = 0; row < GameConstants.GridRows; row++)
                {
                    builder.Append(row);
                    builder.Append(" |");

                    for (int col = 0; col < GameConstants.GridColumns; col++)
                    {
                        builder.Append(' ');

                        // Is there a ship at this location?
                        Point location = new Point(col, row);

                        // Is this location a hit?
                        if (grid.Hits.Contains(location))
                        {
                            // Is there a sunken ship here?
                            if (grid.SunkenShips.Any(ss => ss.GridLocations.Contains(location)))
                            {
                                // Sunken ship
                                builder.Append('X');
                            }
                            else
                            {
                                // Hit
                                builder.Append('+');
                            }
                        }
                        // Is this location a miss?
                        else if (grid.Misses.Contains(location))
                        {
                            // Miss
                            builder.Append('-');
                        }
                        // Is this a private ship location?
                        else if (grid.UnsunkenShips.Any(ss => ss.GridLocations.Contains(location)))
                        {
                            builder.Append('O');
                        }
                        // It is nothing
                        else
                        {
                            // Nothing
                            builder.Append(' ');
                        }
                    }//end for(col)
                    builder.AppendLine();
                }// end for(row)
                builder.AppendLine("  ---------------------");
            }

            return builder.ToString();
        }
    }
}
