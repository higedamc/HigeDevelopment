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
using MasterDetailDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(FontRenderer))]

namespace MasterDetailDemo.Droid
{
    public class FontRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = (TextView)Control;
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "britanic.ttf");
            label.Typeface = font;
        }
    }
}