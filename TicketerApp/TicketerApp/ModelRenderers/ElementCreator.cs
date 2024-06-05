using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class ElementCreator
    {
        public Grid CreateGrid(bool withMargin)
        {
            Grid grid = new Grid
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Auto) }
                    },
                BackgroundColor = Color.Transparent,
            };
            if (withMargin)
            {
                grid.Margin = new Thickness(20, 20, 20, 0);
            }
            return grid;
        }

        public Grid CreateGridWithRows()
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };
            Grid.SetColumn(grid, 0);
            return grid;
        }

        public Frame CreateFrame(Style frameStyle, bool withColumn)
        {
            Frame frame = new Frame
            {
                CornerRadius = 25,
                Style = frameStyle
            };
            if (withColumn)
            {
                Grid.SetColumn(frame, 0);
            }
            return frame;
        }

        public StackLayout CreateStackLayout()
        {
            StackLayout layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Grid.SetColumn(layout, 1);
            return layout;
        }

        public Label CreateLabel(Int32 fontSize, Style textStyle)
        {
            Label label = new Label
            {
                FontSize = fontSize,
                Style = textStyle,
                FontAttributes = FontAttributes.Bold,
            };
            return label;
        }
    }
}
