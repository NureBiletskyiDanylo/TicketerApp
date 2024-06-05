using System.Collections.ObjectModel;
using TicketerApp.APIConnector;
using TicketerApp.Models;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public static class ConfirmationCollectionViewDesign
    {
        static ElementCreator _creator = new ElementCreator();
        public static ObservableCollection<Ticket> ToConfirm;
        public static CollectionView CreateConfirmationStyledCollectionView<T>(RequestManager manager, ObservableCollection<T> tickets, TicketsStyleCollection collection, INavigation navigation, ObservableCollection<T> confirmed) where T : TicketerApp.Models.Ticket
        {
            ToConfirm = tickets as ObservableCollection<Ticket>;
            var listView = new CollectionView
            {
                ItemsSource = tickets,
                ItemTemplate = new DataTemplate(() =>
                {
                    Grid mainGrid = _creator.CreateGrid(true);
                    Frame mainFrame = _creator.CreateFrame(collection.outerFrameTicketsStyle, true);
                    Grid inFrameGrid = _creator.CreateGrid(false);
                    Grid leftGrid = _creator.CreateGridWithRows();
                    StackLayout rightLayout = _creator.CreateStackLayout();
                    Frame innerFrame = _creator.CreateFrame(collection.innerFrameTicketsStyle, false);
                    mainFrame.Content = inFrameGrid;
                    inFrameGrid.Children.Add(leftGrid);
                    inFrameGrid.Children.Add(rightLayout);

                    Label eventTextLabel = _creator.CreateLabel(20, collection.textColorTicketsStyle);
                    Label startsAtLabel = _creator.CreateLabel(14, collection.textColorTicketsStyle);
                    eventTextLabel.SetBinding(Label.TextProperty, "Name");
                    startsAtLabel.SetBinding(Label.TextProperty, new Binding("ConfirmationAbilityExpiringDate", stringFormat: "{0:HH:mm} - {1:HH:mm}"));
                    Grid.SetRow(eventTextLabel, 0);
                    Grid.SetRow(startsAtLabel, 1);
                    leftGrid.Children.Add(eventTextLabel);
                    leftGrid.Children.Add(startsAtLabel);

                    Label priceLabel = _creator.CreateLabel(16, collection.priceColorTicketsStyle);
                    priceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: "${0:F2}");
                    innerFrame.Content = priceLabel;
                    rightLayout.Children.Add(innerFrame);
                    mainGrid.Children.Add(mainFrame);


                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        var selectedTicket = (T)((BindableObject)s).BindingContext;
                        if (selectedTicket != null)
                        {
                            navigation.PushAsync(new ConfirmationDetailPage(selectedTicket, manager, ToConfirm, TicketCollectionViewDesign.Tickets));
                        }
                    };
                    mainFrame.GestureRecognizers.Add(tapGestureRecognizer);

                    return new ContentView { Content = mainGrid };
                })
            };

            return listView;
        }


        public static Label CreateLabel(string text, double fontSize, FontAttributes fontAttributes, TextAlignment textAlignment)
        {
            return new Label
            {
                Text = text,
                FontSize = fontSize,
                FontAttributes = fontAttributes,
                TextColor = Color.White,
                HorizontalTextAlignment = textAlignment,
                VerticalTextAlignment = TextAlignment.Center,

            };
        }

        public static Label CreateNoItemsLabel(string message)
        {
            return new Label
            {
                Text = message,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 18,
                TextColor = Color.Gray,
                Margin = new Thickness(10)
            };
        }
    }
}
