namespace Bank_Account
{
    class Program
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.Open();

            Console.WriteLine(bankAccount.IsBlocked);
        }
    }
}