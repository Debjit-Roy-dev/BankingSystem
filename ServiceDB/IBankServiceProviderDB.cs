using BankingSystem.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ServiceDB
{
    internal interface IBankServiceProviderDB
    {
        void CreateAccountDB(string acType);
        void ListAccounts();
        void CalculateInterest();
    }
}
