using PropertyChanged;
using SBToolkit.MVVM.Dialog;
using SBToolkit.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

            ContinueCommand = new RelayCommand(ContinueAction);
            UndoCommand = new RelayCommand(UndoAction);
        }

        #endregion

        #region Properties

        public string Title { get; set; }

        public string Message { get; set; }

        public Visibility UndoVisibility => Visibility.Visible;

        [DoNotNotify]
        public ICommand ContinueCommand { get; set; }

        [DoNotNotify]
        public ICommand UndoCommand { get; set; }

        #endregion

        #region Methods

        private void ContinueAction() => CloseRequested?.Invoke(true);

        private void UndoAction() => CloseRequested?.Invoke(false);

        #endregion
    }
}
