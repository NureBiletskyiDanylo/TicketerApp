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

        public void Render(TicketsStyleCollection collection, ObservableCollection<Ticket> tickets)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }

            _tickets = tickets;
            if (_tickets.Count > 0)
            {
                _collectionView = TicketCollectionViewDesign.CreateStyledTicketCollectionView(_tickets, collection, _navigation);
                _collectionView.Style = collection.ticketsStyleBackground;
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
    }
}
