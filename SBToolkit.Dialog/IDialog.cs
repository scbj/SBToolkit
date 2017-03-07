using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SBToolkit.Dialog
{
    public interface IDialog
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data context for an element when it participates in data binding.
        /// </summary>
        object DataContext { get; set; }

        ///// <summary>
        ///// Gets or sets the dialog result value, which is the value that is returned from the <see cref="ShowDialog"/> method.
        ///// </summary>
        //bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Window"/> owner of the dialog.
        /// </summary>
        Window Owner { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Manually closes a Window.
        /// </summary>
        void Close();

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <returns></returns>
        bool? ShowDialog();

        #endregion

    }
}
