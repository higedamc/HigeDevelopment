using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MasterDetailDemo.Droid.Extentions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomFontRenderer))]

namespace MasterDetailDemo.Droid.Extentions
{
    public class CustomFontRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (string.IsNullOrEmpty(e.NewElement?.FontFamily))
            {
                return;
            }
            try
            {
                var font = Typeface.CreateFromAsset(Forms.Context.Assets, e.NewElement.FontFamily);
                Control.Typeface = font;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}