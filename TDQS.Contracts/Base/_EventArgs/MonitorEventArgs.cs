#region CLR版本 4.0.30319.225
// MonitorEventArgs 类
// 时间：2012-2-22 18:14:38
// 名称：
// 大纲：
//
// 创建人：郭威
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS
{
    /// <summary>
    /// 
    /// </summary>
    public class MonitorEventArgs
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public MonitorEventArgs(object target)
            : base()
        {
            m_target = target;
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        public object Target
        {
            get
            {
                return m_target;
            }
        }

        private object m_target;

        #endregion // 属性及其私有变量

    }

    public class MonitorEventArgs<T>
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public MonitorEventArgs(T target)
            : base()
        {
            m_target = target;
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        public T Target
        {
            get
            {
                return m_target;
            }
        }

        private T m_target;

        #endregion // 属性及其私有变量

    }
}