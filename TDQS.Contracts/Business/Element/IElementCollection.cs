#region CLR版本 4.0.30319.239
// IElementCollection 接口
// 时间：2011-11-18 16:53:16
// 名称：IElementCollection
// 大纲：电网元件集合（来自原CNP4.0系统 ）
//
// 创建人：王津 (原CNP4.0创建人wss)
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 基本元件集合接口（不包含Notify模式)
    /// </summary>
    public interface IElementCollection : IEnumerable<IElement>
    {
        #region 方法

        #region 获取
        /// <summary>
        /// 当前数据源中是否包含某元件
        /// </summary>
        /// <param name="element">元件</param>
        /// <returns></returns>
        bool Contains(IElement element);

        /// <summary>
        /// 当前数据源中是否深度包含某元件 (包括集合元素中的子集)
        /// </summary>
        /// <param name="element">元件</param>
        /// <returns></returns>
        bool DeepContains(IElement element);

        /// <summary>
        /// 获取某元件
        /// </summary>
        /// <param name="id">元件ID</param>
        /// <returns>元件</returns>
        IElement Get(string id);

        /// <summary>
        /// 获取元件集合
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        ICollection<IElement> Get(ICollection<string> sID);

        /// <summary>
        /// 获取所有元件集合
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        ICollection<IElement> Get();

        /// <summary>
        /// 获取当前集合所包含的元件类型
        /// </summary>
        /// <returns></returns>
        ICollection<ElementType> GetDistincateElementType();

        /// <summary>
        /// 获取某类型元件数组
        /// </summary>
        /// <typeparam name="elementType">元件类型</typeparam>
        /// <returns></returns>
        ICollection<ElementType> Get<ElementType>()
            where ElementType : IElement;//, new();// 王斌修改 2013-9-22，去掉泛型参数new()約束

        /// <summary>
        /// 获取某类型元件数组
        /// </summary>
        /// <typeparam name="elementType">元件类型</typeparam>
        /// <returns>元件集合</returns>
        ICollection<IElement> Get(ElementType elementType);
        #endregion

        #region Count

        /// <summary>
        /// 返回元件个数
        /// </summary>
        int Count();

        /// <summary>
        /// 返回某类型元件的个数
        /// </summary>
        /// <typeparam name="elementType">元件类型</typeparam>
        /// <returns>元件个数</returns>
        int Count<ElementType>()
            where ElementType : IElement, new();

        #endregion

        #region Add

        /// <summary>
        /// 添加一个元件到数据源
        /// </summary>
        /// <param name="element">元件</param>
        bool Add(IElement element);

        /// <summary>
        /// 添加一组元件
        /// </summary>
        /// <param name="elements">元件集合</param>
        /// <returns>操作是否成功</returns>
        bool Add(ICollection<IElement> elements);
        #endregion // Add

        #region Remove
        /// <summary>
        /// 删除元件
        /// </summary>
        /// <param name="element">元件</param>
        bool Remove(IElement element);

        /// <summary>
        /// 删除元件
        /// </summary>
        /// <param name="element">元件</param>
        bool Remove(string id);

        /// <summary>
        /// 删除元件
        /// </summary>
        /// <param name="element">元件</param>
        bool Remove(ICollection<IElement> elements);

        /// <summary>
        /// 删除元件
        /// </summary>
        /// <param name="element">元件</param>
        bool Remove(ICollection<string> IDs);
        #endregion


        #endregion // 方法

        #region 属性

        #region 性能优化 刘东亮, 2013/3/26 16:51:08, 修改：删除优化 删除元件数据表和说明表
       
        #endregion 性能优化
        /// <summary>
        /// 内置缓冲区
        /// </summary>
        IDictionary<string, IElement> ElementCache
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

