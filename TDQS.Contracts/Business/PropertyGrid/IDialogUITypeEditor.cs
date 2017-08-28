#region CLR版本 4.0.30319.17379
// IDialogUITypeEditor 接口
// 时间：2012/08/02 17:24:08
// 名称：IDialogUITypeEditor
// 大纲：弹出框编辑器接口
//
// 创建人：孙书涛
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
    /// 弹出框编辑器接口
    /// </summary>
    public interface IDialogUITypeEditor
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 结果
        /// </summary>
        string Result
        {
            get;
        }
        /// <summary>
        /// 参数
        /// </summary>
        string parameter
        {
            get;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

