using API_Sat_2023_Primer.DAL.Entities;

namespace API_Sat_2023_Primer.Domain.Interfaces
{
    public interface IStateService
    {
        //IList
        //ICollection
        //IEnumerable 
        Task<IEnumerable<State>> GetStatesByCountryIdAsync(Guid countryId);
        Task<State> CreateStateAsync(State state, Guid countryId);
        Task<State> GetStateByIdAsync(Guid id);
        Task<State> EditStateAsync(State state, Guid id);
        Task<State> DeleteStateAsync(Guid id);
    }
}
