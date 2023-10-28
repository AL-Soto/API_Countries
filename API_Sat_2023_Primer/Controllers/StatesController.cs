using API_Sat_2023_Primer.DAL.Entities;
using API_Sat_2023_Primer.Domain.Interfaces;
using API_Sat_2023_Primer.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Sat_2023_Primer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStatesByCountryIdAsync(countryId);
            if (states == null || !states.Any()) return NotFound();
            

            return Ok(states);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateStateAsync(State state, Guid countryId)
        {
            try
            {
                var createState = await _stateService.CreateStateAsync(state, countryId);

                if (createState == null) return NotFound();

                return Ok(createState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El pais {0} ya existe ", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null)
            {
                return NotFound(); 
            }

            return Ok(state);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state, Guid id)
        {
            try
            {
                var editState = await _stateService.EditStateAsync(state, id);
                return Ok(editState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El pais {0} ya existe ", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        //Delete
        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");
            var deleteState = await _stateService.DeleteStateAsync(id);
            if (deleteState == null) return NotFound("estado no encontrado");
            return Ok(deleteState);
        }







        public IActionResult Index()
        {
            return View();
        }
    }
}
