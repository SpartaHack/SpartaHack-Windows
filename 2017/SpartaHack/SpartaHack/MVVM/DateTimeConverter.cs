using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SpartaHack.MVVM
{
    public class DateTimeConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("t");
      
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }

    public class LocalDateTimeConverter:DateTimeConverter
    {
        public override object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            if (DateTime.Now.DayOfYear == dt.DayOfYear)
                return dt.ToString("t");
            else if (DateTime.Now.DayOfYear - dt.DayOfYear == 1)
                return "Yesterday";
            else
                return (DateTime.Now - dt).Days + " Days Ago";


        }
    }

}
