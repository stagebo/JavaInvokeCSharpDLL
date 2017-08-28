#region CLR版本 4.0.30319.239
// IVisionMng 接口
// 时间：2011/12/7 15:58:12
// 名称：在MEF中使用的视野管理接口
// 大纲：
//
// 创建人：孙书涛
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		       修改人		描述
//20120117     孙书涛        增加对
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// MEF视野接口
    /// </summary>
    public interface IVisionMng
    {
        #region 方法
        /// <summary>
        /// 返回ToolStripItem
        /// </summary>
        /// <returns></returns>
        ToolStripItem GetToolStripItem();

        /// <summary>
        /// 点击功能按钮方法
        /// </summary>
        void OnButtonClick();
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 标志位
        /// </summary>
        bool Flag
        {
            get;
            set;
        }
        #endregion // 属性

        #region 事件
        /// <summary>
        /// 点击按钮事件
        /// </summary>
        event MouseEventHandler RightButtonClick;
        #endregion // 事件
    }
}

