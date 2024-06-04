using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TicketerApp.Models;

namespace TicketerApp.APIConnector.Converters
{
    public class TicketConverter : BasicConverter<Ticket>
    {
        public override List<Ticket> ReadJson(JsonReader reader, Type objectType, List<Ticket> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonArray = JArray.Load(reader);
            var tickets = new List<Ticket>();
            foreach (var item in jsonArray)
            {
                var ticket = new Ticket()
                {
                    Id = (int)item["id"],
                    Price = (float)item["plan"]["price"],
                    Name = (string)item["event"]["name"],
                    StartTime = DateTimeOffset.FromUnixTimeSeconds((long)item["event"]["start_time"]).DateTime,
                    EndTime = DateTimeOffset.FromUnixTimeSeconds((long)item["event"]["end_time"]).DateTime
                };
                tickets.Add(ticket);
            }
            return tickets;
        }

        public override void WriteJson(JsonWriter writer, List<Ticket> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
