#region CLR版本 4.0.30319.239
// ServicesContainer 类
// 时间：2011-11-10 14:04:17
// 名称：ServicesContainer 
// 大纲：所有扩展服务的容器类
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
using System.Windows.Forms;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel.Composition.Primitives;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有扩展服务的容器类
    /// </summary>
    public sealed class ServicesContainer
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public ServicesContainer()
        {
            //
            
            //
            Compose();
        }

        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 加载服务
        /// </summary>
        /// <returns></returns>
        public int Compose()
        {
            //TODO: 刘振伟修改 加载服务目录
            try
            {
                DirectoryCatalog directoryCatalog = new DirectoryCatalog(@"Services");
                //AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                AggregateCatalog aggregateCatalog = new AggregateCatalog();
                aggregateCatalog.Catalogs.Add(directoryCatalog);
                //aggregateCatalog.Catalogs.Add(assemblyCatalog);

                var parent = new CompositionContainer(aggregateCatalog);
                //过滤服务
                var container = new FilteredCatalog(aggregateCatalog, def => def.Metadata.GetType() == typeof(IService));
                CompositionContainer child = new CompositionContainer(container, parent);
                child.ComposeParts(this);
            }
            catch (System.Reflection.ReflectionTypeLoadException ex)
            {
                Debug.Assert(false, ex.Message + "\r\n"  + ex.LoaderExceptions.First().Message  + "\r\n" + ex.StackTrace);
                XSystem.LogHandler.Error("ServicesContainer", ex);
            }
            return 0;
        }

        /// <summary>
        /// 获得日志服务
        /// </summary>
        /// <returns>日志服务对象</returns>
        public ILogService GetLogService()
        {
            foreach (var logService in Services)
            {
                if (logService.Value.Active() && (logService.Metadata.ItemType == "LogService"))
                    return (ILogService)logService.Value;
            }
            //如果不存在任何日志服务，则创建空对象实例，以避免已有代码异常。
            NullLogService nullLogService = NullLogService.Instance;
            return nullLogService;
        }
        /// <summary>
        /// 获得异常服务
        /// </summary>
        /// <returns>异常服务对象</returns>
        public IExceptionService GetExceptionService()
        {
            foreach (var exceptionService in Services)
            {
                if (exceptionService.Value.Active() && (exceptionService.Metadata.ItemType == "ExceptionService"))
                    return (IExceptionService)exceptionService.Value;
            }
            //如果不存在任何异常服务，则创建空对象实例，以避免已有代码异常。
            return NullExceptionService.Instance;
        }
        /// <summary>
        /// 获得对象序列化服务
        /// </summary>
        /// <returns></returns>
        public ISerializeService GetSerializeService()
        {
            foreach (var objectSerializeService in Services)
            {
                if (objectSerializeService.Value.Active() && (objectSerializeService.Metadata.ItemType == "ObjectSerializeService"))
                    return (ISerializeService)objectSerializeService.Value;
            }
            return null;
        }
        /// <summary>
        /// 获得资源服务
        /// </summary>
        /// <returns>资源服务对象</returns>
        public IResourceService GetResourceService()
        {
            foreach (var resourceService in Services)
            {
                if (resourceService.Value.Active() && (resourceService.Metadata.ItemType == "ResourceService"))
                    return (IResourceService)resourceService.Value;
            }
            //如果不存在任何异常服务，则创建空对象实例，以避免已有代码异常。
            //return NullResourceService.Instance;
            return null;
        }
        /// <summary>
        /// 获得配置服务
        /// </summary>
        /// <returns>配置服务对象</returns>
        public IConfigService GetConfigService()
        {
            foreach (var configSevice in Services)
            {
                if (!configSevice.Value.Active()
                    || configSevice.Metadata.ItemType != "ConfigService")
                {
                    continue;
                }
                return (IConfigService)configSevice.Value;
            }
            return null;
        }
        /// <summary>
        /// 获得授权服务
        /// </summary>
        /// <returns></returns>
        public IAuthorizeService GetAuthorizeService()
        {
            foreach (var configSevice in Services)
            {
                if (!configSevice.Value.Active()
                    || configSevice.Metadata.ItemType != "AuthorizeService")
                {
                    continue;
                }
                return (IAuthorizeService)configSevice.Value;
            }
            return null;
        }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 单例
        /// </summary>
        static readonly ServicesContainer instance = new ServicesContainer();
        /// <summary>
        /// 单例实例
        /// </summary>
        public static ServicesContainer Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// 晚期绑定服务
        /// </summary>
        [ImportMany(AllowRecomposition = true)]
        private Lazy<IService, IServiceMetadataView>[] Services = null;
        #endregion // 属性及其私有变量

    }
}