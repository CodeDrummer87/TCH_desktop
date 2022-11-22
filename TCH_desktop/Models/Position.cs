using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Abbreviate { get; set; }
    }
}
