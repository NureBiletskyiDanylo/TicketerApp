using System.Collections.ObjectModel;
using TicketerApp.APIConnector;
using TicketerApp.ModelRenderers;
using TicketerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmationDetailPage : ContentPage
	{
		RequestManager manager;
		Ticket ticket;
		ObservableCollection<Ticket> ticketList;
		ObservableCollection<Ticket> confirmed;
		public ConfirmationDetailPage (Ticket ticketToConfirm, RequestManager manager, ObservableCollection<Ticket> ticketsToConfirm, ObservableCollection<Ticket> confirmed)
		{
			this.confirmed = confirmed;
			ticketList = ticketsToConfirm;
			this.manager = manager;
			InitializeComponent ();
			ticket = ticketToConfirm;
			BindingContext = ticketToConfirm;
		}

        private async void cancelTicketOnClick(object sender, System.EventArgs e)
        {
			await manager.CancelTicket(ticket);
			ConfirmationCollectionViewDesign.ToConfirm.Remove(ticket);
        }

        private async void confirmTicketOnClick(object sender, System.EventArgs e)
        {
			await manager.ConfirmTicket(ticket);
			ConfirmationCollectionViewDesign.ToConfirm.Remove(ticket);
            ticket.State = true;
            TicketCollectionViewDesign.Tickets.Add(ticket);
        }
    }
}