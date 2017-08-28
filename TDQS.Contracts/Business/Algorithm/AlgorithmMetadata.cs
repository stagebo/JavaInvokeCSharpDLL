#region CLR版本 4.0.30319.239
// TopoMetadata 类
// 时间：2012/4/16 20:56:16
// 名称：算法设置属性类
// 大纲：
//
// 创建人：聂桂春
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 算法设置属性类
    /// </summary>
    [MetadataAttribute]
    public class AlgorithmMetadata : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public AlgorithmMetadata()
        {
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 工具名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 算法属性接口
    /// </summary>
    public interface IAlgorithmMetadata
    {
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
    }
}