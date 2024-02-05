using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.model
{
    internal abstract class BankAccount
    {
        public  int AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        public BankAccount() { }
        public BankAccount(int accountNumber,string customerName, double balance)
        {
            AccountNumber=accountNumber;
            CustomerName=customerName;
            Balance=balance;

        }


        public abstract void Calculate_Interest();
    }
}
