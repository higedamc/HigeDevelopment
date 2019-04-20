using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetailDemo.Converter
{
    public static class ImgConverter
    {
        public static byte[] GetByteArrayFromStream(Stream sm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                sm.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static Stream GetStreamFromImageSource(ImageSource source)
        {
            StreamImageSource streamImageSource = (StreamImageSource)source;
            System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;
            return stream;
        }
    }
}
