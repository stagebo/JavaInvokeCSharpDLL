#region CLR版本 4.0.30319.225
// ITreeViewContainer 接口
// 时间：2011-11-28 15:26:48
// 名称：树容器接口
// 大纲：
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 树容器接口
    /// </summary>
    public interface ITreeViewContainer
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取容器实例
        /// </summary>
        Control Container
        {
            get;
        }

        /// <summary>
        /// 获取树指针
        /// </summary>
        ITreeViewPointer TreeView
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

