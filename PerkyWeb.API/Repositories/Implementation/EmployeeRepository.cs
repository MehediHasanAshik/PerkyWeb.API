using Microsoft.EntityFrameworkCore;
using PerkyWeb.API.Data;
using PerkyWeb.API.Models.Domain;
using PerkyWeb.API.Models.DTO;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Repositories.Implementation
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await dbContext.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee?> DeleteAsync(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();

                return employee;
            }

            return null;
        }

        public async Task<IEnumerable<Employee>> GetALlAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeDTO?> GetByIdAsync(int id)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x=> x.EmployeeId == id);
            if (employee == null)
            {
                return null;
            }

            /*var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == employee.DepartmentId);
            var position = await dbContext.Positions.FirstOrDefaultAsync(p => p.PositionId == employee.PositionId);*/

            var departmentIds = await dbContext.Departments
                .Select(d => d.DepartmentId)
                .ToArrayAsync();

            var positionIds = await dbContext.Positions
                .Select(p => p.PositionId)
                .ToArrayAsync();

            var employeeDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId,
                DepartmentIds = departmentIds,
                PositionIds = positionIds
            };

            return employeeDTO;
        }

        public async Task<Employee?> UpdateAsync(Employee employee)
        {
            var exEmployee = await dbContext.Employees.FindAsync(employee.EmployeeId);

            if(exEmployee != null)
            {
                dbContext.Entry(exEmployee).CurrentValues.SetValues(employee);

                await dbContext.SaveChangesAsync();

                return employee;
            }

            return null;
        }
    }
}
