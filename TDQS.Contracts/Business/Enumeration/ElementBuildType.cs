#region CLR版本 4.0.30319.239
// ElementBuildType 类
// 时间：2012-3-16 10:50:22
// 名称：ElementBuildType
// 大纲：元件创建类型
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
    /// 元件创建类型
    /// </summary>
    public enum ElementBuildType
    {
        /// <summary>
        /// 数据库方式
        /// </summary>
        DataBase,
        /// <summary>
        /// 配置文件
        /// </summary>
        Config,
        /// <summary>
        /// 先装入数据库，再装入配置文件
        /// </summary>
        DataBaseAndConfig

    }
}