using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SBToolkit.MVVM.Dialog
{
    public partial class DialogService
    {
        private IDictionary<Type, Type> _mappings;

        #region Constructors

        private DialogService() => _mappings = new Dictionary<Type, Type>();

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
            IDialog dialog = GetDialogInstance(typeof(TViewModel))
                ?? throw new ArgumentException($"There are no {typeof(TViewModel)} type register in the service.");

            if (!canClose)
                dialog.Closing += Dialog_Closing;


            viewModel.CloseRequested += OnCloseRequested;

            dialog.DataContext = viewModel;
            dialog.Owner = _owner;

            return dialog.ShowDialog();


            void OnCloseRequested(bool? dialogResult)
            {
                // Unsubscribe to events.
                viewModel.CloseRequested -= OnCloseRequested;

                if (!canClose)
                    dialog.Closing -= Dialog_Closing;

                // Set dialog result and close the dialog.
                dialog.DialogResult = dialogResult;

                dialog.Close();
            }
        }

        #endregion

        #region Functions

        private IDialog GetDialogInstance(Type viewModelType)
        {
            if (!_mappings.TryGetValue(viewModelType, out Type viewType))
                return null;

            return (IDialog)Activator.CreateInstance(viewType);
        }

        private void Dialog_Closing(object sender, CancelEventArgs e) => e.Cancel = true;

        #endregion
    }
}
