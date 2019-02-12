using System;
using System.IO;
using ServicesDemo.InterFaces;
using ServicesDemo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace ServicesDemo.iOS
{
    public class SQLite_IOS: ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            try
            {
                var fileName = "Employee.db3";
                var documntspath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var libraryPath = Path.Combine(documntspath, "..", "Library");
                var path = Path.Combine(libraryPath, fileName);
                var connection = new SQLite.SQLiteConnection(path);
                System.Diagnostics.Debug.WriteLine(path);
                return connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
