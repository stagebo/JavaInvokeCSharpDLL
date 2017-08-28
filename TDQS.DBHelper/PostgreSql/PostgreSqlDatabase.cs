// PostgreSqlDatabase 类
// 时间: 2011-07-25 17:58:13
// 名称：PostgreSqlDatabase 
// 大纲：postgresql数据库基础操作封装
//
// 创建人：程建波
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述

using System;
using System.Diagnostics;
using System.Collections.Generic;
using Npgsql;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 名称: PostgreSql数据库类
    /// 功能: 用来创建PostgreSql数据库
    /// </summary>
    [CLSCompliant(false)] 
    public class PostgreSqlDatabase : Database
    {
        #region 构造和析构

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connctionString">数据库连接串</param>
        public PostgreSqlDatabase(String connctionString)
        {
            Debug.Assert(!string.IsNullOrEmpty(connctionString), "数据库连接字符串为空！");
            m_connString = connctionString;
            m_dbFactory = NpgsqlFactory.Instance;
            //程建波 将默认的命令超时时间调整为120秒 2013-03-20
            if (connctionString.IndexOf("COMMANDTIMEOUT") < 1)
            {
                if (connctionString.EndsWith(";"))
                {
                    connctionString += "COMMANDTIMEOUT=120";
                }
                else
                {
                    connctionString += ";COMMANDTIMEOUT=120";
                }
               
            
            }
            m_dbFactory.CreateConnectionStringBuilder().ConnectionString = m_connString;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="hostName">服务器名称或IP地址</param>
        /// <param name="database">数据库名称</param>
        /// <param name="port">数据库服务器端口</param>
        public PostgreSqlDatabase(string userId, string password, string hostName, string database, string port)
        {
            Debug.Assert(!string.IsNullOrEmpty(userId), "用户名为空！");
            Debug.Assert(!string.IsNullOrEmpty(password), "密码为空！");
            Debug.Assert(!string.IsNullOrEmpty(hostName), "服务器名称或IP地址为空！");
            Debug.Assert(!string.IsNullOrEmpty(database), "数据库名称为空！");
            Debug.Assert(!string.IsNullOrEmpty(port), "数据库服务器端口为空！");

            m_dbFactory = NpgsqlFactory.Instance;
            DbConnectionStringBuilder dbStringBuilder = m_dbFactory.CreateConnectionStringBuilder();
            dbStringBuilder.ConnectionString = "Server=" + hostName;
            dbStringBuilder.Add("Port", port);
            dbStringBuilder.Add("User Id", userId);
            dbStringBuilder.Add("Password", password);
            dbStringBuilder.Add("Database", database);
            //程建波 将默认的命令超时时间调整为600秒 2013-03-20
            dbStringBuilder.Add("COMMANDTIMEOUT", 600);
          
            m_connString = dbStringBuilder.ToString();
        }

        #endregion // 构造和析构

        #region 公有方法

        #endregion // 公有方法

        #region 保护方法

        /// <summary>
        /// 获得类型的数据类型名
        /// </summary>
        /// <param name="dc">数据列</param>
        /// <returns>数据类型名</returns>
        protected override string GetDataTypeString(DataColumn dc)
        {
            Debug.Assert(dc != null, "表格列为空！");
            // 默认字符数据类型
            String defStringType = "varchar(50)";
            // 默认数值数据类型
            String defnumicType = "float8";
            switch (dc.DataType.ToString())
            {
                case "System.Boolean":
                    return "bool";
                //case "System.Byte":
                //    return "bool";
                case "System.Char":
                    return defStringType;
                case "System.DateTime":
                    return "timestamp with time zone";
                case "System.Decimal":
                    return defnumicType;
                case "System.Double":
                    return defnumicType;
                case "System.Int16":
                    return "smallint";
                case "System.Int32":
                    return "int";
                case "System.Int64":
                    return "bigint";
                case "System.SByte":
                    return defStringType;
                case "System.Single":
                    return defnumicType;
                case "System.String":
                    if (dc.MaxLength <= 10485760)
                    {
                        return "varchar(" + dc.MaxLength + ")";
                    }
                    else
                    {
                        return "text";
                    }
                case "System.TimeSpan":
                    return "timestamp with time zone";
                case "System.UInt16":
                    return defnumicType;
                case "System.UInt32":
                    return defnumicType;
                case "System.UInt64":
                    return defnumicType;
                default:
                    return defStringType;
            }
        }
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        #endregion // 属性及其私有变量

    }
}