// Database 类
// 时间: 2010-05-01 11:04:20
// 名称：Database 
// 大纲：数据库对象 基类
//
// 创建人：刘东亮
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
//  2012.11.19  聂桂春      修改连接方式为实时释放，支持事务查询。
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Text;
using System.Text.RegularExpressions;
using TDQS.Contracts;

namespace TDQS.DBHelper
{
    /// <summary>
    /// DataBase 基类
    /// 名称: 数据库对象 基类
    /// 功能: 实现数据操作
    /// </summary>
    [CLSCompliant(false)] 
    public abstract class Database : IDatabase
    {
        #region 构造和析构

        /// <summary>
        /// 析构
        /// </summary>
        ~Database()
        {
            Dispose(false);
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法

        /// <summary>
        /// 创建字段SQL语句
        /// </summary>
        /// <param name="dc">表格列</param>
        /// <returns>创建字段SQL语句</returns>
        protected virtual String CreateFieldSql(DataColumn dc)
        {
            Debug.Assert(dc != null, "表格列为空！");
            // 列名，数据类型，是否为空
            String fieldString = dc.ColumnName + " " + GetDataTypeString(dc)
                + (dc.AllowDBNull ? "" : " NOT") + " NULL "
                + ",";
            return fieldString;
        }

        /// <summary>
        /// 创建字段SQL语句
        /// </summary>
        /// <param name="dc">表格列</param>
        /// <returns>创建字段SQL语句</returns>
        protected virtual String CreatePkeyFieldSql(DataColumn dc)
        {
            Debug.Assert(dc != null, "表格列为空！");
            String fieldString = CreateFieldSql(dc);
            fieldString += " Primary Key";
            return fieldString;
        }

        /// <summary>
        /// 获得类型的数据类型名
        /// </summary>
        /// <param name="dc">数据列</param>
        /// <returns>数据类型名</returns>
        protected virtual String GetDataTypeString(DataColumn dc)
        {
            Debug.Assert(dc != null, "表格列为空！");
            if (dc.DataType.ToString() == "System.Int32")
            {
                return "int";
            }
            if (dc.DataType.ToString() == "System.String")
            {
                return "varchar(" + dc.MaxLength + ")";
            }
            if (dc.DataType.ToString() == "System.Int16")
            {
                return "smallint";
            }
            if (dc.DataType.ToString() == "System.Int64")
            {
                return "bigint";
            }
            return "varchar(50)";
        }

        /// <summary>
        /// 是否需求引号
        /// </summary>
        /// <param name="dc">数据列</param>
        /// <returns>是否需求引号</returns>
        protected virtual Boolean NeedQuotes(DataColumn dc)
        {
            Debug.Assert(dc != null, "表格列为空！");
            String datatypeString = dc.DataType.ToString();

            if (datatypeString == "System.Int16" || datatypeString == "System.Int32" || datatypeString == "System.Int64"
                || datatypeString == "System.Single" || datatypeString == "System.Double" || datatypeString == "System.Decimal")
            {
                return false;
            }
            return true;
        }

        #endregion // 保护方法

        #region 私有方法

        /// <summary>
        /// 是否查询语句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns>是否查询语句</returns>
        private Boolean IsQuery(String sql)
        {
            Debug.Assert(!string.IsNullOrEmpty(sql), "要执行的SQL为空！");
            return sql.ToUpper().StartsWith("SELECT");
        }

        /// <summary>
        /// 查询断言校验
        /// </summary>
        /// <param name="sql">Sql语句</param>
        private void AssertQuery(String sql)
        {
            Debug.Assert(!string.IsNullOrEmpty(sql), "要执行的SQL为空！");
            Contract.Requires(IsQuery(sql), "请使用SELECT的查询语句");
        }

        #endregion // 私有方法

        #region 属性及其私有变量

        #endregion // 属性及其私有变量

        #region IDatabase 成员

        #region 创建对象

        /// <summary>
        /// 创建数据连接对象
        /// </summary>
        /// <returns>数据连接对象</returns>
        public DbConnection CreateConnection()
        {
            Debug.Assert(!string.IsNullOrEmpty(m_connString), "数据库连接字符串为空！");
            DbConnection  conn = m_dbFactory.CreateConnection();
            conn.ConnectionString = m_connString;
            return conn;
        }

        /// <summary>
        /// 返回当前数据库连接
        /// </summary>
        /// <returns>数据库连接</returns>
        protected virtual DbConnection CreateAndOpenConnection()
        {
            Debug.Assert(!string.IsNullOrEmpty(m_connString), "数据库连接字符串为空！");
            DbConnection connect = null;
            try
            {
                connect = CreateConnection();
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
            }
            catch 
            {
                throw new Exception("创建或打开数据库连接失败！") ;
            }
            return connect;
        }

        #endregion

        #region 检索结果

        /// <summary>
        /// 执行单条查询语句得到数据集
        /// *带异常处理
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据集</returns>
        public System.Data.DataSet QueryDataSet(string sql)
        {
            AssertQuery(sql);
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    // 命令对象
                    command.Connection = CreateAndOpenConnection();
                    command.CommandText = sql;
                    // 数据操作对象
                    DbDataAdapter adapter = m_dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = command;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行多条查询语句得到数据集
        /// *带异常处理
        /// </summary>
        /// <param name="sqls">查询语句集合</param>
        /// <returns>数据集</returns>
        public System.Data.DataSet QueryDataSet(ICollection<string> sqls)
        {
            Debug.Assert(sqls!=null, "SQL语句集合为空！");
            DataSet ds = new DataSet();
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    DbDataAdapter dbAdapter = m_dbFactory.CreateDataAdapter();
                    dbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                    dbAdapter.SelectCommand = command;
                    command.Connection = CreateAndOpenConnection();

                    foreach (String sql in sqls)
                    {
                        command.CommandText = sql;
                        try
                        {
                            DataTable dt = new DataTable();
                            dbAdapter.Fill(dt);
                            ds.Tables.Add(dt);
                        }
                        catch (Exception ex)
                        {
                            Debug.Assert(false, ex.Message + Environment.NewLine + ex.StackTrace);
                        }
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行单条查询语句得到数据表
        /// *带异常处理
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据表</returns>
        public System.Data.DataTable QueryTable(string sql)
        {
            AssertQuery(sql);
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    // 命令对象
                    command.Connection = CreateAndOpenConnection();
                    command.CommandText = sql;

                    // 数据操作对象
                    DbDataAdapter adapter = m_dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                    
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                }
            }
        }

        // [李睿2014-8-13]添加带事务的查询，解决事务中无法查询插入的结果的问题
        /// <summary>
        /// 执行单条查询语句得到数据表
        /// *带异常处理
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sql">查询语句</param>
        /// <returns>数据表</returns>
        public System.Data.DataTable QueryTable(ITrans trans,string sql)
        {
            AssertQuery(sql);
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    // 命令对象
                    command.Connection = trans.DbConnection;
                    command.Transaction = trans.DbTrans;
                    command.CommandText = sql;

                    // 数据操作对象
                    DbDataAdapter adapter = m_dbFactory.CreateDataAdapter();
                    adapter.SelectCommand = command;

                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;

                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 执行单条查询语句得到数据只进流
        /// *不关闭外部连接
        /// *带异常处理
        /// </summary>
        /// <param name="conn">连接</param>
        /// <param name="sql">查询语句</param>
        /// <returns>只进数据流</returns>
        public System.Data.Common.DbDataReader QueryReader(DbConnection conn, string sql)
        {
            AssertQuery(sql);
            Debug.Assert(conn != null, "连接对象为空！");
            try
            {
                using (DbCommand command = m_dbFactory.CreateCommand())
                {
                    command.Connection = conn;
                    command.CommandText = sql;
                    return command.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 执行单条查询语句得到数据只进流
        /// *带异常处理
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>只进数据流</returns>
        public System.Data.Common.DbDataReader QueryReader(string sql)
        {
            AssertQuery(sql);
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    command.Connection = CreateAndOpenConnection();
                    command.CommandText = sql;
                    return command.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        /// 返回结果集中的第一行第一列
        /// *带异常处理
        /// </summary>
        /// <param name="sql">数据查询语句</param>
        /// <returns>结果集中的第一行第一列</returns>
        public object QueryScalar(string sql)
        {
            AssertQuery(sql);
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    // 命令对象
                    command.Connection = CreateAndOpenConnection ();
                    command.CommandText = sql;
                    return command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return null;
            }
            finally
            {
                if (command != null && command.Connection != null)
                {
                    command.Connection.Close();
                }
            }
        }

        #endregion

        #region 执行命令

        /// <summary>
        /// 执行单条SQL语句
        /// </summary>
        /// <param name="sql">数据操作语句</param>
        /// <returns>语句执行影响记录数量</returns>
        public int Execute(string sql)
        {
            Debug.Assert(!string.IsNullOrEmpty(sql), "要执行的SQL为空！");
            DbCommand command = null;
            try
            {
                using (command = m_dbFactory.CreateCommand())
                {
                    // 命令对象
                    //默认命令超时时间为3分钟 程建波 添加于 2013-04-01
                    //command.CommandTimeout = 180;
                    //设置为无限期等待 程建波 添加于 2013-04-17
                    command.CommandTimeout = 0;
                    command.Connection = CreateAndOpenConnection();
                    command.CommandText = sql;
                    int result= command.ExecuteNonQuery();
                    if (result == -1)
                    {
                        return 0;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return -1;
            }
            finally
            {
                if (command != null && command.Connection!=null)
                {
                    command.Connection.Close();
                }
            }
        }

        /// <summary>
        ///  执行多条SQL语句（事务执行）
        /// </summary>
        /// <param name="sqls">SQL集合</param>
        /// <returns>执行结果</returns>
        public int Execute(ICollection<string> sqls)
        {
            Debug.Assert(sqls != null, "SQL语句集合为空！");
            DbConnection conn = CreateAndOpenConnection();
            DbTransaction dbTrans = conn.BeginTransaction();
            try
            {
                using (DbCommand command = m_dbFactory.CreateCommand())
                {
                    command.Transaction = dbTrans;
                    int exeCount = 0;
                    foreach (String sql in sqls)
                    {
                        // 命令对象
                        command.Connection = conn;
                        command.CommandText = sql;

                        exeCount += command.ExecuteNonQuery();
                    }
                    dbTrans.Commit();
                    if (exeCount == -1)
                    {
                        return 0;
                    }
                    return exeCount;
                }
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return -1;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region 事务

        /// <summary>
        /// 创建事务对象
        /// </summary>
        /// <returns>事务对象</returns>
        public ITrans CreateTrans()
        {
            return new Trans(this);
        }

        /// <summary>
        /// 执行单条SQL语句
        /// 需外部提交
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sql">数据操作语句</param>
        /// <returns>语句执行影响记录数量</returns>
        public int Execute(ITrans trans, String sql)
        {
            Debug.Assert(!string.IsNullOrEmpty(sql), "要执行的SQL为空！");
            Debug.Assert(trans!=null, "事务对象为空！");
            try
            {
                using (DbCommand command = m_dbFactory.CreateCommand())
                {
                    //设置默认命令超时时间为3分钟 程建波 添加于 2013-04-01
                    //command.CommandTimeout = 180;
                    //设置为无限期等待 程建波 添加于 2013-04-17
                    command.CommandTimeout = 0;
                    command.Transaction = trans.DbTrans;
                    command.Connection = trans.DbConnection;
                    command.CommandText = sql;

                    int result= command.ExecuteNonQuery();
                    if (result == -1)
                    {
                        return  0;
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 执行多条SQL语句（事务执行）
        /// 需外部提交
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sqls">数据操作语句集合</param>
        /// <returns>语句执行影响记录数量</returns>
        public int Execute(ITrans trans, ICollection<String> sqls)
        {
            Debug.Assert(trans != null, "事务对象为空！");
            Debug.Assert(sqls != null, "SQL语句集合为空！");
            try
            {
                using (DbCommand command = m_dbFactory.CreateCommand())
                {
                    //默认命令超时时间为3分钟 程建波 添加于 2013-04-01
                    //command.CommandTimeout = 180;
                    //设置为无限期等待 程建波 添加于 2013-04-17
                    command.CommandTimeout = 0;
                    command.Transaction = trans.DbTrans;
                    command.Connection = trans.DbConnection;
                    int exeCount = 0;
                    StringBuilder sb = new StringBuilder();
                    
                    foreach (String sql in sqls)
                    {
                        sb.Append(sql);
                        sb.Append(";");
                        // 命令对象
                    }
                    command.CommandText = sb.ToString(); ;
                    exeCount += command.ExecuteNonQuery();
                    if (exeCount == -1)
                    {
                        return 0;
                    }
                    return exeCount;
                }
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error(ex.Message);
                Debug.Assert(false, ex.Message);
                return -1;
            }
        }

        #endregion

        #region 工具函数

        /// <summary>
        /// 有效值（消除特殊字符）
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>有效值</returns>
        public string ValidValue(string value)
        {
            Debug.Assert(!string.IsNullOrEmpty(value), "值为空！");
            return value.Replace("'", "''");
        }
        
        #endregion

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return m_connString;
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected String m_connString = "";

        /// <summary>
        /// 数据源工厂
        /// </summary>
        public DbProviderFactory DbProviderFactory
        {
            get
            {
                return m_dbFactory;
            }
        }

        /// <summary>
        /// 数据源工厂
        /// </summary>
        protected DbProviderFactory m_dbFactory = null;

        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">是否释放</param>
        private void Dispose(Boolean disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                }

                _disposed = true;
            }
        }
        /// <summary>
        /// 是否已释放完成
        /// </summary>
        private Boolean _disposed = false;

        #endregion

    }

    
}
