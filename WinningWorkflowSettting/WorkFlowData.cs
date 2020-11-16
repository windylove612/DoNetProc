using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Reflection;

namespace WinningWorkflowSettting
{
    public class WorkFlowData
    {
        /// <summary>
        /// 创建默认的工作流配置
        /// </summary>
        /// <param name="fullConfigFileName">配置文件</param>
        /// <param name="workflows">工作流定义集合</param>
        public void CreateWorkflows(string fullConfigFileName, List<WorkflowInfo> workflows)
        {
            XDocument doc = new XDocument();
            //建立Xml的定义声明
            XDeclaration declaration = new XDeclaration("1.0", "utf-8", null);
            doc.Declaration = declaration;
            //建立配置文件根节点
            XElement element = new XElement(@"configuration");
            doc.Add(element);
            //建立configSections节点
            XElement sectionsElement = new XElement(@"configSections");
            element.Add(sectionsElement);

            //LogicPath Section
            XElement logicPathSectionElement = CreateSectionXElement(@"LogicPath");
            sectionsElement.Add(logicPathSectionElement);
            //LogicPath element
            XElement logicPathElement = CreateLogicPathXElement(workflows);
            element.Add(logicPathElement);

            foreach (WorkflowInfo workflow in workflows)
            {
                //Section
                sectionsElement.Add(CreateSectionXElement(workflow.Name));
                //Element
                element.Add(CreateWorkflowXElement(workflow));
            }

            doc.Save(fullConfigFileName);
        }
        /// <summary>
        /// 创建Section节点
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        private XElement CreateSectionXElement(string name)
        {
            XElement result = new XElement(@"section");
            XAttribute nameAttribute = new XAttribute(@"name", name);
            result.Add(nameAttribute);
            XAttribute typeAttribute = new XAttribute(@"type",
                @"Winning.FrameWork.Core.Configuration.TreeHandler`1[[Winning.FrameWork.Core.Logic.Element.EventLogicPathElement, Winning.FrameWork.Core.Logic, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null]], Winning.FrameWork.Core, Version=5.0.0.0, Culture=neutral, PublicKeyToken=null");
            result.Add(typeAttribute);

            return result;
        }

        private XElement CreateLogicPathXElement(List<WorkflowInfo> workflows)
        {
            XElement result = new XElement(@"LogicPath");
            XElement groupElement = new XElement(@"NodeGroup");
            result.Add(groupElement);

            foreach (WorkflowInfo workflow in workflows)
            {
                XElement nodeElement = new XElement(@"NodeInfo");
                groupElement.Add(nodeElement);
                XAttribute eventAttribute = new XAttribute(@"EventLogicPath", workflow.Name);
                nodeElement.Add(eventAttribute);
                XAttribute goToAttribute = new XAttribute(@"GotoLogicPath", @"");
                nodeElement.Add(goToAttribute);
                XAttribute memoAttribute = new XAttribute(@"Memo", workflow.Title);
                nodeElement.Add(memoAttribute);
                XAttribute indexAttribute = new XAttribute(@"IndexId", workflow.Id);
                nodeElement.Add(indexAttribute);
            }
            return result;
        }

        private XElement CreateWorkflowXElement(WorkflowInfo workflow)
        {
            XElement result = new XElement(workflow.Name);
            XElement groupElement = new XElement(@"NodeGroup");
            result.Add(groupElement);
            foreach (ActivityInfo activity in workflow.Activities)
            {
                string[] handles = activity.HandleName.Split(new char[] { ',' });
                string functionName = string.Empty;
                string className = string.Empty;
                string moduleName = string.Empty;
                if (handles.Length >= 3)
                {
                    functionName = handles[0];
                    className = handles[1];
                    moduleName = string.Join(",", handles.Skip(2).Take(handles.Length - 2));
                }
                else
                {
                    moduleName = activity.HandleName;
                }

                XElement nodeElement = new XElement(@"NodeInfo");
                groupElement.Add(nodeElement);
                XAttribute logicPathAttribute = new XAttribute(@"SalfLogicPath", activity.WorkflowName);
                nodeElement.Add(logicPathAttribute);
                XAttribute goToAttribute = new XAttribute(@"GotoLogicPath", @"");
                nodeElement.Add(goToAttribute);
                XAttribute moduleNameAttribute = new XAttribute(@"ModuleName", moduleName);
                nodeElement.Add(moduleNameAttribute);
                XAttribute startClassAttribute = new XAttribute(@"StartClass", className);
                nodeElement.Add(startClassAttribute);
                XAttribute startFunctionAttribute = new XAttribute(@"StartFunction", functionName);
                nodeElement.Add(startFunctionAttribute);
                XAttribute isCreateAttribute = new XAttribute(@"IsCreate", @"false");
                nodeElement.Add(isCreateAttribute);
                XAttribute enabledAttribute = new XAttribute(@"Enabled", activity.IsEnabled);
                nodeElement.Add(enabledAttribute);
                XAttribute memoAttribute = new XAttribute(@"Memo", activity.Title);
                nodeElement.Add(memoAttribute);
                XAttribute indexAttribute = new XAttribute(@"IndexId", activity.Id);
                nodeElement.Add(indexAttribute);
            }

            return result;
        }

        /// <summary>
        /// 加载类型信息
        /// </summary>
        /// <returns>返回类型信息</returns>
        public List<ComponentInfo> LoadTypeFromAssembly(string dllName, string containerName)
        {
            List<ComponentInfo> result = new List<ComponentInfo>();
            string file = dllName;
            List<Type> types = new List<Type>();
            try
            {
                Assembly assembly = Assembly.LoadFile(file);
                types.AddRange(assembly.GetExportedTypes());
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("从文件{0}中加载程序集失败！", file) + ex.Message;
                System.Windows.Forms.MessageBox.Show(sMsg);
            }

            foreach (Type type in types)
            {
                AttributeFunction func = new AttributeFunction();
                List<ComponentAttribute> components = new List<ComponentAttribute>();
                try
                {
                    components.AddRange(func.GetCustomAttributes<ComponentAttribute>(type, false));
                }
                catch (Exception ex)
                {
                    string sMsg = string.Format("从文件{0}中加载程序集失败！", file) + ex.Message;
                    System.Windows.Forms.MessageBox.Show(sMsg);
                }
                foreach (var item in components)
                {
                    string fromKey = this.GetTypeGuid(item.FromType);
                    ComponentInfo typeName = new ComponentInfo
                    {
                        Name = item.Name,
                        TypeName = fromKey,
                        Type = item.FromType,
                        MapToName = type.GUID.ToString("B").ToUpper(),
                        MapTo = type,
                        ContainerName = containerName,
                    };
                    result.Add(typeName);
                }
            }

            return result.OrderBy(p => p.TypeName).ToList();
        }

        /// <summary>
        /// 获取类型唯一键
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>返回类型唯一键</returns>
        private string GetTypeGuid(Type type)
        {
            string result = type.GUID.ToString("B").ToUpper();

            //泛型处理
            if (type.IsGenericType)
            {
                foreach (Type gType in type.GetGenericArguments())
                {
                    result += this.GetTypeGuid(gType);
                }
            }
            return result;
        }
    }
}
