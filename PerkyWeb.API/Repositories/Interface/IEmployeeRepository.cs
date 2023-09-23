using PerkyWeb.API.Models.Domain;
using PerkyWeb.API.Models.DTO;

namespace PerkyWeb.API.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);

        Task<IEnumerable<Employee>> GetALlAsync();

        Task<EmployeeDTO?> GetByIdAsync(int id);

        Task<Employee?> UpdateAsync(Employee employee);

        Task<Employee?> DeleteAsync(int id);

        Task<List<Employee>> SearchAsync(string searchTerm);
    }
}
