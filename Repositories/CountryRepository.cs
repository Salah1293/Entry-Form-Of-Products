using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryForm.Repositories
{
    public class CountryRepository : ICountriesRepository
    {

        private readonly ApplicatioDbContext _context;

        public CountryRepository(ApplicatioDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
