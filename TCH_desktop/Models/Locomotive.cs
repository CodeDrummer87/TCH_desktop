using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Locomotive
    {
        [Key]
        public int Id { get; set; }
        public int LocoType { get; set; }
        public int Series { get; set; }
        public int Number { get; set; }
        public int Allocation { get; set; }
        public int NumberOfBrakeHolders { get; set; }
        public string ImagePath { get; set; }
    }
}
