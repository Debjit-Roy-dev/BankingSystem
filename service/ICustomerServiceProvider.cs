using BankingSystem.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.service
{
    internal interface ICustomerServiceProvider
    {
        public float Get_Account_Balance(long accNo);
        public float Deposit(long accNo, float amount);
        public float Withdraw(long accNo, float amount);
        public void Transfer(long fromAccountNo, long toAccountNo, float amount);
        public AccountA GetAccountDetails(long accountNo);
        
    }
}
