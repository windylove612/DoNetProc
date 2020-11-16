using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WinningWorkflowSettting
{
    /// <summary>
    /// 工作流信息
    /// </summary>
    public class WorkflowInfo
    {
        /// <summary>
        /// 初始化工作流信息
        /// </summary>
        /// <param name="id">唯一键</param>
        /// <param name="name">名称</param>
        /// <param name="title">标题</param>
        public WorkflowInfo(string id, string name, string title)
        {
            this.Id = id;
            this.Name = name;
            this.Title = title;
            this.Activities = new List<ActivityInfo>();
        }
        /// <summary>
        /// 初始化工作流信息
        /// </summary>
        /// <param name="id">唯一键</param>
        /// <param name="name">名称</param>
        /// <param name="title">标题</param>
        public WorkflowInfo()
        {
        }
        /// <summary>
        /// 获取或者设置唯一键
        /// </summary>
        public string Id { get; private set; }
        /// <summary>
        /// 获取或者设置标题
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// 获取或者设置名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 获取工作流项信息的集合
        /// </summary>
        public List<ActivityInfo> Activities { get; private set; }

        public WorkflowInfo Clone()
        {
            WorkflowInfo newObj = new WorkflowInfo();
            newObj.Id = this.Id;
            newObj.Name = this.Name;
            newObj.Title = this.Title;
            newObj.Activities = this.Activities;
            return newObj;
        }
    }
}
