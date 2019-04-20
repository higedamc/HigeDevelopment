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

namespace MasterDetailDemo.Droid
{
    public class VolumeButtonPressed
    {
        public override bool VolumeButtonPressed(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.VolumeDown)
            {
                return true;
            }
            if (keyCode == Keycode.VolumeUp)
            {
                return true;

            }
            return base.VolumeButtonPressed(keyCode, e);
        }
    }
}