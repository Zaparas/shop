using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Customer
    {
        public Customer(){}

        public Customer(string first,string last){
            FirstName = first;
            LastName = last;
        }

        public Customer(string first,string last,string number){
            FirstName = first;
            LastName = last;
            Phone = number;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = "Not-set";
        public string LastName { get; set; } = "Not-set";
        public string Phone { get; set; } = "555-555-5555";
    }
}