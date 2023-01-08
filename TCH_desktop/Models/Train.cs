using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class Train
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public int Weight { get; set; }
        public int Axles { get; set; }
        public int SpecificLength { get; set; }
        public string TailCar { get; set; }
        public string TrainFixation { get; set; }
    }
}
