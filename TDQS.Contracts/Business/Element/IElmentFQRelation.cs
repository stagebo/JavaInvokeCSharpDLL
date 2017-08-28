#region CLR版本 4.0.30319.239
// IElmentFQRelation 接口
// 时间：2012/11/21 10:15:51
// 名称：
// 大纲：
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
    /// 分区关系
    /// </summary>
    public interface IElmentFQRelation
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 分区ID
        /// </summary>
        string f_fqid { get; set; }

        /// <summary>
        /// 是否手动分区
        /// </summary>
        short f_shfshdfq { get; set; }

        /// <summary>
        /// 工程ID
        /// </summary>
        string f_subgchid { get; set; }

        /// <summary>
        /// 元件ID
        /// </summary>
        string f_yjid { get; set; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

