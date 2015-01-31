using AIBattles.WebPlayers.Models.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIBattles.WebPlayers.Controllers
{
    public class TicTacToePlayerController : Controller
    {
        [HttpPost]
        public ActionResult Index(TicTacToeGameRequest gameRequest)
        {
            switch(gameRequest.GameMethod)
            {
                case "Get Placement":
                    var getPlacementRequest = new GetPlacementRequest();
                    UpdateModel(getPlacementRequest);
                    var response = GetPlacement(getPlacementRequest);
                    return Json(response);
                default:
                    throw new Exception("Unhandled game method: " + gameRequest.GameMethod);
            }

        }

        protected virtual GetPlacementResponse GetPlacement(GetPlacementRequest request)
        {
            GetPlacementResponse response = new GetPlacementResponse();

            // Get a list of all empty locations
            List<Coordinate> emptyLocations = new List<Coordinate>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (string.IsNullOrEmpty(request.Grid[i][j]))
                    {
                        emptyLocations.Add(new Coordinate(i,j));
                    }
                }
            }

            // Can we win?
            Coordinate winningLocation = null;
            foreach (Coordinate emptyLocation in emptyLocations)
            {
                if (IsWinningLocation(emptyLocation, request.Grid, request.MyName))
                {
                    winningLocation = emptyLocation;
                    break;
                }
            }
            if (winningLocation != null)
            {
                response.Placement = winningLocation;
                return response;
            }

            // Can we keep the opponent from winning?
            string opponentName = string.Empty;
            for (int i = 0; i < 3 && opponentName.Length == 0; i++)
            {
                for (int j = 0; j < 3 && opponentName.Length == 0; j++)
                {
                    string name = request.Grid[i][j];
                    if (string.IsNullOrEmpty(name)) continue;
                    if (name == request.MyName) continue;

                    opponentName = name;
                }
            }

            if (!string.IsNullOrEmpty(opponentName))
            {
                winningLocation = null;
                foreach (Coordinate emptyLocation in emptyLocations)
                {
                    if (IsWinningLocation(emptyLocation, request.Grid, opponentName))
                    {
                        winningLocation = emptyLocation;
                        break;
                    }
                }
                if (winningLocation != null)
                {
                    response.Placement = winningLocation;
                    return response;
                }
            }

            // Choose randomly
            Random random = new Random();
            Coordinate placement = emptyLocations[random.Next(emptyLocations.Count)];
            response.Placement = placement;
            return response;
        }

        protected bool IsWinningLocation(Coordinate p, string[][] grid, string name)
        {
            // Check the row
            for (int i = 0; i < 3; i++)
            {
                string[] othersInRow = GetOthersInRow(p, grid);
                if (othersInRow.Count(s => s == name) == othersInRow.Length) return true;
            }

            // Check the column
            for (int i = 0; i < 3; i++)
            {
                string[] othersInCol = GetOthersInCol(p, grid);
                if (othersInCol.Count(s => s == name) == othersInCol.Length) return true;
            }

            // Check the diagonal
            if (p.X == 0 && p.Y == 0)
            {
                if (grid[1][1] == name && grid[2][2] == name) return true;
            }
            else if (p.X == 1 && p.Y == 1)
            {
                if (grid[0][0] == name && grid[2][2] == name) return true;
                if (grid[0][2] == name && grid[2][0] == name) return true;
            }
            else if (p.X == 2 && p.Y == 2)
            {
                if (grid[0][0] == name && grid[1][1] == name) return true;
            }
            else if (p.X == 0 && p.Y == 2)
            {
                if (grid[1][1] == name && grid[2][0] == name) return true;
            }
            else if (p.X == 2 && p.Y == 0)
            {
                if (grid[1][1] == name && grid[0][2] == name) return true;
            }

            return false;
        }

        protected string[] GetOthersInRow(Coordinate p, string[][] grid)
        {
            List<string> others = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (i == p.X) continue;

                others.Add(grid[i][p.Y]);
            }

            return others.ToArray();
        }

        protected string[] GetOthersInCol(Coordinate p, string[][] grid)
        {
            List<string> others = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                if (i == p.Y) continue;

                others.Add(grid[p.X][i]);
            }

            return others.ToArray();
        }

	}
}