using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SBToolkit.MVVM.Converters
{
    public static class ConverterHerlper
    {
        public static object Convert<TConverter>(object value) where TConverter : IValueConverter
            => Convert<TConverter, object>(value);

        public static TDestination Convert<TConverter, TDestination>(object value) where TConverter : IValueConverter
            => Convert<TConverter, TDestination>(value, null);
        public static TDestination Convert<TConverter, TDestination>(object value, object parameter) where TConverter : IValueConverter
            => Convert<TConverter, TDestination>(value, parameter, CultureInfo.CurrentCulture);

        public static TDestination Convert<TConverter, TDestination>(object value, object parameter, CultureInfo culture) where TConverter : IValueConverter
        {
            // Create new instance of type TDestination.
            TConverter converter = Activator.CreateInstance<TConverter>();

            object obj = converter?.Convert(value, typeof(TDestination), parameter, culture);

            return obj is TDestination convertedValue ? convertedValue : default(TDestination);
        }
    }
}
