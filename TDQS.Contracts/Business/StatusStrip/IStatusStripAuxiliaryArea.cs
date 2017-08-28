#region CLR版本 4.0.30319.239
// IStatusStripAuxiliaryArea 接口
// 时间：2011/11/17 10:04:57
// 名称：状态栏辅助功能区功能接口
// 大纲：
//
// 创建人：孙书涛
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 状态栏辅助功能区功能接口
    /// </summary>
    public interface IStatusStripAuxiliaryArea
    {
        #region 方法
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        /// <summary>
        /// 捕捉按钮鼠标点击事件
        /// </summary>
        event EventHandler CatchButtonClick;
        /// <summary>
        /// 正交按钮鼠标点击事件
        /// </summary>
        event EventHandler CrossButtonClick;
        /// <summary>
        /// 正交接线按钮鼠标点击事件
        /// </summary>
        event EventHandler CrossLineButtonClick;
        /// <summary>
        /// 极轴按钮鼠标点击事件
        /// </summary>
        event EventHandler PolarAxisButtonClick;
        /// <summary>
        /// 锁按钮鼠标点击事件
        /// </summary>
        event EventHandler LockButtonClick;
        /// <summary>
        /// 全屏按钮鼠标点击事件
        /// </summary>
        event EventHandler FullScreenButtonClick;
        /// <summary>
        /// 设置按钮鼠标点击事件
        /// </summary>
        event EventHandler ContextMenuItemClick;

        #endregion // 事件
    }
}

