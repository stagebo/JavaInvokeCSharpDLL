#region CLR版本 4.0.30319.239
// IDataExchangeService 接口
// 时间：2011-11-10 14:04:17
// 名称：IDataExchangeService 接口
// 大纲：对象序列化服务
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 对象序列化服务
    /// </summary>
    public interface ISerializeService: IService
    {
        #region 方法
        /// <summary>
        /// 获得二进制操作者
        /// </summary>
        /// <returns>获得二进制序列化处理器</returns>
        ISerializeHandler GetBinaryHandler();

        /// <summary>
        /// 获得Json操作者
        /// </summary>
        /// <returns>获得Json序列化处理器</returns>
        ISerializeHandler GetJsonHandler();

        /// <summary>
        /// 获得Xml操作者
        /// </summary>
        /// <returns>获得Xml序列化处理器</returns>
        ISerializeHandler GetXmlHandler();
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 对象操作者
        /// </summary>
        ISerializeHandler ObjectSerializeHandler { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

