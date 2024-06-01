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

            ThemeButtonsInitialization();
            StackLayoutRendererInitialization();
        }

        void ThemeChange(object sender, EventArgs e)
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

        void ThemeButtonsInitialization()
        {
            brightThemeButton = FindByName("bright") as Button;
            darkThemeButton = FindByName("dark") as Button;
            brightThemeButton.Clicked += ThemeChange;
            darkThemeButton.Clicked += ThemeChange;
        }

        void StackLayoutRendererInitialization()
        {
            Style boxViewBottomBorderStyle = (Style)this.Resources["BoxViewBottomBorder"];

            StackLayout confirmationStackLayout = FindByName("ConfirmationGridList") as StackLayout;
            ConfirmationRenderer confirmationRenderer = new ConfirmationRenderer(confirmationStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style confirmationStyle = (Style)this.Resources["ListViewBackGroundStyle"];
            Style boxViewConfirmationStyle = (Style)this.Resources["TicketBoxViewStyle"];
            confirmationRenderer.Render(confirmationStyle, (boxViewBottomBorderStyle, boxViewConfirmationStyle));


            StackLayout ticketsStackLayout = FindByName("TicketsGridList") as StackLayout;
            TicketRenderer ticketRenderer = new TicketRenderer(ticketsStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style ticketsStyle = (Style)this.Resources["ListViewBackGroundStyle"];
            Style boxViewTicketsStyle = (Style)this.Resources["TicketBoxViewStyle"];
            
            ticketRenderer.Render(ticketsStyle, (boxViewBottomBorderStyle, boxViewTicketsStyle));
        }
    }
}
