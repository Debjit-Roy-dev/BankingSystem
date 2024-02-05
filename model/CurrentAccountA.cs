using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Bean;

namespace BankingSystem.model
{
    internal class CurrentAccountA:AccountA
    {
        public double OverDraftiLimit { get; set; } = 1000;
        
        public CurrentAccountA() { }

        public CurrentAccountA(string accountType, float accountBalance, Customer customer) : base(accountType, accountBalance, customer)
        {
            
        }
        
    }
}
