#region CLR版本 4.0.30319.239
// ITaskMonitor 接口
// 时间：2011-4-28 17:11:00
// 名称：任务监视器接口
// 大纲：进度条信息相关的任务监视器接口,通过实现任务监视器接口,来展现任务的进度信息
//
// 创建人：王斌 （移植整理）
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 20110926 孙书涛  1）将toolstripitem相关操作方法移除，放在IToolStripItemManager接口中
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 进度条信息相关的任务监视器接口,通过实现任务监视器接口,来展现任务的进度信息。
    /// </summary>
    public interface ITaskMonitor
    {
        #region 方法
        

        /// <summary>
        /// 通过状态服务通知用户一个任务的开始
        /// </summary>
        /// <param name="sTaskName">任务名</param>
        /// <param name="TotalTaskStep">任务总进度</param>
        void StartTask(string sTaskName, int TotalTaskStep);

        /// <summary>
        /// 通过状态服务通知用户一个任务的开始
        /// 说明：该方法适用于任务总进度未知的情况
        /// </summary>
        /// <param name="sTaskName">任务名</param>
        void StartTask(string sTaskName);

        /// <summary>
        /// 设置当前任务名
        /// </summary>
        /// <param name="sTaskName">任务名</param>
        void UpdateTask(string sTaskName);

        /// <summary>
        /// 设置当前的任务进度+1
        /// </summary>
        void UpdateTask();
        /// <summary>
        /// 设置当前的任务进度
        /// 说明：任务进度不能超过 任务总进度
        /// </summary>
        /// <param name="TaskStep">任务进度</param>
        void UpdateTask(int TaskStep);

        /// <summary>
        /// 设置当前的任务进度
        /// 说明：任务进度不能超过 任务总进度
        /// </summary>
        /// <param name="sTaskName">任务名</param>
        /// <param name="TaskStep">任务进度</param>
        void UpdateTask(string sTaskName, int TaskStep);

        /// <summary>
        /// 任务完成，任务进度到达总进度
        /// </summary>
        void TaskDone();

        /// <summary>
        /// 取消任务
        /// </summary>
        void CancelTask();

       
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件

        #region 原IXStatusListener成员
        #region 方法

        /// <summary>
        /// 清除当前状态监听的所有输出
        /// </summary>
        void Clear();

        /// <summary>
        /// StatusService(状态服务) 设置当前状态为 “就绪” 状态
        /// </summary>
        void Ready();

        /// <summary>
        /// StatusService(状态服务) 输出一条消息到状态监听器中
        /// </summary>
        /// <param name="sMessage">消息</param>
        void Message(string sMessage);

        /// <summary>
        /// StatusService(状态服务) 输出一条消息到状态监听器中
        /// </summary>
        /// <param name="sName">消息名称</param>
        /// <param name="sMessage">消息</param>
        void Message(string sName, string sMessage);

        /// <summary>
        /// StatusService(状态服务) 输出一条警告到状态监听器中
        /// </summary>
        /// <param name="sMessage">警告</param>
        void Warn(string sMessage);

        /// <summary>
        /// StatusService(状态服务) 输出一条警告到状态监听器中
        /// </summary>
        /// <param name="sName">警告名称</param>
        /// <param name="sMessage">警告</param>
        void Warn(string sName, string sMessage);

        /// <summary>
        /// StatusService(状态服务) 输出一条错误到状态监听器中
        /// </summary>
        /// <param name="sMessage">错误</param>
        void Error(string sMessage);

        /// <summary>
        /// StatusService(状态服务) 输出一条错误到状态监听器中
        /// </summary>
        /// <param name="sName">错误名称</param>
        /// <param name="sMessage">错误</param>
        void Error(string sName, string sMessage);

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 消息名称
        /// </summary>
        string NameString
        {
            get;
        }

        /// <summary>
        /// 消息
        /// </summary>
        string MessageString
        {
            get;
        }

        #endregion
        #endregion
    }
}