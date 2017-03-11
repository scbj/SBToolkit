using SBToolkit.MVVM.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SBToolkit.Dialog.Tests.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageDialogViewModel.xaml
    /// </summary>
    public partial class MessageDialog : Window, IDialog
    {
        public MessageDialog() => InitializeComponent();
    }
}
