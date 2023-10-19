using API_Sat_2023_Primer.DAL;
using API_Sat_2023_Primer.DAL.Entities;
using API_Sat_2023_Primer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Sat_2023_Primer.Domain.Services
{
    public class CountryService : ICountryService
    {
        public readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.ID = Guid.NewGuid();
                country.CreateDate = DateTime.Now;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
