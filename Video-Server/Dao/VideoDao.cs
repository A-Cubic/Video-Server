using System;
using System.Data;
using Com.ACBC.Framework.Database;
         
namespace VideoServer.Dao
{
    public class VideoDao
    {
        /// <summary>
        /// 构造函数
        /// </summary>
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

        /// <summary>
        /// 获取主页信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getHomePage(string id)
        {
            string sqls = "SELECT * "
                        + "FROM T_LIST_HOMEPAGE A "
                        + "WHERE A.COMPANY = " + id;

            DataTable dt = DatabaseOperationWeb.ExecuteSelectDS(sqls, "T").Tables[0];

            return dt;
        }

        /// <summary>
        /// 获取入口列表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getEntry(string id)
        {
            string sqls = "SELECT * "
                        + "FROM T_LIST_ENTRY A "
                        + "WHERE A.HOMEPAGE = " + id;

            DataTable dt = DatabaseOperationWeb.ExecuteSelectDS(sqls, "T").Tables[0];

            return dt;
        }

        /// <summary>
        /// 获取视频列表信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getItmes(string id)
        {
            string sqls = "SELECT * "
                        + "FROM T_LIST_ITEMS A "
                        + "WHERE A.ENTRY = " + id;

            DataTable dt = DatabaseOperationWeb.ExecuteSelectDS(sqls, "T").Tables[0];

            return dt;
        }

        /// <summary>
        /// 获取视频播放信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getVideo(string id)
        {
            string sqls = "SELECT * "
                        + "FROM T_LIST_VIDEO A "
                        + "WHERE A.ITEM = " + id;

            DataTable dt = DatabaseOperationWeb.ExecuteSelectDS(sqls, "T").Tables[0];

            return dt;
        }

        /// <summary>
        /// 获取关联商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getGoods(string id)
        {
            string sqls = "SELECT * "
                        + "FROM T_LIST_GOODS A "
                        + "WHERE A.VIDEO = " + id;

            DataTable dt = DatabaseOperationWeb.ExecuteSelectDS(sqls, "T").Tables[0];

            return dt;
        }
    }
}
