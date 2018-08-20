using System.Collections.Generic;

namespace BussKollen.Models
{
    public class FareSetItem
    {
        public List<ServiceDay> ServiceDays { get; set; }
        public LegList LegList { get; set; }
        public TariffResult TariffResult { get; set; }
        public int Idx { get; set; }
        public string TripId { get; set; }
        public string CtxRecon { get; set; }
        public string Duration { get; set; }
        public string Checksum { get; set; }
    }
}
