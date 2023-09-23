namespace PerkyWeb.API.Models.Domain
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
