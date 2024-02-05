using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;
using BankingSystem.Repository;
using BankingSystem.RepositoryDB;
using BankingSystem.ExceptionsDB;
using BankingSystem.Utility;
using Microsoft.Data.SqlClient;


namespace BankingSystem.ServiceDB
{
    internal class BankDBServiceProviderImpl:CustomerServiceProviderImpl,IBankServiceProviderDB
    {
        List<AccountDB> accounts;
        List<TransactionDB> transactions;
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        readonly IBankDBRepository _bankDBRepository;
        public BankDBServiceProviderImpl()
        {
            _bankDBRepository = new BankRepositoryImpl();
        }
        public void CreateAccountDB(string acType)
        {
            CustomerDB customerDB = new CustomerDB();
            Console.WriteLine("Enter Customer Id:");
            customerDB.CustomerId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter Customer First Name:");
            customerDB.FirstName = Console.ReadLine();
            Console.WriteLine("enter Customer Last Name:");
            customerDB.LastName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth:");
            customerDB.DateOfBirth=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer Email:");
            customerDB.Email = Console.ReadLine();
            Console.WriteLine("Enter Customer Phone Number:");
            customerDB.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Address:");
            customerDB.Address = Console.ReadLine();
            Console.WriteLine("Enter Initial Balance");
            float balance=float.Parse(Console.ReadLine());

            if (acType == "savings")
            {
                while (balance < 500)
                {
                    Console.WriteLine("Savings Account Needs a minimum Balance of 500. Try Again.");
                    balance=float.Parse(Console.ReadLine());
                }
            }
            _bankDBRepository.CreateAccountDB(customerDB,acType,balance);

        }
        public void ListAccounts()
        {
            List<AccountDB> accountDBs = _bankDBRepository.ListAccounts();
            if(accountDBs!=null)
            {
                foreach(AccountDB accountDB in accountDBs)
                {
                    Console.WriteLine($"Account Id:{accountDB.AccountNumber}\nAccount Type:{accountDB.AccountType}\nAccount Balance:{accountDB.AccountBalance}\n");
                    Console.WriteLine($"Customer Id:{accountDB.Customer.CustomerId}\nCustomer Name:{accountDB.Customer.FirstName + ' ' + accountDB.Customer.LastName}");
                    Console.WriteLine($"Customer DateOfBirth:{accountDB.Customer.DateOfBirth.Date.ToShortDateString()}\nCustomer Email:{accountDB.Customer.Email}\nCustomer Phone Number:{accountDB.Customer.PhoneNumber}\nCustomer Address:{accountDB.Customer.Address}\n\n");
                }
            }
            else
            {
                throw new NullPointerException("No Accounts");
            }
        }
        public void CalculateInterest()
        {
            try
            {
                Console.WriteLine("Enter Account Number to Calculate Interest of:");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                float interest = _bankDBRepository.CalculateInterest(accountNumber);
                if (interest == -2)
                {
                    Console.WriteLine("No Interest for Current Account.");
                }
                else
                {
                    Console.WriteLine($"Interest for account number {accountNumber} is Rs.{interest} ");
                }
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
