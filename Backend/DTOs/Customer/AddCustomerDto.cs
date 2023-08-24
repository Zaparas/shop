using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.Customer
{
    public class AddCustomerDto
    {
        public string FirstName { get; set; } = "Not-set";
        public string LastName { get; set; } = "Not-set";
        public string phone { get; set; } = "555-555-5555";
    }
}