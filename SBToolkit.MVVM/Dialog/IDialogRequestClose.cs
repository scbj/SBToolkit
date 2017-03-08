using System;

namespace SBToolkit.MVVM.Dialog
{
    public interface IDialogRequestClose
    {
        /// <summary>
        /// Occurs when the view model request closing the dialog.
        /// </summary>
        event Action<bool?> CloseRequested;
    }
}