#region CLR版本 4.0.30319.239
// IDockWindow 接口
// 时间：2011-12-6 9:34:26
// 名称：IDockWindow
// 大纲：停泊窗
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
using System.Windows.Forms;
using WinFormsUI.Docking;

namespace TDQS.Contracts
{
    /// <summary>
    /// 停泊窗接口
    /// </summary>
    public interface IDockWindow
    {
        #region 方法

        /// <summary>
        /// 激活停泊窗
        /// </summary>
        void Activate();

        #endregion // 方法

        #region 属性

        /// <summary>
        /// Dock实例
        /// </summary>
        DockContent Instance
        {
            get;
        }

        /// <summary>
        /// 资源名称
        /// </summary>
        string PrpResourceName
        {
            get;
            set;
        }

        /// <summary>
        /// 资源模式
        /// </summary>
        ResourceMode PrpResourceMode
        {
            get;
            set;
        }

        /// <summary>
        /// 停泊窗是否激活
        /// </summary>
        bool IsActivated
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

