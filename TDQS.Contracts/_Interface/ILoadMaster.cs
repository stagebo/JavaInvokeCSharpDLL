#region CLR版本 4.0.30319.269
// ILoadMaster 接口
// 时间：2012-7-27 15:13:54
// 名称：装卸工接口约束
// 大纲：限定装卸动作的显式实现
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

namespace TDQS.Contracts
{
    /// <summary>
    /// 装卸工接口约束，限定装卸动作的显式实现
    /// </summary>
    public interface ILoadMaster
    {
        #region 方法

        /// <summary>
        /// 装载单位数据
        /// </summary>
        /// <param name="data">数据</param>
        void Load(object data);
        /// <summary>
        /// 卸载单位数据
        /// </summary>
        /// <param name="data">数据</param>
        void Unload(object data);
        /// <summary>
        /// 卸载所有数据
        /// </summary>
        void Unload();

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 装卸工接口约束，限定装卸动作的显式实现
    /// </summary>
    public interface ILoadMaster<T>
    {
        #region 方法

        /// <summary>
        /// 装载单位数据
        /// </summary>
        /// <param name="data">数据</param>
        void Load(T data);
        /// <summary>
        /// 卸载单位数据
        /// </summary>
        /// <param name="data">数据</param>
        void Unload(T data);
        /// <summary>
        /// 卸载所有数据
        /// </summary>
        void Unload();

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

