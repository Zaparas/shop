using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.Products
{
    public class AddProductDto
    {
        public string Name { get; set; } = "not named yet";
        public string? Summary { get; set; }
        public double Price { get; set; }
    }
}