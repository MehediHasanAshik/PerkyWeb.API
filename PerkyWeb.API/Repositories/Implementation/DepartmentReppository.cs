using Microsoft.EntityFrameworkCore;
using PerkyWeb.API.Data;
using PerkyWeb.API.Models.Domain;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Repositories.Implementation
{
    public class DepartmentReppository : IDepartmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentReppository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<Department>> GetALlAsync()
        {
            return await dbContext.Departments.ToListAsync();
        }
    }
}
