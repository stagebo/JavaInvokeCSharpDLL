#region CLR版本 4.0.30319.225
// Singleton 类
// 时间：2012-2-6 9:23:00
// 名称：普遍单例模型
// 大纲：非单例类的单例容器
//
// 创建人：郭威
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace TDQS
{
    internal static class GlobalInstanceCollection
    {
        static GlobalInstanceCollection()
        {
            m_instances = new Dictionary<Type, object>();
        }

   

        internal static void Add(this object instance)
        {
            Type type = instance.GetType();
            if (m_instances.ContainsKey(type))
            {
                return;
            }
            m_instances.Add(type, instance);
            foreach (Type baseType in type.SeekBaseType())
            {
                if (m_instances.ContainsKey(baseType))
                {
                    return;
                }
                if (!baseType.IsAbstract)
                {
                    continue;
                }
                if (m_instances.ContainsKey(baseType))
                {
                    m_instances[baseType] = instance;
                    continue;
                }
                m_instances.Add(baseType, instance);
            }
            foreach (Type interfaceType in type.GetInterfaces())
            {
                if (!m_instances.ContainsKey(interfaceType))
                {
                    m_instances.Add(interfaceType, instance);
                    continue;
                }
                if (!type.IsInstanceOfType(m_instances[interfaceType]))
                {
                    continue;
                }
                m_instances[interfaceType] = instance;
            }
        }

        internal static bool Contains(Type type)
        {
            return m_instances.ContainsKey(type);
        }

        internal static object Get(Type type)
        {
            return m_instances[type];
        }

        private static Dictionary<Type, object> m_instances;
    }

    public static class Singleton<T>
        where T : class
    {
        static Singleton()
        {
            m_lock = new object();
        }

        public static T GetInstance(params object[] args)
        {
            Type type = typeof(T);
            if (GlobalInstanceCollection.Contains(type))
            {
                return (T)GlobalInstanceCollection.Get(type);
            }
            if (type.IsInterface
                || type.IsAbstract)
            {
                return null;
            }
            lock (m_lock)
            {
                try
                {
                    object instance = type.New(args);
                    GlobalInstanceCollection.Add(instance);
                    return (T)instance;
                }
                catch
                {
                    return null;
                }
            }
        }
      
        private static readonly object m_lock;
    }    
}
