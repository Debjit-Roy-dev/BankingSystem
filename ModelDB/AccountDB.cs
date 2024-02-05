using BankingSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class AccountDB
    {
        public long AccountNumber { get; set; }

        public string AccountType { get; set; }

        public float AccountBalance { get; set; }

        public CustomerDB Customer { get; set; }

        
        public static long lastAccNo { get; set; } = 1012;

        public AccountDB() { }

        public AccountDB( string accountType, float accountBalance, CustomerDB customer)
        {
            AccountNumber = lastAccNo++;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Customer = customer;
        }

    }
}
