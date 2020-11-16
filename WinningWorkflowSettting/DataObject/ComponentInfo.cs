using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinningWorkflowSettting
{
    public class ComponentInfo
    {
        /// <summary>
        /// 获取或者设置注册名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或者设置类型别名
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 获取或者设置类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 获取或者设置注册到类型别名
        /// </summary>
        public string MapToName { get; set; }
        /// <summary>
        /// 获取或者设置注册到类型
        /// </summary>
        public Type MapTo { get; set; }
        /// <summary>
        /// 获取或者设置容器名称
        /// </summary>
        public string ContainerName { get; set; }
    }
}
