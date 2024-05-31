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
        private Button brightThemeButton;
        private Button darkThemeButton;
        public MainPage()
        {
            InitializeComponent();
            ObservableCollection<Confirmation> requestsToConfirm = new ObservableCollection<Confirmation>();
            // some code to get all requests
            brightThemeButton = FindByName("bright") as Button;
            darkThemeButton = FindByName("dark") as Button;
            brightThemeButton.Clicked += themeChange;
            darkThemeButton.Clicked += themeChange;

            StackLayout confirmationStackLayout = FindByName("ConfirmationGridList") as StackLayout;
            ConfirmationRenderer confirmationRenderer = new ConfirmationRenderer(confirmationStackLayout, (Style)this.Resources["PlainTextStyle"]);
            confirmationRenderer.Render();

            StackLayout ticketsStackLayout = FindByName("TicketsGridList") as StackLayout;
            TicketRenderer ticketRenderer = new TicketRenderer(ticketsStackLayout, (Style)this.Resources["PlainTextStyle"]);
            ticketRenderer.Render();
        }

        void themeChange(object sender, EventArgs e)
        {
            if (sender == brightThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
            }
            else if (sender == darkThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Unspecified;
            }
        }
    }
}
