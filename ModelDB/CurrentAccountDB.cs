using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class CurrentAccountDB : AccountDB
    {
        public static float OverDraftLimit { get; set; } = 1000f;

        public CurrentAccountDB() { }

        public CurrentAccountDB(string accountType, float accountBalance, CustomerDB customer) : base(accountType, accountBalance, customer)
        {
            
        }

    }
}
