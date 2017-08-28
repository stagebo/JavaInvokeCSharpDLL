#region CLR版本 4.0.30319.239
// NullLogService 类
// 时间：2011-11-10 14:04:17
// 名称：NullLogService 
// 大纲：NullObject模式，当不存在任何LogService时，建立空对象，以保证不出现异常。
//
// 创建人：王津
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
    /// NullObject模式，当不存在任何LogService时，建立空对象，以保证不出现异常。 
    /// </summary>
    public sealed class NullLogService : ILogService
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public NullLogService()
        {
            //
            
            //
        }

        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// 激活
        /// </summary>
        /// <returns>操作是否成功</returns>
        public bool Active()
        {
            return false;
        }

        /// <summary>
        /// 开启
        /// </summary>
        public void Start() { }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause() { }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop() { }

        /// <summary>
        /// 重启
        /// </summary>
        /// <returns>操作是否成功</returns>
        public bool Required()
        {
            return false;
        }

        /// <summary>
        /// 获得日志句柄
        /// </summary>
        /// <param name="loggerName">策略名称</param>
        /// <returns>空处理器</returns>
        public ILogHandler GetLogger(string loggerName)
        {
            NullLogHandler nullLogHandler = NullLogHandler.Instance;
            return nullLogHandler;
        }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 单例对象
        /// </summary>
        static readonly NullLogService instance = new NullLogService();
        /// <summary>
        /// 返回对象实例
        /// </summary>
        public static NullLogService Instance
        {
            get { return instance; }
        }
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 实现一个空的LogHandler类，为NullLogService提供空操作。 
    /// </summary>
    public sealed class NullLogHandler : ILogHandler
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public NullLogHandler()
        {
            //
            
            //
        }

        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">消息对象</param>
        public void Debug(object message) { }

        /// <summary>
        ///  调试
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常对象</param>
        public void Debug(object message, Exception exception) { }
        //public void DebugFormat(string format, object arg0) { }
        //public void DebugFormat(string format, params object[] args) { }
        //public void DebugFormat(string format, object arg0, object arg1) { }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">消息对象</param>
        public void Error(object message) { }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常对象</param>
        public void Error(object message, Exception exception) { }
        //public void ErrorFormat(string format, object arg0) { }
        //public void ErrorFormat(string format, params object[] args) { }
        //public void ErrorFormat(string format, object arg0, object arg1) { }

        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="message">消息对象</param>
        public void Fatal(object message) { }

        /// <summary>
        /// 致命
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常对象</param>
        public void Fatal(object message, Exception exception) { }
        //public void FatalFormat(string format, object arg0) { }
        //public void FatalFormat(string format, params object[] args) { }
        //public void FatalFormat(string format, object arg0, object arg1) { }

        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="message">消息对象</param>
        public void Info(object message) { }

        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常对象</param>
        public void Info(object message, Exception exception) { }
        //public void InfoFormat(string format, object arg0) { }
        //public void InfoFormat(string format, params object[] args) { }
        //public void InfoFormat(string format, object arg0, object arg1) { }
        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息对象</param>
        public void Warn(object message) { }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">消息对象</param>
        /// <param name="exception">异常对象</param>
        public void Warn(object message, Exception exception) { }
        //public void WarnFormat(string format, object arg0) { }
        //public void WarnFormat(string format, params object[] args) { }
        //public void WarnFormat(string format, object arg0, object arg1) { }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 日志服务（单实例模式）
        /// </summary>
        static readonly NullLogHandler instance = new NullLogHandler();

        /// <summary>
        /// 日志服务（单实例模式）
        /// </summary>
        public static NullLogHandler Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// 日志输出方法
        /// </summary>
        private void OnLogOutput(object Output)
        {
            if (LogOutput != null)
            {
                LogOutput(Output);
            }
        }
        #endregion // 属性及其私有变量

        #region ILogHandler 成员

        /// <summary>
        /// 输出事件
        /// </summary>
        public event LogOutputEventHandler LogOutput;

        #endregion
    }

}