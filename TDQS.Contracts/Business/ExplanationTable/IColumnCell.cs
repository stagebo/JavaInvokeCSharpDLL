#region CLR版本 4.0.30319.239
// IXExplanationField 接口
// 时间：2011-9-28 17:16:02
// 名称：说明字段 接口
// 大纲：说明字段说明了属性库表中字段的基本属性, 包括字段长度, 类型, 显示形式, 校验范围等信息。
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2011/12/7 14:21:07, 刘东亮, 整理字段
// 2012/11/29 18:13:13, 刘东亮, 增加XDisplayStyle枚举值ExtendDropDownList,可扩展的下拉列表(文本框不能编辑，只能选择;可编辑)
#endregion
using System;
using System.Collections.Generic;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 说明字段说明了属性库表中字段的基本属性, 包括字段长度, 类型, 显示形式, 校验范围等信息
    /// </summary>
    public interface IXExplanationField
    {
        #region 方法

        /// <summary>
        /// 获取字段的标准类型
        /// 如 F_ID 的 字段类型为 XFieldType.String, 而标准类型为 C#中的 typeof(string)
        /// </summary>
        /// <returns>类型</returns>
        Type GetFieldStandardType();


        /// <summary>
        /// 获取外键表
        /// </summary>
        /// <returns>外键表</returns>
        DataTable GetForeignDataTable();

        /// <summary>
        /// 获取外键字符串
        /// </summary>
        /// <returns>外键串</returns>
        string GetForeignListString();

        /// <summary>
        /// 获取外键表
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="paramID">参数表ID</param>
        /// <param name="sshgs">所属公司</param>>
        /// <param name="sort">排序方式</param
        /// <returns>外键表</returns>
        DataTable GetForeignDataTable(IDatabase db, string paramID,int sshgs=-1,SortMode sort= SortMode.ASC);

        /// <summary>
        /// 获取外键字符串
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="paramID">参数表ID</param>
        /// <param name="sshgs">所属公司</param>>
        /// <param name="sort">排序方式</param
        /// <returns>外键表</returns>
        string GetForeignListString(IDatabase db, string gchID, int sshgs = -1, SortMode sort = SortMode.ASC);

        /// <summary>
        /// 根据说明表验证
        /// </summary>
        /// <param name="value">值</param>
        void ValidateValue(object value);

        /// <summary>
        /// 值格式化处理
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>格式化后的值</returns>
        object FormatValue(object value);

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 字段的名称 : F_NAME
        /// 如 对说明表中字段 F_ID, 此属性应该返回 F_ID
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 字段对应的对象属性名称
        /// 如 为空则取字段名
        /// 聂桂春2012.11.23增加
        /// </summary>
        string PropName
        {
            get;
        }

        /// <summary>
        /// 字段的界面显示名称 F_CNAME
        /// 如 对说明表中字段 F_ID, 此属性应该返回 ID
        /// </summary>
        string DisplayName
        {
            get;
            set;
        }

        /// <summary>
        /// 字段的界面显示名称和单位
        /// 组合显示 F_NAME(F_UNIT)
        /// </summary>
        string DisplayNameWithUnit
        {
            get;
        }

        /// <summary>
        /// 字段的描述 : F_DESCIPTION
        /// 如 对说明表中字段 F_ID, 此属性应该返回 唯一标识。
        /// </summary>
        string Description
        {
            get;
        }

        /// <summary>
        /// 字段的描述 : F_NOTE
        /// 返回该字段的内部说明备注，也用做枚举值
        /// 如开关表中的功能类型可以分为如下枚举值 0:断路器;1:负荷开关；2:隔离开关；3:熔断器
        /// </summary>
        string Note
        {
            get;
            set;
        }

        /// <summary>
        /// 字段的类型 : F_TYPE
        /// 如 对说明表中字段 F_ID, 此属性应该返回 XFieldType.String。
        /// </summary>
        XFieldType FieldType
        {
            get;
            set;
        }

        /// <summary>
        /// 字段的显示样式 : F_SHOWTYPE
        /// 如 对说明表T_XLXD中字段 F_TYPE, 此属性应该返回 XDisplayStyle.Combox。
        /// </summary>
        XDisplayStyle DisplayStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 字段长度 : F_LENGTH
        /// 如 对说明表中字段 F_ID, 此属性应该返回 30
        /// </summary>
        int Length
        {
            get;
        }

        /// <summary>
        /// 小数位数 : F_DEC
        /// 如 对说明表中字段 F_ID, 此属性应该返回 0
        /// </summary>
        int DecimalDigits
        {
            get;
            set;
        }

        /// <summary>
        /// 界面中显示精度 : F_DISPRECISION
        /// </summary>
        int DisplayPrecision
        {
            get;
            set;
        }

        /// <summary>
        /// 单位 对应说明表字段： F_UNIT
        /// </summary>
        string Unit
        {
            get;
            set;
        }

        /// <summary>
        /// 是否必须 对应说明表字段： F_BENEED
        /// </summary>
        bool BeNeed
        {
            get;
        }

        /// <summary>
        /// 是否主键 对应说明表字段： F_PKEY
        /// </summary>
        bool PrimalityKey
        {
            get;
        }

        /// <summary>
        /// 是否唯一 对应说明表字段： F_EXCLU
        /// </summary>
        bool Exclusive
        {
            get;
        }

        /// <summary>
        /// 分组显示索 引对应说明表字段： F_GROUPINDEX
        /// </summary>
        int GroupIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 分组显示名称 对应说明表字段： F_GROUPNAME
        /// </summary>
        string GroupName
        {
            get;
        }

        /// <summary>
        /// 父组
        /// </summary>
        int ParentGroup
        {
            get;
        }

        /// <summary>
        /// 组内显示序号 对应说明表字段： F_ORDER
        /// </summary>
        int Order
        {
            get;
            set;
        }

        /// <summary>
        /// 合法默认值 对应说明表字段： F_LAWDEFAULT
        /// </summary>
        string LawDefault
        {
            get;
            set;
        }

        /// <summary>
        /// 非法默认值 对应说明表字段： F_LAWLESSDEF
        /// </summary>
        string LawLessDefault
        {
            get;
        }

        /// <summary>
        /// 可否为空 对应说明表字段： F_NULL
        /// </summary>
        bool AllowNullValue
        {
            get;
        }

        /// <summary>
        /// 取值范围 对应说明表字段： F_RANGE
        /// </summary>
        string ValueRange
        {
            get;
        }

        /// <summary>
        /// 取值范围的解释, 当用户填入了错误的取值范围将使用ValueRangeExplainInfo进行提示,对应说明表字段： F_RANGEEXPRESSION
        /// 如 在 T_XLXD 的 F_LEN 字段(要求只能输入数字), 若用户输入了 字符串, 则给出该提示
        /// </summary>
        string ValueRangeExplainInfo
        {
            get;
        }

        /// <summary>
        /// 外键 对应说明表字段： F_FOREIGN
        /// </summary>
        //[Obsolete("不推荐使用该属性，而使用ForeignKeys进行对象化操作")]
        string ForeignKey
        {
            get;
        }

        /// <summary>
        /// 外键, 解析了F_FOREIGN
        /// </summary>
        XForeignKey[] ForeignKeys
        {
            get;
        }

        /// <summary>
        /// 是否独立 对应说明表字段： F_INDEPEND
        /// </summary>
        bool InDepend
        {
            get;
        }

        /// <summary>
        /// 表内联动函数 对应说明表字段： F_FUNCTION
        /// </summary>
        string Function
        {
            get;
        }

        /// <summary>
        /// 是否只读 对应说明表字段： F_READONLY
        /// </summary>
        bool ReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// 是否拷贝
        /// 该值为 true 时指示在表记录复制时, 可以拷贝该值
        /// 如: F_ID 的 此属性为 false 表示不能复制, 必须生成新值以免键值冲突
        /// </summary>
        bool Copy
        {
            get;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
        }

        /// <summary>
        /// 统计类型
        /// </summary>
        XStatisticalType StatisticalType
        {
            get;
        }

        /// <summary>
        /// 统计键
        /// </summary>
        string TJKey
        {
            get;
        }

        /// <summary>
        /// 枚举字符串，枚举值字典，该字典通过解析说明表类似以下字符串而成：   0:原有;1:新建;2:扩建
        /// </summary>
        Dictionary<string, string> DataEnums
        {
            get;
        }

        /// <summary>
        /// 枚举字符串。 如： 0:原有;1:新建;2:扩建
        /// </summary>
        String DataEnumsString
        {
            get;
        }

        /// <summary>
        /// 下属字段
        /// </summary>
        IList<IXExplanationField> ChildExpFields
        {
            get;
        }

        /// <summary>
        /// 当前数据字段所在的说明表
        /// </summary>
        IExplanationTable ExplanationTable
        {
            get;
        }

        /// <summary>
        /// 小数位处理(默认是保留)：DisplayDecWay.BL:保留,DisplayDecWay.JQ:精确
        /// </summary>   
        DisplayDecWay BL_JQ
        {
            get;
            set;
        }


        /// <summary>
        /// 进位方式
        /// JinweiType.Rounding：四舍五入，
        /// JinweiType.IntoALaw：进一法,
        /// JinweiType.De_Tail:去尾法（舍去保留位后的小数位）
        /// </summary>   
        JinweiType MathJinwei
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件

        /// <summary>
        /// 字段显示顺序修改事件
        /// </summary>
        event EventHandler<XFieldOrderChangedEventArgs> OrderChanged;
        #endregion // 事件
    }

    /// <summary>
    /// 外键
    /// </summary>
    public struct XForeignKey
    {
        /// <summary>
        /// 表
        /// </summary>
        public string Table;
        /// <summary>
        /// 字段
        /// </summary>
        public string Field; 
        /// <summary>
        /// 字段值
        /// </summary>
        public String Value; 
        /// <summary>
        /// 条件值
        /// </summary>
        public string Condition; 
    }

    /// <summary>
    /// 字段的类型
    /// </summary>
    public enum XFieldType : byte
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,

        /// <summary>
        /// 字符串
        /// </summary>
        String = 1,

        /// <summary>
        /// 备注
        /// </summary>
        Memo,

        /// <summary>
        /// 布尔型， true 和 false
        /// </summary>
        Bool,

        /// <summary>
        /// 整型，有符号 32 位整数，-2,147,483,648 到 2,147,483,647
        /// </summary>
        Integer,

        /// <summary>
        /// 长整型，有符号 64 位整数，-9,223,372,036,854,775,808 到 9,223,372,036,854,775,807
        /// </summary>
        Long,

        /// <summary>
        /// 单精度浮点型，±1.5e−45 到 ±3.4e38
        /// </summary>
        Float,

        /// <summary>
        /// 双精度浮点型，±5.0 × 10-324 到 ±1.7 × 10308
        /// </summary>
        Double,

        /// <summary>
        /// 二进制
        /// </summary>
        Binary,

        /// <summary>
        /// 日期
        /// </summary>
        Date,

        /// <summary>
        /// 自动编号
        /// </summary>
        AutoNum,

        /// <summary>
        /// 数值数据
        /// </summary>
        Decimal
    }

    /// <summary>
    /// 字段的显示类型
    /// </summary>
    public enum XDisplayStyle : byte
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,

        /// <summary>
        /// 字符串
        /// </summary>
        String = 1,

        /// <summary>
        /// 单精度浮点
        /// </summary>
        Float,

        /// <summary>
        /// 双精度浮点
        /// </summary>
        Double,

        /// <summary>
        /// 布尔
        /// </summary>
        Bool,

        /// <summary>
        /// 日期
        /// </summary>
        Date,

        /// <summary>
        /// 年份(主要用于投运年份)
        /// </summary>
        Year,

        /// <summary>
        /// 日期加时分（2009-11-16 09：32）（不带秒）
        /// </summary>
        DateMinute,

        /// <summary>
        /// 整型
        /// </summary>
        Integer,

        /// <summary>
        /// 下拉列表框(文本框可编辑)
        /// </summary>
        Combox,

        /// <summary>
        /// DropDownList(文本框不能编辑，只能选择)
        /// </summary>
        DropDownList,

        /// <summary>
        /// 自定义显示内容下拉列表
        /// </summary>
        CusDropDownList,

        /// <summary>
        /// 可扩展的下拉列表(文本框不能编辑，只能选择;可编辑)
        /// </summary>
        ExtendDropDownList,

        /// <summary>
        /// Ole对象
        /// </summary>
        Ole,

        /// <summary>
        /// 百分比
        /// </summary>
        Percent,

        /// <summary>
        /// Name选择器，选择Name，动态修改其F_ID
        /// </summary>
        NameSelector,

        /// <summary>
        /// ID选择器，存储ID，显示Name
        /// </summary>
        IDSelector,

        /// <summary>
        /// TDQS扩展百分比格式。乘以100显示
        /// </summary>
        TDQSPercent,

        /// <summary>
        /// 线路坐标串不显示首末端点
        /// </summary>
        TurnPointLine,

        /// <summary>
        /// 颜色
        /// </summary>
        ColorString,

        /// <summary>
        /// 字体
        /// </summary>
        FontString
    }

    /// <summary>
    /// 进位方式
    /// </summary>
    public enum JinweiType : byte
    {
        /// <summary>
        /// 四舍五入
        /// </summary>
        Rounding = 0,

        /// <summary>
        /// 进一法
        /// </summary>
        IntoALaw = 1,

        /// <summary>
        /// 去尾法
        /// </summary>
        De_Tail
    }

    /// <summary>
    /// 小数位显示方式
    /// </summary>
    public enum DisplayDecWay : byte
    {
        /// <summary>
        /// 按保留位数处理
        /// </summary>
        BL = 0,

        /// <summary>
        /// 按精确位处理
        /// </summary>
        JQ = 1
    }

    /// <summary>
    /// 字段统计类型
    /// </summary>
    [Flags]
    public enum XStatisticalType : byte
    {
        /// <summary>
        /// 不统计
        /// </summary>
        None = 0, 
        /// <summary>
        /// 总数
        /// </summary>
        Count = 1, 
        /// <summary>
        /// 求和
        /// </summary>
        Sum = 2,
        /// <summary>
        /// 绝对值
        /// </summary>
        Abs = 4, 
        /// <summary>
        /// 平均值
        /// </summary>
        Avg = 8, 
        /// <summary>
        /// 最大值
        /// </summary>
        Max = 16, 
        /// <summary>
        /// 最小值
        /// </summary>
        Min = 32, 
        /// <summary>
        /// 全部操作
        /// </summary>
        All = Count | Sum | Abs | Avg | Max | Min  
    }

    /// <summary>
    /// 记录说明表字段顺序
    /// </summary>
    public class XFieldOrderChangedEventArgs : System.EventArgs
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="oldOrder">原有字段顺序号</param>
        /// <param name="Order">当前字段顺序号</param>
        public XFieldOrderChangedEventArgs(Int32 oldOrder, Int32 order)
            : base()
        {
            m_oldOrder = oldOrder;
            m_order = order;
        }

        #endregion

        #region 属性及其私有变量

        /// <summary>
        /// 原有字段顺序号
        /// </summary>
        public Int32 OldOrder
        {
            get 
            { 
                return m_oldOrder; 
            }
            set 
            { 
                m_oldOrder = value; 
            }
        }
        private Int32 m_oldOrder;

        /// <summary>
        /// 当前字段顺序号
        /// </summary>
        public Int32 Order
        {
            get
            {
                return m_order;
            }
            set 
            { 
                m_order = value; 
            }
        }
        private Int32 m_order;

        #endregion
    }
}

