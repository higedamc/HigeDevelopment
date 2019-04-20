using MasterDetailDemo;
using Xamarin.Forms;

namespace App7
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "splashicon.png",
                WidthRequest = 100,
                HeightRequest = 100
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
                new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#1976D2");
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Time consuming process for like initialization
            await splashImage.ScaleTo(1, 750);
            await splashImage.ScaleTo(0.9, 750, Easing.Linear);
            await splashImage.ScaleTo(150, 850, Easing.Linear);
            // After the loading of SplashPage, navigating to MainPage!
            Application.Current.MainPage = new AppShell();
        }
    }
}