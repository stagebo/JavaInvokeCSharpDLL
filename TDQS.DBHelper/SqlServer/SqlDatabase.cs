// PostgreSqlDatabase 类
// 时间: 2011-6-2 17:58:13
// 名称：SQL Server类的数据库操作
// 大纲：提供SQL Server类的数据操作方法
//
// 创建人：刘东亮
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace TDQS.DBHelper.SqlServer
{
    /// <summary>
    /// SqlDatabase 类
    /// </summary>
   [CLSCompliant(false)] 
    public class SqlDatabase : Database
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="connctionString">数据库连接字符串</param>
        public SqlDatabase(String connctionString)
        {
            Debug.Assert(!string.IsNullOrEmpty(connctionString), "数据库路径 " + connctionString + " 不存在！");
            m_connString = connctionString;
            m_dbFactory = SqlClientFactory.Instance;
            m_dbFactory.CreateConnectionStringBuilder().ConnectionString = m_connString;
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量

    }
}