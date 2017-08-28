#region CLR版本 4.0.30319.269
// ICollector 接口
// 时间：2012-7-26 9:49:36
// 名称：收集器接口约束
// 大纲：
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

namespace TDQS.Collections.Generic
{
    /// <summary>
    /// 收集器接口约束
    /// </summary>
    public interface ICollector<T>
    {
        #region 方法

        /// <summary>
        /// 按条件进行收集
        /// </summary>
        /// <param name="predicate">条件</param>
        void Collect(System.Predicate<T> predicate);

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 收集
        /// </summary>
        System.Collections.Generic.IEnumerable<T> Collection { get; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

