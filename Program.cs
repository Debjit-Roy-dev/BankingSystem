using BankingSystem.Bean;
using BankingSystem.model;
using BankingSystem.Repository;
using BankingSystem.ServiceDB;
using BankingSystem.ExceptionsDB;
namespace BankingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region nonDatabaseTasks
            {
                #region task1
                /*Console.WriteLine("Insert Credit Score of Customer:");
                int creditScore=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Insert Annual Income:");
                int annualIncome=Convert.ToInt32(Console.ReadLine());

                if( (annualIncome>=50000 )&&(creditScore>700))
                {
                    Console.WriteLine("Congratulations! You are eligible for loan.");
                }
                else
                {
                    Console.WriteLine("Sorry,You are not eligible for loan.");
                }*/
                #endregion
                #region task2
                /*Console.WriteLine("Choose appropriate option:");
                Console.WriteLine("1.CheckBalance");
                Console.WriteLine("2.Deposit");
                Console.WriteLine("3.Withdraw");
                int choice=Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Balance:");
                int balance = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine($"Your account Balance is {balance}");
                }
                else if(choice==2){
                    Console.WriteLine("Enter Amount to Deposit:");
                    int amount=Convert.ToInt32(Console.ReadLine());
                    int newBalance = balance + amount;
                    Console.WriteLine($"New Balance in account is {newBalance}");
                }
                else if(choice==3)
                {
                    Console.WriteLine("Enter Amount to Withdraw:");
                    int withdrawAmount=Convert.ToInt32(Console.ReadLine());
                    if (withdrawAmount > balance)
                    {
                        Console.WriteLine("Sorry,withdraw amount can not be greater than available balance.");
                        return;
                    }
                    if (withdrawAmount % 100 != 0)
                    {
                        Console.WriteLine("Sorry, Withdrawal amount should be in multiple of 100 or 500.");
                        return;
                    }
                    balance = balance - withdrawAmount;
                    Console.WriteLine($"available balance after withdrawal is {balance}");

                }
                else
                {
                    Console.WriteLine("Wrong Choice.");
                }*/
                #endregion
                #region task3
                /*
                Console.WriteLine("enter number of customers:");
                int num=Convert.ToInt32(Console.ReadLine());    
                for(int i = 0; i < num; i++)
                {
                    Console.WriteLine($"enter initial balance of user {i+1}:");
                    double initial_amount=Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("enter interest rate:");
                    double rateofint = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("enter no of years:");
                    int years=Convert.ToInt32(Console.ReadLine());

                    double future_balance = Math.Round(initial_amount * Math.Pow((1 + (rateofint / 100)),years),2);
                    Console.WriteLine($"future balance for user {i+1} is {future_balance} ");

                }
                Console.ReadLine();
                */
                #endregion
                #region task4
                /*
                int[] accountnumber = { 1234, 4567, 6789 };
                double[] accountbalance= { 1000, 3500, 7850 } ;
                while (true) {
                    Console.WriteLine("enter account number");
                    int acno=Convert.ToInt32(Console.ReadLine());
                    int index= Array.IndexOf(accountnumber,acno);
                    if(index != -1) {
                        double balance = accountbalance[index];
                        Console.WriteLine($"balance of account{acno} is  {balance}.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account number. Try Again...");
                    }
                }

            Console.ReadLine();*/
                #endregion
                #region task5
                /*Console.WriteLine("Create a password for your bank account:");

                string password = Console.ReadLine();

                if (IsPasswordValid(password))
                {
                    Console.WriteLine("Password is valid. Your bank account is now secured!");
                }
                else
                {
                    Console.WriteLine("Invalid password. Please follow the password requirements.");
                }



                static bool IsPasswordValid(string password)
                {

                    if (password.Length < 8)
                    {
                        Console.WriteLine("Password must be at least 8 characters long.");
                        return false;
                    }


                    if (!ContainsUppercaseLetter(password))
                    {
                        Console.WriteLine("Password must contain at least one uppercase letter.");
                        return false;
                    }


                    if (!ContainsDigit(password))
                    {
                        Console.WriteLine("Password must contain at least one digit.");
                        return false;
                    }


                    return true;
                }


                static bool ContainsUppercaseLetter(string password)
                {
                    foreach (char character in password)
                    {
                        if (char.IsUpper(character))
                        {
                            return true;
                        }
                    }
                    return false;
                }

                static bool ContainsDigit(string password)
                {
                    foreach (char character in password)
                    {
                        if (char.IsDigit(character))
                        {
                            return true;
                        }
                    }
                    return false;
                }

                #endregion
                #region task6
                /*
                Console.WriteLine("No of Transactions you want to perform?");
                int num=Convert.ToInt32(Console.ReadLine());
                String[] transactions=new string[num];
                int count = 0;
                while (true)
                {
                    Console.WriteLine("press 1 to do a transaction. press 2 to exit.");
                    int choice=Convert.ToInt32(Console.ReadLine());
                    if(choice == 2)
                    {
                        break;
                    }
                    else if(choice == 1) {

                        Console.WriteLine("1. Deposite      2. Withdraw");
                        int type=Convert.ToInt32(Console.ReadLine());
                        if(type == 1) { 
                            Console.WriteLine("Enter amount to deposite.");
                            double amount=Convert.ToDouble(Console.ReadLine());
                            transactions[count]= ($"Rs.{amount} deposited.");
                            count++;
                        }
                        else if(type == 2) {
                            Console.WriteLine("Enter amount to Withdraw.");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            transactions[count] = ($"Rs.{amount} withdrawn.");
                            count++;
                        }
                        else
                        {
                            Console.WriteLine("Wrong choice. Try again.");
                        }
                    }
                    else {
                        Console.WriteLine("Wrong choice. choose again.");
                    }

                }
                Console.WriteLine("Account Transactions.");
               for(int i=0;i<count;i++){
                    Console.WriteLine(transactions[i]);
                }  

                Console.ReadLine();*/
                #endregion
                #region task7
                /*
                Account ac1 = new Account(787546265, "Savings", 18000);
                ac1.Deposit(7500.50f);
                ac1.Withdraw(2500.50f);
                ac1.Calculate_Interest();*/
                #endregion
                #region task8
                /*
                Console.WriteLine("Choose type of account you want to create. 1.Saving Account. 2.Current Account");
                int choice=Convert.ToInt32(Console.ReadLine());
                Account account = null;
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter Account Number:");
                        int saccno=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter balance:");
                        double sbalance=Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Interest Rate:");
                        double sinterest_rate=Convert.ToDouble(Console.ReadLine());

                        account=new SavingsAccount(saccno,"Savings",sbalance,sinterest_rate);
                        break;
                    case 2:
                        Console.WriteLine("Enter Account Number:");
                        int caccno = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter balance:");
                        double cbalance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter OverDraftLimit:");
                        double overDraft=Convert.ToDouble(Console.ReadLine());

                        account=new CurrentAccount(caccno,"Current",cbalance,overDraft);
                        break;

                    default:
                        Console.WriteLine("Wrong Choice.");
                        return;

                }
                Console.WriteLine("Amount to deposit:");
                double depositAmount=Convert.ToDouble(Console.ReadLine());
                account.Deposit(depositAmount);

                Console.WriteLine("Amount to withdraw:");
                double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(withdrawAmount);

                account.Calculate_Interest();
                */
                #endregion
                #region task9
                /*
                Console.WriteLine("Creating Savings Account.");
                Console.WriteLine("Enter Account Number:");
                int acno=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Customer Name.");
                string cname=Console.ReadLine();
                Console.WriteLine("Enter Balance.");
                double balance=Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter rate of interest");
                double interestRate=Convert.ToDouble(Console.ReadLine());

                BankAccount account1=new SavingsAccountAbs(acno,cname, balance, interestRate);
                account1.Calculate_Interest();
                */

                #endregion
                #region task10
                /*
                Bank b = new Bank();
                while (true)
                {

                    Console.WriteLine("Choose function: 1.Create Account 2.Deposit 3.Withdraw 4.get balance 5.transfer 6.get account details 7.exit");
                    int choice=Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Which Account type you want to create? 1.Savings 2.Current");
                                int type = Convert.ToInt32(Console.ReadLine());
                                string actype;
                                if (type == 1)
                                {
                                    actype = "Savings";
                                }
                                else if (type == 2) { actype = "Current"; }
                                else
                                {
                                    Console.WriteLine("Wrong Account Type.");
                                    break;
                                }
                                Console.WriteLine("Creating Customer:");
                                Console.WriteLine("enter customer id:");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter First Name:");
                                string fname = Console.ReadLine();
                                Console.WriteLine("Enter Last Name:");
                                string lname = Console.ReadLine();
                                Console.WriteLine("Enter Gmail:");
                                string gmail = Console.ReadLine();
                                Console.WriteLine("Enter Phone Number:");
                                long phone = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter Address:");
                                string address = Console.ReadLine();

                                Customer c = new Customer(cid, fname, lname, gmail, phone, address);
                                Console.WriteLine("Creating Account");
                                Console.WriteLine("Enter Account Balance:");
                                float balance = float.Parse(Console.ReadLine());
                                b.Create_Account(c, actype, balance);

                            }
                            break;

                        case 2:
                            {
                                Console.WriteLine("Enter account number to Deposit balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to deposit:");
                                float amount = float.Parse(Console.ReadLine());
                                float bal = b.Deposit(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after depositing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 3:
                            {
                                Console.WriteLine("Enter account number to Withdraw balance from:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to withdraw:");
                                float amount = float.Parse(Console.ReadLine());
                                float bal = b.Withdraw(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after withdrawing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("Enter account number to find balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                float bal = b.Get_Account_Balance(acno);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 5:
                            {
                                Console.WriteLine("Enter account number to transfer balance from:");
                                long fromacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter account number to transfer balance to:");
                                long toacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter amount to transfer:");
                                float amount = float.Parse(Console.ReadLine());
                                b.Transfer(fromacno, toacno, amount);
                            }
                            break;
                        case 6:
                            {
                                Console.WriteLine("Enter account number to find details:");
                                long acno = Convert.ToInt64(Console.ReadLine());

                                AccountA ac = b.GetAccountDetails(acno);
                                if (ac == null)
                                {
                                    Console.WriteLine("No such account .");
                                }
                                else
                                {
                                    Console.WriteLine($"account number:{ac.AccountNumber}");
                                    Console.WriteLine($"account Type:{ac.AccountType}");
                                    Console.WriteLine($"account Balance:{ac.AccountBalance}");
                                    Console.WriteLine($"Customer  name:{ac.Customer.FirstName + " " + ac.Customer.LastName}");
                                    Console.WriteLine($"Customer email:{ac.Customer.EmailAddress}");
                                    Console.WriteLine($"account Phone number:{ac.Customer.PhoneNumber}");
                                    Console.WriteLine($"account Address:{ac.Customer.Address}");
                                }
                            }
                            break;

                        case 7:
                            return;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice. Try Again");
                            break;

                    }
                }
                */
                #endregion
                #region task11
                /*
                BankServiceProviderImpl b = new BankServiceProviderImpl();
                while (true)
                {

                    Console.WriteLine("Choose function: 1.Create Account 2.Deposit 3.Withdraw 4.get balance 5.transfer 6.get account details 7.List Accounts 8.exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Which Account type you want to create? 1.Savings 2.Current 3.Zero Balance");
                                int type = Convert.ToInt32(Console.ReadLine());
                                string actype;
                                if (type == 1)
                                {
                                    actype = "Savings";
                                    Console.WriteLine("Creating Customer:");
                                    Console.WriteLine("enter customer id:");
                                    int cid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter First Name:");
                                    string fname = Console.ReadLine();
                                    Console.WriteLine("Enter Last Name:");
                                    string lname = Console.ReadLine();
                                    Console.WriteLine("Enter Gmail:");
                                    string gmail = Console.ReadLine();
                                    Console.WriteLine("Enter Phone Number:");
                                    long phone = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Enter Address:");
                                    string address = Console.ReadLine();

                                    Customer c = new Customer(cid, fname, lname, gmail, phone, address);
                                    Console.WriteLine("Creating Account");
                                    Console.WriteLine("Enter Account Balance:");
                                    float balance = float.Parse(Console.ReadLine());
                                    if (balance <= 0)
                                    {
                                        Console.WriteLine("Minimum Balance required is 500 .");
                                        break;
                                    }
                                    Console.WriteLine("Enter Interest rate");
                                    double interestRate = Convert.ToDouble(Console.ReadLine());
                                    SavingsAccountA savingsac = new SavingsAccountA(actype, balance, c, interestRate);
                                    b.account.Add(savingsac);
                                }
                                else if (type == 2)
                                {
                                    actype = "Current";
                                    Console.WriteLine("Creating Customer:");
                                    Console.WriteLine("enter customer id:");
                                    int cid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter First Name:");
                                    string fname = Console.ReadLine();
                                    Console.WriteLine("Enter Last Name:");
                                    string lname = Console.ReadLine();
                                    Console.WriteLine("Enter Gmail:");
                                    string gmail = Console.ReadLine();
                                    Console.WriteLine("Enter Phone Number:");
                                    long phone = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Enter Address:");
                                    string address = Console.ReadLine();

                                    Customer c = new Customer(cid, fname, lname, gmail, phone, address);
                                    Console.WriteLine("Creating Account");
                                    Console.WriteLine("Enter Account Balance:");
                                    float balance = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Withdraw Limit:");
                                    double overdraftLimit = Convert.ToDouble(Console.ReadLine());
                                    CurrentAccountA currentac = new CurrentAccountA(actype, balance, c, overdraftLimit);
                                    b.account.Add(currentac);
                                }
                                else if (type == 3)
                                {
                                    actype = "Zero Balance";
                                    Console.WriteLine("Creating Customer:");
                                    Console.WriteLine("enter customer id:");
                                    int cid = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter First Name:");
                                    string fname = Console.ReadLine();
                                    Console.WriteLine("Enter Last Name:");
                                    string lname = Console.ReadLine();
                                    Console.WriteLine("Enter Gmail:");
                                    string gmail = Console.ReadLine();
                                    Console.WriteLine("Enter Phone Number:");
                                    long phone = Convert.ToInt64(Console.ReadLine());
                                    Console.WriteLine("Enter Address:");
                                    string address = Console.ReadLine();

                                    Customer c = new Customer(cid, fname, lname, gmail, phone, address);
                                    Console.WriteLine("Creating Account");
                                    Console.WriteLine("Enter Account Balance:");
                                    float balance = float.Parse(Console.ReadLine());

                                    ZeroBalanceAccountA zerobalac = new ZeroBalanceAccountA(actype, balance, c);
                                    b.account.Add(zerobalac);
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Account Type.");
                                    break;
                                }


                            }
                            break;

                        case 2:
                            {
                                Console.WriteLine("Enter account number to Deposit balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to deposit:");
                                float amount = float.Parse(Console.ReadLine());
                                float bal = b.Deposit(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after depositing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 3:
                            {
                                Console.WriteLine("Enter account number to Withdraw balance from:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to withdraw:");
                                float amount = float.Parse(Console.ReadLine());


                                float bal = b.Withdraw(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after withdrawing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("Enter account number to find balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                float bal = b.Get_Account_Balance(acno);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 5:
                            {
                                Console.WriteLine("Enter account number to transfer balance from:");
                                long fromacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter account number to transfer balance to:");
                                long toacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter amount to transfer:");
                                float amount = float.Parse(Console.ReadLine());
                                b.Transfer(fromacno, toacno, amount);
                            }
                            break;
                        case 6:
                            {
                                Console.WriteLine("Enter account number to find details:");
                                long acno = Convert.ToInt64(Console.ReadLine());

                                AccountA ac = b.GetAccountDetails(acno);
                                if (ac == null)
                                {
                                    Console.WriteLine("No such account .");
                                }
                                else
                                {
                                    Console.WriteLine($"account number:{ac.AccountNumber}");
                                    Console.WriteLine($"account Type:{ac.AccountType}");
                                    Console.WriteLine($"account Balance:{ac.AccountBalance}");
                                    Console.WriteLine($"Customer  name:{ac.Customer.FirstName + " " + ac.Customer.LastName}");
                                    Console.WriteLine($"Customer email:{ac.Customer.EmailAddress}");
                                    Console.WriteLine($"account Phone number:{ac.Customer.PhoneNumber}");
                                    Console.WriteLine($"account Address:{ac.Customer.Address}");
                                }
                            }
                            break;
                        case 7:
                            {
                                b.listAccounts();
                                break;
                            }

                        case 8:
                            return;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice. Try Again");
                            break;

                    }
                }
                */
                #endregion
                #region task13 
                /*
                BankServiceProviderImpl b = new BankServiceProviderImpl();
                while (true)
                {

                    Console.WriteLine("Choose function: 1.Create Account in List 2.Deposit 3.Withdraw 4.get balance 5.transfer 6.get account details 7.List Accounts  8.Create Account and store in set 9.display accountList 10.Create account in dictionary 11.Display accountDictionary 12.exit ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Which Account type you want to create? 1.Savings 2.Current 3.Zero Balance");
                                int type = Convert.ToInt32(Console.ReadLine());
                                float balance = 0;
                                string actype = "";
                                if (type == 1)
                                {
                                    actype = "Savings";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                    if (balance < 500)
                                    {
                                        Console.WriteLine("Minimum Balance required is 500 .");
                                        break;
                                    }

                                }
                                else if (type == 2)
                                {
                                    actype = "Current";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());

                                }
                                else if (type == 3)
                                {
                                    actype = "Zero Balance";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                }

                                else
                                {
                                    Console.WriteLine("Wrong Account Type.");
                                    break;
                                }
                                Console.WriteLine("Creating Customer:");
                                Console.WriteLine("enter customer id:");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter First Name:");
                                string fname = Console.ReadLine();
                                Console.WriteLine("Enter Last Name:");
                                string lname = Console.ReadLine();
                                Console.WriteLine("Enter Gmail:");
                                string gmail = Console.ReadLine();
                                Console.WriteLine("Enter Phone Number:");
                                long phone = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter Address:");
                                string address = Console.ReadLine();

                                Customer cus = new Customer(cid, fname, lname, gmail, phone, address);
                                Console.WriteLine("Creating Account");


                                b.Create_Account(cus, actype, balance);

                            }
                            break;

                        case 2:
                            {
                                Console.WriteLine("Enter account number to Deposit balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to deposit:");
                                float amount = float.Parse(Console.ReadLine());
                                float bal = b.Deposit(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after depositing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 3:
                            {
                                Console.WriteLine("Enter account number to Withdraw balance from:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter amount to withdraw:");
                                float amount = float.Parse(Console.ReadLine());


                                float bal = b.Withdraw(acno, amount);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} after withdrawing RS.{amount} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine("Enter account number to find balance:");
                                long acno = Convert.ToInt64(Console.ReadLine());
                                float bal = b.Get_Account_Balance(acno);
                                if (bal > 0)
                                {
                                    Console.WriteLine($"Balance for account no {acno} is: {bal}.");
                                }
                                else
                                {
                                    Console.WriteLine("No such account found.");
                                }
                            }
                            break;

                        case 5:
                            {
                                Console.WriteLine("Enter account number to transfer balance from:");
                                long fromacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter account number to transfer balance to:");
                                long toacno = Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Enter amount to transfer:");
                                float amount = float.Parse(Console.ReadLine());
                                b.Transfer(fromacno, toacno, amount);
                            }
                            break;
                        case 6:
                            {
                                Console.WriteLine("Enter account number to find details:");
                                long acno = Convert.ToInt64(Console.ReadLine());

                                AccountA ac = b.GetAccountDetails(acno);
                                if (ac == null)
                                {
                                    Console.WriteLine("No such account .");
                                }
                                else
                                {
                                    Console.WriteLine($"account number:{ac.AccountNumber}");
                                    Console.WriteLine($"account Type:{ac.AccountType}");
                                    Console.WriteLine($"account Balance:{ac.AccountBalance}");
                                    Console.WriteLine($"Customer  name:{ac.Customer.FirstName + " " + ac.Customer.LastName}");
                                    Console.WriteLine($"Customer email:{ac.Customer.EmailAddress}");
                                    Console.WriteLine($"account Phone number:{ac.Customer.PhoneNumber}");
                                    Console.WriteLine($"account Address:{ac.Customer.Address}");
                                }
                            }
                            break;
                        case 7:
                            {
                                b.listAccounts();
                                break;
                            }

                        case 8:
                            {
                                Console.WriteLine("Which Account type you want to create? 1.Savings 2.Current 3.Zero Balance");
                                int type = Convert.ToInt32(Console.ReadLine());
                                float balance = 0;
                                string actype="";
                                if (type == 1)
                                {
                                    actype = "Savings";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                    if (balance < 500)
                                    {
                                        Console.WriteLine("Minimum Balance required is 500 .");
                                        break;
                                    }

                                }
                                else if (type == 2)
                                {
                                    actype = "Current";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());

                                }
                                else if (type == 3)
                                {
                                    actype = "Zero Balance";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                }

                                else
                                {
                                    Console.WriteLine("Wrong Account Type.");
                                    break;
                                }
                                Console.WriteLine("Creating Customer:");
                                Console.WriteLine("enter customer id:");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter First Name:");
                                string fname = Console.ReadLine();
                                Console.WriteLine("Enter Last Name:");
                                string lname = Console.ReadLine();
                                Console.WriteLine("Enter Gmail:");
                                string gmail = Console.ReadLine();
                                Console.WriteLine("Enter Phone Number:");
                                long phone = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter Address:");
                                string address = Console.ReadLine();

                                Customer cus = new Customer(cid, fname, lname, gmail, phone, address);
                                Console.WriteLine("Creating Account");


                                b.Create_AccountUsingSet(cus, actype, balance);

                            }
                            break;
                        case 9:
                            b.displaySetAccounts();
                            break;
                        case 10:
                            {
                                Console.WriteLine("Which Account type you want to create? 1.Savings 2.Current 3.Zero Balance");
                                int type = Convert.ToInt32(Console.ReadLine());
                                float balance = 0;
                                string actype = "";
                                if (type == 1)
                                {
                                    actype = "Savings";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                    if (balance < 500)
                                    {
                                        Console.WriteLine("Minimum Balance required is 500 .");
                                        break;
                                    }

                                }
                                else if (type == 2)
                                {
                                    actype = "Current";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());

                                }
                                else if (type == 3)
                                {
                                    actype = "Zero Balance";
                                    Console.WriteLine("Enter Account Balance:");
                                    balance = float.Parse(Console.ReadLine());
                                }

                                else
                                {
                                    Console.WriteLine("Wrong Account Type.");
                                    break;
                                }
                                Console.WriteLine("Creating Customer:");
                                Console.WriteLine("enter customer id:");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter First Name:");
                                string fname = Console.ReadLine();
                                Console.WriteLine("Enter Last Name:");
                                string lname = Console.ReadLine();
                                Console.WriteLine("Enter Gmail:");
                                string gmail = Console.ReadLine();
                                Console.WriteLine("Enter Phone Number:");
                                long phone = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter Address:");
                                string address = Console.ReadLine();

                                Customer cus = new Customer(cid, fname, lname, gmail, phone, address);
                                Console.WriteLine("Creating Account");


                                b.Create_AccountUsingDictionary(cus, actype, balance);

                            }
                            break;
                        case 11:
                            b.displayDictionaryAccounts();
                            break;
                        case 12:
                            return;
                            break;
                        default:
                            Console.WriteLine("Wrong Choice. Try Again");
                            break;


                    }
                }
                */
                #endregion
            }
            #endregion
            #region task14
            ICustomerDBServiceProvider c =new CustomerDBServiceProviderImpl() ;
            IBankServiceProviderDB b = new BankDBServiceProviderImpl();
            while (true)
            {
                Console.WriteLine("Enter Your Choice.\n1.Create Account\n2.Deposit\n3.Withdraw\n4.Get Balance\n5.Transfer\n6.Get Account Details\n7.List Accounts\n8.Get Transactions\n9.Exit");
                int choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Choose Account Type.\t1.Savings\t2.Current\t3.Zero Balance.");
                        int actype=Convert.ToInt32(Console.ReadLine());
                        switch(actype)
                        {
                            case 1:
                                    b.CreateAccountDB("savings");
                                    break;
                            case 2:
                                    b.CreateAccountDB("current");
                                    break;
                            case 3:
                                    b.CreateAccountDB("zero_balance");
                                    break;
                            default: Console.WriteLine("Wrong Choice.");
                                    break;
                        }
                        break;
                    case 2:
                        c.Deposit();
                        break;
                    case 3:
                        c.Withdraw();
                        break;
                    case 4:
                        c.GetAccountBalance();
                        break;
                    case 5:
                        c.Transfer();
                        break;
                    case 6:
                        try
                        {
                            c.GetAccountDetails();
                        }
                        catch(NullPointerException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 7:
                        try
                        {
                            b.ListAccounts();
                        }
                        catch(NullPointerException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 8:
                        try
                        {
                            c.GetTransactions();
                        }
                        catch (NullPointerException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Wrong Choice.");
                        break;
                }
            }
            #endregion



            
        }
    }
}
