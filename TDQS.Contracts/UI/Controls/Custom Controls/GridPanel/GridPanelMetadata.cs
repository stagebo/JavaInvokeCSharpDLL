#region CLR版本 4.0.30319.239
// GridPanelMetadata 类
// 时间：2011/10/12 16:10:31
// 名称：GridPanelMetadata 
// 大纲：GridPanel元数据类
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
    /// GridPanelMetadata 类
    /// </summary>
    [MetadataAttribute]
    public class GridPanelMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public GridPanelMetadata()
        {
            //
            
            //
        }

        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// ID: GridPanel的ID值，用于排序.　 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name: GridPanel的名称. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// FormName: GridPanel的父窗体名称. 
        /// </summary>
        public string FormName { get; set; }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量
    }
    /// <summary>
    /// IGridPanelMetadataView 接口
    /// </summary>
    public interface IGridPanelMetadataView
    {
        /// <summary>
        /// ID: GridPanel的ID值，用于排序.　 
        /// </summary>
        long ID { get; }

        /// <summary>
        /// Name: GridPanel的名称. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// FormName: GridPanel的父窗体名称. 
        /// </summary>
        string FormName { get; }
    }
}