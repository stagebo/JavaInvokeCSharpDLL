#region CLR版本 4.0.30319.269
// ISavable 接口
// 时间：2012-5-18 13:27:03
// 名称：可存储接口
// 大纲：具有“存储”谓词特征的接口约束
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
    /// 可存储接口
    /// </summary>
    public interface ISavable
    {
        #region 方法
        void Save();
        #endregion // 方法

        #region 属性
        bool IsSaved
        {
            get;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

