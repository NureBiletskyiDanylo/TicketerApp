using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public static class ConfirmationListViewDesign
    {
        public static ListView CreateStyledListView<T>(ObservableCollection<T> items, (Style, Style) boxViewStyles)
        {
            var listView = new ListView
            {
                ItemsSource = items,
                ItemTemplate = new DataTemplate(() =>
                {
                    var boxViewBackground = new BoxView
                    {
                        Style =boxViewStyles.Item2,
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

                    var eventTitleLabel = CreateLabel("Event Title:", 14, FontAttributes.Bold, TextAlignment.Center);
                    var priceToPayLabel = CreateLabel("Price To Pay:", 14, FontAttributes.Bold, TextAlignment.Center);
                    var mfaRequiredLabel = CreateLabel("MFA Required:", 14, FontAttributes.Bold, TextAlignment.Center);

                    var eventTitleValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    eventTitleValueLabel.SetBinding(Label.TextProperty, "EventTitle");

                    var priceToPayValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    priceToPayValueLabel.SetBinding(Label.TextProperty, "PriceToPay", stringFormat: "${0:F2}");

                    var mfaRequiredValueLabel = CreateLabel(string.Empty, 14, FontAttributes.None, TextAlignment.Center);
                    mfaRequiredValueLabel.SetBinding(Label.TextProperty, "MfaRequired", stringFormat: "{0:Yes;No}");

                    grid.Children.Add(eventTitleLabel, 0, 0);
                    grid.Children.Add(priceToPayLabel, 1, 0);
                    grid.Children.Add(mfaRequiredLabel, 2, 0);

                    grid.Children.Add(eventTitleValueLabel, 0, 1);
                    grid.Children.Add(priceToPayValueLabel, 1, 1);
                    grid.Children.Add(mfaRequiredValueLabel, 2, 1);

                    var absoluteLayout = new AbsoluteLayout();

                    var bottomBorder = new BoxView
                    {
                        HeightRequest = 1,
                        Style = boxViewStyles.Item1,
                    };
                    // Располагаем сетку и фоновый BoxView с абсолютным позиционированием
                    AbsoluteLayout.SetLayoutFlags(bottomBorder, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
                    AbsoluteLayout.SetLayoutBounds(bottomBorder, new Rectangle(0, 1, 1, AbsoluteLayout.AutoSize));
                    AbsoluteLayout.SetLayoutFlags(grid, AbsoluteLayoutFlags.All);
                    AbsoluteLayout.SetLayoutBounds(grid, new Rectangle(0, 0, 1, 1));
                    AbsoluteLayout.SetLayoutFlags(boxViewBackground, AbsoluteLayoutFlags.All);
                    AbsoluteLayout.SetLayoutBounds(boxViewBackground, new Rectangle(0, 0, 1, 1));

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
