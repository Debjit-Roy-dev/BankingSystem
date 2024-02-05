using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class TransactionDB
    {
        public int TransactionId { get; set; }
        public AccountDB AccountDB { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionType { get; set; }
        public float Amount { get; set; }

        public TransactionDB() { }

        public TransactionDB(int transactionId,AccountDB accountDB,DateTime dateTime,string transactionType,float amount)
        {
            TransactionId = transactionId;
            AccountDB = accountDB;
            TransactionDate = dateTime;
            TransactionType = transactionType;
            Amount = amount;
        }


    }
}
