#region CLR版本 4.0.30319.225
// TreePanelMetadata 类
// 时间：2011-11-28 15:26:48
// 名称：TreePanelMetadata 类
// 大纲：TreePanel元数据类
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
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// TreePanel元数据类
    /// </summary>
    [MetadataAttribute]
    public class TreePanelMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public TreePanelMetadata()
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
    /// 所有TreePanelMetadata定义的View
    /// </summary>
    public interface ITreePanelMetadataView
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