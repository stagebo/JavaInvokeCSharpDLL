#region CLR版本 4.0.30319.225
// Relative2D 枚举
// 时间：2011-11-16 11:33:27
// 名称：二维相对关系枚举
// 大纲：枚举二维关系中的习惯性被枚举部分
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
namespace TDQS
{
    /// <summary>
    /// 二维空间关联表述，位域
    /// </summary>
    [System.Flags]
    public enum Relative2D : int
    {
        /// <summary>
        /// 同位
        /// </summary>
        Same = 1,
        /// <summary>
        /// 在上
        /// </summary>
        Up = 2,
        /// <summary>
        /// 在下
        /// </summary>
        Down = 4,
        /// <summary>
        /// 在左
        /// </summary>
        Left = 8,
        /// <summary>
        /// 在右
        /// </summary>
        Right = 16
    }
}
