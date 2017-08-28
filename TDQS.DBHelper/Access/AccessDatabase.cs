// AccessDatabase 类
// 时间: 2010-05-01 11:04:20
// 名称：AccessDatabase 
// 大纲：操作Access数据库基类
//
// 创建人：刘东亮
// 版权：Copyright (C) 2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;

namespace TDQS.DBHelper
{
    /// <summary>
    /// Access数据库对象
    /// </summary>
    [CLSCompliant(false)]
    public class AccessDatabase : Database
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="connctionString">数据库连接字符串</param>
        public AccessDatabase(String connctionString)
        {
            Debug.Assert(!string.IsNullOrEmpty(connctionString), "数据库路径 " + connctionString + " 不存在！");
            m_connString = connctionString;
            m_dbFactory = OleDbFactory.Instance;
            m_dbFactory.CreateConnectionStringBuilder().ConnectionString = m_connString;
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="fileName">数据库文件路径</param>
        /// <param name="userId">用户名</param>
        /// <param name="password">密码</param>
        public AccessDatabase(String fileName, String userId, String password)
        {
            Debug.Assert(File.Exists(fileName), "文件 " + fileName + " 不存在！");
            m_dbFactory = OleDbFactory.Instance;
            DbConnectionStringBuilder dbStringBuilder = m_dbFactory.CreateConnectionStringBuilder();
            dbStringBuilder.ConnectionString = @"Data Source=" + fileName;
            dbStringBuilder.Add("Provider", "Microsoft.Jet.Oledb.4.0");
            m_connString = dbStringBuilder.ToString();
        }

    }
}
