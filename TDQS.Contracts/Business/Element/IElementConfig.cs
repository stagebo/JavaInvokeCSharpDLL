#region CLR版本 4.0.30319.239
// IElmentConfig 接口
// 时间：2012-2-16 16:24:26
// 名称：
// 大纲：
//
// 创建人：王津
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
    /// 元件设置接口,当前采用XML序列化方式存取
    /// </summary>
    public interface IElementConfig
    {
        #region 方法
        /// <summary>
        /// 装载配置
        /// </summary>
        /// <returns></returns>
        IElementConfig Load();
        /// <summary>
        /// 装载配置(根据类型集合)
        /// </summary>
        /// <param name="types">类型集合</param>
        /// <returns></returns>
        IElementConfig Load(Type[] types);
        /// <summary>
        /// 保存配置
        /// </summary>
        void Save();
        /// <summary>
        /// 保存配置(根据类型集合)
        /// </summary>
        /// <param name="types">类型集合</param>
        void Save(Type[] types);
        /// <summary>
        /// 初始化一个元件，即通过模板类装载并设置元件属性.
        /// </summary>
        /// <param name="eleObj">待装载的元件对象</param>
        /// <param name="tempObjID">模板元件对象ID值</param>
        /// <param name="bSetup">是否通过设置界面装载</param>
        /// <returns>装载好的原件对象</returns>
        IElement InitElement(IElement eleObj, string tempObjID, bool bSetup);
        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

