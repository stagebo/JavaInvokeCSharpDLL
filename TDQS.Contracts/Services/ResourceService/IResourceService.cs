#region CLR版本 4.0.30319.239
// IResourceService 接口
// 时间：2011-11-10 14:04:17
// 名称：IResourceService 
// 大纲：资源管理服务接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Drawing;

namespace TDQS.Contracts
{
    /// <summary>
    /// 资源管理服务接口
    /// </summary>
    public interface IResourceService : IService
    {
        #region 方法
        /// <summary>
        /// 获得资源包提供者
        /// </summary>
        /// <returns></returns>
        IResourceProvider GetPackgeProvider();

        /// <summary>
        /// 获得资源包提供者
        /// </summary>
        /// <param name="aResourceMode">资源模式</param>
        /// <param name="aAssembly">程序集</param>
        /// <returns></returns>
        IResourceProvider GetPackgeProvider(ResourceMode aResourceMode, Assembly aAssembly);

        /// <summary>
        /// 获得字符串资源操作者
        /// </summary>
        /// <returns></returns>
        IResourceHandler GetStrResourceHandler();

        /// <summary>
        /// 获得图片资源操作者
        /// </summary>
        /// <returns></returns>
        IResourceHandler GetImageResourceHandler();

        /// <summary>
        /// 获得对象资源操作者
        /// </summary>
        /// <returns></returns>
        IResourceHandler GetObjResourceHandler();

        /// <summary>
        /// 获得资源字符串,先自内部资源查找，后自Common查找
        /// </summary>
        /// <param name="aName">资源名称</param>
        /// <returns></returns>
        string GetString(string aName);

        /// <summary>
        /// 获得资源图片,先自内部资源查找，后自Common查找
        /// </summary>
        /// <param name="aName">资源名称</param>
        /// <returns></returns>
        Image GetImage(string aName);

        /// <summary>
        /// 获得资源对象,先自内部资源查找，后自Common查找
        /// </summary>
        /// <param name="aName"></param>
        /// <returns></returns>
        object GetObject(string aName);
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 资源操作者
        /// </summary>
        IResourceHandler ResourceHandler { get; }

        /// <summary>
        /// 资源提供者
        /// </summary>
        IResourceProvider ResourceProvider { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

