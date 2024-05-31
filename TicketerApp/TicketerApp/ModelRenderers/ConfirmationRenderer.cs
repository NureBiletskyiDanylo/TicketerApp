using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketerApp.Models;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class ConfirmationRenderer
    {
        private ObservableCollection<Confirmation> _confirmations = new ObservableCollection<Confirmation>();
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;
        public ConfirmationRenderer(StackLayout layout, Style style)
        {
            _stackLayout = layout;
            _confirmations.Add(new Confirmation { PaymentId = 1, CorrectConfirmationAnswer = 123, EventTitle = "Event 1", PriceToPay = 49.99f, MfaRequired = true, MfaCode = "ABC123" });
            _plainTextRenderer = new PlainTextRenderer("There are no confirmation requests", style);
        }

        public void Render()
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }

            if (_confirmations.Count > 0)
            {
                ListView listView = ListViewDesign.CreateStyledListView(_confirmations);
                listView.ItemsSource = _confirmations;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(listView);
            }
            else
            {
                Label noConfirmLabel = _plainTextRenderer.Label;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(noConfirmLabel);
            }
        }
    }
}
