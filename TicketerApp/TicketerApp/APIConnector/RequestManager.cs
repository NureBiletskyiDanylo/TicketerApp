using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.APIConnector.RequestType;
using TicketerApp.Models;
using Xamarin.Essentials;
namespace TicketerApp.APIConnector
{
    public class RequestManager
    {
        readonly Uri _baseAddress = new Uri("https://ticketer.ruslan.page");
        TicketsAnalyzer _analyzer;
        LoginRequest _loginRequest;
        RegisterRequest _registerRequest;
        GetTicketsRequest _getTicketsRequest;
        TicketConfirmator _ticketConfirmator;
        public SuccessfulLoginRegistrationResponseModel SuccessfulAuthResponseModel;
        public RequestManager()
        {
            
            _analyzer = new TicketsAnalyzer();
            _ticketConfirmator = new TicketConfirmator(_baseAddress);
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
            SuccessfulAuthResponseModel = _registerRequest.SuccessfulAuthModel;
        }

        public async Task<List<Ticket>> GetTicketsRequest(bool confirmed)
        {
            List<Ticket> tickets = _getTicketsRequest.GetRequest().Result;
            _analyzer.InitializeTicketSort(tickets);
            if(confirmed)
            {
                return _analyzer.GetConfirmedTickets();
            }
            return _analyzer.GetNotConfirmedTickets();
        }

        public async Task ConfirmTicket(Ticket ticket)
        {
            _ticketConfirmator.ConfirmTicket(ticket.Id, Preferences.Get("token", null));
        }

        public async Task CancelTicket(Ticket ticket)
        {
            _ticketConfirmator.CancelTicket(ticket.Id, Preferences.Get("token", null));
        }
    }
}
