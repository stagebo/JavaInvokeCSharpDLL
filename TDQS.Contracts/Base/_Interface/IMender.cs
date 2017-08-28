#region CLR版本 4.0.30319.225
// IMender 接口
// 时间：2011-11-21 13:02:12
// 名称：修复者接口
// 大纲：限定对象的验证及修复行为
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS
{
    /// <summary>
    /// 修复者接口
    /// </summary>
    public interface IMender
    {
        #region 方法
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>是否合法</returns>
        bool Check(object data);
        /// <summary>
        /// 数据修复
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>合法数据</returns>
        object Mend(object data);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

