using MasterDetailDemo.Services;
using MasterDetailDemo.Views;
using Microsoft.ProjectOxford.Face;
using Plugin.FilePicker;
using Plugin.Media;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MasterDetailDemo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
     {


        public AboutPage()
        {
            InitializeComponent();
        }


        public async void TakeASelfie_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front,
                AllowCropping = false
            });
            if (file == null)
            {
                picture.Source = null;
                return;
            }
            picture.Source = ImageSource.FromStream(() => file.GetStream());

            try
            {
                // show the loading page...
                DependencyService.Get<ILoadingPageService>()
                                 .InitLoadingPage(new LoadingIndicatorPage2());
                DependencyService.Get<ILoadingPageService>().ShowLoadingPage();
                var key = "Your API Key";
                var endpoint = "https://japaneast.api.cognitive.microsoft.com/face/v1.0";
                var client = new FaceServiceClient(key, endpoint);
                var result = await client.DetectAsync(file.GetStream(), returnFaceAttributes: new[]
                {
                    FaceAttributeType.Smile,
                });
                // close the loading page...
                DependencyService.Get<ILoadingPageService>().HideLoadingPage();
                if (!result.Any())
                {
                    return;
                }
                await DisplayAlert("じゃじゃーん!", $"あなたの笑顔は{result.First().FaceAttributes.Smile * 100}点です!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ouch!Azureで何かあったようです","","OK" + ex);
            }
            finally
            {
                await Navigation.PopToRootAsync();
            };
        }

        private async void PickAPic_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossFilePicker.Current.PickFile();
            if (file == null)
            {
                picture.Source = null;
                return;
            }
            picture.Source = ImageSource.FromStream(() => file.GetStream());

            try
            {
                // show the loading page...
                DependencyService.Get<ILoadingPageService>()
                                 .InitLoadingPage(new LoadingIndicatorPage2());
                DependencyService.Get<ILoadingPageService>().ShowLoadingPage();
                var key = "46d5b3deacde479f9b9a99021224eabe";
                var endpoint = "https://japaneast.api.cognitive.microsoft.com/face/v1.0";
                var client = new FaceServiceClient(key, endpoint);
                var result = await client.DetectAsync(file.GetStream(), returnFaceAttributes: new[]
                {
                    FaceAttributeType.Smile,
                });
                // close the loading page...
                DependencyService.Get<ILoadingPageService>().HideLoadingPage();
                if (!result.Any())
                {
                    return;
                }
                await DisplayAlert("じゃじゃーん!", $"あなたの笑顔は{result.First().FaceAttributes.Smile * 100}点です!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ouch!Azureで何かあったようです", "", "OK" + ex);
            }
            finally
            {
                await Navigation.PopToRootAsync();
            };
        }
    }
}