#region CLR版本 4.0.30319.269
// OnlineStateAttribute 类
// 时间：2012-11-7 14:32:21
// 名称：在线状态特性
// 大纲：
//
// 创建人：郭威
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

namespace TDQS.Net
{
    /// <summary>
    /// 在线状态特性
    /// </summary>
    public class OnlineStateAttribute : Attribute
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public OnlineStateAttribute(bool online)
            : base()
        {
            m_online = online;
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
        /// 获取在线状态
        /// </summary>
        public bool Online
        {
            get            
            {
                return m_online;
            }
        }

        /// <summary>
        /// 在线状态
        /// </summary>
        private bool m_online;

        #endregion // 属性及其私有变量

    }
}