using System;
using System.Collections.ObjectModel;
using TicketerApp.APIConnector;
using TicketerApp.Models;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class ConfirmationRenderer
    {
        private RequestManager _requestManager;
        private readonly INavigation _navigation;
        private ObservableCollection<Ticket> _notConfirmedTickets = new ObservableCollection<Ticket>();
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;
        private CollectionView _collectionView;
        public ConfirmationRenderer(RequestManager manager, StackLayout layout, Style style, INavigation navigation)
        {
            _requestManager = manager;
            _stackLayout = layout;
            _plainTextRenderer = new PlainTextRenderer("There are no confirmation requests", style);
            _navigation = navigation;
        }

        public void Render(TicketsStyleCollection collection, ObservableCollection<Ticket> notConfirmedTickets, ObservableCollection<Ticket> confirmed)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }
            _notConfirmedTickets = notConfirmedTickets;
            if (_notConfirmedTickets.Count > 0)
            {
                _collectionView = ConfirmationCollectionViewDesign.CreateConfirmationStyledCollectionView(_requestManager, _notConfirmedTickets, collection, _navigation, confirmed);
                _collectionView.Style = collection.ticketsStyleBackground;
                _stackLayout.Children.Clear();
                _stackLayout.Children.Add(_collectionView);
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
