using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.Models
{
    public class Ticket : BasicModel
    {
        public int id { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }   
        public string name { get; set; }
        public float price { get; set; }
    }
}
