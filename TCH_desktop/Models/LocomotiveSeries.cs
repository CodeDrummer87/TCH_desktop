using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class LocomotiveSeries
    {
        [Key]
        public int Id { get; set; }
        public string Series { get; set; }
        public int LocoType { get; set; }
    }
}
