using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
           
        }

        private void OnShowPasswordClicked(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private void OnForgotPasswordClicked(object sender, EventArgs e)
        {
        }
        private void OnBackButtonClicked(object sender, EventArgs e)
        {
        }
        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
        }
        private void OnGoogleLoginClicked(object sender, EventArgs e)
        {
        }

        private void OnFacebookLoginClicked(object sender, EventArgs e)
        {
        }
        private bool AuthenticateUser(string email, string password)
        {
            return email == "test@example.com" && password == "password";
        }
    }
}
