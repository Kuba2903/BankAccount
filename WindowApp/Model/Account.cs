using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowApp.Model
{
    public class Account
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

        private string pesel;

        public string Pesel
        {
            get { return pesel; }
        }
    }
}
