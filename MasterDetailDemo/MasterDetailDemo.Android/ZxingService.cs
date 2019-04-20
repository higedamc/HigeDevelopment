using System;
using System.Collections.Generic;
using Android.Graphics;
using MasterDetailDemo.Droid;
using MasterDetailDemo.Services;
using Xamarin.Forms;
using ZXing;
using ZXing.Common;

[assembly: Dependency(typeof(ZxingService))]
namespace MasterDetailDemo.Droid
{
    public class ZxingService : IZxingService
    {
        public string GetDecodedValue(byte[] image)
        {
            if (image == null || image.Length == 0)
            {
                return String.Empty;
            }

            ZXing.Result result = null;

            try
            {
                //Create Bitamp Object, Specifying the Size
                BitmapFactory.Options opts = new BitmapFactory.Options
                {
                    InSampleSize = 2
                };
                Bitmap bitmap = BitmapFactory.DecodeByteArray(image, 0, image.Length, opts);

                //Get RGB by 3rd Demention
                byte[] rgbBytes = ImageService.GetRgbBytes(bitmap);
                LuminanceSource source = new RGBLuminanceSource(rgbBytes, bitmap.Width, bitmap.Height);
                BinaryBitmap bb = new BinaryBitmap(new HybridBinarizer(source));

                //Read QR Code
                var reader = new MultiFormatReader();
                IDictionary<DecodeHintType, object> hints = new Dictionary<DecodeHintType, object>
                {
                    { ZXing.DecodeHintType.PURE_BARCODE, true },
                    { ZXing.DecodeHintType.POSSIBLE_FORMATS, new List<BarcodeFormat>() { BarcodeFormat.QR_CODE } },    //無くても動作します。
                    { ZXing.DecodeHintType.TRY_HARDER, true }
                };
                reader.Hints = hints;
                result = reader.decode(bb);
            }
            catch (Exception ex)
            {
                // fall thru, it means there is no QR code in image
                Console.WriteLine("あっはーんｗｗｗｗｗｗ", ex);
                throw;
            }

            if (result != null)
            {
                return result.Text;
            }
            return String.Empty;
        }

    }
}