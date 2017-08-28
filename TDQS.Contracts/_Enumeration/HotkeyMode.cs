#region CLR版本 4.0.30319.269
// HotkeyMode 枚举
// 时间：2012-11-12 18:32:52
// 名称：常见热键组合方式
// 大纲：
//
// 创建人：郭威
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
    /// 常见热键组合方式
    /// </summary>
    [Flags]
    internal enum HotkeyMode
    {
        None = 0,
        Control = 1,
        Shift = 2,
        Alt = 4,
    }
}