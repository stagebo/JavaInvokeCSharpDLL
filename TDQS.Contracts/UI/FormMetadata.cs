#region CLR版本 4.0.30319.239
// FormMetadata 类
// 时间：2011-11-10 14:04:17
// 名称：FormMetadata 
// 大纲：所有Form对象的Metadata
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
  /// <summary>
  /// 所有Form对象的元数据类
  /// </summary>
  [MetadataAttribute]
  public class FormMetadata : Attribute
  {
    #region 构造和析构

    /// <summary>
    /// 构造
    /// </summary>
    #endregion // 构造和析构

    #region 公有方法
    /// <summary>
    /// Name: Form的名称，做为Form的标识，不可以重复
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// ItemType: Form的分类，其值为 "Form" "Dialog" "View" "Toolwindow" "TreeGridWatch"
    /// </summary>
    public string ItemType { get; set; }

    /// <summary>
    /// FormType: Form的子类别，其值目前包括 "TreeStyleForm" "TabStyleForm"
    /// </summary>
    public string FormType { get; set; }

    /// <summary>
    /// FormMessage: Form的自定义消息名称
    /// </summary>
    public string FormMessage { get; set; }
    #endregion // 公有方法

    #region 保护方法
    #endregion // 保护方法

    #region 私有方法
    #endregion // 私有方法

    #region 属性及其私有变量
    #endregion // 属性及其私有变量

  }

  /// <summary>
  /// 所有FormMetadata对象的View
  /// </summary>
  public interface IFormMetadataView
  {
    /// <summary>
    /// Name: Form的名称，做为Form的标识，不可以重复
    /// </summary>
    string Name { get; }

    /// <summary>
    /// ItemType: Form的分类，其值为 "Form" "Dialog" "View" "Toolwindow" "TreeGridWatch"
    /// </summary>
    string ItemType { get; }

    /// <summary>
    /// FormType: Form的子类别，其值目前包括 "TreeStyleForm" "TabStyleForm"
    /// </summary>
    string FormType { get; }

    /// <summary>
    /// FormMessage: Form的自定义消息名称
    /// </summary>
    string FormMessage { get; }
  }
}