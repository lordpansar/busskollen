using BussKollen.Interfaces;
using SQLite.Net;

namespace BussKollen.Models
{
    public class TrafficDatabase
    {
        private SQLiteConnection db;
        static object locker = new object();
    }
}
