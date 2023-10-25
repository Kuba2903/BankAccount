using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
    public class SendMoneyViewModel
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }

        public ICommand SendMoneyCommand { get; set; }

        public SendMoneyViewModel()
        {
            SendMoneyCommand = new RelayCommand(SendMoney, TrySendMoney);
        }


        private bool TrySendMoney(object obj) => true;

        private void SendMoney(object obj)
        {
            using BankContext context = new BankContext();
            var receiver = context.Accounts.FirstOrDefault(x => x.AccountId == Id);
            var sender = context.Accounts.FirstOrDefault(x => x.AccountId == Globals.Id);
            if (Amount > 0)
            {
                decimal? temp = Globals.Budget.Value;
                temp -= Amount;
                if (temp >= 0)
                {
                    if(receiver is Account)
                    {
                        receiver.Budget += Amount.Value;
                    }
                    if (sender is Account)
                    {
                        sender.Budget -= Amount.Value;
                        Globals.Budget = sender.Budget;
                    }

                    MessageBox.Show("Success");
                }
            }
            context.SaveChanges();
        }
    }
}
