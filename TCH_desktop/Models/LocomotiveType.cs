using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class LocomotiveType
    {
        [Key]
        public int Id { get; set; }
        public string LocoType { get; set; }
    }
}
