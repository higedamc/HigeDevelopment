using MasterDetailDemo.Droid.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradientLabelPage : ContentPage
    {
        Random randonGen = new Random();

        public GradientLabelPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.WhenAll(
                label.ColorTo("a1", label.TextColor1, GetRandomColor(), c => label.TextColor1 = c, 200),
                label.ColorTo("a2", label.TextColor2, GetRandomColor(), c => label.TextColor2 = c, 200));
            }
        }

        Color GetRandomColor()
        {
            return Color.FromRgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }

        // なんだっけこれ...?
        //async void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    for (int i = 0; i < 50; i++)
        //    {
        //        await Task.WhenAll(
        //        label.ColorTo("a1", label.TextColor1, GetRandomColor(), c => label.TextColor1 = c, 200),
        //        label.ColorTo("a2", label.TextColor2, GetRandomColor(), c => label.TextColor2 = c, 200));
        //    }
        //}

        //Color GetRandomColor()
        //{
        //    return Color.FromRgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        //}
    }
}