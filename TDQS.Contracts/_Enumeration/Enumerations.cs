#region CLR版本 4.0.30319.239
// Enumerations 类
// 时间：2011-12-8 9:33:24
// 名称：
// 大纲：
//
// 创建人：王斌
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2013/4/3 13:18:54, 刘东亮, DrawObjectType改为位域模式，方面一个DrawObject对应多种图元的情况
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 绘制对象类型
    /// </summary>
    [Flags]
    public enum DrawObjectType
    {
        /// <summary>
        /// 节点
        /// </summary>
        Node,
        /// <summary>
        /// 直线
        /// </summary>
        Line,
        /// <summary>
        /// 折线
        /// </summary>
        PolyLine,
        /// <summary>
        /// 面
        /// </summary>
        Polygon
    }

    /// <summary>
    /// 画布视图显示类型
    /// </summary>
    public enum CanvasViewOpenType
    {
        /// <summary>
        /// 主视图
        /// </summary>
        Main,
        /// <summary>
        /// 设备视图
        /// </summary>
        DeviceView,
        /// <summary>
        /// 子网视图
        /// </summary>
        SubNetwork
    }

    /// <summary>
    /// 画布视图关闭模式
    /// </summary>
    public enum ViewCloseMode
    {
        /// <summary>
        /// 隐藏
        /// </summary>
        Hide,
        /// <summary>
        /// 关闭
        /// </summary>
        Close
    }
}