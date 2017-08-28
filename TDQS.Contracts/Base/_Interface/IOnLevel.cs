#region CLR版本 4.0.30319.225
// IOnLevel 接口
// 时间：2012-3-2 11:25:02
// 名称：层级对象
// 大纲：获知对象的层级信息
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
    /// 层级对象，获知对象的层级信息
    /// </summary>
    public interface IOnLevel
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取层级
        /// </summary>
        int Level { get; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 层级对象，获知对象的层级信息
    /// </summary>
    public interface IOnLevel<T>
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取层级
        /// </summary>
        T Level { get; }        

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

