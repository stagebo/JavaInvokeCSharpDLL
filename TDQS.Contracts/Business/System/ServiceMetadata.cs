#region CLR版本 4.0.30319.239
// ServiceMetadata 类
// 时间：2011-11-10 14:04:17
// 名称：ServiceMetadata 
// 大纲：所有服务的Metadata类
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
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有服务的元数据类
    /// </summary>
    [MetadataAttribute]
    public class ServiceMetadata : Attribute
    {
        #region 构造和析构

        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// Name: 服务的名称，做为服务的唯一标识，不可以重复
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ItemType: 服务的类型，其值目前包括 "LogService" "ExceptionService"
        /// </summary>
        public string ItemType { get; set; }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量
    }

    /// <summary>
    /// 所有服务的元数据类的View
    /// </summary>
    public interface IServiceMetadataView
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 类型
        /// </summary>
        string ItemType { get; }
    }
}