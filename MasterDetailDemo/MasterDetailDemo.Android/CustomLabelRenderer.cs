using MasterDetailDemo;
using MasterDetailDemo.Droid;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]

namespace MasterDetailDemo
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            FontManager.Current.ChangeFont(Control, Element.FontFamily);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == Label.FontFamilyProperty.PropertyName)
            {
                FontManager.Current.ChangeFont(Control, Element.FontFamily);
            }
        }
    }

}
