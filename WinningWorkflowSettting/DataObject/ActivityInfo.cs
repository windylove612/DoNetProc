using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinningWorkflowSettting
{
    /// <summary>
    /// 工作流项
    /// </summary>
    public class ActivityInfo
    {
        /// <summary>
        /// 初始化工作流项对象
        /// </summary>
        /// <param name="workflowName">工作流名称</param>
        /// <param name="id">唯一键</param>
        /// <param name="title">标题</param>
        /// <param name="isEnabled">可用</param>
        /// <param name="handleName">处理名称</param>
        public ActivityInfo(string workflowName, string id, string title, bool isEnabled, string functionName, string moduleName, string className, string handleName,string sectionName,bool isCreate)
        {
            this.WorkflowName = workflowName;
            this.Id = id;
            this.Title = title;
            this.IsEnabled = isEnabled;
            this.HandleName = handleName;
            this.FunctionName = functionName;
            this.ModuleName = moduleName;
            this.ClassName = className;
            this.SectionName = sectionName;
            this.IsCreate = isCreate;
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
        /// 获取或者设置可用
        /// </summary>
        public bool IsEnabled { get; private set; }
        /// <summary>
        /// 获取或者设置处理名称
        /// </summary>
        public string HandleName { get; private set; }
        /// <summary>
        /// 获取或者设置工作流名称
        /// </summary>
        public string WorkflowName { get; private set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string FunctionName { get; private set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; private set; }
        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName { get; private set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string SectionName { get; private set; }
        /// <summary>
        /// IsCreate
        /// </summary>
        public bool IsCreate { get; private set; }
    }
}
