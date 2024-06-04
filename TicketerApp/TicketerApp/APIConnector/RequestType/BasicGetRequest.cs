using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.APIConnector.Converters;

namespace TicketerApp.APIConnector.RequestType
{
    public abstract class BasicGetRequest<T>
    {
        public BasicConverter<T> converter;
        public HttpClient client;
        
        public BasicGetRequest(Uri baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public abstract Task<List<T>> GetRequest();
    }
}
