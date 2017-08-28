#region CLR版本 4.0.30319.225
// Span 类
// 时间：2012-4-1 15:10:28
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
    public struct Span<T> : ISpan<T>
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public Span(T start, T end)
        {
            m_start = start;
            m_end = end;
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
        /// 获取段落起点
        /// </summary>
        public T Start
        {
            get
            {
                return m_start;
            }
        }

        /// <summary>
        /// 获取段落终点
        /// </summary>
        public T End
        {
            get
            {
                return m_end;
            }
        }

        private T m_start;
        private T m_end;
        #endregion // 属性及其私有变量

    }
}