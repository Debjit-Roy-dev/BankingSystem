using BankingSystem.Bean;
using BankingSystem.model;
using BankingSystem.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Repository
{
    
    internal class BankServiceProviderImpl : CustomerServiceProviderImpl,IBankServiceProvider
    {
        
        public List<AccountA> account = new List<AccountA>();
        public HashSet<AccountA> accountSet = new HashSet<AccountA>();
        public Dictionary<int, AccountA> accountDictionary = new Dictionary<int, AccountA>();
        private static int id = 1;
        string BranchName { get; set; }
        string BranchAddress { get; set; }

        public void Create_AccountUsingDictionary(Customer customer, string accType, float balance)
        {
            AccountA acc = new AccountA(accType, balance, customer);
            accountDictionary.Add(id++, acc);

        }
        public void displayDictionaryAccounts()
        {
            foreach (var kvp in accountDictionary)
            {
                AccountA acc = kvp.Value;
                Console.WriteLine($"key:{kvp.Key}\tname:{acc.Customer.FirstName + " " + acc.Customer.LastName}\t" +
                                $" email:{acc.Customer.EmailAddress}\taccountId:{acc.AccountNumber}\t" +
                                $"balance:{acc.AccountBalance}\taccount type:{acc.AccountType}");
            }
        }
        public void Create_AccountUsingSet(Customer customer, string accType, float balance)
        {
            AccountA acc = new AccountA(accType, balance, customer);
            accountSet.Add(acc);

        }
        public void displaySetAccounts()
        {
            foreach (AccountA acc in accountSet)
            {
                Console.WriteLine($"name:{acc.Customer.FirstName + " " + acc.Customer.LastName}\t" +
                                $" email:{acc.Customer.EmailAddress}\taccountId:{acc.AccountNumber}\t" +
                                $"balance:{acc.AccountBalance}\taccount type:{acc.AccountType}");
            }
        }

        public void Create_Account(Customer customer, string accType, float balance)
        {
            AccountA acc = new AccountA(accType, balance, customer);
            account.Add(acc);
            
        }

        public void listAccounts()
        {
            foreach(AccountA acc in account)
            {
                GetAccountDetails(acc.AccountNumber);
            }
        }
        public float CalculateInterest(SavingsAccountA a)
        {
            
                float interest =(float) (a.AccountBalance * a.InterestRate/100);
                return interest;
            
            
        }
    }
}
