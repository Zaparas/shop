using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DTOs.Products;

namespace Backend.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> AddProduct(AddProductDto product);
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int id);
        Task<List<Product>> UpdateProduct(UpdateProductDto product);
        Task<List<Product>> DeleteProductById(int id);
    }
}