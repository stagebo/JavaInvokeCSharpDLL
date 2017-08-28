#region CLR版本 4.0.30319.269
// ChangedEventArgs 类
// 时间：2012/6/5 14:43:10
// 名称：元件改变事件函数参数
// 大纲：元件改变事件函数参数
//
// 创建人：刘东亮
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 元件改变事件函数参数
    /// </summary>
    public class ChangedEventArgs : EventArgs
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="explainTableColumn">属性说明对象</param>
        /// <param name="oldValue">属性改变前值</param>
        /// <param name="value">属性改变后值</param>
        public ChangedEventArgs(String propertyName, IXExplanationField explainTableColumn,Object oldValue, Object value)
        {
            m_PropertyName = propertyName;
            m_explainTableColumn = explainTableColumn;
            m_OldValue = oldValue;
            m_Value = value;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public ChangedEventArgs(String propertyName,object value, TriggerType trigType = TriggerType.PorperChange)
        {
            m_PropertyName = propertyName;
            m_Value = value;
            m_triggerType = trigType;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public ChangedEventArgs(String propertyName, TriggerType trigType = TriggerType.PorperChange)
        {
            m_PropertyName = propertyName;
            m_triggerType = trigType;
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        private IXExplanationField m_explainTableColumn;

        /// <summary>
        /// 元件属性字段说明对象
        /// </summary>
        public IXExplanationField ExplainTableColumn
        {
            get
            { 
                return m_explainTableColumn; 
            }
        }

        /// <summary>
        /// 获取改变值的属性名称
        /// </summary>
        public String PropertyName
        {
            get
            {
                return m_PropertyName;
            }
        }
        private String m_PropertyName;


        /// <summary>
        /// 获取属性改变后的值
        /// </summary>
        public Object Value
        {
            get
            {
                return m_Value;
            }
        }
        /// <summary>
        /// 属性改变后的值
        /// </summary>
        private Object m_Value;


        /// <summary>
        /// 获取属性改变前的值
        /// </summary>
        public Object OldValue
        {
            get
            {
                return m_OldValue;
            }
        }
        /// <summary>
        /// 属性改变后的值
        /// </summary>
        private TriggerType m_triggerType;

        /// <summary>
        /// 获取属性改变前的值
        /// </summary>
        public TriggerType triggerType
        {
            get
            {
                return m_triggerType;
            }
        }
        /// <summary>
        /// 属性改变后的值
        /// </summary>
        private Object m_OldValue;
        /// <summary>
        /// 指示此次事件是否需要更新视图显示
        ///  </summary>
        public bool NeedUpdateView = false;
        
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 触发类型
    /// </summary>
    public enum TriggerType
    {
        PorperChange = 0,
        ParmsChange = 1,
        ToolLoad = 2,
        Command=3,
    }
}