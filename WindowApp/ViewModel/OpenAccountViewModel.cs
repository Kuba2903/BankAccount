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

namespace WindowApp.ViewModel
{
    public class OpenAccountViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Pesel { get; set; }

        public ICommand AddPersonCommand {  get; set; }

        public OpenAccountViewModel()
        {
            AddPersonCommand = new RelayCommand(AddUser, TryAddUser);
        }

        private bool TryAddUser(object obj) => true;

        private void AddUser(object obj)
        {
            bool added = false;
            try
            {
                BankContext bank = new BankContext();

                Account account = new Account()
                {
                    Name = Name,
                    Surname = Surname,
                    DateOfBirth = Date_Of_Birth,
                    Pesel = Pesel
                };
                bank.Add(account);
                bank.SaveChanges();
                added = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(added)
                MessageBox.Show("Success");
        }
    }
}
