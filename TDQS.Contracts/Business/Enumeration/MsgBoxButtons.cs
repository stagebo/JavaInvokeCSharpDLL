#region CLR版本 4.0.30319.239
// MessageBoxButtons 类
// 时间：2011-11-9 17:54:55
// 名称：MessageBoxButtons
// 大纲：消息提示框按钮组合
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 消息提示框按钮组合
    /// </summary>
    public enum MsgBoxButtons : byte
    {
        /// <summary>
        /// “确定”
        /// </summary>
        OK = 1,
        /// <summary>
        /// “确定”和“取消”
        /// </summary>
        OKCancel = 2,
        /// <summary>
        /// “是”、“否”和“取消”
        /// </summary>
        YesNoCancel = 3,
        /// <summary>
        /// “是”和“否”
        /// </summary>
        YesNo = 4,
        /// <summary>
        /// “中止”、“重试”和“忽略”
        /// </summary>
        AbortRetryIgnore = 5,
        /// <summary>
        /// “重试”和“取消”
        /// </summary>
        RetryCancel = 6,
        /// <summary>
        /// “继续”和“退出”
        /// </summary>
        ContinueQuit = 7
    }
}