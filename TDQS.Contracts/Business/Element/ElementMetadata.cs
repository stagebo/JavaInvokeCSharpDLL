#region CLR版本 4.0.30319.239
// ElementMetadata 类
// 时间：2011-11-10 13:25:09
// 名称：ElementMetadata
// 大纲：所有元件的Metadata类
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
    /// 元件元数据类
    /// </summary>
    [MetadataAttribute]
    public class ElementMetadata : Attribute
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
        /// ID: 元件的ID值　 
        /// </summary>
        public long ID { get; set; }
        /// <summary>
        /// Name: 元件的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 元件表名
        /// 聂桂春2012.12.4增加
        /// </summary>
        public string TableName
        {
            get;
            set;
        }

        /// <summary>
        /// ElementType: 元件类型
        /// </summary>
        public ElementType ElementType { get; set; }

        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// IElementMetadataView接口
    /// 所有ElementMetadata对象的View
    /// </summary>
    public interface IElementMetadataView
    {
        /// <summary>
        /// ID
        /// </summary>
        long ID { get; }
        /// <summary>
        /// 名称 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 元件表名
        /// 聂桂春2012.12.4增加
        /// </summary>
        string TableName 
        { 
            get; 
        }
        /// <summary>
        /// 元件类型
        /// </summary>
        ElementType ElementType { get; }
    }

}