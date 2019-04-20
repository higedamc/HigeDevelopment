using System.Collections.Generic;
using ZXing;
using Xamarin.Forms;
using MasterDetailDemo.Services;
using Plugin.FilePicker;

namespace MasterDetailDemo
{
    public class BarcodeDecoding
    {
        IImageHelper _imageHelper;
        public BarcodeDecoding()
        {
            _imageHelper = DependencyService.Get<IImageHelper>();
        }


        public Result Decode(string file, BarcodeFormat? format = null, KeyValuePair<DecodeHintType, object>[] aditionalHints = null)
        {
            var r = GetReader(format, aditionalHints);

            var image = GetImage(file);

            var result = r.decode(image);

            return result;
        }

        MultiFormatReader GetReader(BarcodeFormat? format, KeyValuePair<DecodeHintType, object>[] aditionalHints)
        {
            var reader = new MultiFormatReader();

            var hints = new Dictionary<DecodeHintType, object>();

            if (format.HasValue)
            {
                hints.Add(DecodeHintType.POSSIBLE_FORMATS, new List<BarcodeFormat>() { format.Value });
            }
            if (aditionalHints != null)
            {
                foreach (var ah in aditionalHints)
                {
                    hints.Add(ah.Key, ah.Value);
                }
            }

            reader.Hints = hints;

            return reader;
        }

        BinaryBitmap GetImage(string fileName)
        {
            // Get image file and pass in the bytes array
            // or pass in the image name and load the image from the platform implementation.

            var byteArray = (fileName);

            var binaryBitmap = _imageHelper.GetBinaryBitmap(byteArray);

            return binaryBitmap;
        }
    }
}
