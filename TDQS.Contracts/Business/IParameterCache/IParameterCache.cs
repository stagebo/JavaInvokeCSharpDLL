#region CLR版本 4.0.30319.17379
// IParameterCache 接口
// 时间：2012/4/19 15:45:41
// 名称：IParameterCache
// 大纲：参数表缓存操作接口
//
// 创建人：孙书涛
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 参数表缓存操作接口
    /// </summary>
    public interface IParameterCache
    {
        #region 方法

        /// <summary>
        /// 根据名称返回工程级的缓存对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="paramID">参数ID</param>
        /// <returns>缓存对象，不存在时返回null</returns>
        DataTable GetParameterCache(string parameterName, string paramID);

        /// <summary>
        /// 指定名称的工程级数据源数据改变
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="paramID">参数ID</param>
        void ChangeParameter(string parameterName, string paramID);

        /// <summary>
        /// 根据名称返回工程级的缓存对象
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="paramID">参数ID</param>
        /// <returns>缓存对象，不存在时返回null</returns>
        DataTable GetParameterCache(string parameterName);

        /// <summary>
        /// 指定名称的工程级数据源数据改变
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        void ChangeParameter(string parameterName);

        /// <summary>
        /// 获取电网级参数表缓存
        /// </summary>
        /// <param name="entID">电网ID</param>
        /// <param name="parameterName">参数名称</param>
        /// <returns>缓存对象，不存在时返回null</returns>
        DataTable GetEntParameterCache(string entID, string parameterName);

        /// <summary>
        /// 指定名称的参数表数据改变
        /// </summary>
        /// <param name="entID">电网ID</param>
        /// <param name="parameterName">参数名称</param>
        void ChangeEntParameter(string entID,string parameterName);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

