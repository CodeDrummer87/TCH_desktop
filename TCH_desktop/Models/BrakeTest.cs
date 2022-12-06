using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class BrakeTest
    {
        [Key]
        public int Id { get; set; }
        public int Depot { get; set; }
        public bool IsEvenNumberedDirection { get; set; }
        public string RailwayLine { get; set; }
        public string RequiredSpeed { get; set; }
        public string Point { get; set; }
        public string RequiredSpeedForDoubleTrain { get; set; }
        public string PointForDoubleTrain { get; set; }
    }
}
