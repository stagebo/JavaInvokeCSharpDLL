#region CLR版本 4.0.30319.269
// IResource 接口
// 时间：2012-9-6 17:38:19
// 名称：资源模型接口
// 大纲：
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 资源模型接口
    /// </summary>
    public interface IResource
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 唯一性标识
        /// </summary>
        string ID
        {
            get;
            set;
        }

        /// <summary>
        /// 组织名称
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        string Description
        {
            get;
            set;
        }
        
        /// <summary>
        /// 父ID
        /// </summary>
        string ParentID
        {
            get;
            set;
        }

        /// <summary>
        /// 资源类型
        /// </summary>
        string Type
        {
            get;
            set;
        }

        /// <summary>
        /// 资源创建者
        /// </summary>
        string Creater
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

