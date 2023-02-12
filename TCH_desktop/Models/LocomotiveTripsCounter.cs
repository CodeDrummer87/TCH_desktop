namespace TCH_desktop.Models
{
    public class LocomotiveTripsCounter
    {
        public string Locomotive { get; set; }
        public int Count { get; set; }

        public LocomotiveTripsCounter()
        {
            Locomotive = string.Empty;
            Count = 0;
        }
    }
}
