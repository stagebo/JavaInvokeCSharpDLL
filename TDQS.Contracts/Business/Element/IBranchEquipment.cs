#region CLR版本 4.0.30319.239
// ILineEquipment 接口
// 时间：2011-12-15 10:31:41
// 名称：ILineEquipment
// 大纲：支路设备
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
    /// 支路设备
    /// </summary>
    public interface IBranchEquipment :IElement
    {
        #region 方法

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 连接在该支路设备上的起始节点设备
        /// </summary>
        INodeEquipment StartNodeEquipment 
        { 
            get;
            set; 
        }

        /// <summary>
        /// 连接在该支路设备上的结束节点设备
        /// </summary>
        INodeEquipment EndNodeEquipment 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 具有点形态的支路设备 （典型如开关、变压器）
        /// </summary>
        bool IsPointShape
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

