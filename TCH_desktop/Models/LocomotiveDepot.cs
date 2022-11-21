using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class LocomotiveDepot
    {
        [Key]
        public int Id { get; set; }
        public int Railroad { get; set; }
        public string ShortTitle { get; set; }
        public string FullTitle { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
    }
}
