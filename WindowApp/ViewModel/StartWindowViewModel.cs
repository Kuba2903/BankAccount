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
        public ICommand ExitProgramCommand { get; set; }

        public StartWindowViewModel()
        {
            ShowOpenAccountCommand = new RelayCommand(ShowOpenAccount, CanShowOpenAccount);
            ShowLogAccountCommand = new RelayCommand(ShowLogAccount, CanShowLogAccount);
            ExitProgramCommand = new RelayCommand(ExitProgram, TryExitProgram);
        }

        private bool TryExitProgram(object obj) => true;

        private bool CanShowLogAccount(object obj) => true;
        private bool CanShowOpenAccount(object obj) => true;

        private void ExitProgram(object obj) => Environment.Exit(0);
        private void ShowLogAccount(object obj)
        {
            LogAccountView view = new LogAccountView();
            view.Show();
        }

        private void ShowOpenAccount(object obj)
        {
            OpenAccountView view = new OpenAccountView();
            view.Show();
        }
        
    }
}
