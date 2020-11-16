using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace WhatYouWant
{
    [ConfigurationCollection(typeof(MyKeyValueSetting))]
    public class DataBaseDetailCollection : System.Configuration.ConfigurationElementCollection
    {
        public DataBaseDetailCollection()
            : base(StringComparer.OrdinalIgnoreCase)    // 忽略大小写
        {
        }
        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        new public MyKeyValueSetting this[string name]
        {
            get
            {
                return (MyKeyValueSetting)base.BaseGet(name);
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyKeyValueSetting();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MyKeyValueSetting)element).name;
        }
        // 说明：如果不需要在代码中修改集合，可以不实现Add， Clear， Remove
        public void Add(MyKeyValueSetting setting)
        {
            this.BaseAdd(setting);
        }
        public void Clear()
        {
            base.BaseClear();
        }
        public void Remove(string name)
        {
            base.BaseRemove(name);
        }
    }


    public class MyKeyValueSetting : System.Configuration.ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public string name
        {
            get
            {
                return (string)base["name"];
            }
            set
            {
                base["name"] = value;
            }
        }

        [ConfigurationProperty("ConnectString", IsRequired = true)]
        public string ConnectString
        {
            get
            {
                return (string)base["ConnectString"];
            }
            set
            {
                base["ConnectString"] = value;
            }
        }

        [ConfigurationProperty("table", IsRequired = true)]
        public string table
        {
            get
            {
                return (string)base["table"];
            }
            set
            {
                base["table"] = value;
            }
        }

        [ConfigurationProperty("column", IsRequired = true)]
        public string column
        {
            get
            {
                return (string)base["column"];
            }
            set
            {
                base["column"] = value;
            }
        }
    }
}
