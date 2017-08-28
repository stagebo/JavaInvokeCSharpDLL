#region CLR版本 4.0.30319.239
// ICommand 接口
// 时间：2011-11-10 14:04:17
// 名称：ICommand 
// 大纲：所有业务命令的接口
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
    /// 所有业务命令的接口
    /// </summary>
    public interface ICommand
    {
        #region 方法
        /// <summary>
        /// 执行命令，自动压undoredo栈运行
        /// </summary>
        /// <returns></returns>
        bool Do();

        /// <summary>
        /// 撤销。自undoredo栈运行。 
        /// </summary>
        /// <returns>撤销是否成功</returns>
        ICommand Undo();

        /// <summary>
        /// 重做。自undoredo栈运行。 
        /// </summary>
        /// <returns>重做是否成功</returns>
        ICommand Redo();

        /// <summary>
        /// 执行命令,不压栈执行。
        /// </summary>
        /// <returns></returns>
        bool Execute();

        /// <summary>
        /// 反执行命令,不压栈执行。
        /// </summary>
        /// <returns></returns>
        bool UnExecute();

        /// <summary>
        /// 重复执行命令
        /// </summary>
        /// <returns></returns>
        bool ReExecute();
            

        #endregion // 方法

        #region 属性
   
        /// <summary>
        /// 获取命令名
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 获取命令执行的错误信息
        /// </summary>
        string ErrorMessage
        {
            get;
        }

        #endregion // 属性

        #region 事件

        /// <summary>
        /// 命令执行前发生
        /// </summary>
        event CommandExecutingEventHandler CommandExecuting;

        /// <summary>
        /// 命令执行后发生
        /// </summary>
        event EventHandler CommandExecuted;

        /// <summary>
        /// 撤销前发生
        /// </summary>
        event CommandExecutingEventHandler CommandUnExecuting;

        /// <summary>
        /// 撤销后发生
        /// </summary>
        event EventHandler CommandUnExecuted;

        /// <summary>
        /// 重做前发生
        /// </summary>
        event CommandExecutingEventHandler CommandReExecuting;

        /// <summary>
        /// 重做后发生
        /// </summary>
        event EventHandler CommandReExecuted;

        #endregion // 事件
    }


    /// <summary>
    /// 命令事件参数
    /// </summary>
    public class CommandExecutingEventArgs : EventArgs
    {
        /// <summary>
        /// 是否取消当前命令的执行
        /// </summary>
        public bool Cancel
        {
            get
            {
                return m_bCancel;
            }
            set
            {
                m_bCancel = value;
            }
        }
        private bool m_bCancel;
    }

    /// <summary>
    /// 命令中的事件处理器
    /// </summary>
    /// <param name="sender">命令本身</param>
    /// <param name="e">命令参数</param>
    public delegate void CommandExecutingEventHandler(ICommand sender, CommandExecutingEventArgs e);

    /// <summary>
    /// 命令管理器事件参数  接口
    /// </summary>
    public class CommandEventArgs : EventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cmd"></param>
        public CommandEventArgs(ICommand cmd)
        {
            this.m_cmd = cmd;
        }

        #region 属性
        /// <summary>
        /// 命令
        /// </summary>
        public ICommand Command
        {
            get
            {
                return this.m_cmd;
            }
        }
        private ICommand m_cmd;

        #endregion //属性
    }
}

