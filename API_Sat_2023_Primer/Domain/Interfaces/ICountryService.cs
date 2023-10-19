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
    }
}
