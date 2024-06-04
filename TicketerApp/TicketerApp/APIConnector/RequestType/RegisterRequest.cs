using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;

namespace TicketerApp.APIConnector.RequestType
{
    public class RegisterRequest : BasicAuthenticationRequest
    {
        public RegisterRequest(Uri baseAddress) : base(baseAddress)
        {
        }
        public override async Task MakeRequest(object model)
        {
            RegisterRequestModel registerModel = (RegisterRequestModel)model;

            string jsonData = JsonConvert.SerializeObject(registerModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync("/api/auth/register", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();
                SuccessfulAuthModel = JsonConvert.DeserializeObject<SuccessfulLoginRegistrationResponseModel>(result);
                SaveData();
            }
        }
    }
}
