using System;
using Com.ACBC.Framework.Database;
         
namespace VideoServer.Dao
{
    public class VideoDao
    {
        public VideoDao()
        {
            if(DatabaseOperationWeb.TYPE == null)
            {
                DatabaseOperationWeb.TYPE = new DBManager();
            }
        }

        public string getDBTest()
        {
            return DatabaseOperationWeb.ExecuteSelectDS("select now()", "Test").Tables[0].Rows[0][0].ToString();
        }
    }
}
