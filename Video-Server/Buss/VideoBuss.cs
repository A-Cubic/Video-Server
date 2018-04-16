using System;
using Newtonsoft.Json;
using VideoServer.Dao;
using VideoServer.Json;

namespace VideoServer.Buss
{
    public class VideoBuss
    {
        private VideoDao dao;
        public VideoBuss()
        {
            this.dao = new VideoDao();
        }

        public string getTestString()
        {
            return dao.getDBTest();
        }

        public string getVList()
        {
            VList list = new VList();
            VListMain main = new VListMain();
            main.img = "http://localhost:8080/static/L6.png";
            main.text = "运动有益于身心";
            main.word = "运动";
            list.main = main;

            return JsonConvert.SerializeObject(list, Formatting.None);
        }
    }
}
