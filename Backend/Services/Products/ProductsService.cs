using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTOs.Products;

namespace Backend.Services.Products
{
    public class ProductsService : IProductService
    {
        private readonly DataContext _data;
        public ProductsService(DataContext dataManager)
        {
            _data = dataManager;
        }

        public async Task<List<Product>> AddProduct(AddProductDto product)
        {

            Product input;
            if (product.Summary!=null)
            {
                input = new Product(product.Name, product.Price, product.Summary);
            }
            else
            {
                input = new Product(product.Name, product.Price);
            }

            _data.Products.Add(input);
            await _data.SaveChangesAsync();
            
            return await _data.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProducts(){
            return await _data.Products.ToListAsync();
        }

        public Task<Product?> GetProductById(int id){

            var result = _data.Products.FirstOrDefaultAsync(d => d.Id == id);
            return result;
        }

        public async Task<List<Product>> UpdateProduct(UpdateProductDto product)
        {
            var result = _data.Products.Where(item => item.Id == product.Id).Single();
            if (result == null){
                return await _data.Products.ToListAsync();
            }
            else{
                // Make changes and save update product
                if (product.Price != null)
                    result.Price = product.Price.Value;
                if (product.Summary != null)
                    result.Summary = product.Summary;
                if (product.Name != null)
                    result.Name = product.Name;
            }

            await _data.SaveChangesAsync();
            
            return await _data.Products.ToListAsync();
        }

        public async Task<List<Product>> DeleteProductById(int id)
        {
            var result = _data.Products.Where(item => item.Id == id).Single();
            if (result == null){
                return await _data.Products.ToListAsync();
            }
            else{
                _data.Products.Remove(result);
            }

            await _data.SaveChangesAsync();
            
            return await _data.Products.ToListAsync();
        }

    }
}