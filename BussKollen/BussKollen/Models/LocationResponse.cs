using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
