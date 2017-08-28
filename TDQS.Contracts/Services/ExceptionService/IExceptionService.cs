#region CLR版本 4.0.30319.239
// IExceptionService 接口
// 时间：2011/11/16 10:43:52
// 名称：异常服务
// 大纲：提供对应的异常操作服务
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 提供对应的异常操作服务
    /// </summary>
    public interface IExceptionService:IService
    {
        #region 方法
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>对话框处理结果</returns>
        DialogResult ProcessExeception(Exception ex, string strExHanlderName, MsgBoxButtons buttons);
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="errorString">友好提示信息</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>对话框处理结果></returns>
        DialogResult ProcessByErrorString(Exception ex, string strExHanlderName, string errorString, MsgBoxButtons buttons);
        /// <summary>
        /// 调用指定的异常处理器，进行异常处理
        /// </summary>
        /// <param name="ex">原始异常</param>
        /// <param name="strExHanlderName">异常策略</param>
        /// <param name="errorCode">友好提示异常编码</param>
        /// <param name="buttons">消息提示框按钮组合</param>
        /// <returns>对话框处理结果</returns>
        DialogResult ProcessByErrorCode(Exception ex, string strExHanlderName, string errorCode, MsgBoxButtons buttons);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

