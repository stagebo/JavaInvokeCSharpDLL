#region CLR版本 4.0.30319.225
// Trend 枚举
// 时间：2011-11-16 11:33:27
// 名称：线性倾向枚举
// 大纲：枚举线性关系中的相对倾向
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
    /// 单方面（线性）倾向性枚举类型
    /// </summary>
    public enum Trend : int
    {
        /// <summary>
        /// 无倾向
        /// </summary>
        Even = 0,
        /// <summary>
        /// 升序倾向
        /// </summary>
        Asc = 1,
        /// <summary>
        /// 降序倾向
        /// </summary>
        Desc = -1
    }
}
