#region CLR版本 4.0.30319.225
// IChainNode 接口
// 时间：2012-2-6 16:43:20
// 名称：单向节点接口
// 大纲：提供单向节点对象
//
// 创建人：郭威
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
namespace TDQS
{
    /// <summary>
    /// 单向节点接口
    /// </summary>
    public interface IChainNode
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 下一个节点
        /// </summary>
        IChainNode Next { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 单向节点接口
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    public interface IChainNode<T> : IChainNode
        where T : IChainNode
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 下一个节点
        /// </summary>
        T Next { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}
