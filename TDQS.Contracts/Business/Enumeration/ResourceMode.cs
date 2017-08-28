#region CLR版本 4.0.30319.239
// ResourceMode 类
// 时间：2011-9-29 14:11:36
// 名称：ResourceMode 类
// 大纲：资源应用方式
//
// 创建人：王津
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
    /// 资源应用方式
    /// </summary>
    public enum ResourceMode : byte
    {
        /// <summary>
        /// 未定义
        /// </summary>
        Null  = 0,
        /// <summary>
        /// 公用
        /// </summary>
        Common = 1,
        /// <summary>
        /// 自身
        /// </summary>
        Self = 2,
        /// <summary>
        /// 外部
        /// </summary>
        Ext = 3
    }
}