using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;


namespace WhatYouWant
{
    public class weatherUtils
    {
        private static string sLocateName = "合肥"; //默认地点是合肥

        /// <summary>
        /// 根据地区获取天气
        /// </summary>
        /// <returns></returns>
        public static string GetWeatherByCity(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
                sLocateName = cityName;
            try
            {
                string url = "http://www.weather.com.cn/data/sk/101010100.html";// +UrlEncodeNew(cityName);
                //string url = "http://wthrcdn.etouch.cn/weather_mini?city=" + UrlEncodeNew(cityName); //中华万年历的
                WebClient client = new WebClient();
                var buffer = client.DownloadData(url);
                //string jsonText = client.DownloadString(url);
                string jsonText = Encoding.UTF8.GetString(buffer);
                //jsonText = Encoding.Default.GetString(buffer);

                string str = string.Empty;
                weatherDataObject.weatherObj weatherInfos = JsonConvert.DeserializeObject<weatherDataObject.weatherObj>(jsonText);
                if (weatherInfos != null)
                {
                    if (weatherInfos.status == 1000)
                        str = weatherInfos.data.wendu;
                }
                return str;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string UrlEncodeNew(string url)
        {
            if (url == "")
                return url;
            byte[] bs = Encoding.UTF8.GetBytes(url);
            string msg = string.Empty;
            foreach (byte b in bs)
                msg += string.Format("%{0:X}", b);
            return msg;
        }

        public static weatherDataObject.weatherWebObj GetWeatherByCityWebServices(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
                sLocateName = cityName;
            try
            {
                weatherDataObject.weatherWebObj weathObj = new weatherDataObject.weatherWebObj();
                cn.com.webxml.www.WeatherWebService weatherInfo = new cn.com.webxml.www.WeatherWebService();
                string[] s = new string[23];//声明string数组存放返回结果
                s = weatherInfo.getWeatherbyCityName(cityName);
                if (s[8] == "")
                {
                    System.Windows.Forms.MessageBox.Show("暂时不支持您查询的城市");
                }
                else
                {
                    weathObj.temp = s[5];
                    weathObj.tempDetail = s[6];
                    weathObj.note = s[10];
                }
                return weathObj;
            }
            catch
            {
                return null;
            }
        }

    }
}
