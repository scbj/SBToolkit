using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SBToolkit.MVVM.ViewModel
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Updates the property and raises the changed event, but only if the new value does not equal the old value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldValue">A reference to the backing field of the property.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns></returns>
        public bool Set<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "") where T : class
        {
            if (newValue == oldValue)
                return false;

            oldValue = newValue;

            return RaisePropertyChanged(propertyName);
        }

        /// <summary>
        /// Updates the property and raises the changed event.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns></returns>
        public bool OnPropertyChanged([CallerMemberName] string propertyName = null) => RaisePropertyChanged(propertyName);

        #region Functions

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private bool RaisePropertyChanged(string propertyName)
        {
            if (propertyName == null)
                return false;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        #endregion
    }
}
