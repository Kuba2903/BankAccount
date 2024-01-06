using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowApp.Commands;
using WindowApp.Data;
using WindowApp.DBModels;

namespace WindowApp.ViewModel
{
    public class OpenAccountViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Pesel { get; set; }

        public string Password { get; set; }
        public int Budget { get; set; }
        public DateTime TodayDate { get; set; }

        public ICommand AddPersonCommand {  get; set; }

        public OpenAccountViewModel()
        {
            AddPersonCommand = new RelayCommand(AddUser, TryAddUser);
            TodayDate = DateTime.Today;
            Budget = 0;
        }

        private bool TryAddUser(object obj) => true;

        private void AddUser(object obj)
        {
            bool added = false;

            if (Password.Length < 6)
            {
                MessageBox.Show("Password must be minimum 6 characters length!");
            }
            else
            {
                try
                {
                    BankContext bank = new BankContext();

                    Account account = new Account()
                    {
                        Name = Name,
                        Surname = Surname,
                        DateOfBirth = Date_Of_Birth,
                        Pesel = Pesel,
                        Password = Password,
                        Budget= Budget
                    };
                    bank.Add(account);
                    bank.SaveChanges();
                    added = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (added)
                    MessageBox.Show("Success");
            }
        }
    }
}
