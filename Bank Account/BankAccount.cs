using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public class BankAccount
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }
        private string lastname;
        public string LastName
        {
            get
            {
                return lastname;
            }
            set { lastname = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }

            set { age = value; }
        }

        private bool isblocked;
        public bool IsBlocked
        {
            get { return isblocked; }
        }
        public void Open()
        {
            Console.WriteLine("To open account we need from you some data");
            Console.WriteLine("First, let tell us what is your name and last name");

            var parts = Console.ReadLine().Split(' ');
            name = parts[0];
            lastname = parts[1];

            Console.WriteLine("Now let give us your birthday date in format 'DD-MM-YYYY'");

            var dOb = Console.ReadLine().ToString().Split('-');

            DateTime date = new DateTime(int.Parse( dOb[2]), int.Parse( dOb[1]),int.Parse( dOb[0]));
            
            age = DateTime.Now.Year - date.Year;
             
            if(DateTime.Now < date)
            {
                Console.WriteLine("Wrong date");
            }
            if(age < 18)
            {
                Console.WriteLine("You are too young to open bank account");
                isblocked = true;
            }
        }
    }
}
