#region CLR版本 4.0.30319.225
// IXmlProvider 接口
// 时间：2011-11-16 10:29:39
// 名称：配置数据供应者
// 大纲：
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
using System.Xml;

namespace TDQS.Contracts
{
    /// <summary>
    /// 配置数据供应者接口
    /// </summary>
    public interface IConfigProvider
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取通过索引值所能找到的数据
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>数据</returns>
        object this[object index]
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

