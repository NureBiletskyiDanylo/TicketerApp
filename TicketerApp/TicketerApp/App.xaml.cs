using Plugin.FirebasePushNotification;
using System.Threading.Tasks;
using TicketerApp.APIConnector.Fcm;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.Utils;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace TicketerApp
{
    public partial class App : Application
    {
        FcmTokenManager _manager;
        public App()
        {
            InitializeComponent();
            _manager = new FcmTokenManager();
            LoggedInCheck();
        }
        protected override void OnStart()
        {
            SetTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void LoggedInCheck()
        {
            bool isLoggedIn;
            if (!Preferences.ContainsKey("logged_in"))
            {
                isLoggedIn = false;
                Preferences.Set("logged_in", false);
            }
            else
            {
                isLoggedIn = Preferences.Get("logged_in", false);
            }
            if (isLoggedIn)
            {
                string fcmToken = Preferences.Get("fcm_token", null);
                if(fcmToken == null)
                {
                    fcmToken = CrossFirebasePushNotification.Current.Token;

                }
                string authToken = Preferences.Get("token", null);
                if(authToken == null)
                {
                    return;
                }
                _manager.SendFcmToken(fcmToken, authToken).Wait(1000);
                double currentTimeStamp = UnixStampToDateTimeConverter.GetCurrentUnixTimeStamp();
                double expires_at = Preferences.Get("expires_at", currentTimeStamp);
                SuccessfulLoginRegistrationResponseModel model = new SuccessfulLoginRegistrationResponseModel() { Token = Preferences.Get("token", null), ExpiresAt = expires_at };
                MainPage = new NavigationPage(new MainPage(model));
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
        }
        



        private void SetTheme()
        {
            string themeName = Preferences.Get("theme", "bright");
            switch (themeName)
            {
                case "bright":
                    Application.Current.UserAppTheme = OSAppTheme.Light; 
                    break;
                case "dark":
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                default:
                    Application.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
            }
        }
    }
}
