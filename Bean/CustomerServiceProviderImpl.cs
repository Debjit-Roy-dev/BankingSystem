using BankingSystem.Bean;
using BankingSystem.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Repository
{
    internal class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        public List<AccountA> account = new List<AccountA>();
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
                    if (acc.AccountType == "Savings")
                    {
                        if (acc.AccountBalance - amount < 500)
                        {
                            Console.WriteLine("Have to maintain Minimum Balance . Withdraw Cancelled.");
                            return acc.AccountBalance;
                        }
                    }
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
