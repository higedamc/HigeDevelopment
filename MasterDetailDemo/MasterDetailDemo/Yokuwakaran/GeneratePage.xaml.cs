using Android.App;
using ImageCircle.Forms.Plugin.Abstractions;
using MasterDetailDemo.Converter;
using MasterDetailDemo.Services;
using MasterDetailDemo.Views;
using Plugin.FilePicker;
using Plugin.Toasts;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MasterDetailDemo.View
{
    public partial class GeneratePage : ContentPage
    {
        public GeneratePage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EntryShare.Text.Length > 0)
            {
                TouchMe.IsEnabled = true;
                // For MasterDetailPage
                //await (Application.Current.MainPage as MasterDetailPage)
                //    .Detail.Navigation.PushAsync(new ListPage(EntryShare.Text));
                await Navigation.PushAsync(new ListPage(EntryShare.Text));
            }
            else
            {
                TouchMe.IsEnabled = false;
            }
        }

        public void EntryTextChanged(object obj, EventArgs args)
        {
            if (EntryShare.Text.Length > 0)
            {
                TouchMe.IsEnabled = true;
            }
            else
            {
                TouchMe.IsEnabled = false;
            }
        }

        private async void ImageA_Clicked(object sender, EventArgs e)
        {
            try
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file == null)
                {
                    return;
                }
                //byte[] byteArray = null;
                // GET A PIC STREAM FROM CROSSFILEPICKER
                Stream fileData = file.GetStream();
                //GET AN IMAGE SOURCE FROM LOCAL FILES
                //ImageSource imgSource = ImageSource.FromResource(@"MasterDetailDemo.Resources.Drawable.about.png");
                //GET STREAM FROM IMAGESOURCE FOR LOCAL FILES
                //Stream stream = ImgConverter.GetStreamFromImageSource(imgSource);
                //GET STREAM FROM IMAGE SOURCE
                //Stream stream = ImgConverter.GetStreamFromImageSource(this.ImageA.Source);
                // CONVERT STREAM TO BYTE[]
                byte[] byteArray = ImgConverter.GetByteArrayFromStream(fileData);
                // READ QR CODE DATA FROM PICS
                string result = DependencyService.Get<IZxingService>().GetDecodedValue(byteArray);
                ResultText.Text = result;
                HandleResult(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        private async void HandleResult(string result)
        {
            var msg = "No result!";
            if(result != null)
            {
                msg = result;
                await Clipboard.SetTextAsync(result);
                await Clipboard.GetTextAsync();
                await DisplayAlert("おつまる水産！", msg, "OK");
                if (true)
                {
                    Android.Widget.Toast.MakeText(Android.App.Application.Context,
                        "Copied to the Clipboard", Android.Widget.ToastLength.Long).Show();
                }
            }
        }
    }
}