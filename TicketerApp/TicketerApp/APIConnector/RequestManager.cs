using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.APIConnector.RequestType;
using TicketerApp.Models;
namespace TicketerApp.APIConnector
{
    public class RequestManager
    {
        readonly Uri _baseAddress = new Uri("https://ticketer.ruslan.page");
        LoginRequest _loginRequest;
        RegisterRequest _registerRequest;
        GetTicketsRequest _getTicketsRequest;
        public SuccessfulLoginRegistrationResponseModel SuccessfulAuthResponseModel;
        public RequestManager()
        {
            _getTicketsRequest = new GetTicketsRequest(_baseAddress);
            _loginRequest = new LoginRequest(_baseAddress);
            _registerRequest = new RegisterRequest(_baseAddress);
        }

        public async Task LoginSimpleRequest(LoginRequestModel loginModel)
        {
            await _loginRequest.MakeRequest(loginModel);
            if(_loginRequest.SuccessfulAuthModel != null)
            {
                SuccessfulAuthResponseModel = _loginRequest.SuccessfulAuthModel;
            }
        }

        public async Task RegisterSimpleRequest(RegisterRequestModel registerModel)
        {
            await _registerRequest.MakeRequest(registerModel);
        }

        public async Task<List<Ticket>> GetTicketsRequest()
        {
            List<Ticket> tickets = _getTicketsRequest.GetRequest().Result;
            return tickets;
        }
    }
}
