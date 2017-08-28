#region CLR版本 4.0.30319.239
// IGridPanel 接口
// 时间：2011/10/12 16:10:31
// 名称：IGridPanel 接口
// 大纲：表格用户控件，操作接口
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 表格用户控件，操作接口
    /// </summary>
    public interface IGridPanel
    {
        #region 方法
        /// <summary>
        /// 数据绑定
        /// </summary>
        void DataBind();
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 用户控件
        /// </summary>
        IGridControl GridContrl { get; }
        /// <summary>
        /// 自身用户控件
        /// </summary>
        UserControl View { get; }
        /// <summary>
        /// 只读属性
        /// </summary>
        bool ReadOnly { set; }
        /// <summary>
        /// 底部容器的样式
        /// </summary>
        ButtomPanelStyle ButtomPanelStyle { get; set; }
        #endregion // 属性

        #region 事件
        event EventHandler RefreshData;

        event EventHandler ExportData;

        event EventHandler ExportDataToCnpx;

        event Action<string> RelocateElement;
        #endregion // 事件
              

    }

    /// <summary>
    /// 底部容器的样式
    /// </summary>
    public enum ButtomPanelStyle
    {
        Static = 0,
        Chart = 1,
        Hide = 9
    }
}

