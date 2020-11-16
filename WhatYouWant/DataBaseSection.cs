using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace WhatYouWant
{
    public class DataBaseSection : System.Configuration.ConfigurationSection
    {
        private static readonly ConfigurationProperty s_property
        = new ConfigurationProperty(string.Empty, typeof(DataBaseDetailCollection), null,
                                        ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public DataBaseDetailCollection Section
        {
            get
            {
                return (DataBaseDetailCollection)base[s_property];
            }
            set
            {
                base[s_property] = value;
            }
        }
    }
}
