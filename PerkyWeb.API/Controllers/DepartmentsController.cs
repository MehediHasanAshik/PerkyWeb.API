using Microsoft.AspNetCore.Mvc;
using PerkyWeb.API.Models.DTO;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository deptRepository;

        public DepartmentsController(IDepartmentRepository deptRepository)
        {
            this.deptRepository = deptRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await deptRepository.GetALlAsync();

            var response = new List<DepartmentDTO>();

            foreach(var department in departments)
            {
                response.Add(new DepartmentDTO
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName,
                });
            }

            return Ok(response);
        }
    }
}
