using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
}
