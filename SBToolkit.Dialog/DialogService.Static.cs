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
        #region Fields

        private static DialogService _instance;
        private static Window _owner;

        #endregion

        #region Methods

		public static void Initialize(Window owner)
        {
            _owner = owner;

            _instance = new DialogService();
        }

        #endregion

        /// <summary>
        /// Register the specified view model for the specified view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TView">The type of the view.</typeparam>
        public static void Register<TViewModel, TView>()
            where TViewModel : IDialogRequestClose
            where TView : IDialog
        {
            if (_instance == null)
                throw new Exception($"{nameof(DialogService)} must be initialized before calling ShowDialog method.");

            _instance.RegisterDialog<TViewModel, TView>();
        }

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="viewModel">The view model for the DataContext property of the dialog.</param>
        /// <returns></returns>
        public static bool? Show<TViewModel>(TViewModel viewModel) where TViewModel : IDialogRequestClose
        {
            if (_instance == null)
                throw new Exception($"{nameof(DialogService)} must be initialized before calling ShowDialog method.");

            return _instance.ShowDialog(viewModel);
        }
    }
}
