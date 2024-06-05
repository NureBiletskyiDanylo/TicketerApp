using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{

    public static class TicketCollectionViewDesign
    {
        static ElementCreator _creator = new ElementCreator();
        public static CollectionView CreateStyledTicketCollectionView<T>(ObservableCollection<T> tickets, TicketsStyleCollection collection)
        {
            var listView = new CollectionView()
            {
                SelectionMode = SelectionMode.Single,
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
                startsAtLabel.SetBinding(Label.TextProperty, new Binding("StartTime", stringFormat: "{0:HH:mm} - {1:HH:mm}"));
                Grid.SetRow(eventTextLabel, 0);
                Grid.SetRow(startsAtLabel, 1);
                leftGrid.Children.Add(eventTextLabel);
                leftGrid.Children.Add(startsAtLabel);


                Label priceLabel = _creator.CreateLabel(16, collection.priceColorTicketsStyle);
                priceLabel.SetBinding(Label.TextProperty, "Price", stringFormat: "${0:F2}");
                innerFrame.Content = priceLabel;
                rightLayout.Children.Add(innerFrame);
                mainGrid.Children.Add(mainFrame);
                return new ContentView { Content = mainGrid };
                })
            };
            return listView;
        }
    }
}
