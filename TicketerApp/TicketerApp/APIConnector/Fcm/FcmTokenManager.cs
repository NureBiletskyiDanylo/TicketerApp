using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketerApp.APIConnector.Fcm
{
    public class FcmTokenManager
    {
        internal class FcmTokenModel
        {
            [JsonProperty("device_token")]
            internal string FcmToken { get; set; }
        }
        HttpClient client;
        readonly Uri _baseAddress = new Uri("https://ticketer.ruslan.page");
        public FcmTokenManager()
        {
            client = new HttpClient();
            client.BaseAddress = _baseAddress;
        }

        public async Task SendFcmToken(string fcmToken, string authorizationToken)
        {
            if (client.DefaultRequestHeaders.Contains("authorization"))
            {
                client.DefaultRequestHeaders.Remove("authorization");
            }
            client.DefaultRequestHeaders.Add("authorization", authorizationToken);
            FcmTokenModel model = new FcmTokenModel() { FcmToken = fcmToken };
            string jsonBody = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("/api/users/me/devices", content);
        }
    }
}
