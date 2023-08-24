using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Customer;
using Backend.DTOs.Products;
using Backend.DTOs.Purchase;
using Backend.Models;
using Backend.Services.Customers;
using Backend.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController(ICustomerService customerService){
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(await _customerService.GetCustomers());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetById(int id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Add(AddCustomerDto input)
        {
            return Ok(await _customerService.AddCustomer(input));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update(UpdateCustomerDto input){
            return Ok(await _customerService.UpdateCustomer(input));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return Ok(await _customerService.DeleteCustomerById(id));
        }

        [HttpPost("purchase")]
        public async Task<ActionResult<List<Product>>> Purchase(int customerId,PurchaseInputDto PurchasedProducts)
        {
            return Ok(await _customerService. MakePurchase( customerId, PurchasedProducts));
        }   
    }
}