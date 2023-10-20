using API_Sat_2023_Primer.DAL;
using API_Sat_2023_Primer.DAL.Entities;
using API_Sat_2023_Primer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

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

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            //return await _context.Countries.FindAsync(id);
            //return await _context.Countries.FirstAsync(c => c.ID == id);
            return await _context.Countries.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            return await _context.Countries.FirstOrDefaultAsync(C => C.Name == name);
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Countries.Update(country); //El metodo update sirve para actualizar un objeto 
                await _context.SaveChangesAsync();
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        //Delete 
        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.ID == id);
                if (country == null) return null; 

                _context.Countries.Remove(country);
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
