using System.ComponentModel.DataAnnotations;

namespace TCH_desktop.Models
{
    public class TrafficLight
    {
        [Key]
        public int Id { get; set; }
        public byte IsEvenDirection { get; set; }
        public string Title { get; set; }
        public int Station { get; set; }
    }
}
