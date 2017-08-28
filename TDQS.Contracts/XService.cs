#region CLR版本 4.0.30319.239
// XSystem 类
// 时间：2011-11-25 9:49:26
// 名称：XSystem
// 大纲：系统基础服务入口
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 系统基础服务入口
    /// </summary>
    public partial class XSystem
    {

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        // TODO: Code Analysis Start(刘东亮 2012/10/23 17:56:36)
        // 类型: [违反扩展原则] 
        // 严重程度: [ 2  ] （1:非常严重  2:严重 3:一般） 
        // 详细说明:  
        //            
        // ======================================================= 
        //  日期		   修改人	    	描述 

        /// <summary>
        /// 异常服务
        /// </summary>
        public static IExceptionService ExceptionService
        {
            get
            {
                if (m_exceptionService == null)
                {
                    m_exceptionService = ServicesContainer.Instance.GetExceptionService();
                }
                return m_exceptionService;
            }
            set
            {
                m_exceptionService = value;
            }
        }
        private static IExceptionService m_exceptionService = null;
        // TODO: Code Analysis Start(刘东亮 2012/10/23 17:59:47)
        // 类型: [违反编程规范、技术要求或详细设计] 
        // 严重程度: [ 2  ] （1:非常严重  2:严重 3:一般） 
        // 详细说明:  
        //            
        // ======================================================= 
        //  日期		   修改人	    	描述 

        /// <summary>
        ///获取或设置日志服务
        /// </summary>
        public static ILogService LogService
        {
            get
            {
                if (m_logService == null)
                {
                    m_logService = ServicesContainer.Instance.GetLogService();
                }
                return m_logService;
            }
            set
            {
                LogService = value;
            }
        }
        /// <summary>
        ///获取或设置日志服务
        /// </summary>
        private static ILogService m_logService = null;
        /// <summary>
        /// 默认日志处理器
        /// </summary>
        public static ILogHandler LogHandler
        {
            get
            {
                if (LogService != null)
                {
                    return LogService.GetLogger("TDQS.CNP");
                }
                return null;
            }
        }
        // Code Analysis End(刘东亮 2012/10/23 18:00:01)

        /// <summary>
        /// 获取或设置资源服务
        /// </summary>
        public static IResourceService ResourceService
        {
            get
            {
                if (m_resourceService == null)
                {
                    m_resourceService = ServicesContainer.Instance.GetResourceService();
                }
                return m_resourceService;
            }
            set
            {
                m_resourceService = value;
            }
        }
        /// <summary>
        /// 获取或设置资源服务
        /// </summary>
        private static IResourceService m_resourceService = null;
        /// <summary>
        /// 获取或设置对象序列化服务
        /// </summary>
        public static ISerializeService SerializeService
        {
            get 
            {
                if (m_serializeService == null)
                {
                    m_serializeService = ServicesContainer.Instance.GetSerializeService();
                }
                return m_serializeService; 
            }
            set 
            { 
                m_serializeService = value; 
            }
        }
        /// <summary>
        /// 获取或设置对象序列化服务
        /// </summary>
        private static ISerializeService m_serializeService = null;

        /// <summary>
        /// 获取或设置配置服务
        /// </summary>
        public static IConfigService ConfigService
        {
            get
            {
                if (m_configService == null)
                {
                    m_configService = ServicesContainer.Instance.GetConfigService();
                }
                return m_configService;
            }
            set
            {
                m_configService = value;
            }
        }
        /// <summary>
        /// 获取或设置配置服务
        /// </summary>
        private static IConfigService m_configService = null;

        /// <summary>
        /// 获取或设置授权服务
        /// </summary>
        public static IAuthorizeService AuthorizeService
        {
            get
            {
                if (m_authorizeService == null)
                {
                    m_authorizeService = ServicesContainer.Instance.GetAuthorizeService();
                }
                return m_authorizeService;
            }
            set
            {
                if (m_authorizeService == value)
                {
                    return;
                }
                m_authorizeService = value;
            }
        }

        /// <summary>
        /// 获取或设置授权服务
        /// </summary>
        private static IAuthorizeService m_authorizeService;


       

        // Code Analysis End(刘东亮 2012/10/23 17:56:55)
        #endregion // 属性及其私有变量

    }
}