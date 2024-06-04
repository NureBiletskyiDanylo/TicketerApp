using System;
using System.Collections.ObjectModel;
using TicketerApp.APIConnector;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.ModelRenderers;
using TicketerApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TicketerApp
{
    public partial class MainPage
    {
        RequestManager _requestManager;
        private Button _brightThemeButton;
        private Button _darkThemeButton;
        private SuccessfulLoginRegistrationResponseModel _model;
        public MainPage(SuccessfulLoginRegistrationResponseModel model)
        {
            InitializeComponent();
            _requestManager = new RequestManager();
            ObservableCollection<Confirmation> requestsToConfirm = new ObservableCollection<Confirmation>();
            // some code to get all requests
            _model = model;
            ThemeButtonsInitialization();
            StackLayoutRendererInitialization();
        }

        void ThemeChange(object sender, EventArgs e)
        {
            if (sender == _brightThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Light;
                Preferences.Set("theme", "bright");
            }
            else if (sender == _darkThemeButton)
            {
                App.Current.UserAppTheme = OSAppTheme.Dark;
                Preferences.Set("theme", "dark");
            }
            else
            {
                App.Current.UserAppTheme = OSAppTheme.Unspecified;
                Preferences.Set("theme", "bright");
            }
        }

        void ThemeButtonsInitialization()
        {
            _brightThemeButton = FindByName("bright") as Button;
            _darkThemeButton = FindByName("dark") as Button;
            _brightThemeButton.Clicked += ThemeChange;
            _darkThemeButton.Clicked += ThemeChange;
        }

        void StackLayoutRendererInitialization()
        {
            Style boxViewBottomBorderStyle = (Style)this.Resources["BoxViewBottomBorder"];

            StackLayout confirmationStackLayout = FindByName("ConfirmationGridList") as StackLayout;
            ConfirmationRenderer confirmationRenderer = new ConfirmationRenderer(confirmationStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style confirmationStyle = (Style)this.Resources["CollectionViewBackGroundStyle"];
            Style boxViewConfirmationStyle = (Style)this.Resources["TicketBoxViewStyle"];
            confirmationRenderer.Render(confirmationStyle, (boxViewBottomBorderStyle, boxViewConfirmationStyle));


            StackLayout ticketsStackLayout = FindByName("TicketsGridList") as StackLayout;
            TicketRenderer ticketRenderer = new TicketRenderer(ticketsStackLayout, (Style)this.Resources["PlainTextStyle"], this.Navigation);
            Style ticketsStyle = (Style)this.Resources["CollectionViewBackGroundStyle"];
            Style boxViewTicketsStyle = (Style)this.Resources["TicketBoxViewStyle"];
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>(_requestManager.GetTicketsRequest().Result);
            ticketRenderer.Render(ticketsStyle, (boxViewBottomBorderStyle, boxViewTicketsStyle), tickets);
        }

        private void LogOutClickedEventHandler(object sender, EventArgs e)
        {
            Preferences.Set("logged_in", false);
            Preferences.Remove("token");
            Preferences.Remove("expires_at");
            Application.Current.MainPage = new NavigationPage(new Login());
        }
    }
}
