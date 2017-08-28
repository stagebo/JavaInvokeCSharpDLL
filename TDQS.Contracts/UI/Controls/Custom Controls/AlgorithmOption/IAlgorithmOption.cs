#region CLR版本 4.0.30319.239
// IAlgorithmOption 接口
// 时间：2012/4/16 18:29:48
// 名称：IAlgorithmOption
// 大纲：算法设置
//
// 创建人：聂桂春
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 算法设置接口
    /// </summary>
    public interface IAlgorithmOption
    {
        #region 方法

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 算法设置菜单
        /// </summary>
        System.Windows.Forms.ToolStripDropDownButton OptionButton { get; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

}

