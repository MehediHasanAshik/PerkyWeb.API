using Microsoft.AspNetCore.Mvc;
using PerkyWeb.API.Models.DTO;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PositionsController : Controller
    {
        private readonly IPositionRepository posRepository;

        public PositionsController(IPositionRepository posRepository)
        {
            this.posRepository = posRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPositions()
        {
            var positions = await posRepository.GetALlAsync();

            var response = new List<PositionDTO>();

            foreach (var position in positions)
            {
                response.Add(new PositionDTO
                {
                    PositionId = position.PositionId,
                    Title = position.Title,
                });
            }

            return Ok(response);
        }
    }
}
