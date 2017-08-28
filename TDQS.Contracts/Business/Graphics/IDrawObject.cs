#region CLR版本 4.0.30319.239
// IDrawObject 接口
// 时间：2011-11-8 16:03:24
// 名称：IDrawObject
// 大纲：所有绘制对象必须实现的接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
//
//
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Xml;
using System.ComponentModel;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有绘制对象必须实现的接口
    /// </summary>
    public interface IDrawObject : ICloneable,INotify
    {
        #region 方法
        /// <summary>
        /// 绘制方法
        /// </summary>
        /// <param name="saveToDisk">是否存盘</param>
        bool Draw(bool saveToDisk = false);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="saveToDisk">是否存盘</param>
        bool Delete(bool saveToDisk = false);

        /// <summary>
        /// 移动方法
        /// </summary>
        /// <param name="x">X偏移量</param>
        /// <param name="y">Y偏移量</param>
        void Move(double x, double y);
        #endregion // 方法

        #region 属性
        ///// <summary>
        ///// 可见
        ///// </summary>
        //[Browsable(false)]
        //bool Visible { get; set; }
        /// <summary>
        /// 绘制对象是否被选中
        /// </summary>
        [Browsable(false)]
        bool Selected { get; set; }

        /// <summary>
        /// 绘制对象对应的元件对象
        /// </summary>
        IElement ElementObj { get; set; }
        
        // TODO: Code Analysis Start(刘东亮 2012/11/7 11:44:49) 类型: [违反扩展原则] 严重程度: [ 2  ]
        // 详细说明:  
        // DrawObject是否有具体的类型？还有有具体类型外还有类似cad块的一种类型。
        // 1个DrawObject由多种图元组成的情况如何描述：1、图形平台处理；2、包含图元集合，每个图元有对应的类型   
        // ======================================================= 
        //  日期		   修改人	    	描述 

        /// <summary>
        /// 绘制对象类型
        /// </summary>
        DrawObjectType DrawObjType { get; }
        // Code Analysis End(刘东亮 2012/11/7 11:44:53)

        /// <summary>
        /// 绘制对象操作句柄数
        /// </summary>
        int HandleCount { get; set; }

        /// <summary>
        /// 图元信息集合
        /// </summary>
        List<FeatureLite> FeatureLists
        {
            get;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

