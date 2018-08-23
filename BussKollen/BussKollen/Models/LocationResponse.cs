using System.Collections.Generic;

namespace BussKollen.Models
{
    public class LocationResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public int ExecutionTime { get; set; }
        public List<Location> ResponseData { get; set; }
    }
}
