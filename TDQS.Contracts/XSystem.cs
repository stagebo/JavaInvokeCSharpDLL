#region CLR版本 4.0.30319.239
// XSystem 类
// 时间：2011-11-10 14:04:17
// 名称：系统组件统一访问接口
// 大纲：提供获得访问组件
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		   修改人		描述
// 2012-11-23  郭威         Authenticate添加；
//                          1.统一系统启动时的有效性验证接口，合并本地及网络版；
//                          2.除返回有效性外，同时返回错误提示内容；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         Invoke添加；
//                          1.重载子系统热键执行函数，参数为子系统及热键主值；
//                          2.通过GetHotkeyMode的两个重载函数实现热键匹配的认定；
//                          3.执行热键对应的FunctionAction中的方法；
//                          优化要点阐述完毕。
// 2012-11-23  郭威         GetHotkeyMode添加；
//                          1.重载获取当前热键模式的方法；
//                          2.重载解析热键字符串的方法；
//                          优化要点阐述完毕。
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using TDQS.IO;
using TDQS.Win32;

namespace TDQS.Contracts
{
    /// <summary>
    /// 提供获得访问组件
    /// </summary>
    public partial class XSystem
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public XSystem()
        {

        }

        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 通过支持格式或扩展名获取规格
        /// </summary>
        /// <param name="supportedFormat"></param>
        /// <returns></returns>
        public static IShellSpec GetSpec(string supportedFormat)
        {
            if (m_specDictionary == null)
            {
                return null;
            }
            foreach (IShellSpec spec in m_specDictionary.Values)
            {
                if (spec.FileExtension.Equals(supportedFormat, StringComparison.CurrentCultureIgnoreCase))
                {
                    return spec;
                }
                foreach (string format in spec.SupportedFormats)
                {
                    if (!format.Equals(supportedFormat, StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    return spec;
                }
            }
            return null;
        }

        /// <summary>
        /// 进入系统前的有效性验证
        /// </summary>
        /// <returns>是否允许进入</returns>
        public static bool Authenticate(ref string errorMessage)
        {
            //单机版认为具有效性
            if (XSystem.AuthorizeService == null)
            {
                return true;
            }
            //这部分为日常控制网络或单机版提供条件，正式发布可移除
            if (ConfigurationManager.AppSettings["Online"] != "1")
            {
                return true;
            }
            //判断网络是否连通
            if (!IsNetConnect())
            {
                errorMessage = "未连接到服务器，请检查网络后重试此操作。";
                return false;
            }
            //如果为网络版，需要以登录是否成功为验证标准
            return XSystem.AuthorizeService.Login();
        }

        /// <summary>
        /// 子系统单快捷键功能执行
        /// </summary>
        /// <param name="system">子系统</param>
        /// <param name="key">快捷键</param>
        /// <returns>是否执行</returns>
        public static bool Invoke(SubSystem system, Keys key)
        {
            //子系统为空认定为未执行
            if (system == null)
            {
                return false;
            }
            //找到对应快捷键的动作并执行
            foreach (FunctionAction action in system.SubSystemFactory.FunctionActions)
            {
                //不包含基础键则跳过
                if (!action.FuncStruct.GlobalShortcut
                    || string.IsNullOrWhiteSpace(action.FuncStruct.ShortcutKey)
                    || !action.FuncStruct.ShortcutKey.EndsWith(key.ToString()))
                {
                    continue;
                }
                //获取动作的热键模式
                HotkeyMode mode = GetHotkeyMode(action.FuncStruct.ShortcutKey);
                //如果当前热键模式不符合动作热键模式则跳过
                if (!mode.In(GetHotkeyMode()))
                {
                    continue;
                }
                //完全符合要求则执行
                //默认阻拦消息
                Singleton<ITagged<bool>>.GetInstance().Tag = true;
                action.FuncStruct.Action(system);
                return Singleton<ITagged<bool>>.GetInstance().Tag;
            }
            //未找到认定为未执行
            return false;
        }

        /// <summary>
        /// 根据目录得到加载的容器
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static CompositionContainer GetContainerByDirectory(string directory)
        {
            if (m_compositionContainers.ContainsKey(directory.ToLower()))
            {
                return m_compositionContainers[directory.ToLower()];
            }
            AggregateCatalog aggregateCatalog = new AggregateCatalog();

            DirectoryCatalog directoryCatalog = new DirectoryCatalog(directory);
            aggregateCatalog.Catalogs.Add(directoryCatalog);

            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetEntryAssembly());
            aggregateCatalog.Catalogs.Add(assemblyCatalog);

            CompositionContainer container = new CompositionContainer(aggregateCatalog);
            m_compositionContainers.Add(directory.ToLower(), container);
            return m_compositionContainers[directory.ToLower()];
        }
        /// <summary>
        /// 根据接口从子系统得到实例
        /// </summary>
        /// <typeparam name="T">实例接口</typeparam>
        /// <typeparam name="S">描述接口</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetImplementBySystem<T, S>()
        {
            foreach (Lazy<T, S> lazy
               in SubSystemCompositionContainer.GetExports<T, S>())
            {
                yield return lazy.Value;
            }
        }

        /// <summary>
        /// 获取配置项
        /// </summary>
        /// <typeparam name="TConfig"></typeparam>
        /// <param name="Config"></param>
        /// <returns></returns>
        public static TConfig GetConfig<TConfig>() where TConfig : IConfigContext
        {
            if (ConfigContexts.Find(temp => temp is TConfig) != null)
            {
                return (TConfig)ConfigContexts.Find(temp => temp is TConfig);
            }
            else
            {
                return default(TConfig);
            }
        }

        /// <summary>
        /// 添加配置项
        /// </summary>
        /// <typeparam name="TConfig"></typeparam>
        /// <param name="Config"></param>
        public static void SetConfig<TConfig>(TConfig Config) where TConfig : IConfigContext
        {
            if (Config is IConfigContext)
            {
                IConfigContext c = Config as IConfigContext;
                if (!ConfigContexts.Exists(temp => temp.Equals(c)))
                {
                    ConfigContexts.Add((IConfigContext)Config);
                }
                else
                {

                    IConfigContext c1 = (IConfigContext)ConfigContexts.Find(temp => temp is TConfig);
                    c1 = c;
                }
            }
        }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法

        /// <summary>
        /// 判断网络是否连通， true:连通， false:未连通
        /// </summary>
        /// <returns></returns>
        private static bool IsNetConnect()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["postgres"].ToString();

                string[] arrConn = connString.Split(';');

                string ipConn = string.Empty;

                int portConn = 0;

                foreach (string connItem in arrConn)
                {
                    if (connItem.Split('=')[0].ToLower() == "server")
                    {
                        ipConn = connItem.Split('=')[1];
                    }

                    if (connItem.Split('=')[0].ToLower() == "port")
                    {
                        portConn = Convert.ToInt32(connItem.Split('=')[1]);
                    }
                }

                TcpClient tc = new TcpClient(ipConn, portConn);

                if (tc.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 获取当期热键模式
        /// </summary>
        /// <returns>热键模式</returns>
        private static HotkeyMode GetHotkeyMode()
        {
            HotkeyMode ctrlMode = IsLControlPressed() || IsRControlPressed()
           ? HotkeyMode.Control : HotkeyMode.None;
            HotkeyMode shiftMode = IsLShiftPressed() || IsRShiftPressed()
                ? HotkeyMode.Shift : HotkeyMode.None;
            HotkeyMode altMode = IsRAltPressed() || IsLAltPressed()
                ? HotkeyMode.Alt : HotkeyMode.None;
            return ctrlMode | shiftMode | altMode;
        }

        /// <summary>
        /// 判断左Ctrl是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsLControlPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_LCONTROL) & 0x80).ToBoolean();
        }
        /// <summary>
        /// 判断右Ctrl是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsRControlPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_RCONTROL) & 0x80).ToBoolean();
        }
        /// <summary>
        /// 判断左Shift是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsLShiftPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_LSHIFT) & 0x80).ToBoolean();
        }
        /// <summary>
        /// 判断右Shift是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsRShiftPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_RSHIFT) & 0x80).ToBoolean();
        }
        /// <summary>
        /// 判断左Alt是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsLAltPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_LMENU) & 0x80).ToBoolean();
        }
        /// <summary>
        /// 判断右Alt是否按下
        /// </summary>
        /// <returns>是否按下</returns>
        private static bool IsRAltPressed()
        {
            return (NativeMethods.GetKeyState((int)VirtualKeyStates.VK_RMENU) & 0x80).ToBoolean();
        }


        /// <summary>
        /// 获取热键字符串的热键模式
        /// </summary>
        /// <param name="shortcutKey">热键字符串</param>
        /// <returns>热键模式</returns>
        private static HotkeyMode GetHotkeyMode(string shortcutKey)
        {
            HotkeyMode ctrlMode = shortcutKey.Contains("Control")
                ? HotkeyMode.Control : HotkeyMode.None;
            HotkeyMode shiftMode = shortcutKey.Contains("Shift")
                ? HotkeyMode.Shift : HotkeyMode.None;
            HotkeyMode altMode = shortcutKey.Contains("Alt")
                ? HotkeyMode.Alt : HotkeyMode.None;
            return ctrlMode | shiftMode | altMode;
        }

        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 子系统MEF扩展的dll
        /// </summary>
        private static string[] LoadSubSystemDll = new string[] { ".dll", ".BusinessLayer.dll" };

        /// <summary>
        /// 当前子系统容器
        /// </summary>
        public static CompositionContainer SubSystemCompositionContainer
        {
            get
            {
                return m_subSystemCompositionContainer;
            }
            set
            {
                m_subSystemCompositionContainer = value;
            }
        }
        private static CompositionContainer m_subSystemCompositionContainer = null;

        /// <summary>
        /// 子系统容器对照表
        /// </summary>
        private static Dictionary<string, CompositionContainer> m_compositionContainers
            = new Dictionary<string, CompositionContainer>();

        /// <summary>
        /// 各子系统规格
        /// </summary>
        public static Dictionary<string, IShellSpec> SpecDictionary
        {
            get
            {
                return m_specDictionary;
            }
            set
            {
                m_specDictionary = value;
            }
        }

        /// <summary>
        /// 各子系统规格
        /// </summary>
        private static Dictionary<string, IShellSpec> m_specDictionary = null;

        /// <summary>
        /// 根据扩展名找到对应的系统规格
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns>
        public static IShellSpec GetSubSystemSpec(string Extension)
        {
            IShellSpec spec = null;
            if (SpecDictionary.ContainsKey(Extension))
            {
                spec = SpecDictionary[Extension];
            }
            return spec;
        }

        /// <summary>
        /// 主窗体
        /// </summary>
        private static Shell m_shell = null;
        /// <summary>
        /// 主窗体
        /// </summary>
        public static Shell Shell
        {
            get { return m_shell; }
            set { m_shell = value; }
        }

        /// <summary>
        /// 登录系统用户名
        /// </summary>
        public static string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        private static string m_UserName;

        /// <summary>
        /// 工程ID
        /// </summary>
        public static string Category
        {
            get
            {
                if (XSystem.Shell != null && XSystem.Shell.ProjectManager.GetActiveProject() != null)
                {
                    m_Category = XSystem.Shell.ProjectManager.GetActiveProject().ID;
                }
                else
                {
                    m_Category = "空工程";
                }
                return m_Category;
            }
            set { m_Category = value; }
        }
        private static string m_Category;
        /// <summary>
        /// 客户端IP地址
        /// </summary>
        public static string IP
        {
            get
            {
                if (m_ip == null)
                {
                    foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    {
                        if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                        {
                            m_ip = _IPAddress.ToString();
                            return m_ip;
                        }
                    }
                }
                return m_ip;
            }
        }
        internal static string m_ip = null;

        /// <summary>
        /// 获取系统名称
        /// </summary>
        public static string Name
        {
            get
            {
                return m_chsName + m_type;
            }
        }

        /// <summary>
        /// 获取系统中文名称
        /// </summary>
        public static string ChsName
        {
            get
            {
                return m_chsName;
            }
        }
        private static string m_chsName = "电网规划计算机辅助决策系统";

        /// <summary>
        /// 获取系统型号
        /// </summary>
        public static string Type
        {
            get
            {
                return m_type;
            }
        }
        private static string m_type = "TCNP5000";

        /// <summary>
        /// 获取或设置系统的在线状态
        /// </summary>
        public static bool Online
        {
            get
            {
                return m_online;
            }
            set
            {
                if (m_online == value)
                {
                    return;
                }
                m_online = value;
            }
        }
        private static bool m_online = false;

        /// <summary>
        /// 系统设置
        /// </summary>
        public static ISystemConfig SystemConfig
        {
            get
            {
                return m_SystemConfig;
            }
            set
            {
                m_SystemConfig = value;
            }
        }
        private static ISystemConfig m_SystemConfig;

        /// <summary>
        /// 系统配置项列表
        /// </summary>
        private static List<IConfigContext> ConfigContexts = new List<IConfigContext>();

        /// <summary>
        /// 参数表和报表多实例的字典
        /// </summary>
        public static Dictionary<string, ITreeGridWatch> DicTreeGridFrm = new Dictionary<string, ITreeGridWatch>();

        /// <summary>
        /// 版权信息
        /// </summary>
        const string Copyright = "CCECBDF2CCECB4F3C7F3CAB5B5E7C1A6D0C2BCBCCAF5B9C9B7DDD3D0CFDEB9ABCBBE20B0E6C8A8CBF9D3D0";

        /// <summary>
        /// 是否锁定图形操做
        /// 用于解决图形不太不支持多线程的问题；
        /// 问题体现ＬｏａｄＭａｐ和ｓｅｌｅｃｔＴｏｏｌ冲突
        /// 张增平添加，ｔｏｄｏ应该使用ＯＧＲ重写读取元件获取做ｗｉｎｄｏｗｓ服务作自动备份
        /// /// </summary>
        public static bool IsLockedGisTool = false;

        
        #endregion // 属性及其私有变量

    }
}