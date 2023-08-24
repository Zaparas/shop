using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Products;
using Backend.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService){
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            return Ok(await _productService.GetProducts());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Add(AddProductDto productDto)
        {
            return Ok(await _productService.AddProduct(productDto));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Update(UpdateProductDto input){
            return Ok(await _productService.UpdateProduct(input));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id){
            return Ok(await _productService.DeleteProductById(id));
        }
    }
}