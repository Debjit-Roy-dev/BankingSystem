using BankingSystem.model;

namespace BankingSystem.Bean
{
    internal class AccountA
    {
        public long AccountNumber { get; set; }

        public string AccountType { get; set; }

        public float AccountBalance { get; set; }

        public Customer Customer { get; set; }

        public AccountA() { }



        public static long Acnum { get; set; } = 1001;
        public AccountA(string accountType, float accountBalance, Customer customer)
        {
            AccountNumber = Acnum++;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Customer = customer;
        }
        public AccountA(long accountNumber, string accountType, float accountBalance, Customer customer)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountBalance = accountBalance;
            Customer = customer;
        }








    }
}
