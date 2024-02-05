using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ExceptionsDB
{
    internal class AccountNotFoundException:ApplicationException
    {
        AccountNotFoundException() { }
        public AccountNotFoundException(string message):base(message) 
        {
        
        }
    }
}
