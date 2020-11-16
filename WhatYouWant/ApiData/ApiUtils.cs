using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Xfrog.Net;
using System.Diagnostics;
using System.Web;
using System.Configuration;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WhatYouWant
{
    public class ApiUtils
    {
        public string appkey = ConfigurationManager.AppSettings["AppKey"];

        public bool ApiData_Get(PubApi.ApiTypeEnum getType,out object Obj, params object[] args)
        {
            Obj = null;
            switch (getType)
            {
                case PubApi.ApiTypeEnum.ApiMobileInfo:
                    {
                        string sPhone = args[0] as string;
                        ApiData_GetMobileInfo(appkey, sPhone);
                    }
                    break;
                case PubApi.ApiTypeEnum.ApiExpressInfo:
                    {
                        string sType = args[0] as string;
                        string sNum = args[1] as string;
                        ApiData_GetExpressInfo(sType, sNum, out Obj);
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        public bool ApiData_GetMobileInfo(string appkey, string mobileNum)
        {
            //手机归属地查询
            string url = "http://apis.juhe.cn/mobile/get";
            var parametersGet = new Dictionary<string, string>();
            parametersGet.Add("phone", mobileNum.Substring(0, 7)); //需要查询的手机号码或手机号码前7位
            parametersGet.Add("key", appkey);//你申请的key
            parametersGet.Add("dtype", ""); //返回数据的格式,xml或json，默认json

            PubApi apiProcess = new PubApi();
            string resultGet = apiProcess.sendPost(url, parametersGet, "get");

            apiDataObject.MobileInfoObj mobileInfos = JsonConvert.DeserializeObject<apiDataObject.MobileInfoObj>(resultGet);

            //JsonObject newObjGet = new JsonObject(resultGet);
            //string errorCode = newObjGet["error_code"].Value;
            if (mobileInfos != null)
            {
                if (mobileInfos.error_code == 0)
                {
                    string sNr = string.Empty;
                    sNr += "您查询的手机号信息为：" + "\r\n";
                    sNr += "省份：" + mobileInfos.result.province + "\r\n";
                    sNr += "城市：" + mobileInfos.result.city + "\r\n";
                    sNr += "区号：" + mobileInfos.result.areacode + "\r\n";
                    sNr += "邮编：" + mobileInfos.result.zip + "\r\n";
                    sNr += "运营商：" + mobileInfos.result.company;
                    System.Windows.Forms.MessageBox.Show(sNr);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(mobileInfos.resultcode.ToString() + ":" + mobileInfos.reason);
                }
            }
            return true;
        }

        /// <summary>
        /// 快递查询接口
        /// </summary>
        /// <param name="expressType">快递公司代号</param>
        /// <param name="expressNo">快递单号</param>
        /// <param name="ObjInfo">返回数据</param>
        /// <returns></returns>
        public bool ApiData_GetExpressInfo(string expressType, string expressNo, out object ObjInfo)
        {
            ObjInfo = null;
            try
            {
                string url = "http://www.kuaidi100.com/query?type=" + expressType + "&postid=" + expressNo;
                WebClient client = new WebClient();
                var buffer = client.DownloadData(url);
                string jsonText = Encoding.UTF8.GetString(buffer);

                string str = string.Empty;
                apiDataObject.ExpressInfoObj expressInfos = JsonConvert.DeserializeObject<apiDataObject.ExpressInfoObj>(jsonText);
                if (expressInfos != null)
                {
                    ObjInfo = expressInfos;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
    }
}
