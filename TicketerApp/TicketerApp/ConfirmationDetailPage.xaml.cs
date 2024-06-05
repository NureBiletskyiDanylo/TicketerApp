using TicketerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmationDetailPage : ContentPage
	{
		public ConfirmationDetailPage (Ticket ticketToConfirm)
		{
			InitializeComponent ();
			BindingContext = ticketToConfirm;
		}
	}
}