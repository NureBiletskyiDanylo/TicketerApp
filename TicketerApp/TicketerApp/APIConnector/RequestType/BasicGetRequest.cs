using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TicketerApp.APIConnector.Converters;

namespace TicketerApp.APIConnector.RequestType
{
    public abstract class BasicGetRequest<T>
    {
        public BasicConverter<T> Converter;
        public HttpClient Client;
        
        public BasicGetRequest(Uri baseAddress)
        {
            Client = new HttpClient();
            Client.BaseAddress = baseAddress;
        }

        public abstract Task<List<T>> GetRequest();
    }
}
