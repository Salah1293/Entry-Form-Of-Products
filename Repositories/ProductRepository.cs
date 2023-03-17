using EntryForm.Dtos;
using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EntryForm.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ApplicatioDbContext _context;

        public ProductRepository(ApplicatioDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product product)
        {
            await _context.AddAsync(product);

            return product;
        }

        public Product Delete(Product product)
        {
            _context.Remove(product);

            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
                .OrderByDescending(p => p.ModifiedDate)
                .Include(p => p.Category)
                .Include(p => p.Country)
                .Include(p => p.Manufacturer)
                .ToListAsync();
        }



        public async Task<Product> GetById(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Country)
                .Include(p => p.Manufacturer)
                .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public Product Update(Product product)
        {
            _context.Update(product);

            return product;
        }


        public async Task<IEnumerable<Product>> Search(string productName = null, string manufacturerName = null, string categoryName = null)
        {
            return await _context.Products
                .Where(p => p.Name == productName || productName == null)
                .Where(p => p.Manufacturer.Name == manufacturerName || manufacturerName == null)
                .Where(p => p.Category.Name == categoryName || categoryName == null)
                .OrderByDescending(p => p.ModifiedDate)
                .Include(p => p.Category)
                .Include(p => p.Country)
                .Include(p => p.Manufacturer)
                .ToListAsync();
        }

    }

        
    
}
