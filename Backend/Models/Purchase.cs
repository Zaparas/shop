using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Purchase
    {
        public Purchase(int customerID)
        {
            CustomerID = customerID;
        }

        public Purchase(int customerID, List<PurchaseProduct> purchasedProducts)
        {
            CustomerID = customerID;  
            PurchasedProducts = purchasedProducts;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerID { get; set; }

        public List<PurchaseProduct> PurchasedProducts { get; set; } = new List<PurchaseProduct>();
    }
}