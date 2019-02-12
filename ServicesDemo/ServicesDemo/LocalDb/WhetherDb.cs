using System;
using System.Collections.Generic;
using System.Linq;
using ServicesDemo.InterFaces;
using ServicesDemo.Models;
using SQLite;
using Xamarin.Forms;

namespace ServicesDemo.LocalDb
{
    public class WhetherDB
    {
        private SQLiteConnection _sqlConnection;
        public WhetherDB()
        {
            _sqlConnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqlConnection.CreateTable<WhetherInfo>();
        }
        public IEnumerable<WhetherInfo> GetWhethers()
        {
            return (from emp in _sqlConnection.Table<WhetherInfo>() select emp).ToList();
        }
        public WhetherInfo GetEmployee(int id)
        {
            return _sqlConnection.Table<WhetherInfo>().FirstOrDefault(emp => emp.ID == id);
        }
        public void AddEmployee(WhetherInfo emp)
        {
            _sqlConnection.Insert(emp);
        }
        public void deleteEmployee(int id)
        {
            _sqlConnection.Delete<WhetherInfo>(id);
        }
    }
}
