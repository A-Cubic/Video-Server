using System;
using System.Collections.Generic;

namespace VideoServer.Json
{
    /// <summary>
    /// 错误信息
    /// </summary>
    public class Error
    {
        public string code;
        public string msg;
    }


    /// <summary>
    /// 列表页列表信息
    /// </summary>
    public class VListItem
    {
        public string id;
        public string img;
        public string name;
        public string time;
        public string person;
    }

    /// <summary>
    /// 列表页题头信息
    /// </summary>
    public class VListMain
    {
        public string img;
        public string word;
        public string text;
    }

    /// <summary>
    /// 列表页信息
    /// </summary>
    public class VList
    {
        public List<VListItem> item;
        public VListMain main;
    }

    /// <summary>
    /// 首页信息
    /// </summary>
    public class HomePage
    {
        public string ids;
        public string title_img;
        public string title_text;

        public List<Entry> entry;
    }

    /// <summary>
    /// 首页入口信息
    /// </summary>
    public class Entry
    {
        public string ids;
        public string list_img;
        public string list_text_p;
        public string list_text_s;
        public string list_inner_img;

        public List<Item> item;
    }

    /// <summary>
    /// 分类列表信息
    /// </summary>
    public class Item
    {
        public string ids;
        public string item_img;
        public string item_text;
        public string item_time;
        public string item_author;

        public Video video;
    }

    /// <summary>
    /// 视频播放页
    /// </summary>
    public class Video
    {
        public string ids;
        public string video_title;
        public string video_text;
        public string video_time;
        public string video_url;

        public List<Goods> goods;
    }

    /// <summary>
    /// 关联商品信息
    /// </summary>
    public class Goods
    {
        public string ids;
        public string goods_img;
        public string goods_text;
        public string goods_price;
        public string goods_url;
    }
}
