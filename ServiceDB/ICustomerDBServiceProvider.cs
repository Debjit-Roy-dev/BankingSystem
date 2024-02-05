using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;

namespace BankingSystem.ServiceDB
{
    internal interface ICustomerDBServiceProvider
    {
        void GetAccountBalance();
        void Deposit();
        void Withdraw();
        void Transfer();
        void GetAccountDetails();
        void GetTransactions();

    }
}
