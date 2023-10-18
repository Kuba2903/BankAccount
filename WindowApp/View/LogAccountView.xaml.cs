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
using WindowApp.ViewModel;

namespace WindowApp.View
{
    /// <summary>
    /// Interaction logic for LogAccountView.xaml
    /// </summary>
    public partial class LogAccountView : Window
    {
        public LogAccountView()
        {
            InitializeComponent();
            LogAccountViewModel model = new LogAccountViewModel();
            this.DataContext = model;
        }
    }
}
