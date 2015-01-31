using AIBattles.Core.Requests;
using AIBattles.Core.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AIBattles.Core.PlayerProxies
{
    public class NetworkPlayerProxy : PlayerProxy
    {
        protected Uri _Uri;

        public NetworkPlayerProxy(string name, Uri uri) : base(name)
        {
            _Uri = uri;
        }

        public override IGameResponse ProcessRequest<T>(IGameRequest request)
        {
            return _Post<T>(request);
        }

        protected T _Post<T>(IGameRequest request)
            where T : IGameResponse
        {
            // Convert object to JSON, then JSON to bytes
            var requestJson = JsonConvert.SerializeObject(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            // Send over the web
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var responseBytes = client.UploadData(_Uri, requestBytes);

            // Convert bytes to JSON, then JSON to object
            var responseJson = Encoding.UTF8.GetString(responseBytes);
            var response = JsonConvert.DeserializeObject<T>(responseJson);
            return response;
        }
    }
}
