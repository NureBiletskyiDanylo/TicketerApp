using System.Collections.ObjectModel;
using System;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{

    public static class TicketListViewDesign
    {
        public static ListView CreateStyledTicketListView<T>(ObservableCollection<T> tickets, Style boxViewStyle)
        {
            var listView = new ListView
            {
                ItemsSource = tickets,
                ItemTemplate = new DataTemplate(() =>
                {
                    var boxViewBackground = new BoxView
                    {
                        Style = boxViewStyle,
                        Opacity = 0.5 // Уменьшаем немного прозрачность фона
                    };

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

                    var nameLabel = CreateLabel("Name:", 14, FontAttributes.Bold, TextAlignment.Center);
                    var priceLabel = CreateLabel("Price:", 14, FontAttributes.Bold, TextAlignment.Center);
                    var timeLabel = CreateLabel("Time:", 14, FontAttributes.Bold, TextAlignment.Center);

                    var nameValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    nameValueLabel.SetBinding(Label.TextProperty, "name");

                    var priceValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    priceValueLabel.SetBinding(Label.TextProperty, "price", stringFormat: "${0:F2}");

                    var timeValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    timeValueLabel.SetBinding(Label.TextProperty, new Binding("startTime", stringFormat: "{0:HH:mm} - {1:HH:mm}"));

                    grid.Children.Add(nameLabel, 0, 0);
                    grid.Children.Add(priceLabel, 1, 0);
                    grid.Children.Add(timeLabel, 2, 0);

                    grid.Children.Add(nameValueLabel, 0, 1);
                    grid.Children.Add(priceValueLabel, 1, 1);
                    grid.Children.Add(timeValueLabel, 2, 1);

                    var absoluteLayout = new AbsoluteLayout();

                    AbsoluteLayout.SetLayoutFlags(grid, AbsoluteLayoutFlags.All);
                    AbsoluteLayout.SetLayoutBounds(grid, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(boxViewBackground, AbsoluteLayoutFlags.All);
                    AbsoluteLayout.SetLayoutBounds(boxViewBackground, new Rectangle(0, 0, 1, 1));
                    // Create a bottom border
                    var bottomBorder = new BoxView
                    {
                        HeightRequest = 1,
                        BackgroundColor = Color.Black
                    };
                    AbsoluteLayout.SetLayoutFlags(bottomBorder, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
                    AbsoluteLayout.SetLayoutBounds(bottomBorder, new Rectangle(0, 1, 1, AbsoluteLayout.AutoSize));

                    absoluteLayout.Children.Add(boxViewBackground);
                    absoluteLayout.Children.Add(grid);
                    absoluteLayout.Children.Add(bottomBorder);

                    return new ViewCell { View = absoluteLayout };
                }),
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
