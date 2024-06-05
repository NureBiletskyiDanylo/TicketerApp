using System;
using System.Collections.ObjectModel;
using TicketerApp.Models;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class ConfirmationRenderer
    {
        private readonly INavigation _navigation;
        private ObservableCollection<Ticket> _notConfirmedTickets = new ObservableCollection<Ticket>();
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;
        private CollectionView _collectionView;
        public ConfirmationRenderer(StackLayout layout, Style style, INavigation navigation)
        {
            _stackLayout = layout;
            _plainTextRenderer = new PlainTextRenderer("There are no confirmation requests", style);
            _navigation = navigation;
        }

        public void Render(Style collectionViewStyle, (Style, Style)boxViewStyles, ObservableCollection<Ticket> notConfirmedTickets)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }
            _notConfirmedTickets = notConfirmedTickets;
            if (_notConfirmedTickets.Count > 0)
            {
                _collectionView = ConfirmationCollectionViewDesign.CreateStyledCollectionView(_notConfirmedTickets, boxViewStyles);
                _collectionView.Style = collectionViewStyle;
                _collectionView.SelectionChanged += selectedConfirmation;
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

        async void selectedConfirmation(Object sender, SelectionChangedEventArgs e)
        {
            Ticket ticket = (Ticket)((CollectionView)sender).SelectedItem;
            if (ticket != null)
            {
                await _navigation.PushAsync(new ConfirmationDetailPage(ticket));

                _collectionView.SelectionChanged -= selectedConfirmation;
                ((CollectionView)sender).SelectedItem = null;
                _collectionView.SelectionChanged += selectedConfirmation;
            }

        }
    }
}
