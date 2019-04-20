using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpFromTheBottom : ContentPage
    {
        public PopUpFromTheBottom()
        {
            InitializeComponent();
        }

        private async void ToggleFlyoutButtonClicked(object sender, EventArgs e)
        {
            if (flyout.IsVisible)
            {
                await flyout.TranslateTo(0, flyout.Height, 300);
                flyout.IsVisible = !flyout.IsVisible;
            }
            else
            {
                await flyout.TranslateTo(0, flyout.Height, 0);
                flyout.IsVisible = !flyout.IsVisible;
                await flyout.TranslateTo(0, 0, 300);
            }
        }
    }
}