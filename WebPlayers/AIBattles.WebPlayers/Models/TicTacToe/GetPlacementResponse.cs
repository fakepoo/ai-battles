using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AIBattles.WebPlayers.Models.TicTacToe
{
    public class GetPlacementResponse : TicTacToeGameResponse
    {
        public Coordinate Placement { get; set; }
    }
}