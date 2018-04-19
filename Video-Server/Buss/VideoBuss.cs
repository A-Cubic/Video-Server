using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using VideoServer.Dao;
using VideoServer.Json;

namespace VideoServer.Buss
{
    public class VideoBuss
    {
        /// <summary>
        /// 数据对象
        /// </summary>
        private VideoDao videoDao;
        /// <summary>
        /// 构造函数
        /// </summary>
        public VideoBuss()
        {
            this.videoDao = new VideoDao();
        }

        #region public

        /// <summary>
        /// 获取主页数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetHomePageByCompanyId(string id, bool inner)
        {
            var json = this.getHomePageByCompanyId(id, inner);
            if(json == null)
            {
                return this.getError("1", "HomePage");
            }
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

        /// <summary>
        /// 获取入口列表信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetEntryByHomePageId(string id, bool inner)
        {
            var json = this.getEntryByHomePageId(id, inner);
            if (json == null)
            {
                return this.getError("2", "Entry");
            }
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

        /// <summary>
        /// 获取视频列表信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetItemsByEntryId(string id, bool inner)
        {
            var json = this.getItemsByEntryId(id, inner);
            if (json == null)
            {
                return this.getError("3", "Items");
            }
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

        /// <summary>
        /// 获取视频播放数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetVideoByItemId(string id, bool inner)
        {
            var json = this.getVideoByItemId(id, inner);
            if (json == null)
            {
                return this.getError("4", "Video");
            }
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

        /// <summary>
        /// 获取关联商品信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetGoodsByVideoId(string id)
        {
            var json = this.getGoodsByVideoId(id);
            if (json == null)
            {
                return this.getError("5", "Goods");
            }
            return JsonConvert.SerializeObject(json, Formatting.None);
        }

        #endregion

        #region private

        /// <summary>
        /// 获取错误信息对象
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private string getError(string code, string msg)
        {
            Error error = new Error();
            error.code = code;
            error.msg = msg;
            return JsonConvert.SerializeObject(error, Formatting.None);
        }

        /// <summary>
        /// 获取主页数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private HomePage getHomePageByCompanyId(string id, bool inner)
        {
            HomePage homePage = new HomePage();
            DataTable dtHomePage = this.videoDao.getHomePage(id);
            if (dtHomePage != null && dtHomePage.Rows.Count != 1)
                return null;
            homePage.ids = dtHomePage.Rows[0]["IDS"].ToString();
            homePage.title_img = dtHomePage.Rows[0]["TITLE_IMG"].ToString();
            homePage.title_text = dtHomePage.Rows[0]["TITLE_TEXT"].ToString();
            if (inner)
            {
                homePage.entry = this.getEntryByHomePageId(homePage.ids, inner);
            }
            return homePage;
        }

        /// <summary>
        /// 获取入口列表信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<Entry> getEntryByHomePageId(string id, bool inner)
        {
            List<Entry> list = new List<Entry>();
            DataTable dtEntry = this.videoDao.getEntry(id);
            if (dtEntry == null)
                return null;
            foreach (DataRow drEntry in dtEntry.Rows)
            {
                Entry entry = new Entry();
                entry.ids = drEntry["IDS"].ToString();
                entry.list_img = drEntry["LIST_IMG"].ToString();
                entry.list_inner_img = drEntry["LIST_INNER_IMG"].ToString();
                entry.list_text_p = drEntry["LIST_TEXT_P"].ToString();
                entry.list_text_s = drEntry["LIST_TEXT_S"].ToString();
                if (inner)
                {
                    entry.item = this.getItemsByEntryId(entry.ids, inner);
                }
                list.Add(entry);
            }

            return list;
        }

        /// <summary>
        /// 获取视频列表信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<Item> getItemsByEntryId(string id, bool inner)
        {
            List<Item> list = new List<Item>();
            DataTable dtItem = this.videoDao.getItmes(id);
            if (dtItem == null)
                return null;
            foreach (DataRow drItems in dtItem.Rows)
            {
                Item item = new Item();
                item.ids = drItems["IDS"].ToString();
                item.item_author = drItems["ITEM_AUTHOR"].ToString();
                item.item_img = drItems["ITEM_IMG"].ToString();
                item.item_text = drItems["ITEM_TEXT"].ToString();
                item.item_time = drItems["ITEM_TIME"].ToString();
                if (inner)
                {
                    item.video = this.getVideoByItemId(item.ids, inner);
                }
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// 获取视频播放数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Video getVideoByItemId(string id, bool inner)
        {
            Video video = new Video();
            DataTable dtVideo = this.videoDao.getVideo(id);
            if (dtVideo == null)
                return null;
            video.ids = dtVideo.Rows[0]["IDS"].ToString();
            video.video_text = dtVideo.Rows[0]["VIDEO_TEXT"].ToString();
            video.video_time = dtVideo.Rows[0]["VIDEO_TIME"].ToString();
            video.video_title = dtVideo.Rows[0]["VIDEO_TITLE"].ToString();
            video.video_url = dtVideo.Rows[0]["VIDEO_URL"].ToString();
            if (inner)
            {
                video.goods = this.getGoodsByVideoId(video.ids);
            }

            return video;
        }

        /// <summary>
        /// 获取关联商品信息数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<Goods> getGoodsByVideoId(string id)
        {
            List<Goods> list = new List<Goods>();
            DataTable dtGoods = this.videoDao.getGoods(id);
            if (dtGoods == null)
                return null;
            foreach (DataRow drGoods in dtGoods.Rows)
            {
                Goods goods = new Goods();
                goods.ids = drGoods["IDS"].ToString();
                goods.goods_img = drGoods["GOODS_IMG"].ToString();
                goods.goods_price = drGoods["GOODS_PRICE"].ToString();
                goods.goods_text = drGoods["GOODS_TEXT"].ToString();
                goods.goods_url = drGoods["GOODS_URL"].ToString();
                list.Add(goods);
            }

            return list;
        }

        #endregion
    }
}
