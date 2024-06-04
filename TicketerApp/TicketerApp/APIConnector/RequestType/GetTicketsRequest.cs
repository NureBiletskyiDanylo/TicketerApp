using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TicketerApp.APIConnector.Converters;
using TicketerApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TicketerApp.APIConnector.RequestType
{
    public class GetTicketsRequest : BasicGetRequest<Ticket>
    {
        public GetTicketsRequest(Uri baseAddress) : base(baseAddress)
        {
            Converter = new TicketConverter();
        }
        public override async Task<List<Ticket>> GetRequest()
        {

            string token = Preferences.Get("token", null);
            if (token == null)
            {
                await Application.Current.MainPage.DisplayAlert("Something went wrong", "Can't get tickets", "Ok");
                return new List<Ticket>();
            }

            this.Client.DefaultRequestHeaders.Add("authorization", token);
            HttpResponseMessage response = this.Client.GetAsync("/api/tickets").Result;
            List<Ticket> tickets;
            string value = await response.Content.ReadAsStringAsync();
            using (var reader = new JsonTextReader(new StringReader(value)))
            {
                var serializer = new JsonSerializer();
                tickets = Converter.ReadJson(reader, typeof(List<Ticket>), null, false, serializer);
            }
            return tickets;
        }
    }
}
