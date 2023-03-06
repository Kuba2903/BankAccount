using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public class BankAccount
    {
        //Properties 'name', 'lastname' and 'age' are needed for open account method

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

        private bool isopen; // checks whether the account is open
        public bool IsOpen
        {
            get { return isopen; }
        }

        private decimal budget; //budget of the account

        public decimal Budget
        {
            get { return budget; }
            set { budget = value; }
        }
        /// <summary>
        /// This method opens an account
        /// </summary>
        public void Open()
        {
            if(isopen == true)
            {
                Console.WriteLine("You have opened account already");
            }
            else
            {
                Console.WriteLine("To open account we need from you some data");
                Console.WriteLine("First, let tell us what is your name and last name");

                var parts = Console.ReadLine().Split(' ');
                name = parts[0].ToLower().Trim();
                name = String.Concat(name.Where(c => Char.IsWhiteSpace(c))); //Deletes white spaces from a string

                lastname = parts[1].ToLower().Trim();
                lastname = String.Concat(lastname.Where(c => Char.IsWhiteSpace(c)));

                Console.WriteLine("Now let give us your birthday date in format 'DD-MM-YYYY'");

                var dOb = Console.ReadLine().ToString().Split('-');

                DateTime date = new DateTime(int.Parse(dOb[2]), int.Parse(dOb[1]), int.Parse(dOb[0]));

                age = DateTime.Now.Year - date.Year;

                if (DateTime.Now < date)
                {
                    throw new ArgumentException("Wrong date");
                }
                else if (age < 18)
                {
                    Console.WriteLine("You are too young to open bank account");
                }
                else
                {
                    Console.WriteLine("Your account is open");
                    isopen = true;
                    budget = 0;
                }
            }
            
        }
        /// <summary>
        /// Deposits money to the account
        /// </summary>
        /// <param name="amount">The amount of money you want to deposit</param>
        public void Deposit(decimal amount)
        {
            if(isopen && amount > 0)
            {
                budget =+ amount;
                Console.WriteLine($"You deposit a {amount}$");
                Console.WriteLine($"Your budget is now {budget}$");
            }
            else if(amount <= 0)
            {
                Console.WriteLine("Amount must be higher than 0!");
            }else if(!isopen)
            {
                Console.WriteLine("You must open account!");
            }
        }
        /// <summary>
        /// Withdrawl money from the account
        /// </summary>
        /// <param name="amount">The amount of money you want to withdrawl</param>
        public void Withdrawl(decimal amount)
        {
            if(isopen && amount <= budget)
            {
                budget -= amount;
                Console.WriteLine($"You withdrawl a {amount}$");
                Console.WriteLine($"Your budget is now {budget}$");
            }
            else if(amount <= 0)
            {
                Console.WriteLine("Amount must be higher than 0!");
            }else if (!isopen)
            {
                Console.WriteLine("You must open account!");
            }else if(amount > budget)
            {
                Console.WriteLine("You don't have enough funds on your account!");
            }
        }
        /// <summary>
        /// This method closes an account
        /// </summary>
        public void Close()
        {
            Console.WriteLine("For closing account you need to tell us your name and last name");
            var parts = Console.ReadLine().Split(' ');
            parts[0].ToLower().Trim();
            parts[0] = String.Concat(parts[0].Where(c => Char.IsWhiteSpace(c))); //Deletes empty spaces from string

            parts[1].ToLower().Trim();
            parts[1] = String.Concat(parts[1].Where(c => Char.IsWhiteSpace(c)));
            Console.WriteLine("Now we need your birthday date in the format 'DD-MM-YYYY' ");
            var dob = Console.ReadLine().Split('-');
            DateTime birthday = new DateTime(int.Parse( dob[2]), int.Parse( dob[1]), int.Parse( dob[0]));

            int age = DateTime.Now.Year - birthday.Year;
            if (parts[0] == name && parts[1] == lastname && age == Age)
            {
                Console.WriteLine("Your data is correct. We will withdrawl all your money before closing the account \n");
                isopen = false;

                if(budget  > 0)
                {
                    Console.WriteLine($"The amount of widthdrawl is {budget}$");
                    budget = 0;
                    Console.WriteLine("Your account is closed. Thank you");
                }else if(budget == 0)
                {
                    Console.WriteLine("You don't have any funds on your account, and we closed it. Thank you");
                }
            }
            else
            {
                Console.WriteLine("Incorrect data. We didn't close the account");
            }
            
        }
        /// <summary>
        /// This constructor creates the account
        /// </summary>
        /// <param name="name">your name</param>
        /// <param name="lastname"> your last name</param>
        /// <param name="day_ofBirth">day can't be higher than 31</param>
        /// <param name="month_ofBirth">month can't be higher than 12</param>
        /// <param name="year_ofBirth">can't be higher than the current year</param>
        public BankAccount(string name, string  lastname, int day_ofBirth, int month_ofBirth, int year_ofBirth)
        {
            Name = name.ToLower().Trim();
            LastName = lastname.ToLower().Trim();
            Name = String.Concat(Name.Where(c => Char.IsWhiteSpace(c)));
            LastName = String.Concat(LastName.Where(c => Char.IsWhiteSpace(c)));

            DateTime date_of_birth = new DateTime(year_ofBirth,month_ofBirth,day_ofBirth);

            int age = DateTime.Now.Year - date_of_birth.Year;
            
            Age = age;

            if (DateTime.Now < date_of_birth)
            {
                throw new ArgumentException("Wrong date");
            }
            else if (age < 18)
            {
                Console.WriteLine("You are too young to open bank account");
            }
            else
            {
                Console.WriteLine("Your account is open");
                isopen = true;
                budget = 0;
            }

        }
        /// <summary>
        /// Empty constructor
        /// </summary>
        public BankAccount() { }
    }
}
