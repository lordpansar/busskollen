namespace BussKollen.Models
{
    public class Origin
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public string ExtId { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string PrognosisType { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string Track { get; set; }
        public string RtTime { get; set; }
        public string RtDate { get; set; }
        public bool HasMainMast { get; set; }
        public string MainMastId { get; set; }
        public string MainMastExtId { get; set; }
    }
}
