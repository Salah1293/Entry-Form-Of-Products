using EntryForm.Models;

namespace EntryForm.Interfaces
{
    public interface ICategoriesRepository
    {

        Task<IEnumerable<Category>> GetAll();
    }
}
