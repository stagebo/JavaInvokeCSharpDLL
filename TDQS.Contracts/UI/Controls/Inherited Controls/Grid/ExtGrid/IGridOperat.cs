#region CLR版本 4.0.30319.225
// IGridOperat 接口
// 时间：2011-11-28 15:26:48
// 名称：IGridOperat 接口
// 大纲：表格操作接口
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 表格操作接口
    /// </summary>
    public interface IGridOperat
    {
        #region 方法
        /// <summary>
        /// 删除记录行
        /// </summary>
        void Delete();
        /// <summary>
        /// 添加新纪录
        /// </summary>
        void Add();
        /// <summary>
        /// 保存
        /// </summary>
        void Save();

        /// <summary>
        /// 保存状态 True:已经保存，False:没保存
        /// </summary>
        bool IsSave();
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

