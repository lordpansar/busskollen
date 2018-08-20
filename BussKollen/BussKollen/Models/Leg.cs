namespace BussKollen.Models
{
    public class Leg
    {
        public Origin Origin { get; set; }
        public Destination Destination { get; set; }
        public JourneyDetailRef JourneyDetailRef { get; set; }
        public string JourneyStatus { get; set; }
        public Product Product { get; set; }
        public string Idx { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public bool Reachable { get; set; }
        public string Direction { get; set; }
    }
}
