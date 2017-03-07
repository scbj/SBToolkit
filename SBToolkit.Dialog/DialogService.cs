using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SBToolkit.Dialog
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

        public bool? ShowDialog<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
        {
            if (!_mappings.ContainsKey(typeof(TViewModel)))
                throw new ArgumentException($"There are no {typeof(TViewModel)} type register in the service.");

            Type viewType = _mappings[typeof(TViewModel)];

            IDialog dialog = (IDialog)Activator.CreateInstance(viewType);

            Action<bool?> handler = null;

            handler = (b) =>
            {
                viewModel.CloseRequested -= handler;

                dialog.Close();
            };

            viewModel.CloseRequested += handler;

            dialog.DataContext = viewModel;
            dialog.Owner = _owner;

            return dialog.ShowDialog();
        }

        #endregion
    }
}
