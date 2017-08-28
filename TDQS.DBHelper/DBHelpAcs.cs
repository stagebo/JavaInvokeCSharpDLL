// DbHelperACE 类
// 时间: 2010-05-01 11:04:20
// 名称：DbHelperACE 
// 大纲：操作Access数据库基类
//
// 创建人：刘东亮
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.Diagnostics;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 操作Access数据库基类
    /// </summary>
    public class DbHelperACE
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbHelperACE()
        {

        }

        #endregion 构造函数

        #region 公用方法

        /// <summary>
        /// 获得最大ID
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="TableName">表名</param>
        /// <returns>最大ID</returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            Debug.Assert(!string.IsNullOrEmpty(FieldName), "字段 " + FieldName + " 不存在！");
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperACE.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 检查查询结果是否存在
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>返回是否存在结果</returns>
        public static bool Exists(string strSql)
        {
            Debug.Assert(!string.IsNullOrEmpty(strSql), "要执行的SQL为空！");
            object obj = DbHelperACE.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查查询结果是否存在
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="cmdParms">参数</param>
        /// <returns>返回是否存在结果</returns>
        public static bool Exists(string strSql, params OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(strSql), "要执行的SQL为空！");
            Debug.Assert(cmdParms!=null, "参数为空！");
            object obj = DbHelperACE.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  执行简单SQL语句

        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSql(string SQLString)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="SQLString">sql语句</param>
        /// <param name="cmd">OleDbCommand对象</param>
        /// <returns>返回执行结果影响的行数</returns>
        public static int ExecuteSql(string SQLString, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            try
            {
                cmd.CommandText = SQLString;
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (System.Data.OleDb.OleDbException E)
            {
                throw new Exception(E.Message);
            }
        }

        /// <summary>    
        /// 执行SQL语句，设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">sql语句</param>    
        /// <param name="Times">超时时间</param>    
        /// <returns>返回执行结果影响的行数</returns>    
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">多条SQL语句</param>         
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            Debug.Assert(SQLStringList!=null, "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                OleDbTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.OleDb.OleDbException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>    
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)    
        /// </summary>    
        /// <param name="strSQL">SQL语句</param>    
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>    
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            Debug.Assert(!string.IsNullOrEmpty(strSQL), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                OleDbCommand cmd = new OleDbCommand(strSQL, connection);
                System.Data.OleDb.OleDbParameter myParameter = new System.Data.OleDb.OleDbParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.OleDb.OleDbException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 返回执行sql语句结果的第一行第一列结果
        /// </summary>
        /// <param name="SQLString">sql语句</param>
        /// <param name="cmd">传入的OleDbCommand 对象</param>
        /// <returns>结果的第一行第一列结果</returns>
        public static object GetSingle(string SQLString, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            cmd.CommandText = SQLString;
            object obj = cmd.ExecuteScalar();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                return 0;
            }
            else
            {
                return obj;
            }
        }
        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>    
        /// <returns>查询结果（object）</returns>    
        public static object GetSingle(string SQLString)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }


        /// <summary>    
        /// 执行查询语句，返回SqlDataReader(使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="strSQL">查询语句</param>    
        /// <returns>SqlDataReader</returns>    
        public static OleDbDataReader ExecuteReader(string strSQL)
        {
            Debug.Assert(!string.IsNullOrEmpty(strSQL), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            OleDbConnection connection = new OleDbConnection(connectionstring);
            OleDbCommand cmd = new OleDbCommand(strSQL, connection);
            try
            {
                connection.Open();
                OleDbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>    
        /// <returns>DataSet</returns>    
        public static DataSet Query(string SQLString)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet  
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            DataSet ds = new DataSet();
            try
            {
                cmd.CommandText = SQLString;
                OleDbDataAdapter ada = new OleDbDataAdapter();
                ada.SelectCommand = cmd;
                ada.Fill(ds, "ds");
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }

        /// <summary>    
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="Times">超时时间</param>    
        /// <returns>数据集合</returns>    
        public static DataSet Query(string SQLString, int Times)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    OleDbDataAdapter command = new OleDbDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 带事务的操作数据库
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="cmdParms">参数集合</param>
        /// <param name="cmd">Command对象</param>
        /// <returns>执行结果</returns>
        public static int ExecuteSql(string SQLString, OleDbParameter[] cmdParms, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            try
            {
                PrepareCommand(cmd, SQLString, cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rows;
            }
            catch (System.Data.OleDb.OleDbException E)
            {
                throw new Exception(E.Message);
            }
        }
        /// <summary>    
        /// 执行SQL语句，返回影响的记录数    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>    
        /// <param name="cmdParms">查询参数</param>  
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSql(string SQLString, params OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.OleDb.OleDbException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的OleDbParameter[]）</param>    
        /// <returns>影响的记录数</returns>    
        public static int ExecuteSqlTran(Hashtable SQLStringList)
        {
            Debug.Assert(SQLStringList != null, "SQL集合为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            int result = 0;
            using (OleDbConnection conn = new OleDbConnection(connectionstring))
            {
                conn.Open();
                using (OleDbTransaction trans = conn.BeginTransaction())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    try
                    {
                        //循环    
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            OleDbParameter[] cmdParms = (OleDbParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            result += val;
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
            return result;
        }

        /// <summary>    
        /// 执行一条计算查询结果语句，返回查询结果（object）。    
        /// </summary>    
        /// <param name="SQLString">计算查询结果语句</param>  
        /// <param name="cmdParms">查询参数</param>  
        /// <returns>查询结果（object）</returns>    
        public static object GetSingle(string SQLString, params OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>    
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)    
        /// </summary>    
        /// <param name="SQLString">查询语句</param> 
        /// <param name="cmdParms">参数</param>
        /// <returns>SqlDataReader</returns>
        public static OleDbDataReader ExecuteReader(string SQLString, params OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            OleDbConnection connection = new OleDbConnection(connectionstring);
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                OleDbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }    

        }

        /// <summary>    
        /// 执行查询语句，返回DataSet    
        /// </summary>    
        /// <param name="SQLString">查询语句</param>   
        /// <param name="cmdParms">查询参数</param>   
        /// <returns>DataSet</returns>    
        public static DataSet Query(string SQLString, params OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(!string.IsNullOrEmpty(connectionstring), "数据库连接为空！");
            using (OleDbConnection connection = new OleDbConnection(connectionstring))
            {
                OleDbCommand cmd = new OleDbCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.OleDb.OleDbException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        #endregion

        #region 获取根据指定字段排序并分页查询。


        /**/
        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>    
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns></returns>    
        public static string getPageListCounts(string _ID, string _tbName, string _strCondition, int _Dist)
        {
            //---存放取得查询结果总数的查询语句                        
            //---对含有DISTINCT的查询进行SQL构造    
            //---对含有DISTINCT的总数查询进行SQL构造    
            string strTmp = "", SqlSelect = "", SqlCounts = "";

            if (_Dist == 0)
            {
                SqlSelect = "Select ";
                SqlCounts = "COUNT(*)";
            }
            else
            {
                SqlSelect = "Select DISTINCT ";
                SqlCounts = "COUNT(DISTINCT " + _ID + ")";
            }
            if (_strCondition == string.Empty)
            {
                strTmp = SqlSelect + " " + SqlCounts + " FROM " + _tbName;
            }
            else
            {
                strTmp = SqlSelect + " " + SqlCounts + " FROM " + " Where (1=1) " + _strCondition;
            }
            return strTmp;
        }


        /// <summary>    
        /// 智能返回SQL语句    
        /// </summary>    
        /// <param name="primaryKey">主键（不能为空）</param>    
        /// <param name="queryFields">提取字段（不能为空）</param>    
        /// <param name="tableName">表（理论上允许多表）</param>    
        /// <param name="condition">条件（可以空）</param>    
        /// <param name="orderBy">排序，格式：字段名+""+ASC（可以空）</param>    
        /// <param name="pageSize">分页数（不能为空）</param>    
        /// <param name="pageIndex">当前页，起始为：1（不能为空）</param>    
        /// <returns></returns>    

        public static string getPageListSql(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            string strTmp = ""; //---strTmp用于返回的SQL语句    
            string SqlSelect = "", SqlPrimaryKeySelect = "", strOrderBy = "", strWhere = " where 1=1 ", strTop = "";
            //0：分页数量    
            //1:提取字段    
            //2:表    
            //3:条件    
            //4:主键不存在的记录    
            //5:排序    
            SqlSelect = " select top {0} {1} from {2} {3} {4} {5}";
            //0:主键    
            //1:TOP数量,为分页数*(排序号-1)    
            //2:表    
            //3:条件    
            //4:排序    
            SqlPrimaryKeySelect = " and {0} not in (select {1} {0} from {2} {3} {4}) ";

            if (orderBy != "")
                strOrderBy = " order by " + orderBy;
            if (condition != "")
                strWhere += " and " + condition;
            int pageindexsize = (pageIndex - 1) * pageSize;
            if (pageindexsize > 0)
            {
                strTop = " top " + pageindexsize.ToString();

                SqlPrimaryKeySelect = String.Format(SqlPrimaryKeySelect, primaryKey, strTop, tableName, strWhere, strOrderBy);

                strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, SqlPrimaryKeySelect, strOrderBy);

            }
            else
            {
                strTmp = String.Format(SqlSelect, pageSize.ToString(), queryFields, tableName, strWhere, "", strOrderBy);

            }
            return strTmp;
        }


        /// <summary>
        /// 获取根据指定字段排序并分页查询
        /// </summary>
        /// <param name="connection">连接串</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="queryFields">要查询的字段</param>
        /// <param name="tableName">表名</param>     
        /// <param name="condition">条件</param>     
        /// <param name="orderBy">排序</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页游标</param>
        /// <returns>数据集合</returns>
        public static DataSet GetPagingList(string connection, string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            Debug.Assert(!string.IsNullOrEmpty(connection), "连接串为空！");
            Debug.Assert(!string.IsNullOrEmpty(primaryKey), "主键为空！");
            Debug.Assert(!string.IsNullOrEmpty(queryFields), "要查询的字段为空！");
            Debug.Assert(!string.IsNullOrEmpty(tableName), "表名为空！");
            Debug.Assert(!string.IsNullOrEmpty(condition), "条件为空！");
            string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

            return Query(sql);
        }
      
        /// <summary>
        /// 智能返回SQL语句 
        /// </summary>
        /// <param name="primaryKey">主键（不能为空）</param>    
        /// <param name="queryFields">提取字段（不能为空）</param>    
        /// <param name="tableName">表（理论上允许多表）</param>    
        /// <param name="condition">条件（可以空）</param> 
        /// <param name="orderBy">排序，格式：字段名+""+ASC（可以空）</param>    
        /// <param name="pageSize">分页数（不能为空）</param>    
        /// <param name="pageIndex">当前页，起始为：1（不能为空）</param>  
        /// <returns>SQL语句</returns>
        public static string GetPagingListSQL(string primaryKey, string queryFields, string tableName, string condition, string orderBy, int pageSize, int pageIndex)
        {
            Debug.Assert(!string.IsNullOrEmpty(primaryKey), "主键为空！");
            Debug.Assert(!string.IsNullOrEmpty(queryFields), "要查询的字段为空！");
            Debug.Assert(!string.IsNullOrEmpty(tableName), "表名为空！");
            Debug.Assert(!string.IsNullOrEmpty(condition), "条件为空！");
            string sql = getPageListSql(primaryKey, queryFields, tableName, condition, orderBy, pageSize, pageIndex);

            return sql;
        }

        /// <summary>    
        /// 分页查询数据记录总数获取    
        /// </summary>    
        /// <param name="connection">----连接串</param>    
        /// <param name="_tbName">----要显示的表或多个表的连接</param>    
        /// <param name="_ID">----主表的主键</param>    
        /// <param name="_strCondition">----查询条件,不需where</param>            
        /// <param name="_Dist">----是否添加查询字段的 DISTINCT 默认0不添加/1添加</param>    
        /// <returns>返回记录数</returns>    
        public static int GetRecordCount(string connection, string _ID, string _tbName, string _strCondition, int _Dist)
        {
            Debug.Assert(!string.IsNullOrEmpty(_ID), "主表的主键为空！");
            Debug.Assert(!string.IsNullOrEmpty(_tbName), "表名为空！");
            Debug.Assert(!string.IsNullOrEmpty(_strCondition), "查询条件为空！");
            string sql = getPageListCounts(_ID, _tbName, _strCondition, _Dist);
            object obj = DbHelperACE.GetSingle(sql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 准备Command
        /// </summary>
        /// <param name="cmd">DBCommand对象</param>
        /// <param name="cmdText">Cmd文本</param>
        /// <param name="cmdParms">参数集合</param>
        private static void PrepareCommand(OleDbCommand cmd, string cmdText, OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(cmdText), "Cmd文本为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            Debug.Assert(cmd != null, "DBCommand对象为空！");
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;//cmdType;    
            if (cmdParms != null)
            {
                #region lb 2010-7-19
                /*
                 * 修改原因：对于Access数据库的操作，参数的顺序与执行命令中参数的顺序要相同，
                 *           否则，会出现错误或不执行命令
                 */
                string pat = @"@\w+\s*(,|\s*)\s*";
                Regex re = new Regex(pat);
                Match m = re.Match(cmdText);
                while (m.Success)
                {
                    string key = m.Value.Trim();
                    key = key.EndsWith(",") ? key.TrimEnd(new char[] { ',' }) : key;
                    OleDbParameter parameter = ParamsNameOf(cmdParms, key);
                    if (null != parameter)
                        cmd.Parameters.Add(parameter);
                    m = m.NextMatch();
                }


                #endregion
            }
        }

        /// <summary>
        /// 从参数集合中返回指定参数名称的参数对象
        /// </summary>
        /// <param name="parameters">参数集合</param>
        /// <param name="paramName">参数名称</param>
        /// <returns></returns>
        private static OleDbParameter ParamsNameOf(OleDbParameter[] parameters, string paramName)
        {

            Debug.Assert(!string.IsNullOrEmpty(paramName), "参数名称为空！");
            Debug.Assert(parameters != null, "参数集合为空！");
            foreach (OleDbParameter parameter in parameters)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                if (paramName == parameter.ParameterName)
                    return parameter;
            }

            return null;
        }

        /// <summary>
        /// 准备Command
        /// </summary>
        /// <param name="cmd">DBCommand对象</param>
        /// <param name="conn">连接对象</param>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">Cmd文本</param>
        /// <param name="cmdParms">参数集合</param>
        private static void PrepareCommand(OleDbCommand cmd, OleDbConnection conn, OleDbTransaction trans, string cmdText, OleDbParameter[] cmdParms)
        {
            Debug.Assert(!string.IsNullOrEmpty(cmdText), "参数名称为空！");
            Debug.Assert(cmd != null, "Cmd对象为空！");
            Debug.Assert(conn != null, "连接对象为空！");
            Debug.Assert(trans != null, "事务对象为空！");
            Debug.Assert(cmdParms != null, "参数集合为空！");
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;    
            if (cmdParms != null)
            {


                foreach (OleDbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion 私有方法

        #region 属性

        /// <summary>
        /// 数据库连接字符串(config来配置)   
        /// </summary> 
        public static string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()
            + Application.StartupPath + "\\"
            + ConfigurationManager.AppSettings["Access"].ToString();

        #endregion
    }
}
