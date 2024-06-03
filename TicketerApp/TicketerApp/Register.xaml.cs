using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicketerApp.APIConnector;
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
        Entry _emailEntry;
        Entry _passwordEntry;
        Entry _firstNameEntry;
        Entry _lastNameEntry;
        RequestManager _requestManager;
        public Register()
        {
            InitializeComponent();
            _requestManager = new RequestManager();

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
                first_name = _firstNameEntry.Text,
                last_name = _lastNameEntry.Text,
                email = _emailEntry.Text,
                password = _passwordEntry.Text,
                captcha_key = "123"
            };
            await _requestManager.RegisterSimpleRequest(model);
            if(_requestManager._successfulResponseModel != null)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage(_requestManager._successfulResponseModel));
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
