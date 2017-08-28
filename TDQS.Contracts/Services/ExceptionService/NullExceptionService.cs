#region CLR版本 4.0.30319.239
// NullExceptionService 类
// 时间：2011/9/16 11:51:57
// 名称：NullExceptionService
// 大纲：NullObject模式，当不存在任何ExceptionService 时，建立空对象，以保证不出现异常。
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
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// NullObject模式，当不存在任何ExceptionService 时，建立空对象，以保证不出现异常。
    /// </summary>
    public class NullExceptionService:IExceptionService
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public NullExceptionService()
        {
            //
            
            //
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 单例模式，返回空处理类型异常服务
        /// </summary>
        static readonly NullExceptionService instance = new NullExceptionService();

        /// <summary>
        /// 单例模式，返回空处理类型异常服务
        /// </summary>
        public static NullExceptionService Instance
        {
            get { return instance; }
        }
        #endregion // 属性及其私有变量


        #region IExceptionService 成员
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>DialogResult（对话框返回结果）</returns>
        public DialogResult ProcessExeception(Exception ex, string strExHanlderName, MsgBoxButtons buttons)
        {
            return DialogResult.None;
        }
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="errorString">友好提示信息</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>DialogResult（对话框返回结果）</returns>
        public DialogResult ProcessByErrorString(Exception ex, string strExHanlderName, string errorString, MsgBoxButtons buttons)
        {
            return DialogResult.None;
        }
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="errorCode">友好提示异常编码</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>DialogResult（对话框返回结果）</returns>
        public DialogResult ProcessByErrorCode(Exception ex, string strExHanlderName, string errorCode, MsgBoxButtons buttons)
        {
            return DialogResult.None;
        }

        #endregion

        #region IService 成员
        /// <summary>
        /// 激活
        /// </summary>
        /// <returns>是否</returns>
        public bool Active()
        {
            return false;
        }
        /// <summary>
        /// 开启
        /// </summary>
        public void Start()
        {
            
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void Pause()
        {
            
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            
        }

        /// <summary>
        /// 是否必选
        /// </summary>
        /// <returns>是否</returns>
        public bool Required()
        {
            return true;
        }
        #endregion

    
    }
}