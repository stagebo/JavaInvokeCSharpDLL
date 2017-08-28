#region CLR版本 4.0.30319.239
// IDataView 接口
// 时间：2012-5-11 14:04:17
// 名称：IDataView 
// 大纲：数据校验结果窗口接口
//
// 创建人：聂桂春
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 数据校验结果窗口接口
    /// </summary>
    public interface IDataView
    {
        #region 方法

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="formTitle">窗体标题</param>
        /// <param name="treeTitle">树根节点</param>
        /// <param name="view">视图对象</param>
        /// <param name="elements">元件集合</param>
        void BindData(string formTitle, string treeTitle,IView  view, ICollection<IElement> elements);

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="formTitle">窗体标题</param>
        /// <param name="treeTitle">树根节点</param>
        /// <param name="view">视图对象</param>
        /// <param name="tables">数据表集合</param>
        void BindData(string formTitle, string treeTitle, IView view, IList<DataTable> tables);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

