using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        long lastPress;

        //This here for BackButtonPressedToExit
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                if (currentTime - lastPress > 5000)
                {
                    // Show Snackbar
                    //var notificator = DependencyService.Get<IToastNotificator>();
                    //var androidOptions = new AndroidOptions
                    //{
                    //    DismissText = ""
                    //};
                    //var options = new NotificationOptions()
                    //{
                    //    Title = "Press BACK button again to exit",
                    //    IsClickable = false,
                    //    AndroidOptions = androidOptions
                    //};
                    //await notificator.Notify(options);
                    // Show Tost
                    Android.Widget.Toast.MakeText(Android.App.Application.Context,
                        "Press BACK button again to exit", Android.Widget.ToastLength.Long).Show();
                    lastPress = currentTime;
                }
                else
                {
                    base.OnBackButtonPressed();
                    {
                        var activity = (Android.App.Activity)Android.App.Application.Context;
                        activity.FinishAffinity();
                    }
                }
            });
            return true;
        }
    }
}