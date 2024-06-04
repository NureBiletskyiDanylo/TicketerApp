using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TicketerApp.APIConnector.RequestModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Xamarin.Forms;
using TicketerApp.Models;
using TicketerApp.APIConnector.RequestType;
using System.IO;
using TicketerApp.APIConnector.Converters;
using System.Linq;
namespace TicketerApp.APIConnector
{
    public class RequestManager
    {
        readonly Uri baseAddress = new Uri("https://ticketer.ruslan.page");
        LoginRequest loginRequest;
        RegisterRequest registerRequest;
        GetTicketsRequest getTicketsRequest;
        public SuccessfulLoginRegistrationResponseModel _successfulResponseModel;
        public RequestManager()
        {
            getTicketsRequest = new GetTicketsRequest(baseAddress);
            loginRequest = new LoginRequest(baseAddress);
            registerRequest = new RegisterRequest(baseAddress);
        }

        public async Task LoginSimpleRequest(LoginRequestModel loginModel)
        {
            await loginRequest.MakeRequest(loginModel);
            if(loginRequest._successfulAuthModel != null)
            {
                _successfulResponseModel = loginRequest._successfulAuthModel;
            }
        }

        public async Task RegisterSimpleRequest(RegisterRequestModel registerModel)
        {
            await registerRequest.MakeRequest(registerModel);
        }

        public async Task<List<Ticket>> GetTicketsRequest()
        {
            List<Ticket> tickets = getTicketsRequest.GetRequest().Result;
            return tickets;
        }
    }
}
