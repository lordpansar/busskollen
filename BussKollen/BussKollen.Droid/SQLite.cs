using System.IO;
using BussKollen.Droid;
using BussKollen.Interfaces;
using Xamarin.Forms;
using Environment = System.Environment;
using SQLite;

[assembly: Dependency(typeof(SQLite_Android))]
namespace BussKollen.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() {}

        public SQLiteConnection GetConnection()
        {
            //Set name of db
            string sqliteFilename = "TravelDB.db";
            //Create path
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); //Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            //Create Connection
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}