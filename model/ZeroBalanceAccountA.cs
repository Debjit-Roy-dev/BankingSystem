using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.Bean;

namespace BankingSystem.model
{
    internal class ZeroBalanceAccountA :AccountA
    {
        ZeroBalanceAccountA() { }
        public ZeroBalanceAccountA(string accountType, float accountBalance, Customer customer) : base(accountType, accountBalance, customer)
        {

        }
    }
}
