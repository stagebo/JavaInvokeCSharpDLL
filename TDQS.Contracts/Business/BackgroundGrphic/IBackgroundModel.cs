#region CLR版本 4.0.30319.17379
// IBackgroundModel 接口
// 时间：2012/4/1 11:51:50
// 名称：IBackgroundModel
// 大纲：背景图信息模型接口
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
    /// 背景图信息模型接口
    /// </summary>
    public interface IBackgroundModel
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 指示当前背景图是否是临时背景图
        /// </summary>
        bool TempFile
        {
            get;
            set;
        }

        /// <summary>
        /// 别名
        /// </summary>
        string NickName
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或得到物理文件名
        /// </summary>
        string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或得到背景图是否可见
        /// </summary>
        bool Visible
        {
            get;
            set;
        }
        /// <summary>
        /// 文件宽
        /// </summary>
        float Width { get; set; }

        /// <summary>
        /// 文件高
        /// </summary>
        float Heigth { get; set; }

        /// <summary>
        /// 基点坐标X
        /// </summary>
        float X { get; set; }

        /// <summary>
        /// 基点坐标Y
        /// </summary>
        float Y { get; set; }

        /// <summary>
        /// X轴方向的伸缩比例
        /// </summary>
        float ScaleX { get; set; }

        /// <summary>
        /// Y轴方向的伸缩比例
        /// </summary>
        float ScaleY { get; set; }

        /// <summary>
        /// 背景图类型
        /// </summary>
        BackgroundType BackgroundType { get; set; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 背景图类型
    /// </summary>
    public enum BackgroundType
    {
        /// <summary>
        /// shp图格式
        /// </summary>
        Shp,
        /// <summary>
        /// JPG格式
        /// </summary>
        Jpg,
        /// <summary>
        /// CAD背景图
        /// </summary>
        Cad
    }
}

