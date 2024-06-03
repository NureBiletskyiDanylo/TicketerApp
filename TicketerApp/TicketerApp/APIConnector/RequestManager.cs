using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TicketerApp.APIConnector.RequestModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;
namespace TicketerApp.APIConnector
{
    public class RequestManager
    {
        HttpClient _httpclient;
        public SuccessfulLoginRegistrationResponseModel _successfulResponseModel;
        public RequestManager()
        {
            _httpclient = new HttpClient();
            _httpclient.BaseAddress = new Uri("https://ticketer.ruslan.page/");
        }

        public async Task LoginSimpleRequest(LoginRequestModel loginModel)
        {
            string jsonData = JsonConvert.SerializeObject(loginModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpclient.PostAsync("/api/auth/login", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                _successfulResponseModel = JsonConvert.DeserializeObject<SuccessfulLoginRegistrationResponseModel>(result);
                SaveData();
            }
        }

        public async Task RegisterSimpleRequest(RegisterRequestModel registerModel)
        {
            string jsonData = JsonConvert.SerializeObject(registerModel);

            var content = new StringContent(jsonData, Encoding.UTF8 , "application/json");
            HttpResponseMessage response = await _httpclient.PostAsync("/api/auth/register", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                _successfulResponseModel = JsonConvert.DeserializeObject<SuccessfulLoginRegistrationResponseModel>(result);
                SaveData();
            }
        }

        private void SaveData()
        {
            Preferences.Set("token", _successfulResponseModel.token);
            Preferences.Set("expires_at", _successfulResponseModel.expires_at);
            Preferences.Set("logged_in", true);
        }
    }
}
