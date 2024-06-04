using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.Models;
using TicketerApp.APIConnector.Converters;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using Xamarin.Essentials;

namespace TicketerApp.APIConnector.RequestType
{
    public class GetTicketsRequest : BasicGetRequest<Ticket>
    {
        public GetTicketsRequest(Uri baseAddress) : base(baseAddress)
        {
            converter = new TicketConverter();
        }
        public override async Task<List<Ticket>> GetRequest()
        {

            string token = Preferences.Get("token", null);
            if (token == null)
            {
                await Application.Current.MainPage.DisplayAlert("Something went wrong", "Can't get tickets", "Ok");
                return new List<Ticket>();
            }

            this.client.DefaultRequestHeaders.Add("authorization", token);
            HttpResponseMessage response = await this.client.GetAsync("/tickets");
            int a = 5;
            List<Ticket> tickets;
            using (var reader = new JsonTextReader(new StringReader(response.Content.ToString())))
            {
                var serializer = new JsonSerializer();
                tickets = converter.ReadJson(reader, typeof(List<Ticket>), null, false, serializer);
            }
            return tickets;
        }
    }
}
