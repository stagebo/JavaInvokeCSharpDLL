#region CLR版本 4.0.30319.239
// IElementBuilder 接口
// 时间：2012-2-28 11:05:23
// 名称：IElementBuilder
// 大纲：元件创建接口
//
// 创建人：王津
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
    /// 元件生成器
    /// </summary>
    public interface IElementBuilder
    {
        #region 方法

        /// <summary>
        /// 创建一个元件
        /// </summary>
        /// <param name="tempID">元件模版ID</param>
        /// <returns></returns>
        IElement CreateElement(string tempID);

        /// <summary>
        /// 创建一个元件 
        /// </summary>
        /// <param name="elementType">元件类型</param>
        /// <param name="dataBase">数据库对象</param>
        /// <returns>创建的元件</returns>
        IElement CreateElement(ElementType elementType, IDatabase dataBase);

        /// <summary>
        /// 创建一个元件 
        /// </summary>
        /// <param name="elementType">元件类型</param>
        /// <returns>创建的元件</returns>
        IElement CreateElement(ElementType elementType);

        /// <summary>
        /// 复制一个元件到一个新的元件对象。(支持跨图复制)
        /// </summary>
        /// <param name="sourceObj">源元件对象</param>
        /// <param name="bool">是否改变命名</param>
        /// <param name="bool">是否包含绘制对象</param>
        /// <returns>目标新元件对象</returns>
        IElement CopyElement(IElement sourceObj,ICanvasView canvasView, bool bChangeName = false, bool bHasDrawObj = true, bool bSynSave = true, bool bCopyToTemplate = false);


        /// <summary>
        /// 复制一个元件到一个新的元件对象。(非跨图复制)
        /// </summary>
        /// <param name="sourceObj">源元件对象</param>
        /// <param name="bool">是否改变命名</param>
        /// <param name="bool">是否包含绘制对象</param>
        /// <returns>目标新元件对象</returns>
        IElement CopyElement(IElement sourceObj, bool bChangeName = false, bool bHasDrawObj = true, bool bSynSave = true, bool bCopyToTemplate = false);


        /// <summary>
        /// 通过元件类型获得元件初始名称
        /// </summary>
        /// <param name="etype"></param>
        /// <returns></returns>
        String ElementTypeToTypeName(ElementType etype);

        /// <summary>
        /// 元件类型获得表名
        /// </summary>
        /// <param name="etype">元件类型</param>
        /// <returns>表名</returns>
        String ElementTypeToTableName(ElementType etype);

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 当前视图
        /// </summary>
        ICanvasView CanvasView
        { 
            get;
            set; 
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

