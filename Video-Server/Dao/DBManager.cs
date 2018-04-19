using System;
using Com.ACBC.Framework.Database;

namespace VideoServer.Dao
{
    public class DBManager : IType
    {
        private DBType dbt;
        private string str = "";

        public DBManager()
        {
            var url = System.Environment.GetEnvironmentVariable("VideoDBUrl");
            var uid = System.Environment.GetEnvironmentVariable("VideoDBUser");
            var port = System.Environment.GetEnvironmentVariable("VideoDBPort");
            var passd = System.Environment.GetEnvironmentVariable("VideoDBPassword");

            this.str = "Server="+ url 
                     + ";Port="+ port 
                     + ";Database=video;Uid="+ uid 
                     + ";Pwd="+ passd 
                     + ";CharSet=utf8;";
            Console.Write(this.str);
            this.dbt = DBType.Mysql;
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
