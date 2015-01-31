using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Core.Game
{
    public class GameOverStatus : IGameStatus
    {
        public string NameOfWinner { get; set; } // Leave empty for a tie

        public GameOverStatus(string nameOfWinner)
        {
            NameOfWinner = nameOfWinner;
        }
    }
}
