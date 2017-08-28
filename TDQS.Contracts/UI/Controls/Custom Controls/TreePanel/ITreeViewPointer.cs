#region CLR版本 4.0.30319.225
// ITreeViewPointer 接口
// 时间：2011-11-28 15:26:48
// 名称：树指针
// 大纲：
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System.Collections.Generic;
using System.Windows.Forms;
using TDQS.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 获取树指针
    /// </summary>
    public interface ITreeViewPointer : ICollector<TreeNode>, ICarrier<IEnumerable<ITextualNode>>
    {
        System.Windows.Forms.TreeView Instance { get; }
    }
}
