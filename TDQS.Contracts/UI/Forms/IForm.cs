#region CLR版本 4.0.30319.239
// IForm 接口
// 时间：2011-11-10 14:04:17
// 名称：窗体接口
// 大纲：窗体操作接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TDQS.Contracts
{
    /// <summary>
    /// 窗体操作接口
    /// </summary>
    public interface IForm
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 窗体实例
        /// </summary>
        Form Instance { get; }
        /// <summary>
        /// 资源名称
        /// </summary>
        string PrpResourceName { get; set; }
        /// <summary>
        /// 资源模式
        /// </summary>
        ResourceMode PrpResourceMode { get; set; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}



