using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Customer;
using Backend.DTOs.Purchase;
using Backend.Models;

namespace Backend.Services.Customers
{
    public interface ICustomerService
    {
        Task<List<Customer>> AddCustomer(AddCustomerDto product);
        Task<List<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(int id);
        Task<List<Customer>> UpdateCustomer(UpdateCustomerDto product);
        Task<List<Customer>> DeleteCustomerById(int id);
        Task<Purchase> MakePurchase(int customerID,PurchaseInputDto PurchasedProducts);
    }
}