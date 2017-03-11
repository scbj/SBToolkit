using SBToolkit.Dialog.Tests.Dialogs;
using SBToolkit.Dialog.Tests.ViewModels;
using SBToolkit.MVVM.Dialog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SBToolkit.Dialog.Tests
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DialogService.Initialize(MainWindow);

            DialogService.Register<MessageDialogViewModel, MessageDialog>();

            base.OnStartup(e);
        }
    }
}
