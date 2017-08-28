#region CLR版本 4.0.30319.239
// IResourceHandler 接口
// 时间：2011-11-10 14:04:17
// 名称：IResourceHandler 
// 大纲：资源操作接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Resources;
using System.Globalization;
using System.Drawing;

namespace TDQS.Contracts
{
    /// <summary>
    /// 资源操作接口
    /// </summary>
    public interface IResourceHandler
    {
        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="aResProvider"></param>
        void Init(IResourceProvider aResProvider);

        /// <summary>
        /// 获得字符串资源
        /// </summary>
        /// <param name="aName">资源名称</param>
        /// <returns>资源内容</returns>
        string GetString(string aName);

        /// <summary>
        /// 获得图片资源
        /// </summary>
        /// <param name="aName">资源名称</param>
        /// <returns>资源内容</returns>
        Image GetImage(string aName);

        /// <summary>
        /// 获得对象资源
        /// </summary>
        /// <param name="aName">资源名称</param>
        /// <returns>资源内容</returns>
        object GetObject(string aName);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

