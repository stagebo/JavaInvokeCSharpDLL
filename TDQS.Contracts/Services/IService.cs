#region CLR版本 4.0.30319.239
// IService 接口
// 时间：2011-11-10 14:04:17
// 名称：IService 
// 大纲：所有扩展服务必须实现的接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有扩展服务必须实现的接口
    /// </summary>
    public interface IService
    {
        #region 方法
        /// <summary>
        /// 激活
        /// </summary>
        /// <returns>是否成功</returns>
        bool Active();

        /// <summary>
        /// 启动
        /// </summary>
        void Start();

        /// <summary>
        /// 暂停
        /// </summary>
        void Pause();
        
        /// <summary>
        /// 停止
        /// </summary>
        void Stop();

        /// <summary>
        /// 是否必选
        /// </summary>
        /// <returns>是否必选</returns>
        bool Required();

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

