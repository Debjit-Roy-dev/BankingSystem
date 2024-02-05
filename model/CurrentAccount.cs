using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.model
{
    internal class CurrentAccount : Account
    {
        public double OverDraftLimit { get; set; }
        public CurrentAccount(int accountNumber, string accountType, double accountBalance, double overDraftLimit) : base(accountNumber, accountType, accountBalance)
        {
            OverDraftLimit = overDraftLimit;
        }

        public override void Calculate_Interest()
        {
            
            Console.WriteLine("No Interest for current Account.");
        }

        public override void  Withdraw(double amount)
        {
            if (AccountBalance >= amount)
            {
                AccountBalance = AccountBalance - amount;
                Console.WriteLine($"Rs.{amount} withdrawn.");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
            else if (OverDraftLimit>amount-AccountBalance)
            {
                
                double OverDraft = amount - AccountBalance;
                AccountBalance = 0;
                Console.WriteLine($"Account Balance zero. Rs.{OverDraft} is overdrafted.");

            }
            else
            {
                Console.WriteLine("Insufficient Balance.Over draft limit exceeded.");
                Console.WriteLine($"Available Balance Rs.{AccountBalance} .");
            }
        }

    }
}
