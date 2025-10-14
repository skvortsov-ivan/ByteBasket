using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytebasket
{
    public class Customer
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Customer(string fullName, string address, string email)
        {
            FullName = fullName;
            Address = address;
            Email = email;
        }
    }
}
