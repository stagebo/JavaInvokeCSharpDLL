#region CLR版本 4.0.30319.239
// IObjectOperable 接口
// 时间：2011/10/9 12:03:29
// 名称：IObjectOperable
// 大纲：插入，更新，删除对象，并且更新到数据库
//
// 创建人：刘振伟
// 版权：2010 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace TDQS.Contracts
{
    /// <summary>
    /// 插入，更新，删除对象，并且更新到数据库
    /// </summary>
    public interface IObjectOperable
    {
        #region 方法
        /// <summary>
        /// 插入一个对象到数据库
        /// </summary>
        /// <param name="o">对象</param>
        bool Insert(object o);

        /// <summary>
        /// 更新对象到数据库
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>操作是否成功</returns>
        bool Update(object o);

        /// <summary>
        /// 从数据库中删除一个对象
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>操作是否成功</returns>
        bool Delete(object o);
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取相关事务对象
        /// </summary>
        DbTransaction Transaction
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

