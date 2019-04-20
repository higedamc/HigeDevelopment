using System;
using System.IO;
using Xamarin.Forms;

namespace MasterDetailDemo.Converter
{
    public class ImageSourceFromByteArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource imgSource = null;
            if (value != null)
            {
                byte[] byteArray = (byte[])value;
                imgSource = ImageSource.FromStream(() => new MemoryStream(byteArray));
            }
            return imgSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
