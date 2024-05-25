using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.ModelRenderers;
using TicketerApp.Models;
using Xamarin.Forms;

namespace TicketerApp
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            ObservableCollection<Confirmation> requestsToConfirm = new ObservableCollection<Confirmation>();
            // some code to get all requests

            StackLayout confirmationStackLayout = FindByName("ConfirmationGridList") as StackLayout;
            ConfirmationRenderer confirmationRenderer = new ConfirmationRenderer(confirmationStackLayout);
            confirmationRenderer.Render();

            StackLayout ticketsStackLayout = FindByName("TicketsGridList") as StackLayout;
            TicketRenderer ticketRenderer = new TicketRenderer(ticketsStackLayout);
            ticketRenderer.Render();
        }
    }
}
