#region CLR版本 4.0.30319.239
// ICoordinateOptions 接口
// 时间：2011/11/16 13:18:03
// 名称：坐标信息操作接口
// 大纲：
//
// 创建人：孙书涛
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
    /// 坐标信息操作接口
    /// </summary>
    public interface ICoordinateOptions
    {
        #region 方法

        /// <summary>
        /// 设置坐标信息
        /// </summary>
        /// <param name="coordinate">坐标</param>
        void SetCoordinate(string coordinate);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

