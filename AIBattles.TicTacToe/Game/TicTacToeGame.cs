using AIBattles.Core.Game;
using AIBattles.Core.PlayerProxies;
using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using AIBattles.TicTacToe.Requests;
using AIBattles.TicTacToe.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.TicTacToe.Game
{
    public class TicTacToeGame : AIBattlesGame
    {
        protected string[][] _Grid;
        protected PlayerProxy _CurrentPlayer;

        public TicTacToeGame(IEnumerable<PlayerProxy> players) : base(players)
        {
            // Default values for a new game
            _Grid = new string[3][];
            for (int i = 0; i < 3; i++)
            {
                _Grid[i] = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    _Grid[i][j] = string.Empty;
                }
            }
            _CurrentPlayer = Players[0];
        }

        public override string Serialize()
        {
            throw new NotImplementedException();
        }

        public override void Deserialize(string serializedGame)
        {
            throw new NotImplementedException();
        }

        public override IGameStatus ProcessGameStep()
        {
            // Get the next placement for the current player
            var request = new GetPlacementRequest(_CurrentPlayer.Name, _Grid);
            var response = _CurrentPlayer.ProcessRequest<GetPlacementResponse>(request) as GetPlacementResponse;

            // Is it a valid placement?
            if(IsValidPlacement(response.Placement))
            {
                // Place it
                _Grid[response.Placement.X][response.Placement.Y] = _CurrentPlayer.Name;

                // Switch the current player to the next one
                _CurrentPlayer = _CurrentPlayer == Players[0] ? Players[1] : Players[0];
            }

            return GetGameStatus();
        }

        protected bool IsValidPlacement(Coordinate placement)
        {
            // Is it in the bounds of the grid?
            if (placement.X < 0 || placement.X >= 3 || placement.Y < 0 || placement.Y >= 3) return false;

            // Is it empty?
            if (!string.IsNullOrEmpty(_Grid[placement.X][placement.Y])) return false;

            // If we got here, it is valid.
            return true;
        }

        protected IGameStatus GetGameStatus()
        {
            // Is there a winner in the rows?
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(_Grid[0][i]) &&
                    _Grid[0][i] == _Grid[1][i] &&
                    _Grid[0][i] == _Grid[2][i]
                ) return new GameOverStatus(_Grid[0][i]);
            }

            // Is there a winner in the columns?
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(_Grid[i][0]) &&
                    _Grid[i][0] == _Grid[i][1] &&
                    _Grid[i][0] == _Grid[i][2]
                ) return new GameOverStatus(_Grid[i][0]);
            }

            // Is ther a winner in the diagonals?
            if (!string.IsNullOrEmpty(_Grid[0][0]) &&
                _Grid[0][0] == _Grid[1][1] &&
                _Grid[0][0] == _Grid[2][2]
            ) return new GameOverStatus(_Grid[0][0]);
            if (!string.IsNullOrEmpty(_Grid[2][0]) &&
                _Grid[2][0] == _Grid[1][1] &&
                _Grid[2][0] == _Grid[0][2]
            ) return new GameOverStatus(_Grid[2][0]);

            // Are there any open spaces?
            bool containsEmptySpaces = false;
            for (int i = 0; i < 3 && !containsEmptySpaces; i++)
            {
                for (int j = 0; j < 3 && !containsEmptySpaces; j++)
                {
                    if (string.IsNullOrEmpty(_Grid[i][j]))
                    {
                        containsEmptySpaces = true;
                    }
                }
            }
            if (!containsEmptySpaces)
            {
                // There are no empty spaces, the game is over with a tie
                return new GameOverStatus(string.Empty);
            }

            // No winner, spaces still exist
            return new GameInProgressStatus();
        }

        /*
         *   X|O|X
         *   -----
         *   X|X|O
         *   -----
         *   O|X|O
         */
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(_Grid[0][0].PadRight(1));
            builder.Append('|');
            builder.Append(_Grid[1][0].PadRight(1));
            builder.Append('|');
            builder.AppendLine(_Grid[2][0].PadRight(1));
            builder.AppendLine("-----");
            builder.Append(_Grid[0][1].PadRight(1));
            builder.Append('|');
            builder.Append(_Grid[1][1].PadRight(1));
            builder.Append('|');
            builder.AppendLine(_Grid[2][1].PadRight(1));
            builder.AppendLine("-----");
            builder.Append(_Grid[0][2].PadRight(1));
            builder.Append('|');
            builder.Append(_Grid[1][2].PadRight(1));
            builder.Append('|');
            builder.AppendLine(_Grid[2][2].PadRight(1));

            return builder.ToString();
        }
    }
}
