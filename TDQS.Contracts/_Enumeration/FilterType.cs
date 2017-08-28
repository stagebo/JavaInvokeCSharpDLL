#region CLR版本 4.0.30319.17379
// IFilterType 枚举
// 时间：2012/06/25 16:20:01
// 名称：IFilterType
// 大纲：分类选择过滤方式
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
    /// 分类选择过滤方式
    /// </summary>
    public enum FilerType
    { 
        /// <summary>
        /// 无过滤
        /// </summary>
        None,
        /// <summary>
        /// 多值过滤
        /// </summary>
        Multiple,
        /// <summary>
        /// 单值过滤
        /// </summary>
        Single
    }
}

