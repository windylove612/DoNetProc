using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatYouWant
{
    public class weatherDataObject
    {
        public class weatherObj
        {
            public int status { get; set; }
            public string desc { get; set; }
            public weatherDetail data { get; set; }
            public weatherObj()
            {
                this.status = 0;
                this.desc = string.Empty;
                this.data = null;
            }
        }

        public class weatherDetail
        {
            public string wendu { get; set; }
            public string ganmao { get; set; }
            public string city { get; set; }
            public string aqi { get; set; }
            public List<weatherOne> forecast { get; set; }
            public weatherDetail()
            {
                this.wendu = string.Empty;
                this.ganmao = string.Empty;
                this.city = string.Empty;
                this.aqi = string.Empty;
                this.forecast = null;
            }
        }

        public class weatherOne
        {
            public string date { get; set; }
            public string high { get; set; }
            public string fengli { get; set; }
            public string low { get; set; }
            public string fengxiang { get; set; }
            public string type { get; set; }
        }

        public class weatherWebObj
        {
            public string temp { get; set; }
            public string tempDetail { get; set; }
            public string note { get; set; }
            public weatherWebObj()
            {
                this.temp = string.Empty;
                this.tempDetail = string.Empty;
                this.note = string.Empty;
            }
        }
    }
}
