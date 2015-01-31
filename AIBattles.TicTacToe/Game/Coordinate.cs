using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.TicTacToe.Game
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate() { }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Coordinate p = obj as Coordinate;

                if (p != null)
                {
                    if (p.X == this.X && p.Y == this.Y) return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Coordinate a, Coordinate b)
        {
            return !(a == b);
        }
    }
}
