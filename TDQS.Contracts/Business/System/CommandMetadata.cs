#region CLR版本 4.0.30319.239
// CommandMetadata 类
// 时间：2011-11-10 14:04:17
// 名称：CommandMetadata 
// 大纲：所有Command对象的Metadata
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有Command对象的元数据类
    /// </summary>
    [MetadataAttribute]
    public class CommandMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// ID: 命令的ID值，用于排序，主菜单项预留1-20，如 文件为"101", 帮助为"2001"　 
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name: 命令的名称，做为命令的唯一标识，不应重复。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        public ResourceMode ResMode { get; set; }

        /// <summary>
        /// MenuName:　主菜单项名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// SubMenuName: 二级主菜单项名称
        /// </summary>
        public string SubMenuName { get; set; }

        /// <summary>
        /// MenuText: 菜单项文本
        /// </summary>
        public string MenuText { get; set; }

        /// <summary>
        /// ToolBtnName: 工具栏按钮名称（注：与资源名称相同，以装入资源）
        /// </summary>
        public string ToolBtnName { get; set; }

        /// <summary>
        /// ToolBtnText: 工具栏按钮文本
        /// </summary>
        public string ToolBtnText { get; set; }

        /// <summary>
        /// CheckFunction: Check方法名
        /// </summary>
        public string CheckFunction { get; set; }

        /// <summary>
        /// EnableFunction: Enable方法名
        /// </summary>
        public string EnableFunction { get; set; }

        /// <summary>
        /// VisibleFunction: Visible方法名
        /// </summary>
        public string VisibleFunction { get; set; }
        /// <summary>
        ///DBClickFunction: 双击方法名
        /// </summary>
        public string DBClickFunction { get; set; }

        /// <summary>
        /// 快捷键
        /// </summary>
        public string ShortcutKey { get; set; }

        /// <summary>
        /// 快捷命令
        /// </summary>
        public string ShortcutCommand { get; set; }

        /// <summary>
        /// 获取或设置全局热键状态
        /// </summary>
        public bool GlobalShortcut { get; set; }

        /// <summary>
        /// 工具栏所在行
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// 处理方法所在的命名空间，为空时即为与子系统同名。
        /// </summary>
        public string NameSpace { get; set; }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 所有CommandMetadata对象的View
    /// </summary>
    public interface ICommandMetadataView
    {
        /// <summary>
        /// ID: 命令的ID值，用于排序，主菜单项预留1-20，如 文件为"101", 帮助为"2001"　 
        /// </summary>
        long ID { get; }

        /// <summary>
        /// Name: 命令的名称，做为命令的唯一标识，不应重复。
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ResMode: 资源类型, 其值包括: "Null" "Common" "Self" "Ext"
        /// </summary>
        ResourceMode ResMode { get; }

        /// <summary>
        /// MenuName:　主菜单项名称（注：与资源名称相同，以装入资源）
        /// </summary>
        string MenuName { get; }

        /// <summary>
        /// SubMenuName: 二级主菜单项名称
        /// </summary>
        string SubMenuName { get; }

        /// <summary>
        /// MenuText: 菜单项文本
        /// </summary>
        string MenuText { get; }

        /// <summary>
        /// ToolBtnName: 工具栏按钮名称（注：与资源名称相同，以装入资源）
        /// </summary>
        string ToolBtnName { get; }

        /// <summary>
        /// ToolBtnText: 工具栏按钮文本
        /// </summary>
        string ToolBtnText { get; }

        /// <summary>
        /// Check方法名
        /// </summary>
        string CheckFunction { get; }

        /// <summary>
        /// Enable方法名
        /// </summary>
        string EnableFunction { get; }

        /// <summary>
        /// Visible方法名
        /// </summary>
        string VisibleFunction { get; }
        /// <summary>
        ///DBClickFunction: 双击方法名
        /// </summary>
        string DBClickFunction { get; }

        /// <summary>
        /// 快捷键
        /// </summary>
        string ShortcutKey { get; }

        /// <summary>
        /// 快捷命令
        /// </summary>
        string ShortcutCommand { get; }

        /// <summary>
        /// 获取是否为全局热键
        /// </summary>
        bool GlobalShortcut { get; }

        /// <summary>
        /// 工具栏所在行
        /// </summary>
        int Row { get; }

        /// <summary>
        /// 处理方法所在命名空间名称
        /// </summary>
        string NameSpace { get; }
    }

}