using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TicketerApp.Models;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class TicketRenderer
    {
        private ObservableCollection<Ticket> _tickets = new ObservableCollection<Ticket>();
        private StackLayout _stackLayout;

        public TicketRenderer(StackLayout layout)
        {
            _stackLayout = layout;
        }

        public void Render()
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }

            if (_tickets.Count > 0)
            {
                ListView listView = new ListView();
                listView.ItemsSource = _tickets;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(listView);
            }
            else
            {
                Label noTicketLabel = new Label();
                noTicketLabel.Text = "There are no tickets";
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(noTicketLabel);
            }
        }
    }
}
