using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTOs.Customer;
using Backend.DTOs.Purchase;
using Backend.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Backend.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _data;
        public CustomerService(DataContext dataContext)
        {
            _data = dataContext;
        }
       
        public async Task<List<Customer>> AddCustomer(AddCustomerDto customer)
        {
            Customer input = new Customer(customer.FirstName,customer.LastName,customer.phone);
            _data.Customers.Add(input);
            await _data.SaveChangesAsync();
            return await _data.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _data.Customers.ToListAsync();
        }

        public Task<Customer?> GetCustomerById(int id)
        {
            var result = _data.Customers.FirstOrDefaultAsync(d => d.Id == id);
            return result;
        }

        public async Task<List<Customer>> UpdateCustomer(UpdateCustomerDto customer)
        {
                var result = _data.Customers.Where(item => item.Id == customer.Id).Single();
            if (result == null){
                return await _data.Customers.ToListAsync();
            }
            else{
                // Make changes and save update product
                if (customer.FirstName != null)
                    result.FirstName = customer.FirstName;
                if (customer.LastName != null)
                    result.LastName = customer.LastName;
                if (customer.phone != null)
                    result.Phone = customer.phone;
            }

            await _data.SaveChangesAsync();
            
            return await _data.Customers.ToListAsync();
        }

        public async Task<List<Customer>> DeleteCustomerById(int id)
        {
            var result = _data.Customers.Where(item => item.Id == id).Single();
            if (result == null){
                return await _data.Customers.ToListAsync();
            }
            else{
                _data.Customers.Remove(result);
            }

            await _data.SaveChangesAsync();
            
            return await _data.Customers.ToListAsync();
        }

        public async Task<List<Purchase>> MakePurchase(int customerID, PurchaseInputDto purchaseInput)
        {
            // Validate that all ProductIds exist in the database
            var validProductIds = _data.Products.Select(p => p.Id).ToList();
            var invalidProductIds = purchaseInput.ProductIds.Except(validProductIds).ToList();

            if (invalidProductIds.Any())
            {
                throw new ArgumentException($"The following product IDs are invalid: {string.Join(", ", invalidProductIds)}");
            }

            // First, create and save the Purchase
            var newPurchase = new Purchase(customerID);
            _data.Purchases.Add(newPurchase);
            await _data.SaveChangesAsync();  // Change to async save

            // Now, use the generated ID to create PurchaseProduct records
            newPurchase.PurchasedProducts = new List<PurchaseProduct>();  // List to store all PurchaseProduct objects
            for (int i = 0; i < purchaseInput.ProductIds.Count; i++)
            {
                var purchaseProduct = new PurchaseProduct
                {
                    PurchaseId = newPurchase.Id,  // Use the generated ID here
                    ProductId = purchaseInput.ProductIds[i],
                    Quantity = purchaseInput.Quantities[i]
                };
                newPurchase.PurchasedProducts.Add(purchaseProduct); // Add the created PurchaseProduct to the list
            }

            // _data.PurchaseProducts.AddRange(purchasedProducts); // Add the entire list to the DbSet
            await _data.SaveChangesAsync();

            return await _data.Purchases.ToListAsync();
        }
    }
}