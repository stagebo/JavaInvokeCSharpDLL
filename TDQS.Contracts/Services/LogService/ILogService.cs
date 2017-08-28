#region CLR版本 4.0.30319.239
// ILogService 接口
// 时间：2011/9/16 11:51:57
// 名称：日志服务
// 大纲：提供对应的日志服务
//
// 创建人：刘振伟
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
    /// 提供对应的日志服务
    /// </summary>
    public interface ILogService : IService
    {
        #region 方法
        /// <summary>
        /// 获取日志服务对象
        /// </summary>
        /// <param name="loggerName">日志策略名称</param>
        /// <returns>日志处理器</returns>
        ILogHandler GetLogger(string loggerName);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

