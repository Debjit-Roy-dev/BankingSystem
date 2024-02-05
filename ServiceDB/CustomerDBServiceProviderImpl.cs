using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;
using BankingSystem.RepositoryDB;
using BankingSystem.ExceptionsDB;

namespace BankingSystem.ServiceDB
{
    internal class CustomerDBServiceProviderImpl : ICustomerDBServiceProvider
    {
        readonly ICustomerDBRepository _customerDBRepository;
        public CustomerDBServiceProviderImpl()
        {
            _customerDBRepository= new CustomerDBRepositoryImpl();
        }
        public void GetAccountBalance()
        {
            try
            {
                Console.WriteLine("Enter Account Number to GetBalance");
                long acno = Convert.ToInt64(Console.ReadLine());
                float balance = _customerDBRepository.GetAccountDBBalance(acno);
                Console.WriteLine($"Balance for Account Number  {acno} is Rs.{balance}.");
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void Deposit()
        {
            try
            {
                Console.WriteLine("Enter Account Number to Deposit:");
                long accno = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Amount To Deposit:");
                float amount = float.Parse(Console.ReadLine());
                float balance = _customerDBRepository.Deposit(accno, amount);
                Console.WriteLine($"Current Balance of Account with account Number {accno} is Rs.{balance}");
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void Withdraw()
        {
            try
            {
                Console.WriteLine("Enter Account Number to Withdraw:");
                long accno = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Amount To Withdraw:");
                float amount = float.Parse(Console.ReadLine());
                float balance = _customerDBRepository.Withdraw(accno, amount);
                if (balance >= 0)
                {
                    Console.WriteLine($"Current Balance of Account with account Number {accno} is Rs.{balance}");

                }
                else if (balance == -2000)
                {

                }
                else
                {
                    Console.WriteLine($"Current Balance of Account with account Number {accno} is zero.Rs.{Math.Abs(balance)} overdrafted");

                }
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch(OverdraftLimitExceededException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public void Transfer()
        {
            try
            {
                Console.WriteLine("Enter Account Number to Transfer From:");
                long fromaccno = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Account Number to Transfer To:");
                long toaccno = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Amount To Transfer:");
                float amount = float.Parse(Console.ReadLine());
                _customerDBRepository.Transfer(fromaccno, toaccno, amount);

                float frombalance = _customerDBRepository.GetAccountDBBalance(fromaccno);
                Console.WriteLine($"Current Balance in Account {fromaccno} is Rs.{frombalance}.");
                float tobalance = _customerDBRepository.GetAccountDBBalance(toaccno);
                Console.WriteLine($"Current Balance in Account {toaccno} is Rs.{tobalance}.");

            }

            catch (AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (InsufficientFundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch(OverdraftLimitExceededException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void GetAccountDetails()
        {
            try
            {
                Console.WriteLine("Enter Account Number to get its Details:");
                long acno = Convert.ToInt64(Console.ReadLine());
                AccountDB accountDB = _customerDBRepository.GetAccountDBDetails(acno);
                if (accountDB != null)
                {
                    Console.WriteLine($"Account Id:{accountDB.AccountNumber}\nAccount Type:{accountDB.AccountType}\nAccount Balance:{accountDB.AccountBalance}\n");
                    Console.WriteLine($"Customer Id:{accountDB.Customer.CustomerId}\nCustomer Name:{accountDB.Customer.FirstName + ' ' + accountDB.Customer.LastName}");
                    Console.WriteLine($"Customer DateOfBirth:{accountDB.Customer.DateOfBirth.Date.ToShortDateString()}\nCustomer Email:{accountDB.Customer.Email}\nCustomer Phone Number:{accountDB.Customer.PhoneNumber}\nCustomer Address:{accountDB.Customer.Address}\n\n\n\n");
                }
                else
                {
                    throw new NullPointerException("No Details to show.");
                }
            }
            catch(AccountNotFoundException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        public void GetTransactions()
        {
            Console.WriteLine("Enter Account Number to get Transactions:");
            long acno= Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter search Start Date:");
            DateTime fromDate=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter search End Date:");
            DateTime toDate = DateTime.Parse(Console.ReadLine());
            List<TransactionDB> transactions = _customerDBRepository.GetTransactions(acno,fromDate,toDate);
            if(transactions != null)
            {
                Console.WriteLine("\n\nThe Transactions are:\n\n\n");
                foreach (TransactionDB transactionDB in transactions)
                {
                    AccountDB accountDB = transactionDB.AccountDB;
                    CustomerDB customerDB = transactionDB.AccountDB.Customer;
                    Console.WriteLine($"Transaction Id:{transactionDB.TransactionId}\nTransaction Type:{transactionDB.TransactionType}\nTransaction Amount:Rs.{transactionDB.Amount}\nTransaction Date:{transactionDB.TransactionDate}");
                    Console.WriteLine($"Account Number:{accountDB.AccountNumber}\nAccount Type:{accountDB.AccountType}\nAccount Balance:{accountDB.AccountBalance}\n");
                    Console.WriteLine($"Customer Id:{customerDB.CustomerId}\nCustomer Name:{customerDB.FirstName + ' ' + accountDB.Customer.LastName}\nCustomer Email:{customerDB.Email}\n\n\n\n");
                }
            }
            else
            {
                throw new NullPointerException("No Such Account.");
            }

        }
    }
}
