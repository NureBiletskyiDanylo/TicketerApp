using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TicketerApp.APIConnector.RequestType
{
    public class TicketConfirmator : BasicConfirmRequest
    {
        internal class MfaModel
        {
            internal string mfa_code { get; set; } = "123";
        }
        public TicketConfirmator(Uri baseAddress) : base(baseAddress)
        {
            
        }
        public override async void CancelTicket(int id, string userToken)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("/api/tickets/").Append(id);
            string endpoint = sb.ToString();
            if (_client.DefaultRequestHeaders.Contains("authorization"))
            {
                _client.DefaultRequestHeaders.Remove("authorization");
            }
            _client.DefaultRequestHeaders.Add("authorization", userToken);
            HttpResponseMessage response = await _client.DeleteAsync(endpoint);
        }

        public override async void ConfirmTicket(int id, string userToken)
        {
            MfaModel model = new MfaModel();
            string jsonData = JsonConvert.SerializeObject(model);
            StringBuilder sb = new StringBuilder();
            sb.Append("/api/tickets/").Append(id).Append("/verify-payment");
            string endpoint = sb.ToString();
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            if (_client.DefaultRequestHeaders.Contains("authorization"))
            {
                _client.DefaultRequestHeaders.Remove("authorization");
            }
            _client.DefaultRequestHeaders.Add("authorization", userToken);
            HttpResponseMessage response = await _client.PostAsync(endpoint, content);
        }
    }
}
