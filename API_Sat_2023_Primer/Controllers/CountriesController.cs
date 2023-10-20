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

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountryByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");
            
            var country = await _countryService.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound(); //404
            }

            return Ok(country); //200
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByName/{Name}")]
        public async Task<ActionResult<Country>> GetCountryByNameAsync(string name)
        {
            if (name == null) return BadRequest("nombre es requerido!");

            var country = await _countryService.GetCountryByNameAsync(name);
            if (country == null) return NotFound(); //404

            return Ok(country); //200
        }
        //Update 
        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editCountry = await _countryService.EditCountryAsync(country);            
                return Ok(editCountry);
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
        //Delete
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");
            var deleteCountry = await _countryService.DeleteCountryAsync(id);
            if(deleteCountry == null) return NotFound("Pais no encontrado");
            return Ok(deleteCountry);
        }


    }
}
