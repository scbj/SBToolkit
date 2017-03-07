using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBToolkit.Dialog
{
    public interface IDialogRequestClose
    {
        /// <summary>
        /// Occurs when the view model request closing the dialog.
        /// </summary>
        event Action<bool?> CloseRequested;
    }
}
