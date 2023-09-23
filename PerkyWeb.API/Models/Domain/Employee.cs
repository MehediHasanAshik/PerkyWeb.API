namespace PerkyWeb.API.Models.Domain
{
    public class Employee
    {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int DepartmentId { get; set; }
            public int PositionId { get; set; }

            // Navigation properties
            public Department Department { get; set; }
            public Position Position { get; set; }
        }
}
