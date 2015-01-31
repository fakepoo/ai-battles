using AIBattles.Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.Requests
{
    public class InformationUpdatedRequest : BattleshipRequest
    {
        public InformationUpdatedRequest(string name)
            : base(name, "Information Updated")
        {

        }
    }
}
