using System;
using System.Windows;

namespace SBToolkit.MVVM.Dialog
{
    public partial class DialogService
    {
        #region Fields

        private static DialogService _instance;
        private static Window _owner;

        #endregion

        #region Methods

        /// <summary>
        /// Instanciate a singleton <see cref="DialogService"/> and initialize components.
        /// </summary>
        /// <param name="owner">The <see cref="Window"/> you want to define as the owner of the dialog.</param>
        public static void Initialize(Window owner)
        {
            _owner = owner;

            _instance = new DialogService();
        }

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
        /// <param name="canClose">Allow or not the user to close the dialog without calling the CloseRequested event.</param>
        /// <returns></returns>
        public static bool? Show<TViewModel>(TViewModel viewModel, bool canClose = true) where TViewModel : IDialogRequestClose
        {
            if (_instance == null)
                throw new Exception($"{nameof(DialogService)} must be initialized before calling ShowDialog method.");

            return _instance.ShowDialog(viewModel, canClose);
        }

        #endregion
    }
}
