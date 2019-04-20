//using App7;
using MasterDetailDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MasterDetailDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Page1();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //MainPage = new Page1();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
