using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        public DateTime AttendanceTime { get; set; }
        public int Locomotive { get; set; }
        public string TrafficRoute { get; set; }
        public float ElectricityFactor { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string PassedStations { get; set; }
        public string SpeedLimits { get; set; }
        public int ElectricityAmountRequired { get; set; }
        public float ElectricityRecoveryRequired { get; set; }
        public float TechnicalSpeed { get; set; }
        public string Notes { get; set; }
        public int Train { get; set; }
    }
}
