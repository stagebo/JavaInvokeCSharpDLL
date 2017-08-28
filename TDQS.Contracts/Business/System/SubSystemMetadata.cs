#region CLR版本 4.0.30319.269
// SubSystemMetadata 类
// 时间：2012-5-17 10:14:10
// 名称：SubSystemMetadata
// 大纲：所有子系统对象的Metadata
//
// 创建人：王津
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有子系统对象的元数据类
    /// </summary>
    [MetadataAttribute]
    public class SubSystemMetadata : Attribute
    {
        #region 构造和析构
        #endregion // 构造和析构

        #region 公有方法
        /// <summary>
        /// ID: 子系统的ID值
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Name: 子系统的名称
        /// </summary>
        public string Name { get; set; }
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 所有SubSystemMetadata对象的View
    /// </summary>
    public interface ISubSystemMetadataView
    {
        /// <summary>
        /// ID: 子系统的ID值
        /// </summary>
        long ID { get; }


        /// <summary>
        /// Name: 子系统的名称
        /// </summary>
        string Name { get; }
    }
}