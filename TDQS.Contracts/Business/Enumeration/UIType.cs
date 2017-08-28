#region CLR版本 4.0.30319.269
// UIType 类
// 时间：2012-5-23 17:48:14
// 名称：UIType
// 大纲：界面类型
//
// 创建人：王津
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
    /// 界面类型
    /// </summary>
    public enum UIType : byte
    {
        /// <summary>
        /// 主菜单
        /// </summary>
        MainMenu,
        /// <summary>
        /// 工具栏
        /// </summary>
        Toolbar,
        /// <summary>
        /// 上下文菜单
        /// </summary>
        ContextMenu
    }
}