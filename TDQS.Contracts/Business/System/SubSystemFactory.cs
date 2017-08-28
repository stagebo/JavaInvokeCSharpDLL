#region CLR版本 4.0.30319.269
// SubSystemFactory 类
// 时间：2012-5-16 15:43:48
// 名称：SubSystemFactory
// 大纲：子系统工厂类
//
// 创建人：王津
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 子系统工厂类
    /// </summary>
    public abstract class SubSystemFactory
    {
        #region 构造和析构
        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 装载子系统
        /// </summary>
        /// <param name="name">子系统名称（对应MEF装载路径）</param>
        /// <returns>子系统全局对象</returns>
        public SubSystem Load(Shell shell,string name)
        {
            if (m_SubSystem != null)
            {
                return m_SubSystem;
            }
            Initialize();
            SubSystem subSystem = GetSystemInstance(XSystem.GetSubSystemSpec(name));
            subSystem.shell = shell;
            m_SubSystem = subSystem;
            m_FunctionActions.Clear();
            m_FunctionActions_All.Clear();
            return subSystem;
        }

        /// <summary>
        /// 重新加载工程
        /// </summary>
        public abstract void ReloadProjects();

        /// <summary>
        /// 初始化
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// 获取对应的子系统实例
        /// </summary>
        /// <param name="spec">子系统规格</param>
        /// <returns>子系统实例对象</returns>
        public abstract SubSystem GetSystemInstance(IShellSpec spec);

        /// <summary>
        /// 安装命令
        /// </summary>
        public abstract void InstallCommand(bool bReload);

        /// <summary>
        /// 子系统命令集合
        /// </summary>
        /// <returns>晚期绑定命令集合</returns>
        public abstract IEnumerable<Lazy<Action<SubSystem>, ICommandMetadataView>> GetCommands();

        /// <summary>
        /// 根据Key获得ToolStrip
        /// </summary>
        /// <param name="key">ToolStrip名字</param>
        /// <returns>ToolStrip对象</returns>
        public virtual ToolStrip GetToolStrip(string key)
        {
            if (m_Toolbars == null || !m_Toolbars.ContainsKey(key) )
            {
                return null;
            }
      
            return m_Toolbars[key];
        }

        /// <summary>
        /// 根据Key获得ContextMenu
        /// </summary>
        /// <param name="key">ContextMenu名字</param>
        /// <returns>ContextMenu对象</returns>
        public virtual ContextMenuStrip GetContextMenu(string key)
        {
            if (m_ContextMenus == null || !m_ContextMenus.ContainsKey(key))
            {
                return null;
            }
            return m_ContextMenus[key];
        }


        /// <summary>
        /// 显示某个上下文菜单
        /// </summary>
        /// <param name="key">菜单名</param>
        /// <param name="control">关联的控件</param>
        /// <param name="position">位置</param>
        public virtual void ShowContextMenu(string key, Control control, Point position)
        {
            GetContextMenu(key).Show(control, position);
        }

        /// <summary>
        /// 获取工具栏的行位置
        /// </summary>
        /// <param name="strip">工具栏</param>
        /// <returns>行数</returns>
        public virtual int GetRowNumber(ToolStrip strip)
        {
            FunctionAction function = GetFunctionActionByName(strip.Name);
            if (function == null)
            {
                return -1;
            }
            return function.FuncStruct.Row;
        }

        #endregion // 公有方法

        #region 保护方法

        /// <summary>
        /// 根据名称获取“功能执行动作”
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>功能执行动作</returns>
        protected FunctionAction GetFunctionActionByName(string name)
        {
            IEnumerable<FunctionAction> iterator =
                m_FunctionActions_All.Where(c => c.FuncStruct.Name == name);
            if (iterator.Count() < 1)
            {
                return null;
            }
            return iterator.First();
        }

        /// <summary>
        /// 新建一个子系统实例
        /// </summary>
        /// <param name="spec">规格</param>
        /// <returns>子系统</returns>
        protected virtual SubSystem NewSystemInstance(IShellSpec spec)
        {
            return null;
        }

        /// <summary>
        /// 刷新状态
        /// </summary>
        internal protected virtual void Refresh()
        { 
        }

        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 子系统
        /// </summary>
        protected SubSystem m_SubSystem = null;
                
        /// <summary>
        /// 子系统命令集合（晚期绑定)
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        protected Lazy<Action<SubSystem>, ICommandMetadataView>[] Commands = null;

        /// <summary>
        /// 界面安装对象种类名称
        /// </summary>
        protected string m_CategoryName;

        /// <summary>
        /// 获取主菜单项集合
        /// </summary>
        public ReadOnlyDictionary<string, ToolStripItem> MainMenuItems
        {
            get
            {
                return m_items == null ? null :
                    new ReadOnlyDictionary<string, ToolStripItem>(m_items);
            }
        }

        /// <summary>
        /// 主菜单项集合
        /// </summary>
        protected Dictionary<string, ToolStripItem> m_items;

        /// <summary>
        /// 获取工具栏集合
        /// </summary>
        public ReadOnlyDictionary<string, ToolStrip> Toolbars
        {
            get
            {
                return m_Toolbars == null ? null :
                    new ReadOnlyDictionary<string, ToolStrip>(m_Toolbars);
            }
        }

        /// <summary>
        /// 工具栏列表
        /// </summary>
        protected Dictionary<string, ToolStrip> m_Toolbars;

        /// <summary>
        /// 获取菜单集合
        /// </summary>
        public ReadOnlyDictionary<string, ContextMenuStrip> Menus
        {
            get
            {
                return m_ContextMenus == null ? null : 
                    new ReadOnlyDictionary<string, ContextMenuStrip>(m_ContextMenus);
            }
        }

        /// <summary>
        /// 右键菜单列表
        /// </summary>
        protected Dictionary<string, ContextMenuStrip> m_ContextMenus;

        /// <summary>
        /// 获取功能结构集合
        /// </summary>
        public ReadOnlyCollection<FunctionAction> FunctionActions
        {
            get
            {
                return m_FunctionActions_All == null ? null :
                    new ReadOnlyCollection<FunctionAction>(m_FunctionActions_All);
            }
        }

        /// <summary>
        /// 功能结构集合
        /// </summary>
        protected Collection<FunctionAction> m_FunctionActions_All = new Collection<FunctionAction>();


        /// <summary>
        /// 热键与FunctionAction的关联缓存
        /// </summary>
        internal protected Dictionary<Keys, FunctionAction> m_keyBuffer = new Dictionary<Keys, FunctionAction>();

        /// <summary>
        /// 功能调用Stack
        /// </summary>
        public readonly Stack<FunctionAction> m_FunctionActions = new Stack<FunctionAction>();

        /// <summary>
        /// 获取工具床集合
        /// </summary>
        public ReadOnlyDictionary<string, IToolWindow> ToolWindows
        {
            get
            {
                return m_toolWindows == null ? null 
                    : new ReadOnlyDictionary<string, IToolWindow>(m_toolWindows);
            }
        }

        /// <summary>
        /// 工具窗列表
        /// </summary>
        protected Dictionary<string, IToolWindow> m_toolWindows;

        #endregion // 属性及其私有变量

    }
}