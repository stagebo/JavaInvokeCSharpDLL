#region CLR版本 4.0.30319.239
// INotify 接口
// 时间：2011-11-29 11:01:11
// 名称：INotify
// 大纲：Notify通知/监视模式。通过通知动作执行操作，通过事件监视了解动作并进行下一步操作。
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
    /// Notify通知/监视模式接口。通过通知动作执行操作，通过事件监视了解动作并进行下一步操作。
    /// </summary>
    public interface INotify
    {
        #region 方法
        /// <summary>
        /// 通知方法
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="Action">动作</param>
        void Notify(Object obj, NotifyAction Action);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        /// <summary>
        /// 监视事件
        /// </summary>
        event MonitorEventHandler Monitor;
        #endregion // 事件
    }

    /// <summary>
    /// 事件参数
    /// </summary>
    public class NotifyEventArgs : EventArgs
    {
        /// <summary>
        /// 通知动作类型
        /// </summary>
        public NotifyAction NotifyAction
        {
            get
            {
                return m_NotifyAction;
            }
            set
            {
                m_NotifyAction = value;
            }
        }
        private NotifyAction m_NotifyAction;
    }

    /// <summary>
    /// 通知枚举
    /// </summary>
    public enum NotifyAction : byte
    {
        /// <summary>
        /// 增加
        /// </summary>
        Added = 0,
        /// <summary>
        /// 删除
        /// </summary>
        Deleting = 1,
        /// <summary>
        /// 更新
        /// </summary>
        Updated = 2,
        /// <summary>
        /// 保存
        /// </summary>
        Saved = 3
    }
    /// <summary>
    /// 监视器事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MonitorEventHandler(Object sender, NotifyEventArgs e);

}

