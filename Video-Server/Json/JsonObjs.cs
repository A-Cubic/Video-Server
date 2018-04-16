using System;
using System.Collections.Generic;

namespace VideoServer.Json
{

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
}
