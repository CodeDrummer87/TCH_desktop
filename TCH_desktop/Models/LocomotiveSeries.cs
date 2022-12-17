using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class LocomotiveSeries
    {
        [Key]
        public int Id { get; set; }
        public string SeriesFirst { get; set; }
        public string lIndex { get; set; }
        public byte isUpperIndex { get; set; }
        public string SeriesSecond { get; set; }
        public int LocoType { get; set; }
    }
}
