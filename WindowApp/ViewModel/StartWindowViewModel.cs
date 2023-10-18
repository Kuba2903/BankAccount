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
        public ICommand ShowOpenAccountCommand { get; set; }
        public ICommand ShowLogAccountCommand { get; set; }

        public StartWindowViewModel()
        {
            ShowOpenAccountCommand = new RelayCommand(ShowOpenAccount, CanShowOpenAccount);
            ShowLogAccountCommand = new RelayCommand(ShowLogAccount, CanShowLogAccount);
        }

        private bool CanShowLogAccount(object obj) => true;

        private void ShowLogAccount(object obj)
        {
            LogAccountView view = new LogAccountView();
            view.Show();
        }

        private bool CanShowOpenAccount(object obj) => true;

        private void ShowOpenAccount(object obj)
        {
            OpenAccountView view = new OpenAccountView();
            view.Show();
        }
    }
}
