#region CLR版本 4.0.30319.17379
// IAttributeTrigger 接口
// 时间：2012/4/14 11:19:31
// 名称：IAttributeTrigger
// 大纲：元件属性触发器接口
//
// 创建人：孙书涛
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 元件属性触发器接口
    /// </summary>
    public interface IAttributeTrigger
    {
        #region 方法
        
        ///// <summary>
        ///// 得到备选项字符串
        ///// </summary>
        ///// <param name="attrName"></param>
        ///// <returns></returns>
        //string GetListString(IElement ele, string attrName);

        ///// <summary>
        ///// 根据传入的属性修改相关属性值
        ///// </summary>
        ///// <param name="attrName"></param>
        ///// <param name="refresh"></param>
        //void AlterAttributeValue(IElement ele, string attrName, bool refresh = true);
        
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 得到或设置是否修改相关属性
        /// </summary>
        bool AlterRelativeAttributes
        { 
            get; 
            set; 
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

