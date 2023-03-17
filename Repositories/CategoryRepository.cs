using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryForm.Repositories
{
    public class CategoryRepository : ICategoriesRepository
    {

        private readonly ApplicatioDbContext _context;

        public CategoryRepository(ApplicatioDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
