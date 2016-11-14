using System;
using System.IO;
using Xamarin.Forms;
using WKEU_BESR.iOS;
using WKEU_BESR.Services.Cache;

[assembly: Dependency(typeof(SQLliteIOs))]
namespace WKEU_BESR.iOS
{
    public class SQLliteIOs : ISQLite
    {
        public SQLliteIOs()
        {
        }

        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "WKEU_BESRSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
                //File.Copy(sqliteFilename, path);
            }

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion
    }
}