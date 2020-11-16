using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WhatYouWant
{
    public class pubDefines
    {
        public static class allPathDefine
        {
            public const string mainConfigPath = @".\allConfig";
            public const string mainSavePath = @".\allFiles";
        }
        public static class allNameDefine
        {
            public const string name_PathMemo = "memo";
            public const string name_SetDir = "configSetDir.ini";
            public const string name_ListBox = "configListBox.config";
            public const string name_PathGrid = "grid";
            public const string name_ModelType = "configModelType.config";
            public const string name_SetHotKey = "configSetHotKey.ini";
        }
        public static class toolTipsType
        {
            public const string type_Weather = "Weather";
            public const string type_GridDetail = "GridDetail";
        }

        /// <summary>
        /// 是否显示表格的明细信息
        /// </summary>
        public static bool isShowDetail = false;

        public static string sOwnBrowserPath = ConfigurationManager.AppSettings["OwnBrowserPath"];
    }
}
