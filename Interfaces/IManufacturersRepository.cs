using EntryForm.Models;

namespace EntryForm.Interfaces
{
    public interface IManufacturersRepository
    {

        Task<IEnumerable<Manufacturer>> GetAll();
    }
}
