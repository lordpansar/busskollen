using SQLite;

namespace BussKollen.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
