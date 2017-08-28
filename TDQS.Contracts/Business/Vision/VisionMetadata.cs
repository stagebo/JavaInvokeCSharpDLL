#region CLR版本 4.0.30319.239
// VisionMetadata 接口
// 时间：2011/12/7 16:11:09
// 名称：视野管理元数据
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
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 视野管理元数据
    /// </summary>
    [MetadataAttribute]
    public class VisionMetadata : Attribute
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 工具id
        /// </summary>
        public long ID
        {
            get;
            set;
        }

        /// <summary>
        /// 工具名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 视野元类型
    /// </summary>
    public interface IVisionMetadata
    {
        /// <summary>
        /// 编号
        /// </summary>
        long ID { get; }
        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; }
    }
}

