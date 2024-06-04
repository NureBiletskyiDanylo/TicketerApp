using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using Xamarin.Essentials;

namespace TicketerApp.APIConnector.RequestType
{
    public abstract class BasicAuthenticationRequest
    {
        public HttpClient client {  get; set; }
        public SuccessfulLoginRegistrationResponseModel _successfulAuthModel { get; set; }
        public BasicAuthenticationRequest(Uri baseAddress)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public abstract Task MakeRequest(object model);

        public void SaveData()
        {
            Preferences.Set("token", _successfulAuthModel.token);
            Preferences.Set("expires_at", _successfulAuthModel.expires_at);
            Preferences.Set("logged_in", true);
        }
    }
}
