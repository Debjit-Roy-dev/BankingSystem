namespace BankingSystem.model
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string AccountType{ get; set; }

        public double AccountBalance { get; set; }

        public Account() { }
        public Account(int accountNumber, string accountType,double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;
        }

        public void ShowAccountDetails()
        {
            Console.WriteLine($"Account Number :{AccountNumber} .");
            Console.WriteLine($"Account Type :{AccountType} .");
            Console.WriteLine($"Account Balance :{AccountBalance} Rs.");
        }

        public void Deposit (float amount)
        {
            AccountBalance = AccountBalance+amount;
            Console.WriteLine($"Rs.{amount} deposited.");
            Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
        }
        public void Withdraw(float amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Rs.{amount} withdrawn.");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            } else
            {
                Console.WriteLine("Insufficient Balance...");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
        }
        public void Deposit(int amount)
        {
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($"Rs.{amount} deposited.");
            Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
        }
        public void Withdraw(int amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Rs.{amount} withdrawn.");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
            else
            {
                Console.WriteLine("Insufficient Balance...");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
        }

        public void Deposit(double amount)
        {
            AccountBalance = AccountBalance + amount;
            Console.WriteLine($"Rs.{amount} deposited.");
            Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
        }
        public virtual void Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Rs.{amount} withdrawn.");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
            else
            {
                Console.WriteLine("Insufficient Balance...");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
        }
        public virtual void Calculate_Interest()
        {
            double interest = (AccountBalance * 4.5) / 100;
            AccountBalance += interest;
            Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
        }
        


    }
}
