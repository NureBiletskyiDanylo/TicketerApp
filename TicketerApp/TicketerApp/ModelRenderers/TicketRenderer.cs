using System;
using System.Collections.ObjectModel;
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
        private CollectionView _collectionView;

        public TicketRenderer(StackLayout layout, Style style, INavigation navigation)
        {
            _stackLayout = layout;
            _plainTextRenderer = new PlainTextRenderer("There are no tickets", style);
            _navigation = navigation;
        }

        public void Render(Style collectionViewStyle, (Style, Style) boxViewStyles, ObservableCollection<Ticket> tickets)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }
            // Создаем один билет
            _tickets = tickets;
            if (_tickets.Count > 0)
            {
                _collectionView = TicketCollectionViewDesign.CreateStyledTicketCollectionView(_tickets, boxViewStyles);
                _collectionView.Style = collectionViewStyle;
                _collectionView.SelectionChanged += selectedTicket;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(_collectionView);
            }
            else
            {
                Label noTicketLabel = _plainTextRenderer.Label;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(noTicketLabel);
            }
        }
        async void selectedTicket(Object sender, SelectionChangedEventArgs e)
        {
            Ticket ticket = (Ticket)((CollectionView)sender).SelectedItem;
            if (ticket != null)
            {

                await _navigation.PushAsync(new TicketDetailPage(ticket));

                _collectionView.SelectionChanged -= selectedTicket;
                ((CollectionView)sender).SelectedItem = null;
                _collectionView.SelectionChanged += selectedTicket;

            }
        }
    }
}
