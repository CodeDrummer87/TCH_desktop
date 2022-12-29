using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class TripsBrakeTests
    {
        [Key]
        public int Id { get; set; }
        public int Trip { get; set; }
        public int BrakeTest { get; set; }
    }
}
