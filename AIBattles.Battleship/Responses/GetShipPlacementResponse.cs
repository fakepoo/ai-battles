using AIBattles.Battleship.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Responses
{
    public class GetShipPlacementResponse : BattleshipResponse
    {
        public Ship[] Ships { get; set; }
    }
}
