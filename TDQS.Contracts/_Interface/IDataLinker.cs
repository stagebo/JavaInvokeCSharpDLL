#region CLR版本 4.0.30319.225
// ILinker 接口
// 时间：2012-3-22 16:35:16
// 名称：连接器接口
// 大纲：作为被触发操作的数据通道
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Data;


namespace TDQS.Contracts
{
    /// <summary>
    /// 连接器接口，作为被触发操作的数据通道
    /// </summary>
    public interface IDataLinker : ITextual
    {
        #region 方法

        /// <summary>
        /// 通过数据库通道获取数据视图
        /// 2012-12-1 11:17:33, 王东云       直接返回DataTable 省去转换环节 提高效率
        /// </summary>
        /// <param name="database">数据库通道</param>
        /// <returns>数据</returns>
        DataTable GetDataTable(IDatabase database);

        /// <summary>
        /// 获取解释表与数据表对
        /// </summary>
        /// <param name="database">数据库通道</param>
        /// <returns>数据对</returns>
        KeyValuePair<IExplanationTable, DataTable> GetDataPair(IDatabase database);

        /// <summary>
        /// 扩展列信息
        /// </summary>
        /// <param name="columns"></param>
        void ExpandColnumInfo(IDictionary<string, ITdqsGridColumn> columns);


        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取秩序标示
        /// </summary>
        int Order { get; }

        /// <summary>
        /// 获取所属目录
        /// </summary>
        string Catalog { get; }

        /// <summary>
        /// 获取显示状态
        /// </summary>
        bool Visible { get; }

        /// <summary>
        /// 应用场所
        /// </summary>
        int Site { get; }

        /// <summary>
        /// 合并列
        /// </summary>
        string combineCol { get; }

        /// <summary>
        /// 设置宽度
        /// </summary>
        Dictionary<string, int> FieldWidths { get; }
        
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 数据连接器元数据类
    /// </summary>
    [MetadataAttribute]
    public class DataLinkerMetadata : Attribute
    {
        /// <summary>
        /// 获取秩序标示
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 获取显示文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 获取所属目录
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// 获取显示状态
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// 应用场所
        /// </summary>
        public int Site { get; set; }

        /// <summary>
        /// 合并列
        /// </summary>
        public string combineCol { get; set; }
    }

    /// <summary>
    /// 数据连接器元数据View
    /// </summary>
    public interface IDataLinkerMetadataView
    {
        /// <summary>
        /// 获取秩序标示
        /// </summary>
        int Order { get; }
        /// <summary>
        /// 获取显示文本
        /// </summary>
        string Text { get;}
        /// <summary>
        /// 获取所属目录
        /// </summary>
        string Catalog { get; }
        /// <summary>
        /// 获取显示状态
        /// </summary>
        bool Visible { get; }
        /// <summary>
        /// 应用场所
        /// </summary>
        int Site { get; }
        /// <summary>
        /// 合并列
        /// </summary>
        string combineCol { get; }
    }
}

