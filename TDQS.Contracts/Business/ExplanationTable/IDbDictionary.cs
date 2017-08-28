#region CLR版本 4.0.30319.239
// IXDbDictionary 接口
// 时间：2011-9-28 17:16:02
// 名称：数据库字典 接口
// 大纲：数据库字典是对整个数据库中表的说明, 包括表个数, 每个表的说明, 及表中字段的说明 等信息。
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2011/12/7 16:14:46, 刘东亮, 整理字段
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace TDQS.Contracts
{
    /// <summary>
    /// 数据库字典是对整个数据库中表的说明, 包括表个数, 每个表的说明, 及表中字段的说明 等信息
    /// </summary>
    public interface IDbDictionary
    {
        #region 方法

        /// <summary>
        /// 查询某表(本表, 而不是说明表)是否在数据字典中存在
        /// </summary>
        /// <param name="tableName">某表(本表, 而不是说明表)</param>
        /// <returns>是否在数据字典中存在</returns>
        bool ContainsTable(string tableName);

        /// <summary>
        /// 获取某表(本表, 而不是说明表)的表类型
        /// 如: 传入 T_JD 则为 元件表 XTableType.Element
        ///		传入 T_ZHN2ZHB 则为 附加元件表
        ///     传入 T_JD_FLOW 则为 附加表
        /// </summary>
        /// <param name="tableName">某表(本表, 而不是说明表)</param>
        /// <returns>表类型</returns>
        XTableType GetTableType(string tableName);

        /// <summary>
        /// 获取某表(本表, 而不是说明表)的表顺序（综合了F_GROUP和F_ORDER）
        /// </summary>
        /// <param name="tableName">某表1(本表, 而不是说明表)</param>
        /// <param name="tableName">某表2(本表, 而不是说明表)</param>
        /// <returns>表顺序（综合了F_GROUP和F_ORDER）, 若 tableName1 比 tableName2 靠前则返回 正数，反之为负数</returns>
        int Compare(string tableName1, string tableName2);

        /// <summary>
        /// 获取某表(本表, 而不是说明表)的表顺序（综合了F_GROUP和F_ORDER）
        /// </summary>
        /// <param name="tableName">某表1(本表, 而不是说明表)</param>
        /// <param name="tableName">某表2(本表, 而不是说明表)</param>
        /// <returns>表顺序（综合了F_GROUP和F_ORDER）, 若 tableName1 比 tableName2 靠前则返回 正数，反之为负数</returns>
        int CompareWithoutGROUP(string tableName1, string tableName2);

        /// <summary>
        /// 获取某附加表对应的本表
        /// 如: 获取潮流表TA_ZHLFLOW对应的本表将返回T_XLXD
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>附加表</returns>
        string GetOnwerTableName(string tableName);

        /// <summary>
        /// 获取某表对应的附加表
        /// 如: GetAdditionalTableNames("T_XLXD") 将返回包括潮流计算结果表在内的附加表的集合 string { "TA_ZHLFLOW" }
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>附加表</returns>
        string[] GetAdditionalTableNames(string tableName);

        /// <summary>
        /// 获取本表对应的说明表名
        /// 如: GetExplanationTableName("T_JD") 将返回 T_JD_EXP
        /// </summary>
        /// <param name="tableName">本表名</param>
        /// <returns>说明表名</returns>
        string GetExplanationTableName(string tableName);

        /// <summary>
        /// 获取说明表对应的本表名
        /// 如: GetOriginalTableName("T_JD_EXP") 将返回 T_JD
        /// </summary>
        /// <param name="tableName">说明表名</param>
        /// <returns>本表名</returns>
        string GetOriginalTableName(string tableName);

        /// <summary>
        /// 获取数据库中所有表名的集合(T_TABLES中的表)
        /// </summary>
        /// <returns></returns>
        string[] GetAllTableNames();

        /// <summary>
        /// 获取数据中某类型的所有表名 
        /// </summary>
        /// <param name="tableType">表的类型</param>
        /// <returns>所有表名 </returns>
        string[] GetAllTableNames(XTableType tableType);

        /// <summary>
        /// 获取表的界面显示时的名称
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <returns>显示名 - 即中文名</returns>
        string GetTableDisplayName(string sTableName);

        /// <summary>
        /// 获得外键对应列表
        /// </summary>
        /// <returns></returns>
        IList<object> GetForeignValueList(IXExplanationField field);

        /// <summary>
        /// 刷新某说明表，并且返回该说明表对象
        /// 此方法将强制重新生成对应的说明表对象
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>说明表</returns>
        IExplanationTable RefreshTable(string tableName);


        #endregion // 方法

        #region 属性

        /// <summary>
        /// 说明表的说明表, 即说明表的结构
        /// </summary>
        IExplanationTable ExplanationTableSchema
        {
            get;
        }

        /// <summary>
        /// T_TABLES的说明表
        /// </summary>
        IExplanationTable TablesSchema
        {
            get;
        }

        /// <summary>
        /// 获取以表名为索引的说明表
        /// 如: this["T_JD"] 将获取 T_JD表的说明表
        /// </summary>
        /// <param name="index">表名</param>
        /// <returns>说明表</returns>
        IExplanationTable this[string tableName]
        {
            get;
        }

        /// <summary>
        /// 获取字典中说明表的集合
        /// </summary>
        ICollection<IExplanationTable> Tables
        {
            get;
        }

        /// <summary>
        /// 数据字典 对应的数据库
        /// </summary>
        IDatabase Database
        {
            get;
        }

        /// <summary>
        /// 设置为true时，表示数据字典“脏”了，需要重新生成
        /// </summary>
        bool Dirty
        {
            set;
            get;
        }

        #endregion // 属性

    }
}