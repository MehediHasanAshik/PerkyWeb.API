namespace PerkyWeb.API.Models.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }

        public int[] DepartmentIds { get; set; }
        public int[] PositionIds { get; set; }
    }
}
