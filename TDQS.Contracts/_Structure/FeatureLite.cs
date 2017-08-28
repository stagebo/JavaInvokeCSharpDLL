#region CLR版本 4.0.30319.296
// FeatureLite 类
// 时间：2012-2-2 16:58:33
// 名称：图元信息结构
// 大纲：图元轻量信息
//
// 创建人：王斌
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 图元轻量信息
    /// </summary>
    public struct FeatureLite
    {
        #region 构造和析构

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fid">图元id</param>
        public FeatureLite(int fid = -1)
        {
            FID = fid;
            EID = "";
            LayerName = "";
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
        /// 等于操作符
        /// </summary>
        /// <param name="value1">图元轻量信息</param>
        /// <param name="value2">图元轻量信息</param>
        /// <returns>是否相等</returns>
        public static bool operator ==(FeatureLite value1, FeatureLite value2)
        {
            return value1.LayerName == value2.LayerName
                && value1.FID == value2.FID && value1.EID == value2.EID;
        }

        /// <summary>
        /// 不等于操作符
        /// </summary>
        /// <param name="value1">图元轻量信息</param>
        /// <param name="value2">图元轻量信息</param>
        /// <returns>是否不等</returns>
        public static bool operator !=(FeatureLite value1, FeatureLite value2)
        {
            return !(value1 == value2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return (LayerName + FID + (string.IsNullOrEmpty(EID) ? string.Empty : EID)).GetHashCode();
        }

        /// <summary>
        /// 层名
        /// </summary>
        public string LayerName;
        /// <summary>
        /// 图元ID
        /// </summary>
        public int FID;

        /// <summary>
        /// 图元对应元件ID
        /// </summary>
        public string EID;

        /// <summary>
        /// 空信息
        /// </summary>
        /// <returns></returns>
        public static FeatureLite NullValue
        {
            get
            {
                nullValue.FID = -1;
                return nullValue;
            }
        }
        private static FeatureLite nullValue;
        #endregion // 属性及其私有变量

    }
}