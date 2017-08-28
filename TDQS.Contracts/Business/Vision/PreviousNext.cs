#region CLR版本 4.0.30319.239
// PreviousNext 接口
// 时间：2011/11/25 14:03:54
// 名称：操作步骤动作定义接口
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 操作步骤动作定义接口
    /// </summary>
    public interface PreviousNext
    {
        #region 方法
        /// <summary>
        /// 前景
        /// </summary>
        /// <returns></returns>
        bool Previous();

        /// <summary>
        /// 后景
        /// </summary>
        /// <returns></returns>
        bool Next();

        /// <summary>
        /// 追加
        /// </summary>
        void Append();

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}