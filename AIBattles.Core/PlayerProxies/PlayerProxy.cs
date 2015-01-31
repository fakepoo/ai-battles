using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Core.PlayerProxies
{
    public abstract class PlayerProxy
    {
        public PlayerProxy(string name)
        {
            _Name = name;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
        }

        public abstract IGameResponse ProcessRequest<T>(IGameRequest request) where T : IGameResponse;
    }
}
