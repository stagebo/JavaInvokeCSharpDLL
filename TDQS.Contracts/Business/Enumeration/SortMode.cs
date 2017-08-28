#region CLR版本 4.0.30319.239
// SortMode 类 
// 时间：2011/9/25 11:49:34
// 名称：SortMode 类
// 大纲：排序准则
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 排序准则
    /// </summary>
    public enum SortMode : byte
    {
        /// <summary>
        /// 默认
        /// </summary>
        Null = 1,
        /// <summary>
        /// 升序
        /// </summary>
        ASC = 2,
        /// <summary>
        /// 降序
        /// </summary>
        DESC = 3
    }
}