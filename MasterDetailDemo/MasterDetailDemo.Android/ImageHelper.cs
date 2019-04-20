using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media.Session;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MasterDetailDemo.Droid;
using MasterDetailDemo.Services;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using ZXing;
using ZXing.Common;

[assembly: Xamarin.Forms.Dependency(typeof(ImageHelper))]
namespace MasterDetailDemo.Droid
{
    public class ImageHelper : IImageHelper
    {
        Context context;
        FileData fileData;

        public ImageHelper()
        {
            context = Xamarin.Forms.Forms.Context;
        }

        public BinaryBitmap GetBinaryBitmap(string imageName)
        {
            var fullName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imageName);

            //Try to find it from the source code folder
            if (!System.IO.File.Exists(fullName))
                fullName = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Images", imageName);

            var bmp = new System.Drawing.Bitmap(fullName);

            var bin = new ZXing.Common.HybridBinarizer(new RGBLuminanceSource(bmp, bmp.Width, bmp.Height));

            var i = new BinaryBitmap(bin);

            return i;
        }

        public BinaryBitmap GetBinaryBitmap(byte[] image)
        {
            //uncomment the line below to use the image that is passed instead of a raw image.
            Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length);

            //Bitmap bitmap = BitmapFactory.DecodeStream(context.Resources.OpenRawResource(Resource.Raw.static_qr_code_without_logo));
            byte[] rgbBytes = GetRgbBytes(bitmap);
            var bin = new HybridBinarizer(new RGBLuminanceSource(rgbBytes, bitmap.Width, bitmap.Height));
            var i = new BinaryBitmap(bin);

            return i;
        }

        private byte[] GetRgbBytes(Bitmap image)
        {
            var rgbBytes = new List<byte>();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var c = new Color(image.GetPixel(x, y));

                    rgbBytes.AddRange(new[] { c.R, c.G, c.B });
                }
            }
            return rgbBytes.ToArray();
        }
    }
}