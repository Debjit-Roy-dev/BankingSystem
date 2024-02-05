using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;


namespace BankingSystem.RepositoryDB
{
    internal interface ICustomerDBRepository
    {
        public float GetAccountDBBalance(long accountNumber);
        public float Deposit(long accountNumber, float amount);

        public float Withdraw(long accountNumber, float amount);

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount);

        public AccountDB GetAccountDBDetails(long accountNumber);

        public List<TransactionDB> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate);

       
    }
}
