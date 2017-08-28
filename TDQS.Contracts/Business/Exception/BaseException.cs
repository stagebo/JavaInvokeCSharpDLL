#region CLR版本 4.0.30319.269
// BaseException 类
// 时间：2012-6-5 15:45:46
// 名称：BaseException
// 大纲：异常基类
//
// 创建人：王津
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TDQS.Contracts
{
    /// <summary>
    /// 异常基类
    /// </summary>
    [Serializable]
    public abstract class BaseException : Exception
    {
        #region 构造和析构
        /// <summary>
        /// 异常默认构造
        /// </summary>
        public BaseException()
            : base()
        {
        }

        /// <summary>
        /// 根据错误信息字符串构造异常
        /// </summary>
        /// <param name="message"></param>
        public BaseException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 反序列化异常构造
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// 根据错误信息字符串和内部异常构造异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerex"></param>
        public BaseException(string message, Exception innerex) : base(message, innerex) { }

        /// <summary>
        /// 指定错误码的构造器
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public BaseException(string errorCode, string message)
            : base(message)
        {
        }

        /// <summary>
        /// 指定错误码的构造器
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="returnTrace"></param>
        public BaseException(string errorCode, string message, string returnTrace)
            : base(message)
        {
        }

        /// <summary>
        /// 指定错误码、错误信息字符串和内部异常构造异常
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        /// <param name="innerex"></param>
        public BaseException(string errorCode, string message, Exception innerex)
            : base(message, innerex)
        {
        }

        /// <summary>
        /// 根据指定异常构造异常
        /// </summary>
        /// <param name="ex"></param>
        public BaseException(Exception ex)
            : base("系统发生异常，可通过日志查看内部异常信息", ex) { }

        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// 用于反序列获取对象信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Concat(new string[]
                                            {
                                                "Message:", Message, Environment.NewLine,
                                                "ErrorCode:", ErrorCode,Environment.NewLine,
                                                "Source:", Source,Environment.NewLine,
                                                "StackTrace:", StackTrace,Environment.NewLine,
                                            });
        }

   
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 应用程序域名
        /// </summary>
        public string AppDomainName { get; set; }

        /// <summary>
        /// 程序集名
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Machine Name
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Process Id
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// Process Name 
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Thread Id
        /// </summary>
        public int ThreadId { get; set; }

        /// <summary>
        /// Reason
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Error Code
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// System ID
        /// </summary>
        public string SystemID { get; set; }

        /// <summary>
        /// Return Trace
        /// </summary>
        public string ReturnTrace { get; set; }


        /// <summary>
        /// 注明该异常类型的中文描述
        /// </summary>
        public abstract string ExceptionDescription
        {
            get;
        }

        #endregion // 属性及其私有变量

    }


}