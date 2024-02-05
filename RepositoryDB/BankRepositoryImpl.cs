using BankingSystem.model;
using BankingSystem.ModelDB;
using BankingSystem.Utility;
using Microsoft.Data.SqlClient;
using BankingSystem.ExceptionsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.RepositoryDB
{
    internal class BankRepositoryImpl:IBankDBRepository
    {
        public string connectionString = DBConnUtil.GetConnectionString();
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public BankRepositoryImpl()
        {
            sqlconnection = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        public void CreateAccountDB(CustomerDB customerDB, String accType, float balance)
        {
            try
            {
                AccountDB accountDB = new AccountDB(accType, balance, customerDB);

                sqlconnection.Open();
                cmd.CommandText = "Insert into Customers values(@customer_id,@first_name,@last_name,@date_of_birth,@email,@phone_number,@address)"
                    + "Insert into Account values(@account_id,@customer_id,@account_type,@balance)";
                cmd.Connection = sqlconnection;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@customer_id", customerDB.CustomerId);
                cmd.Parameters.AddWithValue("@first_name", customerDB.FirstName);
                cmd.Parameters.AddWithValue("@last_name", customerDB.LastName);
                cmd.Parameters.AddWithValue("@date_of_birth", customerDB.DateOfBirth);
                cmd.Parameters.AddWithValue("@email", customerDB.Email);
                cmd.Parameters.AddWithValue("@phone_number", customerDB.PhoneNumber);
                cmd.Parameters.AddWithValue("@account_id", accountDB.AccountNumber);
                cmd.Parameters.AddWithValue("@account_type", accountDB.AccountType);
                cmd.Parameters.AddWithValue("@balance", accountDB.AccountBalance);
                int addAccountStatus = cmd.ExecuteNonQuery();
                sqlconnection.Close();
                if (addAccountStatus > 0)
                {
                    Console.WriteLine("Account Added Successfuly.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

        public List<AccountDB> ListAccounts()
        {
            try
            {
                List<AccountDB> accountDBs = new List<AccountDB>();
                sqlconnection.Open();
                cmd.CommandText = "select * from Accounts join Customers on Accounts.customer_id=Customers.customer_id";
                cmd.Connection=sqlconnection;
                SqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    AccountDB accountDB = new AccountDB();
                    CustomerDB customerDB = new CustomerDB();
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
                    accountDBs.Add(accountDB);
                    count++;
                }
                sqlconnection.Close();
                if(count == 0)
                {
                    return null;
                    
                }
                else
                {
                    return accountDBs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
            return null;
        }

        public float CalculateInterest(int accountNumber)
        {
            try
            {
                float balance = -1;
                string acType = "";
                sqlconnection.Open();
                cmd.CommandText = "select balance,account_type from Accunts where account_id=@accountNumber";
                cmd.Connection = sqlconnection;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        balance = (float)reader["balance"];
                        acType = (string)reader["account_type"];
                        sqlconnection.Close();
                    }
                    else
                    {
                        sqlconnection.Close();
                        throw new AccountNotFoundException("No Such Account");
                    }
                    if (acType == "current")
                    {
                        return -2;
                    }
                    else if (acType == "savings")
                    {
                        return balance * SavingsAccountDB.InterestRate;
                    }
                    else
                    {
                        return balance * ZeroBalanceAccountDB.InterestRate;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
            return -1;
        }
    }
}
