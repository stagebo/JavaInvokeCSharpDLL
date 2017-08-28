#region CLR版本 4.0.30319.225
// ValueChangeEventArgs 类
// 时间：2012-2-6 9:23:00
// 名称：值变化事件参数类
// 大纲：值变化事件参数容器，为值变化提供参数依据
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

namespace TDQS
{
    /// <summary>
    /// 值变化事件参数类
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    public class ValueChangeEventArgs<T> : EventArgs
    {
        #region 构造和析构
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="oldValue">旧值</param>
        /// <param name="newValue">新值</param>
        public ValueChangeEventArgs(T oldValue, T newValue)
            : base()
        {
            m_oldValue = oldValue;
            m_newValue = newValue;
        }
        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 获取旧值
        /// </summary>
        public T OldValue
        {
            get
            {
                return m_oldValue;
            }
        }
        /// <summary>
        /// 获取新值
        /// </summary>
        public T NewValue
        {
            get
            {
                return m_newValue;
            }
        }
        //旧值
        protected T m_oldValue;
        //新值
        protected T m_newValue;
        #endregion // 属性及其私有变量
    }
}
