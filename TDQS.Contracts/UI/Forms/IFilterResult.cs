#region CLR版本 4.0.30319.17379
// IFilterResult 接口
// 时间：2012/07/10 17:03:49
// 名称：IFilterResult
// 大纲：分类选择结果
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
    /// 分类选择结果
    /// </summary>
    public interface IFilterResult : IToolWindow
    {
        #region 方法
        void DataBind(List<IElement> elements, IDocument document);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

