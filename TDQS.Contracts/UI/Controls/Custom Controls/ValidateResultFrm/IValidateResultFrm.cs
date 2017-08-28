#region CLR版本 4.0.30319.239
// IValidateResultFrm 接口
// 时间：2012-5-11 14:04:17
// 名称：IEditPanel 
// 大纲：短路数据校验结果窗口接口
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
    /// 短路数据校验结果窗口接口
    /// </summary>
    public interface IValidateResultFrm
    {
        #region 方法

        /// <summary>
        /// 显示验证结果
        /// </summary>
        /// <param name="view">视图对象</param>
        /// <param name="errPropertDic_Illegal">非法错误元件集合</param>
        /// <param name="errPropertDic_Abnormal">异常错误元件集合</param>
        /// <param name="algorithmFunctionNum">算法入口编号</param>
        void ShowValidateResult(IView view, Dictionary<IElement, List<string>> errPropertDic_Illegal,
            Dictionary<IElement, List<string>> errPropertDic_Abnormal, int algorithmFunctionNum);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

