using System.Collections.ObjectModel;
using System;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{

    public static class TicketCollectionViewDesign
    {
        public static CollectionView CreateStyledTicketCollectionView<T>(ObservableCollection<T> tickets, (Style, Style) boxViewStyles)
        {
            var listView = new CollectionView()
            {
                SelectionMode = SelectionMode.Single,
                ItemsSource = tickets,
                ItemTemplate = new DataTemplate(() =>
{
                // Background BoxView
                var boxViewBackground = new BoxView
                {
                    Style = boxViewStyles.Item2,
                    Opacity = 0.5 // Reduce the background opacity a bit
                };

                // Grid for layout
                var grid = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height = GridLength.Auto },
                        new RowDefinition { Height = GridLength.Auto }
                    }
                };

                // Labels for headers
                var nameLabel = CreateLabel("Name:", 14, FontAttributes.Bold, TextAlignment.Center);
                var priceLabel = CreateLabel("Price:", 14, FontAttributes.Bold, TextAlignment.Center);
                var timeLabel = CreateLabel("Time:", 14, FontAttributes.Bold, TextAlignment.Center);

                // Labels for values
                var nameValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                nameValueLabel.SetBinding(Label.TextProperty, "name");

                var priceValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                priceValueLabel.SetBinding(Label.TextProperty, "price", stringFormat: "${0:F2}");

                var timeValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                timeValueLabel.SetBinding(Label.TextProperty, new Binding("startTime", stringFormat: "{0:HH:mm} - {1:HH:mm}"));

                // Adding headers to the grid
                grid.Children.Add(nameLabel, 0, 0);
                grid.Children.Add(priceLabel, 1, 0);
                grid.Children.Add(timeLabel, 2, 0);

                // Adding values to the grid
                grid.Children.Add(nameValueLabel, 0, 1);
                grid.Children.Add(priceValueLabel, 1, 1);
                grid.Children.Add(timeValueLabel, 2, 1);

                // AbsoluteLayout for positioning
                var absoluteLayout = new AbsoluteLayout();

                // Bottom border
                var bottomBorder = new BoxView
                {
                    HeightRequest = 1,
                    Style = boxViewStyles.Item1,
                };

                // Positioning elements using AbsoluteLayout
                AbsoluteLayout.SetLayoutFlags(bottomBorder, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
                AbsoluteLayout.SetLayoutBounds(bottomBorder, new Rectangle(0, 1, 1, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(grid, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(grid, new Rectangle(0, 0, 1, 1));
                AbsoluteLayout.SetLayoutFlags(boxViewBackground, AbsoluteLayoutFlags.All);
                AbsoluteLayout.SetLayoutBounds(boxViewBackground, new Rectangle(0, 0, 1, 1));

                // Adding elements to AbsoluteLayout
                absoluteLayout.Children.Add(boxViewBackground);
                absoluteLayout.Children.Add(grid);
                absoluteLayout.Children.Add(bottomBorder);

                // Return ContentView instead of ViewCell
                return new ContentView { Content = absoluteLayout };
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
                VerticalTextAlignment = TextAlignment.Center
            };
        }
    }
}
