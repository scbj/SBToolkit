using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SBToolkit.MVVM.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If value is a boolean get the value else initialize at false.
            bool boolean = value is bool ? (bool)value : false;

            if (IsInverted(parameter))
                boolean ^= true;

            return boolean ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = value is Visibility v ? v : Visibility.Collapsed;

            if (IsInverted(parameter))
                visibility ^= Visibility.Collapsed;

            return visibility == Visibility.Visible ? true : false;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Return true if the parameter is a string and its value is true otherwise return false.
        /// </summary>
        /// <returns></returns>
        private bool IsInverted(object parameter) => parameter is string s && Boolean.TryParse(s, out bool isInverted) && isInverted;

        #endregion
    }
}
