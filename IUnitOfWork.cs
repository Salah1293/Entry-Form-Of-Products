using EntryForm.Interfaces;
using EntryForm.Models;
using EntryForm.Repositories;

namespace EntryForm
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository Products { get; }
        ICategoriesRepository Category { get; }
        ICountriesRepository Country { get; }
        IManufacturersRepository Manufacturer { get; }


        int Complete();
    }
}
