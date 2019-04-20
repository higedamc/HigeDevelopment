using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MasterDetailDemo.Droid
{
    public class ImageService
    {
        public static byte[] GetRgbBytes(Bitmap image)
        {
            /// <summary>
            /// Get RGB by Pixel
            /// </summary>
            /// <param name="image"></param>
            /// <returns></returns>
            var rgbBytes = new List<byte>();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var c = new Android.Graphics.Color(image.GetPixel(x, y));

                    rgbBytes.AddRange(new[] { c.R, c.G, c.B });
                }
            }
            return rgbBytes.ToArray();
        }
    }
}