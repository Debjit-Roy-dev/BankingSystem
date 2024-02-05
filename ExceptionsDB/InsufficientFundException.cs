using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ExceptionsDB
{
    internal class InsufficientFundException:ApplicationException
    {
        public InsufficientFundException() { }
        public InsufficientFundException(string message) : base(message)
        {

        }
    }
}
