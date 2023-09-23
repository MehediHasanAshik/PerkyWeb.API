using PerkyWeb.API.Models.Domain;
using System.Threading.Tasks;

namespace PerkyWeb.API.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetALlAsync();
    }
}
