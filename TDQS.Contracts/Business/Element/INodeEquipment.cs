#region CLR版本 4.0.30319.239
// INodeEquipment 接口
// 时间：2011-12-15 10:28:32
// 名称：INodeEquipment
// 大纲：节点设备
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
    /// 节点设备
    /// </summary>
    public interface INodeEquipment :IElement
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 节点设备上所有连接的设备集合(支路、附属设备)
        /// </summary>
        IElementCollection Elements 
        { 
            get; 
            set; 
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

