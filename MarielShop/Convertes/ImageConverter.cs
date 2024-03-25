using MarielShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarielShop.Convertes
{

    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null) return null;

            Stream stream = new MemoryStream((byte[])value);
            var imageSource = ImageSource.FromStream(() => stream);
            return imageSource;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
