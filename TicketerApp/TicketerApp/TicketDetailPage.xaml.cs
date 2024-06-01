using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketerApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
namespace TicketerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketDetailPage : ContentPage
    {
        Image qrCode;
        public TicketDetailPage(Ticket selectedTicket)
        {
            InitializeComponent();
            BindingContext = selectedTicket;
        }
    }
}