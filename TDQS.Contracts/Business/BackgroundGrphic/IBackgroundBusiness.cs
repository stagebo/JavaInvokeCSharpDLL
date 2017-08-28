#region CLR版本 4.0.30319.17379
// IBackgroundBusiness 接口
// 时间：2012/4/1 13:45:10
// 名称：IBackgroundBusiness
// 大纲：背景图管理接口
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
using TDQS.Contracts;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 背景图管理接口
    /// </summary>
    public interface IBackgroundBusiness
        : ICollection<IBackgroundModel>
    {
        #region 方法

        /// <summary>
        /// 背景图初始化(网络)
        /// </summary>
        /// <param name="database">数据库操作对象</param>
        /// <param name="projectid">工程编号</param>
        /// <param name="docid">文档编号</param>
        /// <param name="column">列名称</param>
        void DeSerialize(IDatabase database, string projectid, string docid, string column);

        /// <summary>
        /// 背景图对象初始化
        /// </summary>
        /// <param name="itemName">项名称</param>
        void DeSerialize(string itemName);

        /// <summary>
        /// 返回数据表形式的背景图集合
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTable();

        /// <summary>
        /// 保存
        /// </summary>
        void Serialize();

        #endregion // 方法

        #region 属性
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

