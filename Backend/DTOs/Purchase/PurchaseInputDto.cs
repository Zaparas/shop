using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs.Purchase
{
    public class PurchaseInputDto
    {
        public List<int> ProductIds { get; set; } = new List<int>();
        public List<int> Quantities { get; set; } = new List<int>();
    }
}