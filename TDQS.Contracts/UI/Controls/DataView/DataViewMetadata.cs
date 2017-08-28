#region CLR版本 4.0.30319.239
// ValidateResultFrmMetadata 类
// 时间：2012-5-11 14:04:17
// 名称：校验结果元数据定义
// 大纲：
//
// 创建人：聂桂春
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
    /// 校验结果元数据定义
    /// </summary>
    [MetadataAttribute]
    public class DataViewMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        #endregion // 构造和析构

        #region 公有方法

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// Name: EditPanel的名称. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        public ResourceMode EnmResourceMode { get; set; }

        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 所有ValidateResultFrmMetadata定义的View
    /// </summary>
    public interface IDataViewMetadataView
    {
        
        /// <summary>
        /// Name: EditPanel的名称. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        ResourceMode EnmResourceMode { get; }
    }
}