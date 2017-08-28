#region CLR版本 4.0.30319.17379
// ReadOnlyStatus 枚举
// 时间：2012/06/06 9:42:58
// 名称：ReadOnlyStatus
// 大纲：属性框只读属性
//
// 创建人：孙书涛
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
    /// 只读状态
    /// </summary>
    public enum ReadOnlyStatus
    {
        /// <summary>
        /// 开
        /// </summary>
        On = 1,
        /// <summary>
        /// 关
        /// </summary>
        Off = 0,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom = 2
    }
}