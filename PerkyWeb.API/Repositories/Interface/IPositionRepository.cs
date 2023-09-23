using PerkyWeb.API.Models.Domain;

namespace PerkyWeb.API.Repositories.Interface
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetALlAsync();
    }
}
