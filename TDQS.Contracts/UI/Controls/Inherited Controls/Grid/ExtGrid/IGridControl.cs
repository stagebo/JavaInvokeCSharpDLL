#region CLR版本 4.0.30319.225
// IDataGridView 接口
// 时间：2011-11-28 15:26:48
// 名称：IDataGridView 接口
// 大纲：定义数据表格操作接口
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
    /// 定义数据表格操作接口
    /// </summary>
    public interface IGridControl : IGridOperat
    {
        #region 方法
        /// <summary>
        /// 设置显示列
        /// </summary>
        void SetColumns();
        #endregion // 方法
        #region 属性
        /// <summary>
        /// 数据库对象接口
        /// </summary>
        IDatabase DB { get; set; }
        /// <summary>
        /// DataGridView操作对象
        /// </summary>
        Control Instance { get; }
        /// <summary>
        /// 数据表
        /// </summary>
        DataTable DataTable { get; set; }
        /// <summary>
        /// 说明表
        /// </summary>
        IExplanationTable ExplanationTable { get; set; }
        /// <summary>
        /// 操作数据对象
        /// </summary>
        IObjectOperable ObjectOperable { get; set; }
        /// <summary>
        /// 指定需要列值合并的列名
        /// </summary>
        List<string> MergeColumnNames { get; set; }

        /// <summary>
        /// 获取可显示的行
        /// </summary>
        DataTable FilterTable { get;  }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

