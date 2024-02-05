using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.model
{
    internal class SavingsAccount : Account
    {
        public double InterestRate{ get; set; }
        public SavingsAccount(int accountNumber, string accountType, double accountBalance,double interestRate) : base(accountNumber, accountType, accountBalance)
        {
            InterestRate = interestRate;
        }
        public override void Calculate_Interest()
        {
            double interest = (AccountBalance * InterestRate) / 100;
            AccountBalance += interest;
            Console.WriteLine($"Interest Deposited.Available Balance Rs.{AccountBalance} .");
        }
    }
}
