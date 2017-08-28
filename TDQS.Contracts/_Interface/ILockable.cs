#region CLR版本 4.0.30319.269
// IOpenable 接口
// 时间：2012-7-17 10:58:51
// 名称：可打开的接口约束
// 大纲：
//
// 创建人：郭威
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
    /// 可打开的接口约束
    /// </summary>
    public interface ILockable
    {
        #region 方法
        #endregion // 方法

        #region 属性

        bool Locked
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

