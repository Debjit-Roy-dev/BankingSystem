using BankingSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class ZeroBalanceAccountDB : AccountDB
    {
        public ZeroBalanceAccountDB() { }
        public static float InterestRate { get; set; } = 3.5f;
        public ZeroBalanceAccountDB(string accountType, float accountBalance, CustomerDB customer) : base(accountType, accountBalance, customer)
        {
            
        }
    }

}
