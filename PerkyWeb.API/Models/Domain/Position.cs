namespace PerkyWeb.API.Models.Domain
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Title { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
