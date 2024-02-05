using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class SavingsAccountDB:AccountDB
    {
        public static float InterestRate { get; set; } = 7.5f;

        public SavingsAccountDB() { }   
        public SavingsAccountDB( string accountType, float accountBalance,CustomerDB customer) : base( accountType, accountBalance,customer)
        {
            
        }

    }
}
