using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TicketerApp.ModelRenderers
{
    public class TicketsStyleCollection
    {
        public Style ticketsStyleBackground { get; set; }
        public Style outerFrameTicketsStyle { get; set; }
        public Style innerFrameTicketsStyle { get; set; }
        public Style textColorTicketsStyle { get; set; }
        public Style priceColorTicketsStyle { get; set; }
        public TicketsStyleCollection(Style ticketsStyleBackground, Style outerFrameTicketsStyle, Style innerFrameTicketsStyle, Style textColorTicketsStyle, Style priceColorTicketsStyle)
        {
            this.ticketsStyleBackground = ticketsStyleBackground;
            this.textColorTicketsStyle = textColorTicketsStyle;
            this.outerFrameTicketsStyle = outerFrameTicketsStyle;
            this.innerFrameTicketsStyle = innerFrameTicketsStyle;
            this.priceColorTicketsStyle = priceColorTicketsStyle;
        }

    }
}
