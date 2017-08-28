#region CLR版本 4.0.30319.239
// IUndoRedo 接口
// 时间：2011-12-6 17:09:12
// 名称：IUndoRedo
// 大纲：UndoRedo 操作Command堆栈，执行撤销重做
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// UndoRedo接口。 操作Command堆栈，执行撤销重做。
    /// </summary>
    public interface IUndoRedo
    {
        #region 方法
        /// <summary>
        /// 清空堆栈
        /// </summary>
        void Clear();

        /// <summary>
        /// 压入一条命令
        /// </summary>
        /// <param name="cmd"></param>
        bool Push(ICommand cmd);

        /// <summary>
        /// 移除一条命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        void Remove(ICommand cmd);
        
        /// <summary>
        /// 重做
        /// </summary>
        /// <returns>命令项</returns>
        ICommand Redo();

        /// <summary>
        /// 撤销
        /// </summary>
        /// <returns>命令项</returns>
        ICommand Undo();

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 是否能重做
        /// </summary>
        bool CanRedo
        {
            get;
        }

        /// <summary>
        /// 是否能撤销
        /// </summary>
        bool CanUndo
        {
            get;
        }

        /// <summary>
        /// 当前指向的命令,就绪被激发的命令
        /// </summary>
        ICommand CurrentCommand
        {
            get;
        }

        /// <summary>
        /// 正在执行的命令
        /// </summary>
        ICommand ExecutingCommand
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
        /// 执行命令
        /// </summary>
        event EventHandler<CommandEventArgs> CommandDone;

        /// <summary>
        /// 重做命令
        /// </summary>
        event EventHandler<CommandEventArgs> CommandRedone;

        /// <summary>
        /// 撤销命令
        /// </summary>
        event EventHandler<CommandEventArgs> CommandUndone;

        /// <summary>
        /// 状态改变事件
        /// </summary>
        event EventHandler StateChanged;

        #endregion // 事件
    }
}

