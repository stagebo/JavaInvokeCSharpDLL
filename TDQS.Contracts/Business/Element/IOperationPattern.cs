#region CLR版本 4.0.30319.261
// IOperationPattern 接口
// 时间：2012/4/14 15:25:10
// 名称：操作模式类
// 大纲：架杆断线、去杆融线等元件操作模式的接口
//
// 创建人：王斌
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
    /// 操作模式类
    /// </summary>
    [Obsolete("李睿 2013-10-24 经王斌确认此接口标记为无效")]
    public interface IOperationPattern
    {
        #region 方法
        /// <summary>
        /// 正向操作
        /// </summary>
        /// <returns></returns>
        bool Operate();
        /// <summary>
        /// 反向操作
        /// </summary>
        /// <returns></returns>
        bool OppositeOperate();
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

