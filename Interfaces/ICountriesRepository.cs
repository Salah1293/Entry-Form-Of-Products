using EntryForm.Models;

namespace EntryForm.Interfaces
{
    public interface ICountriesRepository
    {

        Task<IEnumerable<Country>> GetAll();
    }
}
