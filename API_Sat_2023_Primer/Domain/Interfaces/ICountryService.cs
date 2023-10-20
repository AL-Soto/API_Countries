using API_Sat_2023_Primer.DAL.Entities;

namespace API_Sat_2023_Primer.Domain.Interfaces
{
    public interface ICountryService
    {
        //IList
        //ICollection
        //IEnumerable 
        Task<IEnumerable<Country>>GetCountriesAsync(); //Una firma del metodo
        Task<Country> CreateCountryAsync(Country country);
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> GetCountryByNameAsync(string name);
        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
