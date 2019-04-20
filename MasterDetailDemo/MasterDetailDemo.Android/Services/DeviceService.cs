using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MasterDetailDemo.Services;
using Xamarin.Forms;

namespace MasterDetailDemo.Droid.Services
{
    public class DeviceService : IDeviceService
    {
        [Obsolete]
        public void PlayVibrate()
        {
            var vib = Android.App.Application.Context.GetSystemService(Context.VibratorService);
            Vibrator vibrator = (Vibrator)vib;
            vibrator.Vibrate(1000);
        }

        private static PowerManager.WakeLock wakeLock = null;

        // Disable Sleep
        public void DisableSleep()
        {
            PowerManager pm = (PowerManager)
                Android.App.Application.Context.GetSystemService(Context.PowerService);
            Context context = Android.App.Application.Context;
            var packageName = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            wakeLock = pm.NewWakeLock(WakeLockFlags.Full, packageName);
            wakeLock.Acquire();
        }

        // Enable Sleep
        public void EnableSleep()
        {
            if(wakeLock != null)
            {
                wakeLock.Release();
                wakeLock = null;
            }
        }
    }
}