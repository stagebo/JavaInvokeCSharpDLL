// PostgreSqlDatabase 类
// 时间: 2008-9-4 17:58:13
// 名称：基本数据增删改操作
// 大纲：基本数据增删改操作 物理表必须存在一个主健
//
// 创建人：刘振伟
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
using System.Text;
using System.Data;
using System.Collections;
using System.Data.OleDb;
using TDQS.Contracts;
using System;
using System.Diagnostics;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 基本数据增删改操作
    /// </summary>
    [CLSCompliant(false)] 
    public  class OperateData
    {
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="htValues">更新的键值对</param>
        /// <param name="htWhere">条件</param>
        /// <returns>返回更新执行的结果</returns> 
        public static int UpdateByWhere(string TableName, Hashtable htValues, Hashtable htWhere)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(htValues != null, "更新的键值对为空！");
            Debug.Assert(htWhere != null, "更新的条件对为空！");
            string ValuesList = string.Empty;
            string WhereList = string.Empty;
            StringBuilder sqlString = new StringBuilder();
            OleDbParameter[] prams;
            int Count = 0;
            sqlString.Append("update  " + TableName + " set ");
            prams = new OleDbParameter[htValues.Count];
            foreach (DictionaryEntry item in htValues)
            {
                if (!string.IsNullOrEmpty(item.Key.ToString()))
                {
                    ValuesList += item.Key.ToString() + "=@" + item.Key.ToString() + ",";
                }
                prams[Count] = new OleDbParameter("@" + item.Key.ToString(), item.Value);
                Count++;
            }

            foreach (DictionaryEntry d in htWhere)
            {
                WhereList += d.Key.ToString() + "=" + d.Value.ToString() + " AND ";
            }

            sqlString.Append(ValuesList.Substring(0, ValuesList.Length - 1) + " where " + WhereList.Substring(0, WhereList.Length - 5));
            return DBHelper.DbHelperACE.ExecuteSql(sqlString.ToString(), prams);
        }

        /// <summary>
        /// 根据条件操作数据 查询 删除
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="ht">参数键值对</param>
        /// <param name="Orderby">排序字段</param>
        /// <param name="type">操作方式</param>
        /// <returns>结果表</returns>
        public static DataTable DataByWhere(string TableName, Hashtable ht,string Orderby, OperateType type)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(ht != null, "参数键值对为空！");
            DataTable dt = new DataTable();
            if (ht.Count > 0)
            {
                string ValuesList = string.Empty;
                string FieldsList = string.Empty;
                OleDbParameter[] prams = new OleDbParameter[ht.Count];
                int Count = 0;
                StringBuilder sqlString = new StringBuilder();
                foreach (DictionaryEntry d in ht)
                {
                    ValuesList += d.Key.ToString() + "=@" + d.Key.ToString() + " AND ";
                    prams[Count] = new OleDbParameter("@" + d.Key.ToString(), d.Value);
                    Count++;
                }
                switch (type)
                {
                    case OperateType.Delete:
                        sqlString.Append("delete from " + TableName + " where " + ValuesList.Substring(0, ValuesList.Length - 5));
                        DBHelper.DbHelperACE.ExecuteSql(sqlString.ToString(), prams);
                        break;
                    case OperateType.Select:
                        sqlString.Append("select * from " + TableName + " where " + ValuesList.Substring(0, ValuesList.Length - 5) + (Orderby == "" ? "" : " order by " + Orderby));
                        dt = DBHelper.DbHelperACE.Query(sqlString.ToString(), prams).Tables[0];
                        break;
                    default:
                        break;
                }
            }
            return dt;
        }

        /// <summary>
        /// 执行sql语句操作
        /// </summary>
        /// <param name="SQLString">sql语句</param>
        /// <param name="cmd">传入的OleDbCommand 对象</param>
        /// <returns>返回sql执行影响的记录数</returns>
        public static int  ExecuteSql(string SQLString, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(SQLString), "要执行的SQL为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            return DBHelper.DbHelperACE.ExecuteSql(SQLString, cmd);
        }
        /// <summary>
        /// 得到通用的主键
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="KeyFileid">主键ID</param>
        /// <param name="cmd">DbCommand</param>
        /// <returns>最大ID</returns>
        public static int GetMaxID(string TableName, string KeyFileid, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(!string.IsNullOrEmpty(KeyFileid), "主键ID为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            string sql = string.Format("select max({0})  FROM {1}", KeyFileid, TableName);
            string ID = DBHelper.DbHelperACE.GetSingle(sql, cmd).ToString();
            return ID == "" ? 1 : int.Parse(ID) + 1;
        }

     /// <summary>
     /// 得到通用的主键
     /// </summary>
     /// <param name="TableName">表名</param>
     /// <param name="KeyFileid">字段名</param>
     /// <param name="tran">事务</param>
     /// <returns>返回最大ID</returns>
        public static int GetMaxID(string TableName, string KeyFileid, ITrans tran)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(!string.IsNullOrEmpty(KeyFileid), "主键ID为空！");
            Debug.Assert(tran != null, "tran为空！");
            string sql = string.Format("select max({0})  FROM {1}", KeyFileid, TableName);
            string ID = tran.Database.QueryScalar(sql).ToString();
            return ID == "" ? 1 : int.Parse(ID) + 1;
        }
       
        /// <summary>
        /// 获得数据表
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="where">条件</param>
        /// <param name="db">数据库对象</param>
        /// <returns>返回的数据表</returns>
        public static DataTable GetData(string TableName, string where,IDatabase db)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(!string.IsNullOrEmpty(where), "Where语句为空！");
            Debug.Assert(db != null, "数据库对象为空！");
            string sql = string.Format("select * from {0} where 1=1 {1}", TableName, where);
            return db.QueryTable(sql);
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="where"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataTable GetData(string TableName, string where, OleDbCommand cmd)
        {
            Debug.Assert(!string.IsNullOrEmpty(TableName), "表 " + TableName + " 不存在！");
            Debug.Assert(!string.IsNullOrEmpty(where), "Where语句为空！");
            Debug.Assert(cmd != null, "DbCommand为空！");
            string sql = string.Format("select * from {0} where 1=1 {1}", TableName, where);
            return DBHelper.DbHelperACE.Query(sql, cmd).Tables[0];
        }

    }
}
