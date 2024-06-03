using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketerApp.Droid.Custom;
using TicketerApp.Droid.Renderers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace TicketerApp.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) {
            AutoPackage = false;
        }

        [Obsolete]
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Application.Current != null)
            {
                Android.Graphics.Color color;
                if (Control != null && Application.Current.UserAppTheme == OSAppTheme.Dark)
                {
                    color = Android.Graphics.Color.ParseColor("#eeba2c");
                }
                else
                {
                    color = Android.Graphics.Color.Black;
                }
                Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
        }
    }
}