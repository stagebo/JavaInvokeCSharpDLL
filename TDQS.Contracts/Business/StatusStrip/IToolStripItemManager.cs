#region CLR版本 4.0.30319.239
// ITaskMonitor 接口
// 时间：2011-9-20 16:17:46
// 名称：状态栏操作项管理接口
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
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 状态栏操作项管理接口
    /// </summary>
    public interface IToolStripItemManager
    {
        #region 方法

        /// <summary>
        /// 增加一个状态栏功能项
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        void AddAdditionalItem(ToolStripItem item, int index = -1);
        
        /// <summary>
        /// 移除指定索引的功能项
        /// </summary>
        /// <param name="index"></param>
        void RemoveAdditionalItem(int index = -1);

        /// <summary>
        ///  根据名称获得状态栏功能项
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        ToolStripItem GetItemByName(string itemName);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}