#region CLR版本 4.0.30319.17379
// IParameterModel 接口
// 时间：2012/4/19 16:02:11
// 名称：IParameterModel
// 大纲：参数对象模型接口
//
// 创建人：孙书涛
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 参数对象模型接口
    /// </summary>
    public interface IParameterModel
    {
        #region 方法
        
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 参数名称
        /// </summary>
        string ParameterName
        {
            get;
            set;
        }

        /// <summary>
        /// 刷新标志
        /// </summary>
        bool Refresh
        {
            get;
            set;
        }

        /// <summary>
        /// 参数数据
        /// </summary>
        DataTable ParameterData
        {
            get;
            set;
        }

        /// <summary>
        /// 命令
        /// </summary>
        string Command
        {
            get;
            set;
        }
        /// <summary>
        /// 参数表ID
        /// 包括系统级_0000_000000000000000000000000和工程级
        /// </summary>
        string ParameterID
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

