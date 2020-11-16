using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WinningWorkflowSettting
{
    /// <summary>
    /// 特性处理相关功能
    /// </summary>
    public class AttributeFunction
    {
        /// <summary>
        /// 获取一个包含所有自定义特性的数组
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">查找的对象类型</param>
        /// <param name="inherit">指定是否搜索该成员的继承链以查找这些特性</param>
        /// <returns>一个包含所有自定义特性的数组，在未定义任何特性时为包含零个元素的数组</returns>
        public IEnumerable<T> GetCustomAttributes<T>(Type type, bool inherit)
            where T : Attribute
        {
            object[] attributes = type.GetCustomAttributes(typeof(T), false);

            foreach (var item in attributes)
            {
                yield return item as T;
            }
        }
        /// <summary>
        /// 获取一个包含所有自定义特性 
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">查找的对象类型</param>
        /// <param name="inherit">指定是否搜索该成员的继承链以查找这些特性</param>
        /// <returns>一个包含所有自定义特性 ，在未定义任何特性时为null</returns>
        public T GetCustomAttribute<T>(Type type, bool inherit)
            where T : Attribute
        {
            object[] attributes = type.GetCustomAttributes(typeof(T), false);

            return attributes.FirstOrDefault() as T;
        }
        /// <summary>
        /// 获取枚举值的特性
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="enumObject">枚举值</param>
        /// <returns>返回特性列表</returns>
        public IEnumerable<T> GetCustomAttributes<TEnum, T>(TEnum enumObject)
            where TEnum : struct, IComparable, IFormattable, IConvertible
            where T : Attribute
        {
            MemberInfo member = typeof(TEnum).GetMember(Enum.GetName(typeof(TEnum), enumObject))[0];
            Attribute[] result = Attribute.GetCustomAttributes(member, typeof(T));

            foreach (Attribute item in result)
            {
                yield return item as T;
            }
        }

        /// <summary>
        /// 获取枚举值的特性
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="enumObject">枚举值</param>
        /// <returns>返回特性</returns>
        public T GetCustomAttribute<TEnum, T>(TEnum enumObject)
            where TEnum : struct, IComparable, IFormattable, IConvertible
            where T : Attribute
        {
            MemberInfo member = typeof(TEnum).GetMember(Enum.GetName(typeof(TEnum), enumObject))[0];
            T result = Attribute.GetCustomAttribute(member, typeof(T)) as T;

            return result;
        }
    }
}
