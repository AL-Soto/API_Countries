using API_Sat_2023_Primer.DAL.Entities;
using API_Sat_2023_Primer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Sat_2023_Primer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        
        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesAsync()
        {
            var countries = await _countryService.GetCountriesAsync();
            if (countries == null || !countries.Any())
            {
                return NotFound();
            }

            return Ok(countries);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Country country)
        {
            try
            {
                var createCountry = await _countryService.CreateCountryAsync(country);
                if (createCountry == null)
                {
                    return NotFound();
                }
                return Ok(createCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El pais {0} ya existe ", country.Name));
                }
                return Conflict(ex.Message);
            }
        }

    }
}
