using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using Xamarin.Forms;

namespace TicketerApp.APIConnector.RequestType
{
    public class LoginRequest : BasicAuthenticationRequest
    {
        public LoginRequest(Uri baseAddress) : base(baseAddress) { }
        public override async Task MakeRequest(object model)
        {
            LoginRequestModel loginModel = (LoginRequestModel)model;
            string jsonData = JsonConvert.SerializeObject(loginModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync("/api/auth/login", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                this._successfulAuthModel = JsonConvert.DeserializeObject<SuccessfulLoginRegistrationResponseModel>(result);
                SaveData();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                await Application.Current.MainPage.DisplayAlert("Log in operation failed", "Credentials are probably wrong. Check your password and email", "Ok");
                return;
            }
        }
    }
}
