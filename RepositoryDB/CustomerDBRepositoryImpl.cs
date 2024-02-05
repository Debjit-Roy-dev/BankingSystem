using BankingSystem.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingSystem.ModelDB;
using System.Data.Common;
using BankingSystem.ExceptionsDB;

namespace BankingSystem.RepositoryDB
{
    internal class CustomerDBRepositoryImpl:ICustomerDBRepository
    {
        public string connectionString = DBConnUtil.GetConnectionString();
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;

        public CustomerDBRepositoryImpl()
        {
            sqlconnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }
        public float GetAccountDBBalance(long accountNumber)
        {
            try
            {
                cmd.CommandText = "select balance from Accounts where account_id=@accountNumber;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber",accountNumber);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                float balance;
                if (reader.Read())
                {
                    balance = Convert.ToSingle(reader["balance"]);
                    sqlconnection.Close();
                    return balance;
                }
                else
                {
                sqlconnection.Close();
                throw new AccountNotFoundException("No such Account Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            return -1;
        }
        public float Deposit(long accountNumber, float amount)
        {
            try
            {
                cmd.CommandText = "select Top 1 transaction_id from Transactions order by transaction_id desc";
                cmd.Connection = sqlconnection;
                sqlconnection.Open ();
                SqlDataReader reader1 = cmd.ExecuteReader();
                int transactionId = -1;
                if (reader1.Read())
                {
                    transactionId = (int)reader1["transaction_id"];
                }
                sqlconnection.Close();
                cmd.CommandText = "update Accounts set balance=balance+@amount  where account_id=@accountNumber;"
                    +"select balance from Accounts where account_id=@accountNumber;"+"insert into Transactions values(@transactionId,@accountNumber,@transactionType,@amount,@transactionDate)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@transactionId", transactionId+1);
                cmd.Parameters.AddWithValue("transactionType", "deposit");
                cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);

                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                float balance;
                if (reader.Read())
                {
                    balance = Convert.ToSingle(reader["balance"]);
                    sqlconnection.Close();
                    return balance;

                }
                else
                {
                    sqlconnection.Close();

                    throw new AccountNotFoundException("No such Account Found.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            return -1;
        }

        public float Withdraw(long accountNumber, float amount)
        {
            try
            {
                cmd.CommandText = "select Top 1 transaction_id from Transactions order by transaction_id desc";
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                int transactionId = -1;
                if (reader1.Read())
                {
                    transactionId = (int)reader1["transaction_id"];
                }
                sqlconnection.Close();
                cmd.CommandText = "select balance,account_type from Accounts where account_id=@accountNumber;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                float balance=-1;
                float newbalance = -1;
                string actype="";
                if (reader.Read())
                {
                    balance = Convert.ToSingle(reader["balance"]);
                    newbalance = balance;
                    actype = (string)reader["account_type"];
                    sqlconnection.Close();
                    if (actype == "savings")
                    {
                        if (balance - amount >= 500)
                        {
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@accountNumber;"
                            + "insert into Transactions values(@transactionId,@accountNumber,@transactionType,@amount,@transactionDate);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@transactionId", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionType", "withdraw");
                            cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);
                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            

                            int depositStatus = cmd.ExecuteNonQuery();
                            if(depositStatus>0)
                                return balance-amount;
                            else
                            {

                                
                                sqlconnection.Close();

                                throw new AccountNotFoundException("No such Account Found.");
                            }
                        }
                        else
                        {
                            
                            sqlconnection.Close();
                            throw new InsufficientFundException("Have to Maintain minimum Balance.Can't Withdraw.");
                            
                            
                        }
                    }
                    else if (actype == "current")
                    {
                        if (amount < balance + CurrentAccountDB.OverDraftLimit)
                        {
                            
                            
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@accountNumber;"
                            + "insert into Transactions values(@transactionId,@accountNumber,@transactionType,@amount,@transactionDate);"
                            +"select balance from Accounts where account_id=@accountNumber;";

                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@transactionId", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionType", "withdraw");
                            cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);
                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            SqlDataReader reader2 = cmd.ExecuteReader();

                            if (reader2.Read())
                            {
                                newbalance = Convert.ToSingle(reader2["balance"]);
                                sqlconnection.Close();
                                return newbalance;

                            }
                            else
                            {

                                
                                sqlconnection.Close();

                                throw new AccountNotFoundException("No such Account Found.");
                            }
                        }
                        else
                        {
                            
                            sqlconnection.Close();
                            throw new OverdraftLimitExceededException("Overdraft Limit exceeded.Can't Withdraw.");
                            
                        
                        }
                    }
                    else
                    {
                        if (balance >= amount )
                        {
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@accountNumber;"
                            + "insert into Transactions values(@transactionId,@accountNumber,@transactionType,@amount,@transactionDate);"
                            + "select balance from Accounts where account_id=@accountNumber";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@transactionId", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionType", "withdraw");
                            cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);
                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            SqlDataReader reader2 = cmd.ExecuteReader();

                            if (reader2.Read())
                            {
                                newbalance = Convert.ToSingle(reader2["balance"]);
                                sqlconnection.Close();
                                return newbalance;

                            }
                            else
                            {
                                
                                
                                sqlconnection.Close();

                                throw new AccountNotFoundException("No such Account Found.");
                            }
                        }
                        else
                        {
                            
                            sqlconnection.Close();
                            throw new InsufficientFundException("Insufficient Balance.Can't Withdraw.");

                            
                            
                        }
                    }
                }
                else
                {
                    sqlconnection.Close();
                    throw new AccountNotFoundException("No Such Account.");
                   
                }

                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error Occured:{ex.Message}");
                return -2000;
            }
            
        }

        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            try
            {
                cmd.CommandText = "select Top 1 transaction_id from Transactions order by transaction_id desc";
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader1 = cmd.ExecuteReader();
                int transactionId = -1;
                if (reader1.Read())
                {
                    transactionId = (int)reader1["transaction_id"];
                }
                sqlconnection.Close();
                cmd.CommandText = "select balance,account_type from Accounts where account_id=@fromAccountNumber;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fromAccountNumber", fromAccountNumber);
                
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                float balance = -1;
                
                string actype = "";
                if (reader.Read())
                {
                    balance = Convert.ToSingle(reader["balance"]);
                    actype = (string)reader["account_type"];
                    sqlconnection.Close();
                    if (actype == "savings")
                    {
                        if (balance - amount >= 500)
                        {
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@fromAccountNumber;"
                            + "insert into Transactions values(@transactionId1,@fromAccountNumber,@transactionType,@amount,@transactionDate);"
                            + "update Accounts set balance=balance+@amount where account_id=@toAccountNumber;"
                            + "insert into Transactions values(@transactionId2,@toAccountNumber,@transactionType,@amount,@transactionDate);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@fromAccountNumber", fromAccountNumber);
                            cmd.Parameters.AddWithValue("@toAccountNumber", toAccountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("transactionId1", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionId2", transactionId + 2);
                            cmd.Parameters.AddWithValue("transactionType", "transfer");
                            cmd.Parameters.AddWithValue("transactionDate",DateTime.Now);

                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            int transferStatus = cmd.ExecuteNonQuery();
                            sqlconnection.Close();
                            if(transferStatus > 0)
                            {
                                Console.WriteLine("Transaction Complete.");
                            }
                            else
                            {
                                throw new AccountNotFoundException("No such Account");
                            }
                            
                        }
                        else
                        {
                            sqlconnection.Close();
                            throw new InsufficientFundException("Have to Maintain minimum Balance.Can't Withdraw.");
                            
                            
                        }
                    }
                    else if (actype == "current")
                    {
                        if (amount < balance + CurrentAccountDB.OverDraftLimit)
                        {
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@fromAccountNumber;"
                            + "insert into Transactions values(@transactionId1,@fromAccountNumber,@transactionType,@amount,@transactionDate);"
                            + "update Accounts set balance=balance+@amount where account_id=@toAccountNumber;"
                            + "insert into Transactions values(@transactionId2,@toAccountNumber,@transactionType,@amount,@transactionDate);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@fromAccountNumber", fromAccountNumber);
                            cmd.Parameters.AddWithValue("@toAccountNumber", toAccountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("transactionId1", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionId2", transactionId + 2);
                            cmd.Parameters.AddWithValue("transactionType", "transfer");
                            cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);
                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            int addArtworkStatus = cmd.ExecuteNonQuery();
                            sqlconnection.Close();
                            if (addArtworkStatus > 0)
                            {
                                Console.WriteLine("Transaction Complete.");
                            }
                            else
                            {
                                throw new AccountNotFoundException("No such Account");
                                
                            }

                           
                        }
                        else
                        {
                            sqlconnection.Close();
                            throw new OverdraftLimitExceededException("Overdraft Limit exceeded.Can't Withdraw.");
                            
                            
                        }
                    }
                    else
                    {
                        if (balance >= amount)
                        {
                            cmd.CommandText = "update Accounts set balance=balance-@amount  where account_id=@fromAccountNumber;"
                            + "insert into Transactions values(@transactionId1,@fromAccountNumber,@transactionType,@amount,@transactionDate);"
                            + "update Accounts set balance=balance+@amount where account_id=@toAccountNumber;"
                            + "insert into Transactions values(@transactionId2,@toAccountNumber,@transactionType,@amount,@transactionDate);";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@fromAccountNumber", fromAccountNumber);
                            cmd.Parameters.AddWithValue("@toAccountNumber", toAccountNumber);
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("transactionId1", transactionId + 1);
                            cmd.Parameters.AddWithValue("transactionId2", transactionId + 2);
                            cmd.Parameters.AddWithValue("transactionType", "transfer");
                            cmd.Parameters.AddWithValue("transactionDate", DateTime.Now);
                            cmd.Connection = sqlconnection;
                            sqlconnection.Open();
                            int transferStatus = cmd.ExecuteNonQuery();
                            sqlconnection.Close();
                            if (transferStatus > 0)
                            {
                                Console.WriteLine("Transaction Complete.");
                            }
                            else
                            {
                                throw new AccountNotFoundException("No such Account Found.");
                            }
                        }
                        else
                        {
                            throw new InsufficientFundException("Insufficient Balance");
                            

                        }
                    }
                }
                else
                {
                    sqlconnection.Close();

                    throw new AccountNotFoundException("No such Account Found.");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error Occured:{ex.Message}");
            }
            
        }

        public AccountDB GetAccountDBDetails(long accountNumber)
        {
            try
            {
                AccountDB accountDB = new AccountDB();
                CustomerDB customerDB = new CustomerDB();
                
                cmd.CommandText = "select * from Accounts join Customers on Accounts.customer_id=Customers.customer_id where account_id = @accountNumber";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                sqlconnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        accountDB.AccountNumber = accountNumber;
                        accountDB.AccountType = (string)reader["account_type"];
                        accountDB.AccountBalance= Convert.ToSingle(reader["balance"]);
                        customerDB.CustomerId = (int)reader["customer_id"];
                        customerDB.FirstName = (string)reader["first_name"];
                        customerDB.LastName = (string)reader["last_name"];
                        customerDB.DateOfBirth = (DateTime)reader["date_of_birth"];
                        customerDB.Email = (string)reader["email"];
                        customerDB.PhoneNumber = (string)reader["phone_number"];
                        customerDB.Address = (string)reader["address"];
                        accountDB.Customer = customerDB;
                        sqlconnection.Close();
                        return accountDB;
                    }
                    else
                    {
                        sqlconnection.Close();
                        throw new AccountNotFoundException("No such Account Found.");
                        
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An Error Occurred.{ex.Message}"); 
                return null;
            }
        }

        public List<TransactionDB> GetTransactions(long accountNumber, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<TransactionDB> transactions = new List<TransactionDB>();
                cmd.CommandText = "select * from Transactions join Accounts on Transactions.account_id=Accounts.account_id join Customers on Accounts.customer_id = Customers.customer_id where Transactions.account_id = @accountNumber and (transaction_date between @fromDate and @toDate)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    TransactionDB transactionDB = new TransactionDB();
                    AccountDB accountDB = new AccountDB();
                    CustomerDB customerDB = new CustomerDB();
                    transactionDB.TransactionId = (int)reader["transaction_id"];
                    transactionDB.TransactionType = (string)reader["transaction_type"];
                    transactionDB.Amount = Convert.ToSingle(reader["amount"]);
                    transactionDB.TransactionDate = (DateTime)reader["transaction_date"];
                    accountDB.AccountNumber = (int)reader["account_id"];
                    accountDB.AccountType = (string)reader["account_type"];
                    accountDB.AccountBalance = Convert.ToSingle(reader["balance"]);
                    customerDB.CustomerId = (int)reader["customer_id"];
                    customerDB.FirstName = (string)reader["first_name"];
                    customerDB.LastName = (string)reader["last_name"];
                    customerDB.DateOfBirth = (DateTime)reader["date_of_birth"];
                    customerDB.Email = (string)reader["email"];
                    customerDB.PhoneNumber = (string)reader["phone_number"];
                    customerDB.Address = (string)reader["address"];
                    accountDB.Customer = customerDB;
                    transactionDB.AccountDB = accountDB;
                    transactions.Add(transactionDB);
                    count++;

                }
                sqlconnection.Close();
                if (count == 0)
                {
                    Console.WriteLine("No Transaction in between these dates in this account");
                    return null;
                }
                else { return transactions; }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
