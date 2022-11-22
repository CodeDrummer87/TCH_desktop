using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int TabNumber { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public int ColumnId { get; set; }

    }
}
