#region CLR版本 4.0.30319.239
// IThreeLineEquipment 接口
// 时间：2012-3-12 11:57:28
// 名称：IThreeLineEquipment
// 大纲：三支路设备
//
// 创建人：王津
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
    /// 三支路设备
    /// </summary>
    public interface IThreeTerminalEquipment :IBranchEquipment
    {
        #region 方法
        ///// <summary>
        ///// 建立关联关系作为线元件中点（双向）
        ///// </summary>
        ///// <param name="ele">关联元件</param>
        //void AssociateAsMiddle(IElement ele);
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 连接在该支路设备上的中间节点设备
        /// </summary>
        INodeEquipment MiddleNodeEquipment { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

