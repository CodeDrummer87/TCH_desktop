using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Column
    {
        [Key]
        public int Id { get; set; }
        public int ColumnNumber { get; set; }
        public string Abbreviation { get; set; }
        public int Specialization { get; set; }
        public int Depot { get; set; }
    }
}
