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
        private readonly INavigation _navigation;
        private ObservableCollection<Ticket> _tickets = new ObservableCollection<Ticket>();
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;
        private ListView _listView;

        public TicketRenderer(StackLayout layout, Style style, INavigation navigation)
        {
            _stackLayout = layout;
            _plainTextRenderer = new PlainTextRenderer("There are no tickets", style);
            _navigation = navigation;
        }

        public void Render(Style listViewStyle, (Style, Style) boxViewStyles)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }
            // Создаем один билет
            Ticket ticket = new Ticket
            {
                startTime = new DateTime(2024, 5, 10, 14, 30, 0),
                endTime = new DateTime(2024, 5, 10, 16, 30, 0),
                name = "Sample Event",
                price = 50.0f
            };

            Ticket ticket2 = new Ticket
            {
                startTime = new DateTime(2024, 5, 10, 14, 30, 0),
                endTime = new DateTime(2024, 5, 10, 16, 30, 0),
                name = "Sample Event",
                price = 50.0f
            };

            // Добавляем билет в коллекцию
            _tickets.Add(ticket);
            _tickets.Add(ticket2);
            if (_tickets.Count > 0)
            {
                _listView = TicketListViewDesign.CreateStyledTicketListView(_tickets, boxViewStyles);
                _listView.Style = listViewStyle;
                _listView.ItemSelected += selectedTicket;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(_listView);
            }
            else
            {
                Label noTicketLabel = _plainTextRenderer.Label;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(noTicketLabel);
            }
        }
        async void selectedTicket(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Ticket ticket = (Ticket)((ListView)sender).SelectedItem;
                await _navigation.PushAsync(new TicketDetailPage(ticket));

                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
