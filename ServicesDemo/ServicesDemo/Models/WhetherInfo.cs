using System;
using SQLite;

namespace ServicesDemo.Models
{

    public class WhetherInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int pressure
        {
            get;
            set;
        }
        public int humidity
        {
            get;
            set;
        }
        public string country
        {
            get;
            set;
        }


    }
}
