using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ExceptionsDB
{
    internal class OverdraftLimitExceededException:ApplicationException
    {
        public OverdraftLimitExceededException() { }
        public OverdraftLimitExceededException(string message) : base(message)
        {

        }
    }
}
