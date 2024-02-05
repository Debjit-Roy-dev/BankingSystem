
namespace BankingSystem.model
{
    internal class SavingsAccountAbs : BankAccount
    {
        public double InterestRate { get; set; }
        public SavingsAccountAbs(int AccountNumber, string customerName, double balance, double interestRate) : base(AccountNumber, customerName, balance)
        {
            InterestRate = interestRate;
        }

        public override void Calculate_Interest()
        {
            double interest = Balance * InterestRate / 100;
            Console.WriteLine($"Interest for Rs,{Balance} at {InterestRate}% rate of interest is {interest}.");
            Balance= Balance+interest;
            Console.WriteLine($"curent balance is {Balance}.");
        }
    }
       
}
