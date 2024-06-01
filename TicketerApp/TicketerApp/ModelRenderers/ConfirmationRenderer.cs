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
        private readonly INavigation _navigation;
        private ObservableCollection<Confirmation> _confirmations = new ObservableCollection<Confirmation>();
        private PlainTextRenderer _plainTextRenderer;
        private StackLayout _stackLayout;
        private CollectionView _collectionView;
        public ConfirmationRenderer(StackLayout layout, Style style, INavigation navigation)
        {
            _stackLayout = layout;
            _confirmations.Add(new Confirmation { PaymentId = 1, CorrectConfirmationAnswer = 123, EventTitle = "Event 1", PriceToPay = 49.99f, MfaRequired = true, MfaCode = "ABC123" });
            _plainTextRenderer = new PlainTextRenderer("There are no confirmation requests", style);
            _navigation = navigation;
        }

        public void Render(Style collectionViewStyle, (Style, Style)boxViewStyles)
        {
            if (_stackLayout == null)
            {
                throw new ArgumentNullException(nameof(_stackLayout));
            }

            if (_confirmations.Count > 0)
            {
                _collectionView = ConfirmationCollectionViewDesign.CreateStyledCollectionView(_confirmations, boxViewStyles);
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
            Confirmation confirmation = (Confirmation)((CollectionView)sender).SelectedItem;
            if (confirmation != null)
            {
                await _navigation.PushAsync(new ConfirmationDetailPage(confirmation));

                _collectionView.SelectionChanged -= selectedConfirmation;
                ((CollectionView)sender).SelectedItem = null;
                _collectionView.SelectionChanged += selectedConfirmation;
            }

        }
    }
}
