using System;
using System.Diagnostics;
using TicketerApp.APIConnector;
using TicketerApp.APIConnector.RequestModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        Entry _emailEntry;
        Entry _passwordEntry;
        RequestManager _manager;
        public Login()
        {
            InitializeComponent();
            _manager = new RequestManager();
            _emailEntry = (Entry)FindByName("EmailEntry");
            _passwordEntry = (Entry)FindByName("PasswordEntry");
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            LoginRequestModel loginModel = new LoginRequestModel()
            {
                email = _emailEntry.Text,
                password = _passwordEntry.Text,
                mfa_code = "123",
                captcha_key = "123"
            };
            await _manager.LoginSimpleRequest(loginModel);
            if(_manager._successfulResponseModel != null)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage(_manager._successfulResponseModel));
            }
        }

        private void OnShowPasswordClicked(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private void OnForgotPasswordClicked(object sender, EventArgs e)
        {
        }
        private void OnQuitButtonClicked(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void OnGoogleLoginClicked(object sender, EventArgs e)
        {
        }


        private void SignUpClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Register());
        }
    }
}
