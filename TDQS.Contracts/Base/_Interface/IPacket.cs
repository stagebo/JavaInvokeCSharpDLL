#region CLR版本 4.0.30319.225
// IPacket 接口
// 时间：2011-11-21 9:58:19
// 名称：数据包及其泛型接口
// 大纲：限定对象以数据容器的形式出现
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
    /// 数据包接口
    /// </summary>
    public interface IPacket
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取内部数据
        /// </summary>
        object Data { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 数据包泛型接口
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public interface IPacket<T> : IPacket
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取内部数据
        /// </summary>
        new T Data { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

