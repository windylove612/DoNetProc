using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WhatYouWant
{
    public class useUtils
    {
        /// <summary>
        /// Windows API 对INI文件写方法
        /// </summary>
        /// <param name="lpApplicationName">要在其中写入新字串的小节名称。这个字串不区分大小写</param>
        /// <param name="lpKeyName">要设置的项名或条目名。这个字串不区分大小写。用null可删除这个小节的所有设置项</param>
        /// <param name="lpString">指定为这个项写入的字串值。用null表示删除这个项现有的字串</param>
        /// <param name="lpFileName">初始化文件的名字。如果没有指定完整路径名，则windows会在windows目录查找文件。如果文件没有找到，则函数会创建它</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        /// <summary>
        /// Windows API 对INI文件读方法
        /// </summary>
        /// <param name="lpApplicationName">欲在其中查找条目的小节名称。这个字串不区分大小写。如设为null，就在lpReturnedString缓冲区内装载这个ini文件所有小节的列表</param>
        /// <param name="lpKeyName">欲获取的项名或条目名。这个字串不区分大小写。如设为null，就在lpReturnedString缓冲区内装载指定小节所有项的列表</param>
        /// <param name="lpDefault">指定的条目没有找到时返回的默认值。可设为空（""）</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">初始化文件的名字。如没有指定一个完整路径名，windows就在Windows目录中查找文件</param>
        /// 注意：如lpKeyName参数为null，那么lpReturnedString缓冲区会载入指定小节所有设置项的一个列表。
        /// 每个项都用一个NULL字符分隔，最后一个项用两个NULL字符中止。也请参考GetPrivateProfileInt函数的注解
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, System.Text.StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, byte[] lpReturnedString, uint nSize, string lpFileName);   
        /// <summary>
        /// 读取section
        /// </summary>
        /// <param name="Strings"></param>
        /// <returns></returns>
        public static List<string> ReadSections(string iniFilename)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileString(null, null, null, buf, (uint)buf.Length, iniFilename);
            int k = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, k, i - k));
                    k = i + 1;
                }
            return result;
        }


        /// <summary>
        /// 读取指定区域Keys列表。
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Strings"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadSingleSection(string Section, string iniFilename)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            byte[] buf = new byte[65536];
            uint lenf = GetPrivateProfileString(Section, null, null, buf, (uint)buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < lenf; i++)
                if (buf[i] == 0)
                {
                    string sKey = Encoding.Default.GetString(buf, j, i - j);
                    string sValue = GetIniKeyValue(Section, sKey, iniFilename);
                    result.Add(sKey, sValue);
                    j = i + 1;
                }
            return result;
        }

        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public string ReadINI(string section, string key, string fileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, null, temp, 1024, fileName);
            return temp.ToString();
        }

        /// <summary>
        /// 向Ini文件中写入值
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <param name="key">键的名称</param>
        /// <param name="value">键的值</param>
        /// <returns>执行成功为True，失败为False。</returns>
        public static long WriteIniKey(string section, string key, string value, string FilePath)
        {
            if (section.Trim().Length <= 0 || key.Trim().Length <= 0 ||
                value.Trim().Length <= 0) return 0;

            return WritePrivateProfileString(section, key, value, FilePath);
        }

        /// <summary>
        /// 删除指定小节中的键
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <param name="key">键的名称</param>
        /// <returns>执行成功为True，失败为False。</returns>
        public static long DeleteIniKey(string section, string key, string FilePath)
        {
            if (section.Trim().Length <= 0 || key.Trim().Length <= 0) return 0;

            return WritePrivateProfileString(section, key, null, FilePath);
        }

        /// <summary>
        /// 删除指定的小节（包括这个小节中所有的键）
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <returns>执行成功为True，失败为False。</returns>
        public static long DeleteIniSection(string section, string FilePath)
        {
            if (section.Trim().Length <= 0) return 0;

            return WritePrivateProfileString(section, null, null, FilePath);
        }

        /// <summary>
        /// 获得指定小节中键的值
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <param name="key">键的名称</param>
        /// <param name="defaultValue">如果键值为空，或没找到，返回指定的默认值。</param>
        /// <param name="capacity">缓冲区初始化大小。</param>
        /// <returns>键的值</returns>
        public static string GetIniKeyValue(string section, string key, string defaultValue, int capacity, string FilePath)
        {
            if (section.Trim().Length <= 0 || key.Trim().Length <= 0) return defaultValue;

            System.Text.StringBuilder strTemp = new System.Text.StringBuilder(capacity);
            long returnValue = GetPrivateProfileString(section, key, defaultValue, strTemp, capacity, FilePath);

            return strTemp.ToString().Trim();
        }

        /// <summary>
        /// 获得指定小节中键的值
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <param name="key">键的名称</param>
        /// <param name="defaultValue">如果键值为空，或没找到，返回指定的默认值。</param>
        /// <returns>键的值</returns>
        public static string GetIniKeyValue(string section, string key, string defaultValue, string FilePath)
        {
            return GetIniKeyValue(section, key, defaultValue, 1024, FilePath);
        }

        /// <summary>
        /// 获得指定小节中键的值
        /// </summary>
        /// <param name="section">小节的名称</param>
        /// <param name="key">键的名称</param>
        /// <returns>键的值</returns>
        public static string GetIniKeyValue(string section, string key, string FilePath)
        {
            return GetIniKeyValue(section, key, string.Empty, 1024, FilePath);
        }
    }
}
