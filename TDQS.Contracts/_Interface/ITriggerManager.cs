#region CLR版本 4.0.30319.239
// ITriggerManager 接口
// 时间：2012/8/15 11:41:37
// 名称：元件属性联动管理器接口
// 大纲：
//
// 创建人：聂桂春
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 元件属性联动管理器接口
    /// </summary>
    public interface ITriggerManager
    {
        #region 方法

        /// <summary>
        /// 属性联动
        /// </summary>
        /// <param name="sender">元件</param>
        /// <param name="e">元件改变事件参数</param>
        void AlterAttributeValue(IElement sender, ChangedEventArgs e);

        /// <summary>
        /// 校验属性
        /// </summary>
        /// <param name="sender">元件</param>
        /// <param name="e">元件改变事件参数</param>
        void ValidateAttribute(IElement sender, ChangedEventArgs e);

        /// <summary>
        /// 指定元件的多个属性联动
        /// </summary>
        /// <param name="sender">元件</param>
        /// <param name="es">元件改变事件参数集合</param>
        void AlterAttributeValues(IElement sender, ChangedEventArgs[] es);

        /// <summary>
        /// 属性联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyName">属性名</param>
        void AlterAttributeValue(IElement sender, string propertyName);

        /// <summary>
        /// 指定元件的多个属性联动
        /// </summary>
        /// <param name="sender">元件</param>
        /// <param name="propertyNames">属性名集合</param>
        void AlterAttributeValues(IElement sender, string[] propertyNames);

        /// <summary>
        /// 刷新指定元件属性
        /// </summary>
        /// <param name="sender">元件</param>
        /// <param name="triggerType">刷新类型</param>
        void RefAttributeValue(IElement sender, TriggerType triggerType= TriggerType.PorperChange);

        /// <summary>
        /// 刷新制定类型的一组元件
        /// </summary>
        /// <param name="type">元件类型</param>
        /// <param name="elements">元件集合</param>
        /// <param name="triggerType">刷新类型</param>
        void RefAttributeValue(ElementType type, ICollection<IElement> elements, TriggerType triggerType = TriggerType.PorperChange);

        /// <summary>
        /// 获取外键表的值
        /// </summary>
        /// <param name="m_column">列</param>
        /// <param name="element">元件</param>
        /// <returns>外键值</returns>
        string GetForeignValues(IXExplanationField m_column, IElement element);

        /// <summary>
        /// 确定属性是否只读
        /// </summary>
        /// <param name="element">元件</param>
        /// <param name="attrName">属性</param>
        /// <returns>是否只读</returns>
        bool ReadOnly(IElement element, string attrName);

        /// <summary>
        /// 确定属性是否可见
        /// </summary>
        /// <param name="element">元件</param>
        /// <param name="attrName">属性名</param>
        /// <returns>是否可见</returns>
        bool Visible(IElement element, string attrName);

        /// <summary>
        /// 获得特殊元件的特殊编辑器
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="element">元件</param>
        /// <returns>编辑器</returns>
        object GetEditor(IXExplanationField column, IElement element);

        /// <summary>
        /// 属性值修改后事件（用于记录手动分区、手动主干、手动长度）
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="element">元件名称</param>
        void OnValueChanged(string columnName, IElement element);

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

