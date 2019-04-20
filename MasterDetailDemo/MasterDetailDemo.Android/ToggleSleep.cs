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

[assembly: Dependency(typeof(IToggleSleep))]
namespace MasterDetailDemo.Droid
{
    public class ToggleSleep : IToggleSleep
    {
        private static PowerManager.WakeLock _wakeLock = null;

        /// <summary>
        /// DisableSleep
        /// </summary>
        public void DisableSleep()
        {
            PowerManager pm = (PowerManager)Android.App.Application.Context.GetSystemService(Context.PowerService);
            Context context = Android.App.Application.Context;    //Android.App.Application.Context;
            var packageName = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            _wakeLock = pm.NewWakeLock(WakeLockFlags.Full, packageName);
            _wakeLock.Acquire();

        }

        /// <summary>
        /// Enable Sleep
        /// </summary>
        public void EnableSleep()
        {
            if (_wakeLock != null)
            {
                _wakeLock.Release();
                _wakeLock = null;
            }
        }
    }
}