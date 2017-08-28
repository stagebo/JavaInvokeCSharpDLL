#region CLR版本 4.0.30319.296
// IBackUpSchedulingScheme 接口
// 时间：2013/6/7 14:32:38
// 名称：自动备份电网方案借口
// 大纲：
//
// 创建人：张增平
// 版权：Copyright (C) 2013 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 自动备份电网方案借口
    /// </summary>
    public interface IBackUpSchedulingScheme
    {
        #region 方法
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件

        /// <summary>
        /// 执行一次备份的时间
        /// </summary>
        event EventHandler IndeedExcute;

        /// <summary>
        /// 执行一次假备份的时间
        /// </summary>
        event EventHandler UnIndeedExcute;

        /// <summary>
        /// 激活
        /// </summary>
        void Active();

        /// <summary>
        /// 解约
        /// </summary>
        void UnActive();

        #endregion // 事件
    }
}

