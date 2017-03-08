using PropertyChanged;
using SBToolkit.MVVM.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SBToolkit.Dialog.Tests.ViewModels
{
    [ImplementPropertyChanged]
    public class MessageDialogViewModel : IDialogRequestClose
    {
        #region Events

        public event Action<bool?> CloseRequested;

        #endregion

        #region Constructors

        public MessageDialogViewModel(string title, string message)
        {
            Title = title;
            Message = message;

            ContinueCommand = new ActionCommand(Continue);
            UndoCommand = new ActionCommand(Undo);
        }

        #endregion

        #region Properties

        public string Title { get; set; }

        public string Message { get; set; }

        public ICommand ContinueCommand { get; set; }

        public ICommand UndoCommand { get; set; }

        #endregion

        #region Methods


        private void Continue(object obj)
        {
            CloseRequested?.Invoke(true);
        }

        private void Undo(object obj)
        {
            CloseRequested?.Invoke(false);
        }

        #endregion
    }
}
