
using System.Net.Sockets;

namespace BankingSystem.model
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public long PhoneNumber { get; set; }

        public string Address { get; set; }

        public Customer(int customerId, string firstName, string lastName, string emailAddress, long phoneNumber, string address)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;

        }
        public void ShowCustomerDetails()
        {
            Console.WriteLine($"Customer Id : {CustomerId} .");
            Console.WriteLine($"Customer First Name : {FirstName} .");
            Console.WriteLine($"Customer Last Name: {LastName} .");
            Console.WriteLine($"Customer Email Address : {EmailAddress} .");
            Console.WriteLine($"Customer PhoneNumber : {PhoneNumber} .");
            Console.WriteLine($"Customer Address : {Address} .");
        }
    }
}
