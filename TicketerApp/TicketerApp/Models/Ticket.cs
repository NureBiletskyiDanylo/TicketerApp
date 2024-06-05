using System;

namespace TicketerApp.Models
{
    public class Ticket : BasicModel
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }   
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ConfirmationAbilityExpiringDate { get; set; }
        public bool State {  get; set; } // true - confirmed | false - not confirmed
    }
}
