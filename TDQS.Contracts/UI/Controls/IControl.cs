#region CLR版本 4.0.30319.239
// IControl 接口
// 时间：2011-11-10 14:04:17
// 名称：IControl 
// 大纲：所有控件必须实现的接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有控件必须实现的接口
    /// </summary>
    public interface IControl
    {
        #region 方法
        void ResourceChanged();
        #endregion // 方法

        #region 属性
        string       mPrpResourceName { get; set; }
        ResourceMode mPrpResourceMode { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

