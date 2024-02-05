using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;

namespace BankingSystem.RepositoryDB
{
    internal interface IBankDBRepository
    {
        public void CreateAccountDB (CustomerDB customerDB,String accType,float balance);
        public List<AccountDB> ListAccounts();

        public float CalculateInterest(int accountNumber);

         
    }
}
