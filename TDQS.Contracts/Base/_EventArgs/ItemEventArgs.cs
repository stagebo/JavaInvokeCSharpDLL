#region CLR版本 4.0.30319.225
// ItemEventArgs 类
// 时间：2012-2-6 9:23:00
// 名称：项事件参数类
// 大纲：项事件参数容器，常与ItemEventHandler配合使用
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
using System.ComponentModel;

namespace TDQS
{
    /// <summary>
    /// 项事件参数类
    /// </summary>
    /// <typeparam name="T">项类型</typeparam>
    public class ItemEventArgs<T> : CancelEventArgs
    {
        #region 构造和析构
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="item">项</param>
        public ItemEventArgs(T item)
            : base()
        {
            m_item = item;
            m_index = -1;
            Cancel = false;
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
        /// 获取项
        /// </summary>
        public T Item
        {
            get
            {
                return m_item;
            }
        }

        /// <summary>
        /// 获取项的索引值
        /// </summary>
        public int Index
        {
            get
            {
                return m_index;
            }
            set
            {
                m_index = value;
            }
        }

        //项
        protected T m_item;
        //项的索引值
        protected int m_index;
        #endregion // 属性及其私有变量
    }
}
