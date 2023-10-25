using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowApp.Commands;
using WindowApp.Data;
using WindowApp.DBModels;
using WindowApp.View;

namespace WindowApp.ViewModel
{
    public class LogAccountViewModel
    {
        public int Id { get; set; }
        public string Pesel { get; set; }

        public ICommand LogAccountCommand { get; set; }
        public LogAccountViewModel()
        {
            LogAccountCommand = new RelayCommand(LogToTheAccount, TryLogToTheAccount);
        }

        private bool TryLogToTheAccount(object obj) => true;

        private void LogToTheAccount(object obj)
        {
            BankContext context = new BankContext(); 

            if (context.Accounts.Any(x => (x.AccountId == Id) && (x.Pesel == Pesel)))
            {
                MessageBox.Show("Success");
                SaveData(context);
                AccountMenuView view = new AccountMenuView();
                view.Show();
            }
            else
                MessageBox.Show("Account not find");
        }

        private void SaveData(BankContext context)
        {
            var accounts = context.Accounts.FirstOrDefault(x => x.AccountId == Id && x.Pesel == Pesel);
            Globals.Name = accounts.Name + " " + accounts.Surname;
            Globals.Budget = accounts.Budget;
            Globals.Id = accounts.AccountId;
            Globals.Pesel = accounts.Pesel;
            Globals.DateOfBirth = accounts.DateOfBirth;
        }
    }
}
