using System;
using System.Collections.Generic;
using System.Text;
using TicketerApp.Models;

namespace TicketerApp.APIConnector
{
    public class TicketsAnalyzer
    {
        private List<Ticket> _confirmedTickets;
        private List<Ticket> _ticketsToConfirm;
        public TicketsAnalyzer()
        {
            _confirmedTickets = new List<Ticket>();
            _ticketsToConfirm = new List<Ticket>();
        }
        public void InitializeTicketSort(List<Ticket> tickets)
        {
            _confirmedTickets.Clear();
            _ticketsToConfirm.Clear();
            foreach (var ticket in tickets)
            {
                if(ticket.State == true)
                {
                    _confirmedTickets.Add(ticket);
                }
                else
                {
                    _ticketsToConfirm.Add(ticket);
                }
            }
        }

        public List<Ticket> GetConfirmedTickets()
        {
            return _confirmedTickets;
        }

        public List<Ticket> GetNotConfirmedTickets()
        {
            return _ticketsToConfirm;
        }
    }
}
