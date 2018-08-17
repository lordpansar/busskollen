using BussKollen.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace BussKollen.Models
{
    public class TrafficDatabase
    {
        private SQLiteConnection db;
        static object locker = new object();

        public TrafficDatabase()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<StarredRoute>();
            db.CreateTable<Travel>();
        }
    }
}
