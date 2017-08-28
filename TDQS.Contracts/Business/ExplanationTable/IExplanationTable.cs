#region CLR版本 4.0.30319.239
// IXExplanationTable 接口
// 时间：2011-9-28 17:16:02
// 名称：说明表 接口
// 大纲：对属性数据库中某表的说明表, 该说明表 包括表名, 中文名(用于程序显示), 说明字段的集合, 表类型等信息。
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2011/12/7 15:42:30, 刘东亮, 整理字段
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TDQS.Contracts
{
    /// <summary>
    /// 说明表记录分组的树状信息描述
    /// </summary>
    public class ExpTableRecordCascadeInfo
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ExpTableRecordCascadeInfo()
        {
            GroupName = string.Empty;
            GroupIndex = 0;
            ParentIndex = 0;
            Children = new List<ExpTableRecordCascadeInfo>();
        }

        /// <summary>
        /// 组名
        /// </summary>
        public string GroupName
        {
            get;
            set;
        }

        /// <summary>
        /// 组索引
        /// </summary>
        public int GroupIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 父组索引
        /// </summary>
        public int ParentIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 子项目
        /// </summary>
        public List<ExpTableRecordCascadeInfo> Children
        {
            get;
            set;
        }

        /// <summary>
        /// 父项目
        /// </summary>
        public ExpTableRecordCascadeInfo Parent
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 对属性数据库中某表的说明表, 该说明表 包括表名, 中文名(用于程序显示), 说明字段的集合, 表类型等信息
    /// </summary>
    public interface IExplanationTable
    {
        #region 方法

        /// <summary>
        /// 是否包含字段
        /// </summary>
        /// <param name="sFieldName">字典名称</param>
        /// <returns>是否包含字段</returns>
        bool Contains(string sFieldName);

        /// <summary>
        /// 说明表组过滤
        /// </summary>
        /// <param name="ShowGroupFilterIndex">过滤组索引</param>
        void SetGroupFilter(int ShowGroupFilterIndex);

        #endregion

        #region 属性

        /// <summary>
        /// 说明表记录分组的树状信息
        /// </summary>
        ExpTableRecordCascadeInfo RecordCascadeInfo
        {
            get;
        }

        /// <summary>
        /// 获得正在使用的字段串 以","分隔 如：F_ID,F_Name,F_DEC
        /// </summary>
        string OnlineFields
        {
            get;
        }

        /// <summary>
        /// 所有显示的字段 注： GroupIndex>0
        /// </summary>
        string DisplayFields
        {
            get;
        }

        /// <summary>
        /// 获得主键数组
        /// </summary>
        string[] GetPrimaryKeys
        {
            get;

        }

        /// <summary>
        /// 获得主键字符串，多主键以'|'相连
        /// </summary>
        /// <returns></returns>
        string GetPrimaryKey
        {
            get;

        }

        /// <summary>
        /// 表的名称
        /// 如 对 T_JD 表的说明表该属性将返回 T_JD
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 说明表的名称
        /// 如 对 T_JD 表的说明表该属性将返回 T_JD_EXP
        /// </summary>
        string SchemaName
        {
            get;
        }

        /// <summary>
        /// 界面的显示名称
        /// </summary>
        /// 如 对 T_JD 表的说明表该属性将返回 节点
        string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 关联表名
        /// </summary>
        string TableRelated
        {
            get;
        }

        /// <summary>
        /// 关联字段
        /// </summary>
        string[] FieldRelated
        {
            get;
        }

        /// <summary>
        /// 表的类型, 以说明该表是元件表, 还是参数表, 还是附加表或附加元件表
        /// </summary>
        XTableType TableType
        {
            get;
        }

        /// <summary>
        /// 显示顺序
        /// </summary>
        int Order
        {
            get;
        }

        /// <summary>
        /// 是否必须, 已指定改表不能被用户删除
        /// 是系统运行所必需的
        /// </summary>
        bool BeNeed
        {
            get;
        }


        /// <summary>
        /// 获取以字段名为索引的说明字段
        /// 如: this["F_ID"] 将获取 F_ID 的字段说明
        /// </summary>
        /// <param name="fieldName">表名</param>
        /// <returns>说明表</returns>
        IXExplanationField this[string fieldName]
        {
            get;
        }

        /// <summary>
        /// 获取说明表中字段的集合
        /// </summary>
        ICollection<IXExplanationField> Fields
        {
            get;
        }

        /// <summary>
        /// 说明表对应的数据字典
        /// </summary>
        IDbDictionary DbDictionary
        {
            get;
        }

        /// <summary>
        /// 冻结的列数
        /// </summary>
        int FreezeCount
        {
            get;
        }

        /// <summary>
        /// 功能项说明
        /// </summary>
        string BrowseItems
        {
            get;
        }

        /// <summary>
        /// 数据显示排序规则
        /// 刘东亮，20090206，添加
        /// </summary>
        String OrderBy
        {
            get;
        }

        /// <summary>
        /// 组过滤 
        /// </summary>
        List<int> GroupFilter
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 表的类型
    /// </summary>
    public enum XTableType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 电网
        /// </summary>
        [Description("电网表")]
        Network = 1,

        /// <summary>
        /// 电网附加表
        /// </summary>
        [Description("电网附加表")]
        AddinationalNetwork = 2,

        /// <summary>
        /// 元件相关数据
        /// </summary>
        [Description("元件相关数据表")]
        ElementData = 3,

        /// <summary>
        /// 设备表
        /// </summary>
        [Description("设备表")]
        Equipment = 4,

        /// <summary>
        /// 设施表
        /// </summary>
        [Description("设施表")]
        EquipmentContainer = 6,

        /// <summary>
        /// 附加元件表
        /// </summary>
        [Description("附加元件表")]
        AddinationalElement = 7,

        /// <summary>
        /// 元件关系表
        /// </summary>
        [Description("元件关系表")]
        ElementRelationship = 8,

        /// <summary>
        /// 参数表
        /// </summary>
        [Description("参数表")]
        Parameter = 9,

        /// <summary>
        /// 附加表
        /// </summary>
        [Description("分析计算表")]
        Addinational = 10,

        /// <summary>
        /// 判据表
        /// </summary>
        [Description("判据表")]
        Criterion = 13,

        /// <summary>
        /// 报表
        /// </summary>
        [Description("报表")]
        Report = 14,

        /// <summary>
        /// 大区表
        /// </summary>
        [Description("大区表")]
        Zone = 20
    }
}

