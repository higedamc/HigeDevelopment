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
using MasterDetailDemo.Droid;
using MasterDetailDemo.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AssemblyService))]

namespace MasterDetailDemo.Droid
{
    public class AssemblyService : IAssemblyService
    {
        // Get app name
        public string GetPackageName()
        {
            Context context = Android.App.Application.Context; // Android.App.Application.Context
            var name = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            return name;
        }

        // Get strings of app version
        public string GetVersionName()
        {
            Context context = Android.App.Application.Context;
            var name = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            return name;
        }

        // Get app version code
        public int GetVersionCode()
        {
            Context context = Android.App.Application.Context;    //Android.App.Application.Context;
            var code = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionCode;
            return code;
        }

    }
}