
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using MasterDetailDemo.Droid;
using MasterDetailDemo.Droid.Extentions;
using MasterDetailDemo.Services;
using MasterDetailDemo.Views;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LoadingPageServiceDroid))]

namespace MasterDetailDemo.Droid
{
    public class LoadingPageServiceDroid : ILoadingPageService
    {
        private Android.Views.View _nativeView;

        private Dialog _dialog;

        private bool _isInitialized;

        [System.Obsolete]
        public void InitLoadingPage(ContentPage loadingIndicatorPage)
        {
            // check if the page parameter is available
            if (loadingIndicatorPage != null)
            {
                // build the loading page with native base
                loadingIndicatorPage.Parent = Xamarin.Forms.Application.Current.MainPage;

                loadingIndicatorPage.Layout(new Rectangle(0, 0,
                    Xamarin.Forms.Application.Current.MainPage.Width,
                    Xamarin.Forms.Application.Current.MainPage.Height));

                var renderer = loadingIndicatorPage.GetOrCreateRenderer();

                _nativeView = renderer.View;

                _dialog = new Dialog(CrossCurrentActivity.Current.Activity);
                _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
                _dialog.SetCancelable(false);
                _dialog.SetContentView(_nativeView);
                Window window = _dialog.Window;
                window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                window.ClearFlags(WindowManagerFlags.DimBehind);
                window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent));

                _isInitialized = true;
            }
        }

        [System.Obsolete]
        public void ShowLoadingPage()
        {
            // check if the user has set the page or not
            if (!_isInitialized)
                InitLoadingPage(new LoadingIndicatorPage2()); // set the default page

            // showing the native loading page
            _dialog.Show();
        }

        public void HideLoadingPage()
        {
            // Hide the page
            _dialog.Hide();
        }
    }
}