using AIBattles.TicTacToe.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.TicTacToe.Responses
{
    public class GetPlacementResponse : TicTacToeResponse
    {
        public Coordinate Placement { get; set; }
    }
}
