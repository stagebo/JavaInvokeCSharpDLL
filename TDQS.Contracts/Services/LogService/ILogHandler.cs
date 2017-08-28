#region CLR版本 4.0.30319.239
// ILogHandler 接口
// 时间：2011/9/16 11:51:57
// 名称：日志处理器
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
    /// 日志处理器,提供对应的日志服务
    /// </summary>
    public interface ILogHandler
    {
        #region 方法
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">消息对象</param>
        void Debug(object message);
        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常</param>
        void Debug(object message, Exception exception);
        //void DebugFormat(string format, object arg0);
        //void DebugFormat(string format, params object[] args);
        //void DebugFormat(string format, object arg0, object arg1);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">消息对象</param>
        void Error(object message);
        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常</param>
        void Error(object message, Exception exception);
        //void ErrorFormat(string format, object arg0);
        //void ErrorFormat(string format, params object[] args);
        //void ErrorFormat(string format, object arg0, object arg1);

        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="message">消息对象</param>
        void Fatal(object message);
        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常</param>
        void Fatal(object message, Exception exception);
        //void FatalFormat(string format, object arg0);
        //void FatalFormat(string format, params object[] args);
        //void FatalFormat(string format, object arg0, object arg1);

        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="message">消息对象</param>
        void Info(object message);
        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常</param>
        void Info(object message, Exception exception);
        //void InfoFormat(string format, object arg0);
        //void InfoFormat(string format, params object[] args);
        //void InfoFormat(string format, object arg0, object arg1);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息对象</param>
        void Warn(object message);
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常</param>
        void Warn(object message, Exception exception);
        //void WarnFormat(string format, object arg0);
        //void WarnFormat(string format, params object[] args);
        //void WarnFormat(string format, object arg0, object arg1);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        /// <summary>
        /// 日志对外输出事件
        /// </summary>
        event LogOutputEventHandler LogOutput;
        
        #endregion // 事件
    }
    /// <summary>
    /// 日志对外输出委托
    /// </summary>
    /// <param name="output">输出对象</param>
    public delegate void LogOutputEventHandler(object output);
}

