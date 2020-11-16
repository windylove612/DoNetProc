using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatYouWant
{
    public class apiDataObject
    {
        public class MobileInfoObj
        {
            public string resultcode { get; set; }
            public string reason { get; set; }
            public MobileInfoDetail result { get; set; }
            public int error_code { get; set; }
            public MobileInfoObj()
            {
                this.resultcode = string.Empty;
                this.reason = string.Empty;
                this.error_code = 0;
            }
        }

        public class MobileInfoDetail
        {
            public string province { get; set; }
            public string city { get; set; }
            public string areacode { get; set; }
            public string zip { get; set; }
            public string company { get; set; }
            public string card { get; set; }
            public MobileInfoDetail()
            {
                this.province = string.Empty;
                this.city = string.Empty;
                this.areacode = string.Empty;
                this.zip = string.Empty;
                this.company = string.Empty;
                this.card = string.Empty;
            }
        }

        public class ExpressInfoObj
        {
            public string message { get; set; }
            public string nu { get; set; }
            public string ischeck { get; set; }
            public string condition { get; set; }
            public string com { get; set; }
            public string status { get; set; }
            public string state { get; set; }
            public List<ExpressInfoDetail> data { get; set; }
            public ExpressInfoObj()
            {
                this.message = string.Empty;
                this.nu = string.Empty;
                this.ischeck = string.Empty;
                this.condition = string.Empty;
                this.com = string.Empty;
                this.status = string.Empty;
                this.state = string.Empty;
                this.data = new List<ExpressInfoDetail>();
            }
        }

        public class ExpressInfoDetail
        {
            public string time { get; set; }
            public string ftime { get; set; }
            public string context { get; set; }
            public string location { get; set; }
            public ExpressInfoDetail()
            {
                this.time = string.Empty;
                this.ftime = string.Empty;
                this.context = string.Empty;
                this.location = string.Empty;
            }
        }
    }
}