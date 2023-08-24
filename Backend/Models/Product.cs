namespace Backend;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class Product
{

    public Product(string name,double price){
        Name = name;
        Price = price;
        DateAdded = DateTime.Now;
    }
    public Product(string name, double price, string summary) 
    {
        Name = name;
        Price = price;
        Summary = summary;
        DateAdded = DateTime.Now;
    }

    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public DateTime DateAdded { get; set; }
    public string? Summary { get; set; }
}