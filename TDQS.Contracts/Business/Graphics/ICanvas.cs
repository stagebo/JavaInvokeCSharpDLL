#region CLR版本 4.0.30319.239
// ICanvas 接口
// 时间：2011-11-8 16:28:43
// 名称：ICanvas 
// 大纲：所有绘制画布接口。
//
// 创建人: 王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace TDQS.Contracts
{
    /// <summary>
    /// 所有绘制画布接口，提供绘制图形功能
    /// </summary>
    public interface ICanvas
    {
        #region 方法

        ///// <summary>
        ///// 绘制方法。
        ///// </summary>
        //void Draw();

        ///// <summary>
        ///// 初始化
        ///// </summary>
        ///// <param name="owner">所属控件</param>
        //void Initialize(System.Windows.Forms.Control owner);

        ///// <summary>
        ///// 自序列化装入
        ///// </summary>
        ///// <param name="reader">XML读取器</param>
        //bool LoadFromXml(XmlTextReader reader);

        ///// <summary>
        ///// 保存到序列化
        ///// </summary>
        ///// <param name="sw">流写入器</param>
        //bool SaveToXml(StreamWriter sw);

        ///// <summary>
        ///// 内容被修改
        ///// </summary>
        //void SetDirty();

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 窗体实例
        /// </summary>
        Control Instance { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

