using BankingSystem.Bean;
using BankingSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.service
{
    internal interface IBankServiceProvider
    {
        public void Create_Account(Customer customer, string accType, float balance);

        public void listAccounts();

        public float CalculateInterest(SavingsAccountA a);
    }
}
