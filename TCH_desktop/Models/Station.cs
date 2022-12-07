using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Railroad { get; set; }
        public string Code { get; set; }
    }
}
