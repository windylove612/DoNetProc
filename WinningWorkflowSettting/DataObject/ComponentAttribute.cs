using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinningWorkflowSettting
{
    /// <summary>
    /// 对象组合标签
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
    public class ComponentAttribute : Attribute
    {
        #region 构造函数
        /// <summary>
        /// 初始化对象组合标签对象
        /// </summary>
        /// <param name="fromType">注册到类型</param>
        public ComponentAttribute(Type fromType)
        {
            this.FromType = fromType;
            this.Name = null;
        }
        #endregion 构造函数

        /// <summary>
        /// 获取注册到类型
        /// </summary>
        public Type FromType { get; private set; }
        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name { get; set; }
    }
}
