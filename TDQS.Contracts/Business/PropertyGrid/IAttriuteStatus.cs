#region CLR版本 4.0.30319.17379
// IAttriuteStatus 接口
// 时间：2012/4/24 15:41:28
// 名称：IAttriuteStatus
// 大纲：属性状态
//
// 创建人：孙书涛
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
    /// 属性状态
    /// </summary>
    public interface IAttriuteStatus
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 是否显示所有属性
        /// </summary>
        bool ShowAllAttribute
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可用所有属性
        /// </summary>
        ReadOnlyStatus ReadOnlyAllAttribute
        {
            get;
            set;
        }
        /// <summary>
        /// 是否显示更多属性
        /// </summary>
        bool ShowMoreAttribute
        {
            get;
            set;
        }

        /// <summary>
        /// 说明表
        /// </summary>
        IExplanationTable ExplanationTable
        {
            get;
        }

        /// <summary>
        /// 显示分组过滤  王津 2013-9-6
        /// </summary>
        int ShowGroupFilterIndex
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

