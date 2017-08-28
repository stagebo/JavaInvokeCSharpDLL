#region CLR版本 4.0.30319.17379
// IWideAreaOptions 接口
// 时间：2012/06/07 15:32:26
// 名称：IWideAreaOptions
// 大纲：分区操作接口
//
// 创建人：孙书涛
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
    /// 分区操作接口
    /// </summary>
    public interface IWideAreaOptions
    {
        #region 方法
        /// <summary>
        /// 判断某元件是否在该大区范围内
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool ElementInWideArea(IElement element);

        /// <summary>
        /// 删除指定元件和分区的关联关系
        /// 聂桂春2013.2.16修改，去除参数document
        /// </summary>
        /// <param name="element">元件</param>
        void RemoveRelations(IElement element);

        /// <summary>
        /// 增加元件关系
        /// 聂桂春2013.2.16修改，去除参数document
        /// </summary>
        /// <param name="element">元件</param>
        void AddRelation(IElement element);
        /// <summary>
        /// 判定元件是否能和大区建立关联
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool ElementRelativeWideArea(IElement element);

        /// <summary>
        /// 删除该分区和该分区内元件的关联关系
        /// 聂桂春2013.2.16修改，去除参数document
        /// </summary>
        void RemoveAllRelations();
        /// <summary>
        /// 将分区内的元件添加到分区子对象集合内
        /// 聂桂春2013.2.16修改，去除参数document
        /// </summary>
        /// <returns>结果</returns>
        List<IElement> GetElements();

        #endregion // 方法

        #region 属性

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

