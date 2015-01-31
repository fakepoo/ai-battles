using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIBattles.WebPlayers.Models.TicTacToe
{
    public class TicTacToeGameRequest
    {
        public string MyName { get; set; }
        public string GameMethod { get; set; }
        public string[][] Grid { get; set; }
    }
}