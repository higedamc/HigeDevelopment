using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailDemo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatteryPage : ContentPage
	{
        private Hoge hoge;


        public BatteryPage ()
		{
			InitializeComponent ();
            SetDisplay(Battery.ChargeLevel,
                Battery.State == BatteryState.Charging);
            var level = Battery.ChargeLevel;
            var level2 = Battery.ChargeLevel * 100;
            //Create hoge object
            this.hoge = new Hoge();
            //hoge.PackageName = DependencyService.Get<IAssemblyService>().GetPackageName();
            //hoge.VersionName = DependencyService.Get<IAssemblyService>().GetVersionName();
            //hoge.VersionCode = DependencyService.Get<IAssemblyService>().GetVersionCode().ToString();
            hoge.PercenTage = level.ToString();
            hoge.Progress = level2.ToString() + "%";
            this.Label5.BindingContext = hoge;
            this.progressRing.BindingContext = hoge;
            this.Label6.BindingContext = hoge;
            //Label6.Text = status;
        }

        public async void SetDisplay(double level, bool charging)
        {
            Color? color = null;
            var status = charging ? "Charging" : "DisCharging";
            //var full = BatteryState.Full.ToString();
            if (level > .8f)
            {
                color = Color.FromHex("#2196F3").MultiplyAlpha(level);
                status = "Full";
                var settings = new SpeechOptions()
                {
                    Volume = .7f,
                    Pitch = 1
                };
                await TextToSpeech.SpeakAsync("Battery is full", settings);
            }
            else if (level > .3f)
            {
                color = Color.Fuchsia.MultiplyAlpha(1d - level);
            }
            else
            {
                color = Color.Red.MultiplyAlpha(1d - level);
            }
            Label6.TextColor = color.Value;
            Label6.Text = status;



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            SetDisplay(e.ChargeLevel, e.State == BatteryState.Charging);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
        }

        private class Hoge
        {
            //public string PackageName { get; set; }
            //public string VersionName { get; set; }
            //public string VersionCode { get; set; }
            //public string BatteryRemains { get; set; }
            //public string CircleName { get; set; }
            public string PercenTage { get; set; }
            public string Progress { get; set; }
        }
    }
}