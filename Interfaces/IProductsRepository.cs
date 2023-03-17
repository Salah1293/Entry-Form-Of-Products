using EntryForm.Models;
using System.Linq.Expressions;

namespace EntryForm.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
        Task<IEnumerable<Product>> Search(string productName = null, string manufacturerName = null, string categoryName = null);

    }
}
