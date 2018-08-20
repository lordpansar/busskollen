using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussKollen.Models
{
    public class Travel
    {
        public List<Trip> Trip { get; set; }
        public string ServerVersion { get; set; }
        public string DialectVersion { get; set; }
        public string RequestId { get; set; }
        public string ScrB { get; set; }
        public string ScrF { get; set; }
    }
}
