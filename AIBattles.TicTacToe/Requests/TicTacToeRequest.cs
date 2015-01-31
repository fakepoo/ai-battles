using AIBattles.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.TicTacToe.Requests
{
    public abstract class TicTacToeRequest : IGameRequest
    {
        public string MyName { get; set; }
        public string GameMethod { get; set; }
        public string[][] Grid { get; set; }

        public TicTacToeRequest(string name, string method, string[][] grid)
        {
            MyName = name;
            GameMethod = method;
            Grid = grid;
        }

    }
}
