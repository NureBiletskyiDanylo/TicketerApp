using TicketerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketDetailPage : ContentPage
    {
        public TicketDetailPage(Ticket selectedTicket)
        {
            InitializeComponent();
            BindingContext = selectedTicket;
        }
    }
}