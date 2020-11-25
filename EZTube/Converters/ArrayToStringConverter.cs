using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace EZTube.Converters
{
    public class ArrayToStringConverter : IValueConverter
    {
        public char Separator { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string[] array)
                return string.Join(Separator, array);

            throw new Exception($"Cant Convert Exception {nameof(value)} is null or Should be an String Array");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                var array = str.Split(Separator)
                    .Select(s => s.Trim())
                    .ToArray();

                return array;
            }

            throw new Exception("Value Should be String");
        }
    }
}
