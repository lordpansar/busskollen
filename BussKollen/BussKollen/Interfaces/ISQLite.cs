using SQLite.Net;

namespace BussKollen.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
