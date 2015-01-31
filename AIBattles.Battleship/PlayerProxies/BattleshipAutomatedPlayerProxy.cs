using AIBattles.Battleship.Requests;
using AIBattles.Battleship.Responses;
using AIBattles.Core;
using AIBattles.Core.PlayerProxies;
using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Battleship.PlayerProxies
{
    public class BattleshipAutomatedPlayerProxy : PlayerProxy
    {
        public BattleshipAutomatedPlayerProxy(string name) : base(name)
        {

        }

        public override IGameResponse ProcessRequest<T>(IGameRequest request)
        {
            if (request is GetShipPlacementRequest)
            {
                GetShipPlacementResponse response = GetShipPlacements((GetShipPlacementRequest)request);
                return response;
            }
            else if (request is GetShotRequest)
            {
                GetShotResponse response = GetShot((GetShotRequest)request);
                return response;
            }
            else if (request is InformationUpdatedRequest)
            {
                NonResponse response = InformationUpdated((InformationUpdatedRequest)request);
                return response;
            }
            else
            {
                throw new NotImplementedException();
            }
        }


        protected virtual GetShipPlacementResponse GetShipPlacements(GetShipPlacementRequest request)
        {
            // Automated player stuff here


            return null;
        }

        protected virtual GetShotResponse GetShot(GetShotRequest getShotRequest)
        {
            // Automated player stuff here


            return null;
        }

        protected virtual NonResponse InformationUpdated(InformationUpdatedRequest request)
        {
            // Nothing necessary here
            return new NonResponse();
        }
    }
}
