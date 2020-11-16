using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.InteropServices;
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
    public static class commonUtils
    {
        /// <summary>
        /// 检测网络是否连通
        /// </summary>
        public static class InternetCheck
        {
            [DllImport("wininet.dll")]
            private extern static bool InternetGetConnectedState(int Description, int ReservedValue);

            /// <summary>
            /// 用于检查网络是否可以连接互联网,true表示连接成功,false表示连接失败 
            /// </summary>
            /// <returns></returns>
            public static bool IsConnectInternet()
            {
                int Description = 0;
                return InternetGetConnectedState(Description, 0);
            }
        }

        /// <summary>
        /// 获取公网IP
        /// </summary>
        /// <returns></returns>
        public static string GetIP()
        {
            string tempip = "";
            try
            {
                WebRequest wr = WebRequest.Create("http://www.ip138.com/");
                Stream s = wr.GetResponse().GetResponseStream();
                StreamReader sr = new StreamReader(s, Encoding.Default);
                string all = sr.ReadToEnd(); //读取网站的数据

                int start = all.IndexOf("您的IP地址是：[") + 9;
                int end = all.IndexOf("]", start);
                tempip = all.Substring(start, end - start);
                sr.Close();
                s.Close();
            }
            catch
            { }
            return tempip;
        }

        /// <summary>
        /// 取得外网 IP Address
        /// </summary>
        /// <returns></returns>
        public static string GetExtranetIPAddress()
        {
            HttpWebRequest request = HttpWebRequest.Create("http://www.ip138.com/ips138.asp") as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0";
            string ip = string.Empty;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string result = reader.ReadToEnd();
                string pattern = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
                ip = Regex.Match(result, pattern).ToString();
            }
            return ip;
        }


        public static string GetIP1()
        {
            string tempip = "未获取到IP地址";
            try
            {
                WebRequest request = WebRequest.Create("http://ip.qq.com/");
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                string htmlinfo = sr.ReadToEnd();
                //匹配IP的正则表达式
                Regex r = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None);
                Match mc = r.Match(htmlinfo);
                //获取匹配到的IP
                tempip = mc.Groups[0].Value;

                resStream.Close();
                sr.Close();
            }
            catch (Exception ex)
            { }

            return tempip;
        }

        public static string GetIPBySohu()
        {
            string tempip = "未获取到IP地址";
            try
            {
                WebRequest request = WebRequest.Create("https://pv.sohu.com/cityjson");
                request.Timeout = 10000;
                WebResponse response = request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, System.Text.Encoding.Default);
                string htmlinfo = sr.ReadToEnd();
                //var returnCitySN = {"cip": "36.33.216.237", "cid": "340000", "cname": "安徽省"};
                int index = htmlinfo.IndexOf("{");
                htmlinfo = htmlinfo.Substring(index, htmlinfo.Length - index);
                if (htmlinfo.EndsWith(";"))
                    htmlinfo = htmlinfo.Substring(0, htmlinfo.Length - 1);
                //获取匹配到的IP
                addressDataObject.SohuIpObject SohuIp = Newtonsoft.Json.JsonConvert.DeserializeObject<addressDataObject.SohuIpObject>(htmlinfo);
                if (SohuIp != null)
                {
                    tempip = SohuIp.cip;
                }
                resStream.Close();
                sr.Close();
            }
            catch (Exception ex)
            { }

            return tempip;
        }

        public static bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        /// <summary>
        /// 新浪api获取地区
        /// </summary>
        /// <returns></returns>
        public static string GetSinaIp(string ip, out string cityName)
        {
            string msgName = string.Empty;
            try
            {
                string url = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=json&ip=" + ip;
                WebClient client = new WebClient();
                var buffer = client.DownloadData(url);
                string jsonText = Encoding.UTF8.GetString(buffer);
                string str = string.Empty;
                addressDataObject.cityObj cityInfos = JsonConvert.DeserializeObject<addressDataObject.cityObj>(jsonText);
                if (cityInfos != null)
                {
                    str = cityInfos.country + cityInfos.province + cityInfos.city;
                    msgName = cityInfos.city;
                }
                cityName = msgName;
                return str;
            }
            catch
            {
                cityName = "";
                return "";
            }
        }

        public static string GetCityNameByPcOnline(string ip, out string cityName)
        {
            string msgName = string.Empty;
            try
            {
                string url = "http://whois.pconline.com.cn/ip.jsp";
                WebClient client = new WebClient();
                var buffer = client.DownloadData(url);
                string jsonText = Encoding.Default.GetString(buffer);
                jsonText = jsonText.Replace("\r", "").Replace("\n", "");
                string str = string.Empty;
                if (!string.IsNullOrEmpty(jsonText))
                {
                    //按省和市之间截取
                    int indexStart = jsonText.IndexOf("省");
                    int indexEnd = jsonText.IndexOf("市");
                    msgName = jsonText.Substring(indexStart + 1, indexEnd - indexStart - 1);
                    str = jsonText.Substring(0, indexEnd + 1);
                }
                cityName = msgName;
                return str;
            }
            catch
            {
                cityName = "";
                return "";
            }
        }
    }
}
