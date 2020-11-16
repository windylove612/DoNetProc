using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatYouWant
{
    public class addressDataObject
    {
        public class cityObj
        {
            public string ret { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public string country { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string isp { get; set; }
            public string type { get; set; }
            public string desc { get; set; }
            public cityObj()
            {
                this.ret = string.Empty;
                this.start = string.Empty;
                this.end = string.Empty;
                this.country = string.Empty;
                this.province = string.Empty;
                this.city = string.Empty;
                this.district = string.Empty;
                this.isp = string.Empty;
                this.type = string.Empty;
                this.desc = string.Empty;
            }
        }

        public class SohuIpObject
        {
            public string cid { get; set; }
            public string cip { get; set; }
            public string cname { get; set; }
            public SohuIpObject()
            {
                this.cid = "";
                this.cip = "";
                this.cname = "";
            }
        }
    }
}
