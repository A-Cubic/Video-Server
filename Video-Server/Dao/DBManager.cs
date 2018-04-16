using System;
using Com.ACBC.Framework.Database;

namespace VideoServer.Dao
{
    public class DBManager : IType
    {
        private DBType dbt;
        private string str = "Server=localhost;Port=3306;Database=mysql;Uid=root;Pwd=13161111;CharSet=utf8;";

        public DBManager()
        {
            this.dbt = DBType.Mysql;
            //this.str = "";
        }

        public DBManager(DBType d, string s)
        {
            this.dbt = d;
            this.str = s;
        }

        public DBType getDBType()
        {
            return dbt;
        }

        public string getConnString()
        {
            return str;
        }

        public void setConnString(string s)
        {
            this.str = s;
        }
    }
}
