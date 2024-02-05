using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Bean;

namespace BankingSystem.model
{
    internal class Bank
    {
        public List<AccountA> account = new List<AccountA>();
        public void Create_Account(Customer customer,  string accType, float balance)
        {
            AccountA acc = new AccountA( accType, balance, customer);
            account.Add(acc);
            Console.WriteLine("Account added.");
        }
        public float Get_Account_Balance(long accNo)
        {
            foreach (AccountA acc in account)
            {

                if (acc.AccountNumber == accNo)
                {
                    return acc.AccountBalance;
                }
            }

            return -1;
        }

        public float Deposit(long accNo, float amount)
        {
            foreach (AccountA acc in account)
            {
                if (acc.AccountNumber == accNo)
                {
                    acc.AccountBalance += amount;
                    return acc.AccountBalance;
                }
            }
            return -1;
        }

        public float Withdraw(long accNo, float amount)
        {
            foreach (AccountA acc in account)
            {
                if (acc.AccountNumber == accNo)
                {
                    acc.AccountBalance -= amount;
                    return acc.AccountBalance;
                }
            }
            return -1;
        }
        public void Transfer(long fromAccountNo, long toAccountNo, float amount)
        {
            bool toacfound = false;
            bool fromacfound = false;
            foreach (AccountA acc in account)
            {
                if (acc.AccountNumber == fromAccountNo)
                {
                    acc.AccountBalance -= amount;
                    fromacfound = true;

                }
                if (acc.AccountNumber == toAccountNo)
                {
                    acc.AccountBalance += amount;
                    toacfound = true;
                }
            }
            if (!(toacfound && fromacfound))
            {
                Console.WriteLine("No Such Account Found.");
            }

        }

        public AccountA GetAccountDetails(long accountNo)
        {
            foreach (AccountA acc in account)
            {
                if (acc.AccountNumber == accountNo)
                {
                    return acc;
                }
            }
            return null;
        }
    }
}
