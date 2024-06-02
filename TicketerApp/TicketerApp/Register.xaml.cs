using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void OnBackButtonClicked(object sender, EventArgs e)
        {
           
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
        }

        private void OnShowPasswordClicked(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            
        }
        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
