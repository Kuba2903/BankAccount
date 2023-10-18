using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowApp.Commands;
using WindowApp.View;

namespace WindowApp.ViewModel
{
    public class StartWindowViewModel
    {
        public ICommand ShowWindowCommand { get; set; }

        public StartWindowViewModel()
        {
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj) => true;

        private void ShowWindow(object obj)
        {
            OpenAccountView view = new OpenAccountView();
            view.Show();
        }
    }
}
