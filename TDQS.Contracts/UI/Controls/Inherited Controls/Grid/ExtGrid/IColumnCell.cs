#region CLR版本 4.0.30319.225
// IColumnCell 接口
// 时间：2011-11-28 15:26:48
// 名称：IColumnCell 接口
// 大纲：添加表格列接口
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
    /// 添加表格列接口
    /// </summary>
    public interface IColumnCell
    {
        #region 方法
        /// <summary>
        /// 单行表头
        /// </summary>
        void SetSinglelayer();
        /// <summary>
        /// 多行表头
        /// </summary>
        void SetMultilayer();
        #endregion // 方法

        #region 属性

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

