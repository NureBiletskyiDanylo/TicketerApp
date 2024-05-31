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
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;

        public TicketRenderer(StackLayout layout, Style style)
        {
            _stackLayout = layout;
            _plainTextRenderer = new PlainTextRenderer("There are no tickets", style);
        }

        public void Render(Style listViewStyle, Style boxViewStyle)
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
                ListView listView = TicketListViewDesign.CreateStyledTicketListView(_tickets, boxViewStyle);
                listView.Style = listViewStyle;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(listView);
            }
            else
            {
                Label noTicketLabel = _plainTextRenderer.Label;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(noTicketLabel);
            }
        }
    }
}
