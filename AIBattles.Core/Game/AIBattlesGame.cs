using AIBattles.Core.PlayerProxies;
using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Core.Game
{
    public abstract class AIBattlesGame
    {
        public abstract string Serialize();
        public abstract void Deserialize(string serializedGame);
        public abstract IGameStatus ProcessGameStep();

        private List<PlayerProxy> _Players;
        public IList<PlayerProxy> Players
        {
            get
            {
                return _Players;
            }
        }

        public AIBattlesGame(IEnumerable<PlayerProxy> players)
        {
            _Players = new List<PlayerProxy>(players);
        }

    }
}
