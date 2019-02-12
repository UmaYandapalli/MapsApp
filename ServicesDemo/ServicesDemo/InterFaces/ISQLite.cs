using System;
namespace ServicesDemo.InterFaces
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
