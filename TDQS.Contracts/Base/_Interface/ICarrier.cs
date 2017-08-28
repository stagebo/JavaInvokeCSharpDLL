#region CLR版本 4.0.30319.269
// ICarrier 接口
// 时间：2012-7-26 9:45:51
// 名称：载体接口约束
// 大纲：限定对象导入、导出动作的显式实现
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

namespace TDQS
{
    /// <summary>
    /// 载体接口约束，限定对象导入、导出动作的显式实现
    /// </summary>
    public interface ICarrier
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="data">数据</param>
        void Import(object data);
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        object Export();

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 载体接口约束，限定对象导入、导出动作的显式实现
    /// </summary>    
    public interface ICarrier<T>
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="data">数据</param>
        void Import(T data);
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <returns></returns>
        T Export();

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

