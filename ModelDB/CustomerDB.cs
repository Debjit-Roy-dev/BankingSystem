using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.ModelDB
{
    internal class CustomerDB
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public CustomerDB() { }
        public CustomerDB(int customerId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string address)
        {
            this.CustomerId= customerId;
            this.FirstName = firstName;
            this.LastName= lastName;
            this.DateOfBirth= dateOfBirth;
            this.Email= email;
            this.PhoneNumber= phoneNumber;
            this.Address= address;
        }
    }
}
