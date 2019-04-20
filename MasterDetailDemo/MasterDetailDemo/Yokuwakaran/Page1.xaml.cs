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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //AnimationView.Play();
        }

        //private void AnimationView_OnFinish(object sender, EventArgs e)
        //{
        //    //AnimationView.IsPlaying = false;
        //    Application.Current.MainPage = new AppShell();
        //}

        //private void Handle_OnFinish(object sender, EventArgs e)
        //{
        //    Application.Current.MainPage = new AppShell();
        //}

        private void AnimationView_OnClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    Application.Current.MainPage = new AppShell();
        //}
    }
}