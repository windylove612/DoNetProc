using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WhatYouWant
{
    public class HotKey
    {
        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）           
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            Keys vk                     //定义热键的内容
            );
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
            );
        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        private static KeyModifiers GetMainHot(string sMainHot)
        {
            KeyModifiers enumHot;
            switch (sMainHot)
            {
                case "None":
                    enumHot = KeyModifiers.None;
                    break;
                case "Alt":
                    enumHot = KeyModifiers.Alt;
                    break;
                case "Ctrl":
                    enumHot = KeyModifiers.Ctrl;
                    break;
                case "Shift":
                    enumHot = KeyModifiers.Shift;
                    break;
                case "WindowsKey":
                    enumHot = KeyModifiers.WindowsKey;
                    break;
                default:
                    enumHot = KeyModifiers.None;
                    break;
            }
            return enumHot;
        }

        public static Dictionary<int, DevExpress.XtraBars.BarButtonItem> dictHotKeys = new Dictionary<int, DevExpress.XtraBars.BarButtonItem>();
        internal static void SetHotKey(IntPtr Handle, Dictionary<string, DevExpress.XtraBars.BarButtonItem> dict)
        {
            //注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            //HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.Shift, Keys.S);
            int hostValue = 100;
            string mainHot = string.Empty;
            string itemHot = string.Empty;
            dictHotKeys.Clear();
            foreach (var detail in dict)
            {
                if (!string.IsNullOrEmpty(detail.Key))
                {
                    string[] itemArray = detail.Key.Split('+');
                    if (itemArray.Length >= 1)
                        mainHot = itemArray[0];
                    if (itemArray.Length >= 2)
                        itemHot = itemArray[1];
                    HotKey.RegisterHotKey(Handle, hostValue, GetMainHot(mainHot), (Keys)Enum.Parse(typeof(Keys), itemHot));
                }
                dictHotKeys.Add(hostValue, detail.Value);
                hostValue++;
            }
        }

        internal static void LogOutHotKey(IntPtr Handle)
        {
            //注销Id号为100的热键设定
            //HotKey.UnregisterHotKey(Handle, 100);
            foreach (var detail in dictHotKeys)
            {
                HotKey.UnregisterHotKey(Handle, detail.Key);
            }
        }

        internal static void processsHotKey(int iHotKey)
        {
            if (dictHotKeys.ContainsKey(iHotKey))
            {
                dictHotKeys[iHotKey].PerformClick();
            }
        }
    }
}
