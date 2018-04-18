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
            var url = System.Environment.GetEnvironmentVariable("VideoDBUrl", EnvironmentVariableTarget.User);
            var uid = System.Environment.GetEnvironmentVariable("VideoDBUser", EnvironmentVariableTarget.User);
            var passd = System.Environment.GetEnvironmentVariable("VideoDBPassword", EnvironmentVariableTarget.User);

            this.str = "Server="+ url 
                     + ";Port=13306;Database=video;Uid="+ uid 
                     + ";Pwd="+ passd 
                     + ";CharSet=utf8;";

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
