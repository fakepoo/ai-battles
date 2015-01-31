using AIBattles.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Requests
{
    public abstract class BattleshipRequest : IGameRequest
    {
        public string MyName { get; set; }

        public string GameMethod { get; set; }

        public BattleshipRequest(string name, string method)
        {
            MyName = name;
            GameMethod = method;
        }
    }
}
