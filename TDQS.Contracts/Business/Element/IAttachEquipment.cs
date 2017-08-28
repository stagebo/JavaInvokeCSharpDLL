#region CLR版本 4.0.30319.239
// IAttachEquipment 接口
// 时间：2011-12-15 10:39:11
// 名称：IAttachEquipment
// 大纲：附属设备
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
    /// 附属设备
    /// </summary>
    public interface IAttachEquipment :IElement
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 与之相连的父级点设备
        /// </summary>
        INodeEquipment AttachedEquipment { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

