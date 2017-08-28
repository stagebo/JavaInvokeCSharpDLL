#region CLR版本 4.0.30319.239
// EditPanelMetadata 类
// 时间：2011-11-10 14:04:17
// 名称：EditPanel编辑控件的Metadata类
// 大纲：所有EditPanel控件的Metadata定义
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
    /// 所有EditPanel控件的元数据定义
    /// </summary>
    [MetadataAttribute]
    public class EditPanelMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// ID: EditPanel的ID值，用于排序.　 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name: EditPanel的名称. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ParentID: EditPanel的父级对象ID. 注：ParentID=0:最上层
        /// </summary>
        public long ParentID { get; set; }

        /// <summary>
        /// ViewID: EditPanel的显示对象ID，用于某个父节点显示的是某个子节点的实例
        /// </summary>
        public long ViewID { get; set; }

        /// <summary>
        /// FormName: EditPanel的父窗体名称. 
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// 对应元件名称
        /// </summary>
        public string ElementName { get; set; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        public ResourceMode EnmResourceMode { get; set; }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 所有EditPanelMetadata定义的View
    /// </summary>
    public interface IEditPanelMetadataView
    {
        /// <summary>
        /// ID: EditPanel的ID值，用于排序.　 
        /// </summary>
        long ID { get; }

        /// <summary>
        /// Name: EditPanel的名称. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ParentID: EditPanel的父级对象ID. 注：ParentID=0:最上层
        /// </summary>
        long ParentID { get; }

        /// <summary>
        /// ViewID: EditPanel的显示对象ID，用于某个父节点显示的是某个子节点的实例
        /// </summary>
        long ViewID { get; }

        /// <summary>
        /// FormName: EditPanel的父窗体名称. 
        /// </summary>
        string FormName { get; }

        /// <summary>
        /// 对应元件名称 
        /// </summary>
        string ElementName { get; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        ResourceMode EnmResourceMode { get; }

    }
}