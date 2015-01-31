using AIBattles.Battleship.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Responses
{
    public class GetShotResponse : BattleshipResponse
    {
        public Point Shot { get; set; }
    }
}
