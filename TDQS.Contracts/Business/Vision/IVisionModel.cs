#region CLR版本 4.0.30319.239
// IVisionModel 接口
// 时间：2011/12/8 11:00:13
// 名称：视野数据模型接口
// 大纲：
//
// 创建人：3VELD97PNBO4RT9
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
    /// 视野数据模型接口
    /// </summary>
    public interface IVisionModel
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取或设置视野范围内左上角X坐标
        /// </summary>
        string X1
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置视野范围内左上角Y坐标
        /// </summary>
        string Y1
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置视野范围内右下角X坐标
        /// </summary>
        string X2
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置视野范围内右下角Y坐标
        /// </summary>
        string Y2
        {
            get;
            set;
        }
        

        /// <summary>
        /// 获取或设置当前视野的名称
        /// </summary>
        string VisionName
        {
            get;
            set;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

