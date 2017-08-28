#region CLR版本 4.0.30319.239
// IElementEx 接口
// 时间：2012-3-21 13:54:18
// 名称：IElementEx
// 大纲：元件扩展对象
//
// 创建人：王津
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 元件扩展对象，用于保存元件的扩展属性，如Tool、Command名称。
    /// </summary>
    public interface IElementEx
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 模板对象ID(与元件模板对象ID相同)
        /// </summary>
        string ID { get; set; }
        /// <summary>
        /// 操作工具名称
        /// </summary>
        string ToolName { get; set; }
        /// <summary>
        /// 命令工具名称
        /// </summary>
        string CommandName { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

