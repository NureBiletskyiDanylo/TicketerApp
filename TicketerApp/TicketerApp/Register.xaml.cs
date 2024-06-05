using Plugin.FirebasePushNotification;
using System;
using System.Diagnostics;
using System.Linq;
using TicketerApp.APIConnector;
using TicketerApp.APIConnector.Fcm;
using TicketerApp.APIConnector.RequestModels;
using TicketerApp.Behaviors;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        FcmTokenManager _tokenManager;
        Entry _emailEntry;
        Entry _passwordEntry;
        Entry _firstNameEntry;
        Entry _lastNameEntry;
        RequestManager _requestManager;
        public Register()
        {
            InitializeComponent();
            _requestManager = new RequestManager();
            _tokenManager = new FcmTokenManager();
            _emailEntry = (Entry)FindByName("EmailEntry");
            _passwordEntry = (Entry)FindByName("PasswordEntry");
            _firstNameEntry = (Entry)FindByName("FirstNameEntry");
            _lastNameEntry = (Entry)FindByName("LastNameEntry");
        }

        private void OnQuitButtonClicked(object sender, EventArgs e)
        {
           Process.GetCurrentProcess().Kill();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        private void OnShowPasswordClicked(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (!Validate())
            {
                return;
            }
            RegisterRequestModel model = new RegisterRequestModel()
            {
                FirstName = _firstNameEntry.Text,
                LastName = _lastNameEntry.Text,
                Email = _emailEntry.Text,
                Password = _passwordEntry.Text,
                CaptchaKey = "123"
            };
            await _requestManager.RegisterSimpleRequest(model);
            if(_requestManager.SuccessfulAuthResponseModel != null)
            {
                string fcmToken = CrossFirebasePushNotification.Current.Token;
                await _tokenManager.SendFcmToken(fcmToken, _requestManager.SuccessfulAuthResponseModel.Token);
                Application.Current.MainPage = new NavigationPage(new MainPage(_requestManager.SuccessfulAuthResponseModel));
            }
        }

        private bool Validate()
        {
            bool isEmailValid = _emailEntry.Behaviors.Any(b => b is EmailValidationBehavior && ((EmailValidationBehavior)b).IsValid);
            bool isPasswordValid = _passwordEntry.Behaviors.Any(b => b is PasswordValidationBehavior && ((PasswordValidationBehavior)b).IsValid);
            bool isFirstNameValid = _firstNameEntry.Behaviors.Any(b => b is NameValidationBehavior && ((NameValidationBehavior)b).IsValid);
            bool isLastNameValid = _lastNameEntry.Behaviors.Any(b => b is NameValidationBehavior && ((NameValidationBehavior)b).IsValid);
            return isEmailValid && isPasswordValid && isFirstNameValid && isLastNameValid;
        }
    }
}
