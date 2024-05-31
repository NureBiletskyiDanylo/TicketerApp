using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class PlainTextRenderer
    {
        public Label Label { get; set; }
        public PlainTextRenderer(string text, Style style)
        {
            Label = new Label { Style = style, Text = text };
        }
    }
}
