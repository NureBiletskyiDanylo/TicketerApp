using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TicketerApp.Models;

namespace TicketerApp.APIConnector.RequestType
{
    public abstract class BasicConfirmRequest
    {
        public HttpClient _client;
        public BasicConfirmRequest(Uri baseAddress)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public abstract void ConfirmTicket(int id, string userToken);
        public abstract void CancelTicket(int id, string userToken);
    }
}
