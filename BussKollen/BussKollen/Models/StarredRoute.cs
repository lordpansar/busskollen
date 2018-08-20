
using SQLite;

namespace BussKollen.Models
{
    public class StarredRoute
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Start { get; set; }
        public string Destination { get; set; }
    }
}
