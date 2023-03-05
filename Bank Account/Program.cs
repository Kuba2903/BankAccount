namespace Bank_Account
{
    class Program
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bankAccount.Open();

            bankAccount.Deposit(200);
            bankAccount.Withdrawl(50);

            Console.WriteLine(bankAccount.Budget);
        }
    }
}