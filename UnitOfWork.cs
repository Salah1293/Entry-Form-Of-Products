using EntryForm.Interfaces;
using EntryForm.Models;
using EntryForm.Repositories;

namespace EntryForm
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicatioDbContext _context;

        public IProductsRepository Products { get; private set; }

        public ICategoriesRepository Category { get; private set; }
        public ICountriesRepository Country { get; private set; }
        public IManufacturersRepository Manufacturer { get; private set; }

        
        public UnitOfWork(ApplicatioDbContext context)
        {
           _context = context;

           Products = new ProductRepository(_context);

           Category = new CategoryRepository(_context);

           Country = new CountryRepository(_context);

           Manufacturer = new ManufacturerRepository(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
