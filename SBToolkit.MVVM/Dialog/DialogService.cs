using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SBToolkit.MVVM.Dialog
{
    public partial class DialogService
    {
        private IDictionary<Type, Type> _mappings;

        #region Constructors

        private DialogService()
        {
            _mappings = new Dictionary<Type, Type>();
        }

        #endregion

        #region Methods

        public void RegisterDialog<TViewModel, TView>()
            where TViewModel : IDialogRequestClose
            where TView : IDialog
        {
            Type viewModelType = typeof(TViewModel);

            if (_mappings.ContainsKey(viewModelType))
                throw new ArgumentException($"Type {viewModelType} is already mapped to type {_mappings[viewModelType].Name}");

            _mappings.Add(viewModelType, typeof(TView));
        }

        public bool? ShowDialog<TViewModel>(TViewModel viewModel, bool canClose) where TViewModel : IDialogRequestClose
        {
            IDialog dialog = GetDialogInstance(typeof(TViewModel));

            if (dialog == null)
                throw new ArgumentException($"There are no {typeof(TViewModel)} type register in the service.");

            if (!canClose)
                dialog.Closing += Dialog_Closing;

            Action<bool?> handler = null;

            handler = (b) =>
            {
                // Unsubscribe to events.
                viewModel.CloseRequested -= handler;

                if (!canClose)
                    dialog.Closing -= Dialog_Closing;

                // Set dialog result and close the dialog.
                dialog.DialogResult = b;

                dialog.Close();
            };

            viewModel.CloseRequested += handler;

            dialog.DataContext = viewModel;
            dialog.Owner = _owner;

            return dialog.ShowDialog();
        }

        #endregion

        #region Functions

        private IDialog GetDialogInstance(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
                return null;

            Type viewType = _mappings[viewModelType];

            return (IDialog)Activator.CreateInstance(viewType);
        }

        private void Dialog_Closing(object sender, CancelEventArgs e) => e.Cancel = true;

        #endregion
    }
}
