#region CLR版本 4.0.30319.239
// IDevice 接口
// 时间：2011-12-15 10:36:20
// 名称：IDevice
// 大纲：设施
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
    /// 设施元件
    /// </summary>
    public interface IDevice : IElement
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 该设施上包含的子元件
        /// </summary>
        IElementCollection ChildElements { get; set; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

