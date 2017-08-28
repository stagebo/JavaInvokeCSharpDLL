#region CLR版本 4.0.30319.225
// ITextualNode 接口
// 时间：2011-11-21 11:34:13
// 名称：文本化数据节点
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
using TDQS.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 文本化数据节点
    /// </summary>
    public interface ITextualNode : ITreeNode<ITextualNode>, IPacket<ITextual>     
    {
        #region 方法
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

