using System;

namespace Datalayer
{

    /// <summary>
    /// following classes are used for getting raw data from external source: https://fakerapi.it/api/v1/products
    /// </summary>
    public class imageItem
    {
        public string title { get; set; }
        public string description
        {
            get; set;
        }
        public string url { get; set; }
    }
    public class dataitem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string ean { get; set; }
        public string upc { get; set; }
        public string image { get; set; }
        public imageItem[] images { get; set; }
        public string price { get; set; }
    }

    public class responsecontent
    {
        public string status { get; set; }
        public int code { get; set; }
        public int total { get; set; }
        public dataitem[] data { get; set; }
    }
}
