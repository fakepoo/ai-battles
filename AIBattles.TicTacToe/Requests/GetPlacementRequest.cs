using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.TicTacToe.Requests
{
    public class GetPlacementRequest : TicTacToeRequest
    {
        public GetPlacementRequest(string name, string[][] grid) : base(name, "Get Placement", grid)
        {
        }
    }
}
