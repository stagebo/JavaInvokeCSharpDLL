#region CLR版本 4.0.30319.225
// IXmlHandler 接口
// 时间：2011-11-16 10:12:33
// 名称：配置操作者
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
    /// 配置操作者接口
    /// </summary>
    public interface IConfigHandler
    {
        #region 方法

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="data">数据</param>
        /// <returns>是否保存成功</returns>
        bool Save(object index, object data);

        /// <summary>
        /// 数据出库
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>数据</returns>
        object Out(object index);

        /// <summary>
        /// 从物理源获取数据集
        /// </summary>
        /// <param name="source">物理源</param>
        void ReadFrom(object source);

        /// <summary>
        /// 将数据集写入物理载体
        /// </summary>
        /// <param name="carrier">载体</param>
        void WriteTo(object carrier);

        /// <summary>
        /// 清理数据集
        /// </summary>
        void Clear();

        #endregion // 方法

        #region 属性
        /// <summary>
        /// XmlDocument对象
        /// </summary>
        XmlDocument Document { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

