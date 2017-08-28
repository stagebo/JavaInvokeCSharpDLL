#region CLR版本 4.0.30319.239
// IOutputWindow 接口
// 时间：2011-11-10 14:04:17
// 名称：IOutputWindow 接口
// 大纲：Output类型ToolWindow
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
    /// Output类型ToolWindow
    /// </summary>
    public interface IOutputWindow : IToolWindow
    {
        #region 方法
        /// <summary>
        /// 输出一行
        /// </summary>
        /// <param name="text"></param>
        void Writeline(string text);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

