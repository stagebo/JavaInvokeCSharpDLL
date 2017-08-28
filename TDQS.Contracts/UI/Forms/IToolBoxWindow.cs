#region CLR版本 4.0.30319.239
// IToolBox 接口
// 时间：2011-11-10 14:04:17
// 名称：IToolBox 接口
// 大纲：ToolBox型ToolWindow
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// ToolBox型ToolWindow
    /// </summary>
    public interface IToolBoxWindow : IToolWindow
    {
        #region 方法
        IToolBox GetNewInstance();
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 工具箱
        /// </summary>
        IToolBox ToolBox
        {
            get;
            set;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

