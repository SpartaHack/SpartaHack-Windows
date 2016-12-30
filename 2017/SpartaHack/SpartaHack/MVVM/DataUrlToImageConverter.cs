using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

using System.IO;
using System.Text.RegularExpressions;

using Windows.UI.Xaml.Media.Imaging;
namespace SpartaHack.MVVM
{
    public class DataUrlToImageConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;
            
            BitmapImage logo = new BitmapImage();
            var base64Data = Regex.Match(value.ToString(), @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = System.Convert.FromBase64String(base64Data);
            using (var stream = new MemoryStream(binData))
            {
                logo.SetSourceAsync(stream.AsRandomAccessStream());
            }
            return logo;


        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
