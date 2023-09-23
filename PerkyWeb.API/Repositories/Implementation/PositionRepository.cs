using Microsoft.EntityFrameworkCore;
using PerkyWeb.API.Data;
using PerkyWeb.API.Models.Domain;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Repositories.Implementation
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PositionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Position>> GetALlAsync()
        {
            return await dbContext.Positions.ToListAsync();
        }
    }
}
