#region CLR版本 4.0.30319.239
// IToolBoxItem 接口
// 时间：2011-11-28 10:37:39
// 名称：工具箱项目类
// 大纲：封装工具箱项目
//
// 创建人：夏禹
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using TDQS.Contracts;
using System.Reflection;

namespace TDQS.Contracts
{
    /// <summary>
    /// IToolBoxItem 类
    /// </summary>
    public interface IToolBoxItem : IDisposable, ICloneable
    {
        /// <summary>
        /// 触发单击事件
        /// </summary>
        void DoClick();

        /// <summary>
        /// 触发Drop事件
        /// </summary>
        void DoDrop();

        /// <summary>
        /// 触发双击
        /// </summary>
        void DoDoubleClick();

        /// <summary>
        /// 强制刷新图标
        /// </summary>
        void RefreshIcon();

        /// <summary>
        /// 单击事件
        /// </summary>
        event EventHandler Click;

        /// <summary>
        /// 拖拽事件
        /// </summary>
        event EventHandler Drop;

        /// <summary>
        /// 双击事件
        /// </summary>
        event EventHandler DoubleClick;

        /// <summary>
        /// 项目ID
        /// </summary>
        string ID
        {
            get;
            set;
        }

        /// <summary>
        /// 项目是否显示
        /// </summary>
        bool Visible
        {
            get;
            set;
        }

        /// <summary>
        /// 项目位置
        /// </summary>
        int Position
        {
            get;
            set;
        }

        /// <summary>
        /// 项目名字
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 项目图标
        /// </summary>
        Image Icon
        {
            get;
        }

        /// <summary>
        /// 项目字体
        /// </summary>
        Font Font
        {
            get;
            set;
        }

        /// <summary>
        /// 项目字体颜色
        /// </summary>
        Color ForeColor
        {
            get;
            set;
        }

        /// <summary>
        /// 项目是否为分组项目
        /// </summary>
        bool IsBand
        {
            get;
            set;
        }

        /// <summary>
        /// 项目是否为空分组
        /// </summary>
        bool IsEmptyBand
        {
            get;
        }

        /// <summary>
        /// 项目是否有需要显示的子项目
        /// </summary>
        bool HasVisibleItem();

        /// <summary>
        /// 空分组描述
        /// </summary>
        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 项目分类（父项目）
        /// </summary>
        IToolBoxItem Category
        {
            get;
            set;
        }

        /// <summary>
        /// 子项目
        /// </summary>
        ToolBoxItemCollection SubItems
        {
            get;
            set;
        }

        /// <summary>
        /// 提示文本
        /// </summary>
        string Tooltip
        {
            get;
            set;
        }

        /// <summary>
        /// 元件类型
        /// </summary>
        string TypeNo
        {
            get;
            set;
        }

        /// <summary>
        /// 项目所属工具箱
        /// </summary>
        IToolBox ToolBox
        {
            get;
            set;
        }


        /// <summary>
        /// 工具箱导入项目
        /// </summary>
        IToolBoxItemObject ItemObject
        {
            get;
            set;
        }

        /// <summary>
        /// 单击事件处理函数
        /// </summary>
        string ClickHandler
        {
            get;
            set;
        }

        /// <summary>
        /// 双击事件处理函数
        /// </summary>
        string DbClickHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Drop事件处理函数
        /// </summary>
        string DropHandler
        {
            get;
            set;
        }

        /// <summary>
        /// 是否属于通常元件
        /// </summary>
        bool IsUsually
        {
            get;
            set;
        }

        /// <summary>
        /// 元件在通常元件分组中的位置
        /// </summary>
        int UsuallyBandPosition
        {
            get;
            set;
        }

        /// <summary>
        /// 元件在通常元件分组中是否显示
        /// </summary>
        bool UsuallyVisible
        {
            get;
            set;
        }

        /// <summary>
        /// 点选项目是否来自常用项目分组
        /// </summary>
        bool FromUsuallyBand
        {
            get;
            set;
        }

        /// <summary>
        /// 图标字体
        /// </summary>
        Font IconFont
        {
            get;
            set;
        }

        /// <summary>
        /// 图标颜色
        /// </summary>
        Color IconColor
        {
            get;
            set;
        }

        /// <summary>
        /// 图标索引
        /// </summary>
        int IconIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 状态栏提示信息
        /// </summary>
        string StatusBarTip
        {
            get;
            set;
        }

        /// <summary>
        /// 元件类型
        /// </summary>
        ElementType ElementType
        {
            get;
            set;
        }

        /// <summary>
        /// 是否激活
        /// </summary>
        bool Enabled
        {
            get;
            set;
        }
    }
}