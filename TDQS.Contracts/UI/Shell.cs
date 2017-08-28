#region CLR版本 4.0.30319.239
// Shell 类
// 时间：2011-11-10 14:04:17
// 名称：Shell基类
// 大纲：应用程序Shell基类
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		   修改人		描述
// 2012-11-23  郭威         InstallSubSystem优化定稿；
//                          1.具备执行锁，可与UninstallSubSystem及本身执行互斥；
//                          2.从工厂缓存中读取子系统工厂或创建并加入工厂；
//                          3.从工厂获取子系统单例；
//                          4.可鉴别初始化子系统还是从再次读取缓存；
//                          5.试图重复加载同一子系统时可执行刷新操作Refresh；
//                          6.调用非锁卸载InternalUninstallSubSystem；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         UninstallSubSystem优化定稿；
//                          1.具备执行锁，可与InstallSubSystem及本身执行互斥；
//                          2.套用InternalUninstallSubSystem的工作；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         InternalUninstallSubSystem添加；
//                          1.UninstallSubSystem的主体工作，
//                          2.没有执行锁，适于程序集内部使用；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         GetActiveSubSystem优化定稿；
//                          1.通过工厂缓存获取子系统单例；
//                          2.寻址索引为m_activeSpec；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         GetSubSystem优化定稿；
//                          1.重载IShellSpec参数函数；
//                          2.重载IDocument参数函数；
//                          优化要点阐述完毕。                        
// 2012-11-23  郭威         ShowSystem添加；
//                          1.应用于InstallSubSystem流程中；
//                          2.只关心如何加载或显示子系统的组件；
//                          3.通过参数区分初始化与缓存读取的情况；
//                          4.具体功能由子类实现；
//                          优化要点阐述完毕。 
// 2012-11-23  郭威         HideSystem添加；
//                          1.应用于InstallSubSystem流程中； 
//                          2.只关心如何移除或隐藏子系统的组件；    
//                          3.具体功能由子类实现；                  
//                          优化要点阐述完毕。
// 2012-11-28  郭威         Record添加；
//                          1.通过缓存m_formRegistry寄存有效样式；
//                          2.没有则添加，有则覆盖；
//                          3.开放使用；
//                          优化要点阐述完毕。
// 2012-11-28  郭威         RecordPurge添加；
//                          1.从缓存m_formRegistry中清理样式；
//                          2.通过停泊窗句柄进行清理；
//                          3.开放使用；
//                          优化要点阐述完毕。
// 2012-11-28  郭威         ContainsRecord添加；
//                          1.判断m_formRegistry中是否已经注册了停泊窗；
//                          2.族内使用；
//                          优化要点阐述完毕。
// 2012-11-28  郭威         GetRecord添加；
//                          1.直接从m_formRegistry获取有效样式；
//                          2.如果从未注册直接抛出异常；
//                          3.族内使用；
//                          优化要点阐述完毕。
// 2012-11-28  郭威         ShowDockWindowEx添加；
//                          1.以未隐藏前样式显示停泊窗；
//                          2.子类实现；
//                          优化要点阐述完毕。
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using TDQS.Contracts;
using WinFormsUI.Docking;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using TDQS.Win32;
//using TDQS.Windows.Forms;
using TDQS.IO;
using System.Diagnostics; 

namespace TDQS.Contracts
{
    /// <summary>
    /// 应用程序Shell基类
    /// </summary>
    public abstract class Shell : Form
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public Shell()
            : base()
        {
            m_activeSpec = null;
            m_factories = new Dictionary<int, SubSystemFactory>();
            m_formRegistry = new Dictionary<IntPtr, DockState>();
            #region 李睿 2013-8-27 重构 从子类移植
            m_dockPanel = new WinFormsUI.Docking.DockPanel();
            m_DictAssemblys = new Dictionary<string, Assembly>(); // 初始化程序集缓存字典
            m_GISViewCacheList = new List<DockContent>();// 界面打开的GISView缓存
            #endregion
        }

        #endregion // 构造和析构

        #region 公有方法

        #region 子系统装卸

        /// <summary>
        /// 安装子系统
        /// </summary>
        /// <param name="spec">子系统规格</param>
        public virtual void InstallSubSystem(IShellSpec spec)
        {
            if (m_subSystemLock)
            {
                return;
            }
            m_subSystemLock = true;
            //定义子系统工厂
            SubSystemFactory factory = null;
            //是否已经完成工厂初始化
            bool initialized = true;
            //定义子系统
            SubSystem system = null;
            //分支1：规格为空，认定为CMN子系统加载
            if (spec == null)
            {
                if (m_activeSpec != null)
                {
                    InternalUninstallSubSystem();
                }
                if (!m_factories.ContainsKey(0))
                {
                    factory = GetSystemFactory("CMN");
                    if (factory == null)
                    {
                        m_subSystemLock = false;
                        return;
                    }
                    m_factories.Add(0, factory);
                    //标记未完成初始化
                    initialized = false;
                }
                else
                {
                    //子系统工厂赋值
                    factory = m_factories[0];
                }
                //切换当前组件目录
                XSystem.SubSystemCompositionContainer = XSystem.GetContainerByDirectory("CMN");
                //获取子系统
                system = factory.GetSystemInstance(null);
                ShowSystem(system, initialized);
                m_activeSpec = null;
                m_subSystemLock = false;
                return;
            }
            //分支2：规格非空，规格为空或规格特征一致则返回
            if (m_activeSpec != null
                && spec.SubgchtypeID == m_activeSpec.SubgchtypeID)
            {
                factory = m_factories[m_activeSpec.SubgchtypeID];
                factory.Refresh();
                m_subSystemLock = false;
                return;
            }
            //分支3：特征不一致，卸载当前子系统
            InternalUninstallSubSystem();
            if (!m_factories.ContainsKey(spec.SubgchtypeID))
            {
                factory = GetSystemFactory(spec.ComponentsDirectory);
                if (factory == null)
                {
                    m_subSystemLock = false;
                    return;
                }
                m_factories.Add(spec.SubgchtypeID, factory);
                //执行了初始化
                initialized = false;
            }
            else
            {
                //子系统工厂赋值
                factory = m_factories[spec.SubgchtypeID];
            }
            //切换当前组件目录
            XSystem.SubSystemCompositionContainer = XSystem.GetContainerByDirectory(spec.ComponentsDirectory);
            //获取子系统
            system = factory.GetSystemInstance(spec);
            //显示子系统
            ShowSystem(system, initialized);
            //使用system.Spec而不使用spec是为了确保IShellSpec对象的一致性
            m_activeSpec = system.Spec;
            m_subSystemLock = false;
        }

        /// <summary>
        /// 卸载当前子系统
        /// </summary>
        public virtual void UninstallSubSystem()
        {
            if (m_subSystemLock)
            {
                return;
            }
            m_subSystemLock = true;
            InternalUninstallSubSystem();
            m_subSystemLock = false;
        }

        #endregion

        #region 停泊窗样式记录

        /// <summary>
        /// 记录停泊窗样式记录
        /// </summary>
        /// <param name="window">窗体</param>
        /// <param name="excludeHidden">是否排斥记录隐藏状态，默认为真</param>
        /// <returns>是否记录成功</returns>
        public bool Record(IDockWindow window, bool excludeHidden = true)
        {
            //此类为空情况不做记录
            if (window == null
                || window.Instance == null)
            {
                return false;
            }
            //排斥且隐藏情况不作记录
            if (excludeHidden &&
                (window.Instance.IsHidden || window.Instance.DockHandler.IsHidden))
            {
                return false;
            }
            //包含则替换，不含则添加
            if (!m_formRegistry.ContainsKey(window.Instance.Handle))
            {
                m_formRegistry.Add(window.Instance.Handle, window.Instance.DockState);
            }
            else
            {
                m_formRegistry[window.Instance.Handle] = window.Instance.DockState;
            }
            return true;
        }

        /// <summary>
        /// 清除停泊窗样式记录
        /// </summary>
        /// <param name="window">窗体</param>
        /// <returns>是否清除成功</returns>
        public bool RecordPurge(IDockWindow window)
        {
            if (window == null
                || window.Instance == null
                || !ContainsRecord(window))
            {
                return false;
            }
            return m_formRegistry.Remove(window.Instance.Handle);
        }

        #endregion

        #region DocView

        /// <summary>
        /// 返回当前激活View
        /// </summary>
        /// <returns></returns>
        public virtual IView GetActiveView()
        {
            #region 李睿 2013-8-27 重构 从子类移植
            return m_CurrentView;
            #endregion
        }

        /// <summary>
        /// 返回当前激活Document
        /// </summary>
        /// <returns></returns>
        public virtual IDocument GetActiveDocument()
        {
            #region 李睿 2013-8-27 重构 从子类移植
            IDocument doc = null;

            IView view = GetActiveView();
            if (view != null)
            {
                doc = view.Document;
            }
            return doc;
            #endregion
        }

        #endregion

        /// <summary>
        /// 显示导航界面
        /// </summary>
        public virtual void ShowWelcome()
        { 
        }

        /// <summary>
        /// 显示 工程管理器组件
        /// </summary>
        /// <param name="switchover"></param>
        public virtual void ShowManager(DisplayType type)
        {

        }

        /// <summary>
        /// 重新绘制菜单
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="directory"></param>
        public virtual void AfreshDrawMenu(IEnumerable<Lazy<Action<Contracts.Shell>, ICommandMetadataView>> commands, string directory)
        {
        }
        /// <summary>
        /// 设置菜单和工具栏状态
        /// </summary>
        /// <param name="flag"></param>
        public virtual void SetMenuState(bool flag)
        {
 
        }
        /// <summary>
        /// 显示DockWindow
        /// </summary>
        /// <param name="dockWindow"></param>
        public virtual void ShowDockWindow(IDockWindow dockWindow)
        {
            #region 李睿 重构 2013-8-27 从子类移植
            try
            {
                XDockState ds = XDockState.Document;
                if (!Enum.TryParse<XDockState>((dockWindow as DockContent).DockState.ToString(), out ds))
                {
                    ShowDockWindow(dockWindow, XDockState.Unknown);
                }
                ShowDockWindow(dockWindow, XDockState.Document);
            }
            catch (Exception ex)
            {
                string errMessage = "切换dockWindow错误！";
                XSystem.LogHandler.Error(errMessage, ex);
                //[质检回归]聂桂春20130731，提示语优化
                //MsgBox.Show(errMessage, ex.Message + Environment.NewLine + ex.StackTrace, "系统提示", MsgBoxButtons.ContinueQuit);
                //MsgBox.Show("窗口切换失败！");
                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// 显示DockWindow
        /// </summary>
        /// <param name="dockWindow"></param>
        /// <param name="dockState"></param>
        public virtual void ShowDockWindow(IDockWindow dockWindow, XDockState dockState)
        {
            #region 李睿 2013-8-27 重构 从子类移植
            try
            {
                DockState ds = DockState.Document;

                if (!Enum.TryParse<DockState>(dockState.ToString(), out ds))
                {
                    Debug.Assert(false, "停靠位置枚举转换失败！#FrmMain.ShowView(IView view, XDockState dockState)#");
                }
                // Start Bug No.[        ]  (李睿 2013/3/28 16:52:19)
                // 问题描述:  对DockPanel相关操作代码进行优化重构
                //            
                // 修改说明:  
                //            
                // ======================================================= 

                //(dockWindow as DockContent).Show(m_dockPanel, ds);

                DockContent dc = dockWindow as DockContent;

                if (dc != null)
                {
                    dc.OnBeforeClose -= dockContent_OnBeforeClose;
                    dc.OnAfterActive -= dockContent_OnAfterActive;

                    dc.OnBeforeClose += new DockContent.OnCloseHandler(dockContent_OnBeforeClose);
                    dc.OnAfterActive += new EventHandler(dockContent_OnAfterActive);
                    if (dockWindow is ICanvasView)
                    {
                        if (!m_GISViewCacheList.Contains(dc))
                        {
                            m_GISViewCacheList.Add(dc);
                        }
                    }
                    dc.Show(m_dockPanel, ds);
                }

                // End Bug No.[        ] (李睿 2013/3/28 16:52:24)
            }
            catch (Exception ex)
            {
                string errMessage = "dockWindow切换报错！";
                XSystem.LogHandler.Error(errMessage, ex);
                //[质检回归]聂桂春20130731，提示语优化
                //MsgBox.Show(errMessage, ex.Message + Environment.NewLine + ex.StackTrace, "系统提示", MsgBoxButtons.ContinueQuit);
                //MsgBox.Show("窗口切换失败！");
                throw ex;
            }
            #endregion
        }

        /// <summary>
        /// 显示停泊窗改进
        /// </summary>
        /// <param name="window">窗体</param>
        public virtual void ShowDockWindowEx(IDockWindow window)
        {
            #region 李睿 2013-8-27 重构 从子类移植
            if (!ContainsRecord(window))
            {
                ShowDockWindow(window);
                return;
            }
            DockState state = GetRecord(window);
            if (window.Instance.DockState != state)
            {
                window.Instance.DockState = state;
            }
            if (IsDockStateAutoHide(window.Instance.DockState))
            {
                //*重要语句，不使用会造成浮动页卡缺失问题
                window.Instance.Visible = true;
                (m_dockPanel.GetField("m_autoHideStripControl") as AutoHideStripBase).Invalidate();
            }
            #endregion
        }

        /// <summary>
        /// 显示View
        /// </summary>
        /// <param name="view"></param>
        public virtual void ShowView(IDockWindow view)
        {
            #region 李睿 2013-8-27 重构 从子类移植
            ShowDockWindow(view, XDockState.Document);
            #endregion
        }

        #region 显示子图

        #region 性能优化 刘东亮, 2013/3/13 11:21:37, 修改：打开子图-视图切换 添加带停靠状态的显示视图方法

        /// <summary>
        /// 显示子图
        /// </summary>
        /// <param name="dockWindow">子图对象</param>
        /// <param name="parentWindow">子图所属的视图</param>
        /// <param name="rectangle">子图浮动显示的位置和大小</param>
        public virtual void ShowChildView(IDockWindow dockWindow, IDockWindow parentWindow, System.Drawing.Rectangle rectangle)
        {
            #region 李睿 2013-8-27 重构 从子类移植

            DockContent pContent = parentWindow as DockContent;
            DockContent cContent = dockWindow as DockContent;

            // Start Bug No.[        ]  (李睿 2013/4/9 9:06:47)
            // 问题描述:  对DockPanel相关操作代码进行优化重构
            //            
            // 修改说明:  
            //            
            // ======================================================= 
            cContent.OnBeforeClose -= dockContent_OnBeforeClose;
            cContent.OnAfterActive -= dockContent_OnAfterActive;

            cContent.OnBeforeClose += new DockContent.OnCloseHandler(dockContent_OnBeforeClose);
            cContent.OnAfterActive += new EventHandler(dockContent_OnAfterActive);
            // End Bug No.[        ] (李睿 2013/4/9 9:06:51)

            if (!cContent.IsHandleCreated)
            {
                cContent.Show(pContent.Pane, rectangle);
            }
            else
            {
                //cContent.DockHandler.ActivateWithoutFocus();
                cContent.DockHandler.Activate();
            }
            #endregion
        }

       #endregion 性能优化

        /// <summary>
        /// 显示子视图
        /// </summary>
        /// <param name="dockWindow">停泊窗体</param>
        /// <param name="parentWindow">父窗体</param>
        public virtual void ShowChildView(IDockWindow dockWindow,IDockWindow parentWindow)
        {
            #region 李睿 2013-8-27 重构 从子类移植

            DockContent pContent = parentWindow as DockContent;
            DockContent cContent = dockWindow as DockContent;

            // Start Bug No.[        ]  (李睿 2013/4/9 9:06:47)
            // 问题描述:  对DockPanel相关操作代码进行优化重构
            //            
            // 修改说明:  
            //            
            // ======================================================= 
            if (pContent != null)
            {
                pContent.OnBeforeClose -= dockContent_OnBeforeClose;
                pContent.OnAfterActive -= dockContent_OnAfterActive;
                pContent.OnBeforeClose += new DockContent.OnCloseHandler(dockContent_OnBeforeClose);
                pContent.OnAfterActive += new EventHandler(dockContent_OnAfterActive);
            }
            cContent.OnBeforeClose -= dockContent_OnBeforeClose;
            cContent.OnAfterActive -= dockContent_OnAfterActive;
            cContent.OnBeforeClose += new DockContent.OnCloseHandler(dockContent_OnBeforeClose);
            cContent.OnAfterActive += new EventHandler(dockContent_OnAfterActive);
            // End Bug No.[        ] (李睿 2013/4/9 9:06:51)

            if (pContent != null && pContent.Pane != null)
            {
                if (!pContent.IsHandleCreated)
                {
                    pContent.Show(cContent.Pane, cContent);
                }
                if (!cContent.IsHandleCreated)
                {
                    cContent.Show(pContent.Pane, pContent);
                }
                else
                {
                    //cContent.DockHandler.ActivateWithoutFocus();
                    cContent.DockHandler.Activate();
                }

                #region 性能优化 刘东亮, 2013/3/13 11:27:08, 修改：打开子图-视图切换 删除已注释的代码

                #endregion 性能优化
                return;
            }
            cContent.Show(m_dockPanel, new System.Drawing.Rectangle(
                Cursor.Position, new System.Drawing.Size(300, 300)));

            #endregion
        }

        #endregion

        /// <summary>
        /// 停泊到
        /// </summary>
        /// <param name="dockWindow">停泊窗体</param>
        /// <param name="paneTo">面板</param>
        public virtual void DockTo(IDockWindow dockWindow, DockPane paneTo)
        {
            #region 李睿 2013-8-27 重构 从子类移植
            DockContent cContent = dockWindow as DockContent;
            cContent.DockPanel = paneTo.DockPanel;
            cContent.DockState = DockState.Document;
            cContent.DockTo(paneTo, DockStyle.Fill, paneTo.Contents.Count);
            cContent.Show();
            #endregion
        }

        /// <summary>
        /// 显示TreeGridWatch
        /// </summary>
        public virtual void ShowTreeGridWatch()
        {
        }

        /// <summary>
        /// 返回工具箱实例
        /// </summary>
        /// <returns></returns>
        public virtual IToolBoxWindow GetToolBox()
        {
            return null;
        }

        /// <summary>
        /// 获取历史备份文档
        /// </summary>
        /// <returns></returns>
        public virtual IHistroyDocmentWindow GetHistroyDocment()
        {
            return null;
        }

        /// <summary>
        /// 主菜单
        /// </summary>
        /// <returns></returns>
        public virtual MenuStrip GetMainMenuStrip(string name)
        {
            return null;
        }

        /// <summary>
        /// 主工具栏
        /// </summary>
        /// <returns></returns>
        public virtual ToolStripPanel GetMainToolStrip(string name)
        {
            return null;
        }

        /// <summary>
        /// 当前激活子系统
        /// </summary>
        /// <returns>子系统</returns>
        public virtual SubSystem GetActiveSubSystem()
        {
            if (m_activeSpec == null)
            {
                if (!m_factories.ContainsKey(0))
                {
                    return null;
                }
                return m_factories[0].GetSystemInstance(m_activeSpec);
            }
            if (!m_factories.ContainsKey(m_activeSpec.SubgchtypeID))
            {
                return null;
            }
            return m_factories[m_activeSpec.SubgchtypeID].GetSystemInstance(m_activeSpec);
        }

        /// <summary>
        /// 根据子系统规格获取对应的子系统
        /// </summary>
        /// <param name="spec">规格</param>
        /// <returns>子系统</returns>
        public SubSystem GetSubSystem(IShellSpec spec)
        {
            if (spec == null
                || !m_factories.ContainsKey(spec.SubgchtypeID))
            {
                return null;
            }
            return m_factories[spec.SubgchtypeID].GetSystemInstance(spec);
        }

        /// <summary>
        /// 根据文档对象获取对应的子系统
        /// </summary>
        /// <param name="document">文档</param>
        /// <returns>子系统</returns>
        public SubSystem GetSubSystem(IDocument document)
        {
            if (document == null)
            {
                return null;
            }
            return GetSubSystem(document.Spec);
        }

        /// <summary>
        /// 工程管理器
        /// </summary>
        /// <returns></returns>
        public virtual IProjectManagerFrm GetProjectManager()
        {
            return null;
        }

        /// <summary>
        /// 在Shell中添加ToolStrip
        /// </summary>
        /// <param name="Strip">工具栏</param>
        /// <returns>是否成功</returns>
        public virtual bool AddToolStrip(string SubSystemName,ToolStrip Strip, int row)
        {
            return false;
        }


        /// <summary>
        /// 返回属性窗实例
        /// </summary>
        /// <returns></returns>
        public virtual IPropertyGrid GetPropertyGrid()
        {
            return null;
        }

        /// <summary>
        /// 返回分类选择结果窗口实例
        /// </summary>
        /// <returns></returns>
        public virtual IToolWindow GetFilterSelectResult()
        {
            return null;
        }

        /// <summary>
        /// 返回站内图窗口实例
        /// </summary>
        /// <returns></returns>
        public virtual ISubViewContainer GetSubViewContainer()
        {
            return null;
        }


        /// <summary>
        /// 返回当前激活DockWindow
        /// </summary>
        /// <returns></returns>
        public virtual IDockWindow GetActiveDockWindow()
        {
            return null;
        }

        /// <summary>
        /// 返回当前dockPanel
        /// </summary>
        /// <returns></returns>
        public virtual DockPanel GetDockPanel()
        {
            #region 李睿 2013-8-27 重构 从子类移植
            return this.m_dockPanel;
            //return null;
            #endregion
        }

        /// <summary>
        /// 获得所有Form集合
        /// </summary>
        /// <returns>Form集合</returns>
        public IEnumerable<Lazy<IForm, IFormMetadataView>> GetForms()
        {
            return Forms.Where(c => c.Metadata.ItemType == "Form");
        }

        /// <summary>
        /// 获得所有ToolWindow集合
        /// </summary>
        /// <returns>ToolWindow集合</returns>
        public IEnumerable<Lazy<IToolWindow, IFormMetadataView>> GetToolWindows()
        {
            return ToolWindows.Where(c => c.Metadata.ItemType == "ToolWindow");
        }

        /// <summary>
        /// 获得所有TreeGridWatch集合
        /// </summary>
        /// <returns>TreeGridWatch集合</returns>
        public IEnumerable<Lazy<ITreeGridWatch, IFormMetadataView>> GetTreeGridWatchs()
        {
            return TreeGridWatchs.Where(c => c.Metadata.ItemType == "TreeGridWatch");
        }

        ///// <summary>
        ///// 获得所有服务集合
        ///// </summary>
        ///// <returns>服务集合</returns>
        //public IEnumerable<Lazy<IService, IServiceMetadataView>> GetServices() { return Services; }

        /// <summary>
        /// 根据Form Name返回 Form实例
        /// </summary>
        /// <param name="name">Form Name</param>
        /// <returns>Form对象</returns>
        public IForm GetForm(string name)
        {
            IEnumerable<Lazy<IForm, IFormMetadataView>> forms = GetForms();
            return forms.Where(c => c.Metadata.Name == name).First().Value;
        }

        /// <summary>
        /// 根据名称返回ToolWindow
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IToolWindow GetToolWindow(string name)
        {
            IEnumerable<Lazy<IToolWindow, IFormMetadataView>> toolWindows = GetToolWindows();
            return toolWindows.Where(c => c.Metadata.Name == name).First().Value;
        }

        /// <summary>
        /// 根据TreeGridWatch Name返回TreeGridWatch实例
        /// </summary>
        /// <param name="name">TreeGridWatch Name</param>
        /// <returns>TreeGridWatch对象</returns>
        public ITreeGridWatch GetTreeGridWatch(string name)
        {
            IEnumerable<Lazy<ITreeGridWatch, IFormMetadataView>> treeGridWatchs = GetTreeGridWatchs();
            return treeGridWatchs.Where(c => c.Metadata.Name == name).First().Value;
        }

        /// <summary>
        /// Shell 退出
        /// </summary>
        public abstract void Exit();


        /// <summary>
        /// 更新UI
        /// </summary>
        public virtual void UpdateUI()
        {
            #region 李睿 2013-8-27 重构 从子类移植
            try
            {
                SubSystem sub = GetActiveSubSystem();
                if (sub != null)
                {
                    SubSystemFactory subFactory = sub.SubSystemFactory;
                    if (subFactory != null && subFactory.FunctionActions.Count > 0)
                    {
                        string directory = sub.Name;

                        List<FunctionAction> listCategory = subFactory.FunctionActions.Where(c => c.FuncStruct.Type == FunctionType.Category).ToList();
                        UpdateUICategory(listCategory, directory);

                        List<FunctionAction> listItem = subFactory.FunctionActions.Where(c => c.FuncStruct.Type == FunctionType.Item).ToList();
                        UpdateUIItem(listItem, directory);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = "更新界面元素失败！";
                XSystem.LogHandler.Error(errMessage, ex);
                //MsgBox.Show(errMessage, ex.Message + Environment.NewLine + ex.StackTrace, "系统提示", MsgBoxButtons.ContinueQuit);
                throw ex;
            }
            #endregion
        }


        // Code Analysis End(刘东亮 2012/10/24 10:29:32)

        /// <summary>
        /// 内部使用的卸载子系统进程，不启动子系统锁
        /// </summary>
        internal void InternalUninstallSubSystem()
        {
            //分支1：激活规格为空
            if (m_activeSpec == null)
            {
                if (m_factories.ContainsKey(0))
                {
                    //隐藏CMN子系统
                    HideSystem(m_factories[0].GetSystemInstance(null));
                }
                return;
            }
            //分支2：激活规格非空，隐藏子系统
            HideSystem(m_factories[m_activeSpec.SubgchtypeID].GetSystemInstance(m_activeSpec));
            //当前规格置空
            m_activeSpec = null;
        }

        #endregion // 公有方法

        #region 保护方法

        /// <summary>
        /// 通过组件目录获取子系统工厂
        /// </summary>
        /// <param name="directory">目录</param>
        /// <returns>子系统工厂</returns>
        protected SubSystemFactory GetSystemFactory(string directory)
        {
            CompositionContainer container = XSystem.GetContainerByDirectory(directory);
            IEnumerable<Lazy<SubSystemFactory, ISubSystemMetadataView>> exports =
                container.GetExports<SubSystemFactory, ISubSystemMetadataView>()
                .Where(c => c.Metadata.Name.ToUpper() == directory.ToUpper());
            if (exports.Count() < 1)
            {
                return null;
            }
            return exports.First().Value;
        }

        /// <summary>
        /// 显示子系统组件，实现由子类完成
        /// </summary>
        /// <param name="system">子系统</param>
        /// <param name="initialized">是否为初始化显示</param>
        protected virtual void ShowSystem(SubSystem system, bool initialized)
        {
        }

        /// <summary>
        /// 隐藏子系统组件，实现由子类完成
        /// </summary>
        /// <param name="system">子系统</param>
        protected virtual void HideSystem(SubSystem system)
        {
        }

        /// <summary>
        /// 查看是否包含停泊窗样式记录
        /// </summary>
        /// <param name="window">窗体</param>
        /// <returns>是否包含</returns>
        protected bool ContainsRecord(IDockWindow window)
        {
            if (window == null
                || window.Instance == null)
            {
                return false;
            }
            return m_formRegistry.ContainsKey(window.Instance.Handle);
        }

        /// <summary>
        /// 获取停泊窗样式记录
        /// </summary>
        /// <param name="window">窗体</param>
        /// <returns>记录</returns>
        protected DockState GetRecord(IDockWindow window)
        {
            return m_formRegistry[window.Instance.Handle];
        }

        #region 李睿 2013-8-27 重构 从子类移植

        /// <summary>
        /// 视图窗体激活后触发事件
        /// </summary>
        /// <param name="sender">激活的窗体</param>
        /// <param name="e">事件参数</param>
        protected abstract void dockContent_OnAfterActive(object sender, EventArgs e);

        /// <summary>
        /// 视图窗体关闭前触发的事件
        /// </summary>
        /// <param name="Content">窗体</param>
        /// <param name="e">事件参数</param>
        protected abstract void dockContent_OnBeforeClose(IDockContent Content, CloseEventArgs e);

        #endregion

        #endregion // 保护方法

        #region 保护属性

        #region 各种窗体集合

        /// <summary>
        /// 晚绑定Form集合
        /// </summary>
        //[ImportMany(AllowRecomposition = true)]
        protected IEnumerable<Lazy<IForm, IFormMetadataView>> Forms = null;

        /// <summary>
        /// 晚绑定ToolWindow集合
        /// </summary>
        //[ImportMany(AllowRecomposition = true)]
        protected IEnumerable<Lazy<IToolWindow, IFormMetadataView>> ToolWindows = null;

        /// <summary>
        /// 晚绑定TreeGridWatch集合
        /// </summary>
        //[ImportMany(AllowRecomposition = true)]
        protected IEnumerable<Lazy<ITreeGridWatch, IFormMetadataView>> TreeGridWatchs = null;

        //[ImportMany(AllowRecomposition = true)]
        //protected Lazy<IService, IServiceMetadataView>[] Services = null;

        #endregion

        #endregion // 保护属性

        #region 私有方法

        /// <summary>
        /// 初始化
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Shell
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Shell";
            this.ResumeLayout(false);
        }

        #region 李睿 2013-8-27 重构 从子类移植

        /// <summary>
        /// 更新UI类型元素(Menu,Toolbar,ContextMenu)
        /// </summary>
        /// <param name="subFactory">子系统UI工厂类</param>
        /// <param name="directory">子系统文件夹</param>
        private void UpdateUICategory(List<FunctionAction> funcCategroyAll, string directory)
        {
            try
            {
                foreach (FunctionAction fa in funcCategroyAll)
                {
                    System.Windows.Forms.Control obj = fa.FuncStruct.Handler as System.Windows.Forms.Control;
                    {
                        if (fa.FuncStruct.VisibleFunction != null && fa.FuncStruct.VisibleFunction.Length > 0)
                        {
                            obj.Visible = CallMethod(directory, fa.FuncStruct.Namespace, fa.FuncStruct.VisibleFunction);
                            if (obj is ToolStrip && !obj.Capture && !VirtualKeyStates.VK_LBUTTON.IsPressed())
                            {
                                ToolStripPanelRow row = (obj as ToolStrip).GetRow();
                                if (row != null && (obj as ToolStrip).IndexOf() == row.Controls.Length - 1 && row.IsLeftGapped())
                                {
                                    row.CloseLeft();
                                }
                            }
                        }
                        if (fa.FuncStruct.EnableFunction != null && fa.FuncStruct.EnableFunction.Length > 0)
                        {
                            obj.Enabled = CallMethod(directory, fa.FuncStruct.Namespace, fa.FuncStruct.EnableFunction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //王津 2013-08-15 
                throw new Exception("更新Menu、Toolbar、ContextMenu元素失败，请检查界面配置文件.[" + ex.Message + "]");
            }

        }

        /// <summary>
        /// 更新UI元素
        /// </summary>
        /// <param name="funcAll">所有已安装功能</param>
        /// <param name="directory">子系统文件夹</param>
        private void UpdateUIItem(List<FunctionAction> funcItemAll, string directory)
        {
            try
            {
                foreach (FunctionAction fa in funcItemAll)
                {
                    dynamic obj = fa.FuncStruct.Handler;
                    {
                        if (fa.FuncStruct.CheckFunction != null && fa.FuncStruct.CheckFunction.Length > 0)
                        {
                            obj.Checked = CallMethod(directory, fa.FuncStruct.Namespace, fa.FuncStruct.CheckFunction);
                        }

                        if (fa.FuncStruct.EnableFunction != null && fa.FuncStruct.EnableFunction.Length > 0)
                        {
                            obj.Enabled = CallMethod(directory, fa.FuncStruct.Namespace, fa.FuncStruct.EnableFunction);
                        }

                        if (fa.FuncStruct.VisibleFunction != null && fa.FuncStruct.VisibleFunction.Length > 0)
                        {
                            obj.Visible = CallMethod(directory, fa.FuncStruct.Namespace, fa.FuncStruct.VisibleFunction);
                            if (obj is ToolStrip && !obj.Capture && !VirtualKeyStates.VK_LBUTTON.IsPressed())
                            {
                                ToolStripPanelRow row = (obj as ToolStrip).GetRow();
                                if (row != null && (obj as ToolStrip).IndexOf() == row.Controls.Length - 1 && row.IsLeftGapped())
                                {
                                    row.CloseLeft();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //王津 2013-08-15 
                throw new Exception("更新界面元素的Check及Enable属性失败，请检查界面配置文件.[" + ex.Message + "]");
            }

        }

        /// <summary>
        /// 动态调用UI静态方法
        /// </summary>
        /// <param name="directory">子系统文件夹</param>
        /// <param name="directory">处理方法命名空间</param>
        /// <param name="name">方法名</param>
        /// <returns>执行是否成功</returns>
        private bool CallMethod(string directory, string namespacestr, string name)
        {
            string dllname;

            if (!string.IsNullOrEmpty(namespacestr))
            {
                dllname = namespacestr;
            }
            else
            {
                dllname = "TDQS." + directory.ToUpper();
            }

            String assemblyFullName = XSystem.ConfigService.PathHandler.BaseDirectory + directory + "\\" + dllname + ".dll";
            Assembly lObjAssembly = null;
            if (m_DictAssemblys.ContainsKey(assemblyFullName))
            {
                lObjAssembly = m_DictAssemblys[assemblyFullName];
            }
            else
            {
                m_DictAssemblys[assemblyFullName] = Assembly.LoadFile(assemblyFullName);
                lObjAssembly = m_DictAssemblys[assemblyFullName];
            }

            Type type = lObjAssembly.GetType(dllname + "." + "Function");
            if (type == null)
            {
                return false;
            }
            return (bool)type.InvokeMember(name, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[] { });
        }

        #endregion

        #endregion // 私有方法

        #region 静态方法
        #region 李睿 2013-8-27 重构 从子类移植
        /// <summary>
        /// 获得停靠状态是否为自动隐藏
        /// </summary>
        /// <param name="dockState">停靠状态</param>
        /// <returns>是否为自动隐藏</returns>
        internal static bool IsDockStateAutoHide(DockState dockState)
        {
            return dockState == DockState.DockLeftAutoHide ||
                dockState == DockState.DockRightAutoHide ||
                dockState == DockState.DockTopAutoHide ||
                dockState == DockState.DockBottomAutoHide;
        }
        #endregion

        #endregion

        #region 属性及其私有变量

        #region 工程管理

        /// <summary>
        /// 管理系统打开的工程
        /// </summary>
        public IProjectManager ProjectManager = null;

        /// <summary>
        /// 网络工程管理器
        /// </summary>
        public IProjectManager OnlineProjectManager = null;

        /// <summary>
        /// 激活的项目
        /// </summary>
        public IProject ActiveProject
        {
            get
            {
                return ActiveProjectManager.GetActiveProject();
            }
        }

        #endregion

        /// <summary>
        /// 系统级应用线程池
        /// </summary>
        public IAppThreadPool ApplicationThreadPool = null;

        /// <summary>
        /// 最近打开的项目容器项
        /// </summary>
        public ToolStripMenuItem m_projectsItem;

        /// <summary>
        /// 获取或设置近期文件记录路径
        /// </summary>
        public string RecentFilesRecord
        {
            get
            {
                return m_recentFilesRecord;
            }
            set
            {
                if (m_recentFilesRecord == value)
                {
                    return;
                }
                m_recentFilesRecord = value;
            }
        }
        private string m_recentFilesRecord = @"Config\RecentFiles.xml";

        /// <summary>
        /// 获取或设置适应的文件扩展名
        /// </summary>
        public string FileExtension
        {
            get
            {
                return m_fileExtension;
            }
            set
            {
                if (m_fileExtension == value)
                {
                    return;
                }
                m_fileExtension = value;
            }
        }
        private string m_fileExtension = "*";

        #region 状态栏

        /// <summary>
        /// 状态栏信息 20111116 孙书涛
        /// </summary>
        public ITaskMonitor TaskMonitor
        {
            get
            {
                return this.m_TaskMonitor;
            }
            set
            {
                this.m_TaskMonitor = value;
            }
        }
        /// <summary>
        /// 任务监视器
        /// </summary>
        private ITaskMonitor m_TaskMonitor;

        /// <summary>
        /// 坐标区操作 20111116 孙书涛
        /// </summary>
        public ICoordinateOptions CoordinateOptions
        {
            get
            {
                return this.m_CoordinateOptions;
            }
            set
            {
                this.m_CoordinateOptions = value;
            }
        }
        /// <summary>
        /// 坐标
        /// </summary>
        private ICoordinateOptions m_CoordinateOptions;

        /// <summary>
        /// 状态栏辅助功能区按钮操作 20111117 孙书涛
        /// </summary>
        public IStatusStripAuxiliaryArea StatusStripAuxiliaryArea
        {
            get
            {
                return this.m_AuxArea;
            }
            set
            {
                this.m_AuxArea = value;
            }
        }
        /// <summary>
        /// 状态栏区
        /// </summary>
        private IStatusStripAuxiliaryArea m_AuxArea;

        #endregion

        #region 画布

        /// <summary>
        /// 画布
        /// </summary>
        private ICanvas m_Canvas;

        /// <summary>
        /// 画布
        /// </summary>
        public ICanvas Canvas
        {
            get
            {
                return m_Canvas;
            }
            set
            {
                m_Canvas = value;
            }
        }

        #endregion


        /// <summary>
        /// 获得或设置当前文件路径
        /// </summary>
        public string CurrentFile
        {
            get;
            set;
        }

        /// <summary>
        /// 显示状态
        /// </summary>
        public int m_isShow = 1;

        /// <summary>
        /// 自定义停靠位置枚举
        /// </summary>
        public enum XDockState
        {
            /// <summary>
            /// 未知
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// 悬浮
            /// </summary>
            Float = 1,

            /// <summary>
            /// 上自动隐藏
            /// </summary>
            DockTopAutoHide = 2,

            /// <summary>
            /// 左自动隐藏
            /// </summary>
            DockLeftAutoHide = 3,

            /// <summary>
            /// 下自动隐藏
            /// </summary>
            DockBottomAutoHide = 4,

            /// <summary>
            /// 右自动隐藏
            /// </summary>
            DockRightAutoHide = 5,

            /// <summary>
            /// 文档
            /// </summary>
            Document = 6,

            /// <summary>
            /// 上
            /// </summary>
            DockTop = 7,

            /// <summary>
            /// 左
            /// </summary>
            DockLeft = 8,

            /// <summary>
            /// 下
            /// </summary>
            DockBottom = 9,

            /// <summary>
            /// 右
            /// </summary>
            DockRight = 10,

            /// <summary>
            /// 隐藏
            /// </summary>
            Hidden = 11,
        }

        #region 结构优化中追加

        /// <summary>
        /// 被激活的子系统规格，默认值为null，表示没有激活任何子系统
        /// </summary>
        private IShellSpec m_activeSpec;

        /// <summary>
        /// 子系统工厂缓存，用子系统特征所谓键值进行寄存
        /// </summary>
        private Dictionary<int, SubSystemFactory> m_factories;

        /// <summary>
        /// 窗体样式注册机
        /// </summary>
        private Dictionary<IntPtr, DockState> m_formRegistry;  

        /// <summary>
        /// 获取激活的工程管理器，郭威
        /// </summary>
        public IProjectManager ActiveProjectManager
        {
            get
            {
                return ProjectManager;
            }
        }

        #endregion

        /// <summary>
        /// 获取工程管理器窗体
        /// </summary>
        public abstract IProjectManagerFrm ProjectManagerForm
        {
            get;
        }

        /// <summary>
        /// 返回参数对象
        /// 聂桂春20131114从Document对象中搬迁
        /// </summary>
        /// <returns>参数对象</returns>
        public  IParameterCache ParameterObject
        {
            get
            {
                return m_parameterCache;
            }
        }

        protected IParameterCache m_parameterCache;

        protected IDatabase m_database;

        /// <summary>
        /// 数据库对象
        /// </summary>
        public IDatabase Database
        {
            get { return m_database; }
        }


        /// <summary>
        /// 子系统锁，用于连续触发子系统装载卸载的互斥
        /// </summary>
        private bool m_subSystemLock = false;

        #region 李睿 2013-8-27 重构 从子类移植



        protected WinFormsUI.Docking.DockPanel m_dockPanel;

        /// <summary>
        /// 当前激活的视图
        /// </summary>
        protected IView m_CurrentView = null;

        /// <summary>
        /// 当前显示的GISView的缓存
        /// </summary>
        protected List<DockContent> m_GISViewCacheList = null;

        /// <summary>
        /// 程序集缓存字典
        /// </summary>
        private Dictionary<String, Assembly> m_DictAssemblys = null;



        #endregion

        #endregion // 属性及其私有变量
    }
}