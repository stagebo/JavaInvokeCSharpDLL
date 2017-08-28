#region CLR版本 4.0.30319.269
// IElementHandler 接口
// 时间：2012-6-13 18:22:28
// 名称：IElementHandler
// 大纲：元件操作接口，操作当前视图中的元件集合、元件绘制对象集合、选中集合、内存缓冲集合等
//
// 创建人：王津
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 元件操作接口，操作当前视图中的元件集合、元件绘制对象集合、选中集合、内存缓冲集合等
    /// </summary>
    public interface IElementHandler
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 绘制对象集合
        /// </summary>
        List<IDrawObject> GraphicsList { get; set; }

        /// <summary>
        /// 选中集合
        /// </summary>
        ICollection<string> SelectedElements { get; set; }

        /// <summary>
        /// 元件集合（地理图中该集合为电网集合、子图中为子图集合。
        /// </summary>
        IElementCollection ElementCollection { get; set; }

        /// <summary>
        /// 下标访问绘制对象
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        IDrawObject this[int index] { get; }

        /// <summary>
        /// 选中个数
        /// </summary>
        int SelectionCount { get; }

        /// <summary>
        /// 绘制对象个数
        /// </summary>
        int GraphicsListCount { get; }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

