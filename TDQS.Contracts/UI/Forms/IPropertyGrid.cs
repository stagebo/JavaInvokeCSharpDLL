#region CLR版本 4.0.30319.239
// IPropertyGrid 接口
// 时间：2011-11-10 14:04:17
// 名称：IPropertyGrid 接口
// 大纲：PropertyGrid类型ToolWindow
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
//  2013-5-24   李睿      添加接口[void ReadOnlyAllAttribute(ReadOnlyStatus readOnly = ReadOnlyStatus.Custom)]
// --------------------------------------------------------
//
//
//
//
// ========================================================
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// PropertyGrid类型ToolWindow
    /// </summary>
    public interface IPropertyGrid : IToolWindow
    {
        #region 方法

        /// <summary>
        /// 绑定元件
        /// </summary>
        /// <param name="element">元件对象</param>
        void Bind(IElement element);

        /// <summary>
        /// 刷新
        /// </summary>
        void Reload();

        /// <summary>
        /// 设置所有页卡是否所有属性可用
        /// </summary>
        /// <param name="readOnly">只读状态</param>
        void ReadOnlyAllAttribute(ReadOnlyStatus readOnly = ReadOnlyStatus.Custom);

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        bool Enable
        {
            set;
            get;
        }

        /// <summary>
        /// 排序类型
        /// </summary>
        PropertySort SortType
        {
            get;
            set;
        }

        /// <summary>
        /// 是否刷新属性框
        /// </summary>
        bool AutoRefresh
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件

        /// <summary>
        /// 属性值改变后事件
        /// </summary>
        event PropertyValueChangedEventHandler PropertyValueChanged;
        #endregion // 事件
    }
}

