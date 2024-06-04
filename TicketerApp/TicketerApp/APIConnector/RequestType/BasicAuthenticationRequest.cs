using System;
using System.Net.Http;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using Xamarin.Essentials;

namespace TicketerApp.APIConnector.RequestType
{
    public abstract class BasicAuthenticationRequest
    {
        public HttpClient Client {  get; set; }
        public SuccessfulLoginRegistrationResponseModel SuccessfulAuthModel { get; set; }
        public BasicAuthenticationRequest(Uri baseAddress)
        {
            Client = new HttpClient();
            Client.BaseAddress = baseAddress;
        }
        public abstract Task MakeRequest(object model);

        public void SaveData()
        {
            Preferences.Set("token", SuccessfulAuthModel.Token);
            Preferences.Set("expires_at", SuccessfulAuthModel.ExpiresAt);
            Preferences.Set("logged_in", true);
        }
    }
}
