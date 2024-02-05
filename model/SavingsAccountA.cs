using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Bean;

namespace BankingSystem.model
{
    internal class SavingsAccountA : AccountA
    {
        public double InterestRate { get; set; } = 7.5;
        
        public SavingsAccountA() { }

        public SavingsAccountA(string accountType, float accountBalance, Customer customer) :base(accountType,accountBalance,customer)
        {
            
        }

    }
}
