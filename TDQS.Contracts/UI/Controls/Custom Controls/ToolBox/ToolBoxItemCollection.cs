#region CLR版本 4.0.30319.239
// ToolBoxItemCollection 类
// 时间：2011-11-28 10:37:39
// 名称：工具箱项目集合类
// 大纲：存储工具箱项目
//
// 创建人：夏禹
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TDQS.Contracts
{
    /// <summary>
    /// ToolBoxItemCollection 类
    /// </summary>
    public class ToolBoxItemCollection : KeyedCollection<string, IToolBoxItem>
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public ToolBoxItemCollection()
        {
            //
            
            //
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        /// <summary>
        /// 获取工具箱项目的KEY
        /// </summary>
        /// <param name="item">工具箱项目</param>
        /// <returns>工具箱项目的KEY</returns>
        protected override string GetKeyForItem(IToolBoxItem item)
        {
            return item.ID;
        }
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量
    }
}