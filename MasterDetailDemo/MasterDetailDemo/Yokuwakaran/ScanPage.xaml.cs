using MasterDetailDemo.Services;
using Plugin.Battery;
using Plugin.Toasts;
using System;
using System.Text.RegularExpressions;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
//using AppName.Services;

namespace MasterDetailDemo.View
{

    public partial class ScanPage : ContentPage
    {

        //ZXingScannerView zxing;
        //ZXingDefaultOverlay overlay;
        ZXingScannerPage scanPage;
        //Button buttonGenerateBarcode;

        public ScanPage()
        {
            InitializeComponent();
            ButtonScanCustom.Clicked += ButtonScanCustom_Clicked;
        }

        
        private void ButtonScanCustom_Clicked(object sender, EventArgs e)
        {
            var overlay = new AbsoluteLayout
            {
                //WidthRequest = 200,
                //HeightRequest = 200,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,

            };
            var stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var grid = new Grid();
            {
                grid.VerticalOptions = LayoutOptions.FillAndExpand;
                grid.HorizontalOptions = LayoutOptions.FillAndExpand;
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                grid.Children.Add(new BoxView
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Black,
                    Opacity = 0.7,
                }, 0, 0);
                grid.Children.Add(new BoxView
                {
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Black,
                    Opacity = 0.7,
                }, 0, 2);
                grid.Children.Add(new BoxView
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = 3,
                    BackgroundColor = Color.FromHex("#1976D2"),
                    Opacity = 0.6,
                }, 0, 1);

            }





            var torch = new Button
            {
                //Text = "Let there be light!",
                Text = "Torch",
                // Enable "Material" Visual on C#
                Visual = VisualMarker.Material,
                //Source = "sculpturetorch.png",
                //HorizontalOptions = LayoutOptions.Start,
                //VerticalOptions = LayoutOptions.End,
                //WidthRequest = 80,
                //HeightRequest = 80,
                //Opacity = 1,
                BackgroundColor = Color.FromHex("#2E7ACE"),
                //Image = "torch.img",



            };

            AbsoluteLayout.SetLayoutFlags(stack,
                AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stack,
                new Rectangle(0f, 0f, 1f, 1f));
            AbsoluteLayout.SetLayoutFlags(torch,
                AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(torch,
                new Rectangle(0, 1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            overlay.Children.Add(stack);
            overlay.Children.Add(torch);
            stack.Children.Add(grid);
            //Content = stack;


            var batteryLevel = CrossBattery.Current.RemainingChargePercent;
            var status = CrossBattery.Current.Status;

            torch.Clicked += async delegate
            {
                if (batteryLevel > 40 || status == Plugin.Battery.Abstractions.BatteryStatus.Charging)
                {
                    scanPage.ToggleTorch();
                }
                if (status == Plugin.Battery.Abstractions.BatteryStatus.NotCharging || batteryLevel < 40)
                {
                    var notificator = DependencyService.Get<IToastNotificator>();
                    var androidOptions = new AndroidOptions
                    {
                        DismissText = ""
                    };
                    var options = new NotificationOptions()
                    {
                        Title = "BatteryLow",
                        AndroidOptions = androidOptions
                    };
                    await notificator.Notify(options);
                }

            };


            //scanPage = new ZXingScannerPage(new MobileBarcodeScanningOptions
            //{ AutoRotate = false, TryHarder = true}, customOverlay: customOverlay);
            //Not using customoverlay
            scanPage = new ZXingScannerPage(new MobileBarcodeScanningOptions
            { AutoRotate = false, TryHarder = true}, customOverlay: overlay);

            //scanPage = new ZXingScannerView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    AutomationId = "zxingScannerView",
            //};
            Navigation.PushModalAsync(scanPage);
            // Work with the result
            scanPage.OnScanResult += (result) =>
            {
                var clipshit = result.Text;
                Clipboard.SetTextAsync(result.Text);
                Clipboard.GetTextAsync();
                scanPage.IsScanning = false;
                // Action starts
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    //if (clipshit != null)
                    //if (result.Text.StartsWith("http"))
                    string input = result.Text;
                    //Regex regex = new Regex(@"https?://[-_.!~*'a-zA-Z0-9;/?:@&=+$,%#]+");
                    Match match = Regex.Match(input, @"https?://[-_.!~*'a-zA-Z0-9;/?:@&=+$,%#]+");
                    //return regex.Matches(strInput);
                    if (match.Success)
                    {
                        var result2 = await DisplayAlert("URL detected.", "Wanna Open Browser?", "yes", "no");
                        if (result2 == true)
                        {

                            //var intent = new Intent(Intent.ActionMain);
                            //intent.SetComponent(new ComponentName("com.catchingnow.tinyclipboardmanager", "com.catchingnow.tinyclipboardmanager.MainActivity"));
                            //StartActivity(intent);
                            Device.OpenUri(new Uri(result.Text));

                        }
                        if (result2 == false)
                        {
                            //await Navigation.PopAsync();
                            //await DisplayAlert("みじっそう", "です", "さーせん");
                            var notificator = DependencyService.Get<IToastNotificator>();
                            var androidOptions = new AndroidOptions
                            {
                                DismissText = "Cancel"
                            };
                            var options = new NotificationOptions()
                            {
                                Title = "Launching Share",
                                AndroidOptions = androidOptions,
                            };
                            var resultt = await notificator.Notify(options);
                            if(!(resultt.Action == NotificationAction.Dismissed))
                            {
                                await Share.RequestAsync(new ShareTextRequest(result.Text));
                            }
                            else
                            {
                                Android.Widget.Toast.MakeText(Android.App.Application.Context,
                                "Cancelled", Android.Widget.ToastLength.Short).Show();
                            }
                            //DependencyService.Get<IDeviceService>().PlayVibrate();
                            //var duration = TimeSpan.FromSeconds(1);
                            //Vibration.Vibrate(duration);
                        }
                    }
                    else
                    {
                        //await Navigation.PopAsync();
                        var result3 = await DisplayAlert("Seems like it's not URL","Share result?","Yes","No");
                        if (result3 == true)
                        {
                            await Share.RequestAsync(new ShareTextRequest(result.Text));
                        }
                        if (result3 == false)
                        {
                            Android.Widget.Toast.MakeText(Android.App.Application.Context,
                        "Result copied to Clipboard", Android.Widget.ToastLength.Short).Show();
                        }


                    }
                    //DependencyService.Get<IDeviceService>().PlayVibrate();

                });

            };
        }
    }
}