using EntryForm.Interfaces;
using EntryForm.Models;
using Microsoft.EntityFrameworkCore;

namespace EntryForm.Repositories
{
    public class ManufacturerRepository : IManufacturersRepository
    {

        private readonly ApplicatioDbContext _context;

        public ManufacturerRepository(ApplicatioDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            return await _context.Manufacturers.ToListAsync();
        }
    }
}
