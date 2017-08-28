#region CLR版本 4.0.30319.239
// IElement 接口
// 时间：2011-11-9 16:49:33
// 名称：IElement 接口
// 大纲：所有元件必须实现的接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		        修改人		    描述

#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 元件接口
    /// </summary>
    public interface IElement : ICloneable,INotify
    {
        #region 方法

        /// <summary>
        /// 复制
        /// </summary>
        /// <returns>当前元件的副本</returns>
        IElement Copy();

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 绘制对象
        /// </summary>
        IDrawObject DrawObject
        {
            get;
            set;
        }

        /// <summary>
        /// 元件数值型ID
        /// </summary>
        int Index 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 元件字符型ID
        /// </summary>
        string ID 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 元件名称
        /// </summary>
        string Name 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 元件类型
        /// </summary>
        ElementType ElementType 
        { 
            get; 
        }

        /// <summary>
        /// 父元件对象
        /// </summary>
        IElement ParentElement
        {
            get;
            set;
        }

        /// <summary>
        /// 元件的父级ID
        /// </summary>
        string ParentID 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 是否包含子元件
        /// </summary>
        bool HasChild 
        { 
            get; 
            set; 
        }
    
        /// <summary>
        /// 电压等级
        /// </summary>
        double Dydj 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 根节点元件对象
        /// </summary>
        IElement RootElement
        {
            get;
            set;
        }

        /// <summary>
        /// 电网ID
        /// </summary>
        string RootElementID 
        { 
            get;
            set; 
        }

        /// <summary>
        /// 标签
        /// </summary>
        object Tag
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

