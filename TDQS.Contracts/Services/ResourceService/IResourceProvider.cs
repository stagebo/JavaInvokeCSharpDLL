#region CLR版本 4.0.30319.239
// IResourceProvider 接口
// 时间：2011-11-10 14:04:17
// 名称：IResourceProvider 
// 大纲：资源提供者接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TDQS.Contracts
{
    /// <summary>
    /// 资源提供者接口
    /// </summary>
    public interface IResourceProvider
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 资源设施名称
        /// </summary>
        string BaseName { get; }

        /// <summary>
        /// 程序集名称
        /// </summary>
        Assembly AssemblyObj { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

