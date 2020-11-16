using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WhatYouWant
{
    public class pubFunction
    {
        /// <summary>
        /// 往txt写入内容
        /// </summary>
        /// <param name="paths">文件路径</param>
        /// <param name="contents">写入内容</param>
        /// <returns></returns>
        public static bool WriteContentToTxt(string paths, string contents, out string msg)
        {
            msg = string.Empty;
            try
            {
                byte[] fs = System.Text.Encoding.Default.GetBytes(contents);
                //全部内容读取之后重新写入，目前没其他好办法
                FileStream writeFile = new FileStream(paths, FileMode.Create);
                writeFile.Write(fs, 0, fs.Length);
                writeFile.Close();
                writeFile.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
        public static Dictionary<string, string> ReadContentFromTxt(string paths, out string msg)
        {
            msg = string.Empty;
            Dictionary<string, string> resultList = new Dictionary<string, string>();
            try
            {
                string[] contents = File.ReadAllLines(paths, Encoding.Default);
                foreach (string str in contents)
                {
                    if (str.Contains("="))
                        resultList.Add(str.Split('=')[0].ToString(), str.Split('=')[1].ToString());
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return resultList;
        }

        public static string[] ReadContentFromTxtAll(string paths, out string msg)
        {
            msg = string.Empty;
            string[] contents = { };
            try
            {
                contents = File.ReadAllLines(paths, Encoding.Default);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return contents;
        }

        public static List<string> ReadContentFromTxtToLList(string paths, out string msg)
        {
            msg = string.Empty;
            List<string> contentsList = new List<string>();
            string[] contents;
            try
            {
                contents = File.ReadAllLines(paths, Encoding.Default);
                foreach (var item in contents)
                {
                    contentsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return contentsList;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="msg"></param>
        public static void deleteFile(string path, out string msg)
        {
            msg = string.Empty;
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
        }

        public static string dictionaryToString(Dictionary<string, string> dict,out string msg)
        {
            msg = string.Empty;
            string resultStr = string.Empty;
            try
            {
                if (dict != null)
                {
                    int count = dict.Count;
                    int index = 1;
                    foreach (var item in dict)
                    {
                        if (index < count)
                        {
                            resultStr += item.Key + "=" + item.Value + "\r\n";
                        }
                        else
                        {
                            resultStr += item.Key + "=" + item.Value;
                        }
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return resultStr;
        }

        /// <summary>
        /// 检查文件是否存在，没有则创建
        /// </summary>
        public static void CheckFileExists(string dirName, string filename)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            if (!File.Exists(dirName + "\\" + filename))
            {
                File.Create(dirName + "\\" + filename).Close();

            }
        }


    }
}
