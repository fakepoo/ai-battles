using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Core.Requests
{
    public interface IGameRequest
    {
        string MyName { get; }

        // For example, "PlaceShips"
        string GameMethod { get; }
    }
}
