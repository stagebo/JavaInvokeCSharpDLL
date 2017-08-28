#region CLR版本 4.0.30319.239
// IDataExchangeHandler 接口
// 时间：2011-11-10 14:04:17
// 名称：IDataExchangeHandler 接口
// 大纲：对象序列化服务 处理器接口
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2012.9.6 王津        增加支持数据库等其他方式需要的流
#endregion
using System;
using System.IO;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 对象序列化服务 处理器接口
    /// </summary>
    public interface ISerializeHandler
    {
        #region 方法
        /// <summary>
        /// 根据文件反序列化成对象
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="type">对象类型</param>
        /// <returns>对象</returns>
        object Load(string filePath, System.Type type);
        /// <summary>
        /// 根据文件反序列化成对象
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象其他类型数据</param>
        /// <returns>对象</returns>
        object Load(string filePath, System.Type type, System.Type[] types);
        /// <summary>
        /// 将对象序列化到文件中
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        void Save(string filePath, object obj, System.Type type);
        /// <summary>
        /// 将对象序列化到文件中
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象类型数组</param>
        void Save(string filePath, object obj, System.Type type, System.Type[] types);

        /// <summary>
        /// 根据流反序列化成对象
        /// </summary>
        /// <param name="textReader">文本读取器</param>
        /// <param name="type">对象类型</param>
        /// <returns>对象</returns>
        object Load(TextReader textReader, System.Type type);
        /// <summary>
        /// 根据流反序列化成对象
        /// </summary>
        /// <param name="textReader">文本读取器</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象类型数组</param>
        /// <returns>对象</returns>
        object Load(TextReader textReader, System.Type type, System.Type[] types);
        /// <summary>
        /// 将对象序列化到流中
        /// </summary>
        /// <param name="textWriter">文本编辑器</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        void Save(TextWriter textWriter, object obj, System.Type type);
        /// <summary>
        /// 将对象序列化到流中
        /// </summary>
        /// <param name="textWriter">文本编辑器</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象类型数组</param>
        void Save(TextWriter textWriter, object obj, System.Type type, System.Type[] types);


        /// <summary>
        /// 根据流反序列化成对象
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        /// <returns>对象</returns>
        object Load(Stream stream, System.Type type);
        /// <summary>
        /// 根据流反序列化成对象
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象类型数组</param>
        /// <returns>对象</returns>
        object Load(Stream stream, System.Type type, System.Type[] types);
        /// <summary>
        /// 将对象序列化到流中
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        void Save(Stream stream, object obj, System.Type type);
        /// <summary>
        /// 将对象序列化到流中
        /// </summary>
        /// <param name="stream">流</param>
        /// <param name="obj">对象</param>
        /// <param name="type">对象类型</param>
        /// <param name="types">对象类型数组</param>
        void Save(Stream stream, object obj, System.Type type, System.Type[] types);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

