using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using PerkyWeb.API.Models.Domain;
using PerkyWeb.API.Models.DTO;
using PerkyWeb.API.Repositories.Interface;

namespace PerkyWeb.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository empRepository;

        public EmployeesController(IEmployeeRepository empRepository)
        {
            this.empRepository = empRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await empRepository.GetALlAsync();

            var response = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                response.Add(new EmployeeDTO
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DateOfBirth = employee.DateOfBirth,
                    DepartmentId = employee.DepartmentId,
                    PositionId = employee.PositionId,
                });
            }

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployees([FromBody]CreateEmployeeDTO request)
        {
            //Map DTO to Domain Model
            var employee = new Employee
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                PositionId = request.PositionId,
            };

            await empRepository.CreateAsync(employee);

            //Domain Model to DTO
            var response = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId,
            };

            return Ok(response);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSingleEmployee([FromRoute] int id)
        {
            var existedEmployee = await empRepository.GetByIdAsync(id);

            if(existedEmployee == null)
            {
                return NotFound();
            }

            var response = new EmployeeDTO
            {
                EmployeeId = existedEmployee.EmployeeId,
                FirstName = existedEmployee.FirstName,
                LastName = existedEmployee.LastName,
                DateOfBirth = existedEmployee.DateOfBirth,
                DepartmentId = existedEmployee.DepartmentId,
                PositionId = existedEmployee.PositionId,
                DepartmentIds = existedEmployee.DepartmentIds,
                PositionIds = existedEmployee.PositionIds

            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, UpdateEmployeeDTO request)
        {
            //Convert DTO To Domain Model
            var employee = new Employee
            {
                EmployeeId = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                PositionId = request.PositionId,
            };

            employee = await empRepository.UpdateAsync(employee);

            if(employee == null)
            {
                return NotFound();
            }

            //Convert Domain to DTO Model
            var response = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                DepartmentId = request.DepartmentId,
                PositionId = request.PositionId,
            };

            return Ok(response);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await empRepository.DeleteAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            var response = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = employee.DateOfBirth,
                DepartmentId = employee.DepartmentId,
                PositionId = employee.PositionId
            };

            return Ok(response);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchEmployeeName([FromQuery]string name)
        {
            var employeeName = await empRepository.SearchAsync(name);

            return Ok(employeeName);
        }
    }
}
