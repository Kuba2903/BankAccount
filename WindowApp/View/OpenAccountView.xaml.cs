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
using WindowApp.Data;
using WindowApp.Models;

namespace WindowApp.View
{
    /// <summary>
    /// Interaction logic for OpenAccountView.xaml
    /// </summary>
    public partial class OpenAccountView : Window
    {
        public OpenAccountView()
        {
            InitializeComponent(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BankContext bank = new BankContext();

            Account account = new Account()
            {
                Name = name_txtbox.Text,
                Surname = surname_txtbox.Text,
                DateOfBirth = DateTime.Parse(dob_txtbox.Text),
                Pesel = pesel_txtbox.Text
            };
            MessageBox.Show("Success");
            bank.Accounts.Add(account);
            bank.SaveChanges();
        }
    }
}
