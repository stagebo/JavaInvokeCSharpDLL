#region CLR版本 4.0.30319.239
// IValidateResultFrm 接口
// 时间：2012-8-29 14:04:17
// 名称：IConModeViewFrm 
// 大纲：高压接线模式异常网架浏览结果窗口接口
//
// 创建人：聂桂春
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
    /// 高压接线模式结果窗口接口
    /// </summary>
    public interface IConModeViewFrm
    {
        #region 方法

        /// <summary>
        /// 显示校验结果
        /// </summary>
        /// <param name="view">视图</param>
        /// <param name="errPropertDic_Illegal">异常网架字典</param>
        void ShowConModeResult(IView  view, Dictionary<string, List<IElement>> errElementDic);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

