using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowApp.Commands;
using WindowApp.Data;
using WindowApp.View;

namespace WindowApp.ViewModel
{
    public class AccountMenuViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        private decimal? budget;

        public decimal? Budget
        {
            get { return budget; }
            set
            {
                if (budget != value)
                {
                    budget = value;
                    OnPropertyChanged("Budget");
                }
            }
        }

        public ICommand DepositCommand { get; set; }
        public ICommand WithdrawlCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public decimal? Value { get; set; }
        public AccountMenuViewModel()
        {
            Name = Globals.Name;
            Id = Globals.Id;
            Budget = Globals.Budget;
            Date = DateTime.Today.Date;
            DepositCommand = new RelayCommand(MakeDeposit, TryMakeDeposit);
            WithdrawlCommand = new RelayCommand(MakeWithdrawl, TryMakeWithdrawl);
            UpdateCommand = new RelayCommand(Update, TryUpdate);
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool TryMakeWithdrawl(object obj) => true;
        private bool TryMakeDeposit(object obj) => true;
        private bool TryUpdate(object obj) => true;

        private void Update(object obj)
        {
            Budget = Globals.Budget.Value;
            OnPropertyChanged("Budget");
        }

        private void MakeWithdrawl(object obj)
        {

            if (Value > 0)
            {
                decimal temp = Budget.Value - Value.Value;
                if (temp >= 0)
                {
                    Budget = temp;
                    Globals.Budget = Budget.Value;
                    MessageBox.Show("Withdrawed money");
                }
            }
            else
            {
                MessageBox.Show("Please provide positive value");
            }

            using (var context = new BankContext())
            {
                var retrieve = context.Accounts.FirstOrDefault(e => e.AccountId == Id);
                if (retrieve != null)
                {
                    retrieve.Budget = Budget;
                    context.SaveChanges();
                }
            }
        }

        private void MakeDeposit(object obj)
        {
            if (Value > 0)
            {
                Budget += Value;
                Globals.Budget = Budget.Value;
                MessageBox.Show("Added money");
            }
            else
            {
                MessageBox.Show("Please give positive value");
            }

            using (var context = new BankContext())
            {
                var retrieve = context.Accounts.FirstOrDefault(e => e.AccountId == Id);
                if (retrieve != null)
                {
                    retrieve.Budget = Budget;
                    context.SaveChanges();
                }
            }
        }

        
        
    }
}
