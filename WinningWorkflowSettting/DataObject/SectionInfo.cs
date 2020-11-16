using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinningWorkflowSettting
{
    /// <summary>
    /// Section节点信息
    /// </summary>
    public class SectionInfo
    {
        /// <summary>
        /// Section节点信息
        /// </summary>
        /// <param name="name">节点名称</param>
        /// <param name="type">节点属性</param>
        public SectionInfo(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
        /// <summary>
        /// 节点属性
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; private set; }
    }
}
