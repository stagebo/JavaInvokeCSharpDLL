#region CLR版本 4.0.30319.239
// ToolMetadata 类
// 时间：2011-11-15 13:14:03
// 名称：ToolMetadata
// 大纲：所有绘图工具的Metadata类
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
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有操作工具的元数据类
    /// </summary>
    [MetadataAttribute]
    public class ToolMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public ToolMetadata()
        {
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// ID: 工具的ID值　 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name: 工具名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name: 元件名称。
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// ElementType: 元件类型
        /// </summary>
        public ElementType ElementType { get; set; }

        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 所有ToolMetadata对象的View
    /// </summary>
    public interface IToolMetadataView
    {
        /// <summary>
        /// ID: 工具的ID值　 
        /// </summary>
        long ID { get; }

        /// <summary>
        /// Name: 工具名称。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Name: 元件名称。
        /// </summary>
        string ElementName { get; }

        /// <summary>
        /// ElementType: 元件类型
        /// </summary>
        ElementType ElementType { get; }
    }

}