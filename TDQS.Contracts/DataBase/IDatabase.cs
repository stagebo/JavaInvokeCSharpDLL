#region CLR版本 4.0.30319.239
// IDatabase 接口、ITrans 接口
// 时间：2010-5-1 17:16:02
// 名称：数据库对象 接口、事务 接口
// 大纲：实现数据操作。实现事务操作。
//
// 创建人：刘东亮
// 版权：2010 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace TDQS.Contracts
{
    /// <summary>
    /// 实现数据操作
    /// </summary>
    public interface IDatabase : IDisposable
    {
        #region 创建对象

        /// <summary>
        /// 创建数据连接对象
        /// </summary>
        /// <returns>数据连接对象</returns>
        DbConnection CreateConnection();

        #endregion

        #region 检索结果

        /// <summary>
        /// 执行单条查询语句得到数据集
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据集</returns>
        DataSet QueryDataSet(String sql);

        /// <summary>
        /// 执行多条查询语句得到数据集（事务执行）
        /// </summary>
        /// <param name="sqls">查询语句集合</param>
        /// <returns>数据集</returns>
        DataSet QueryDataSet(ICollection<String> sqls);

        /// <summary>
        /// 执行单条查询语句得到数据表
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>数据表</returns>
        DataTable QueryTable(String sql);

        // [李睿2014-8-13]添加带事务的查询，解决事务中无法查询插入的结果的问题
        /// <summary>
        /// 执行单条查询语句得到数据表
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sql">查询语句</param>
        /// <returns>数据表</returns>
        DataTable QueryTable(ITrans trans, String sql);

        /// <summary>
        /// 执行单条查询语句得到数据只进流
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        /// <param name="sql">查询语句</param>
        /// <returns>只进数据流</returns>
        DbDataReader QueryReader(DbConnection conn,String sql);

        /// <summary>
        /// 执行单条查询语句得到数据只进流
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>只进数据流</returns>
        DbDataReader QueryReader(String sql);

        /// <summary>
        /// 返回结果集中的第一行第一列
        /// </summary>
        /// <param name="sql">数据查询语句</param>
        /// <returns>结果集中的第一行第一列</returns>
        object QueryScalar(String sql);

        #endregion

        #region 执行命令

        /// <summary>
        /// 执行单条SQL语句
        /// </summary>
        /// <param name="sql">数据操作语句</param>
        /// <returns>语句执行影响记录数量</returns>
        int Execute(String sql);

        /// <summary>
        /// 执行多条SQL语句（事务执行）
        /// </summary>
        /// <param name="sqls">数据操作语句集合</param>
        /// <returns>语句执行影响记录数量</returns>
        int Execute(ICollection<String> sqls);

        #endregion

        #region 事务

        /// <summary>
        /// 创建事务对象
        /// </summary>
        /// <returns></returns>
        ITrans CreateTrans();

        /// <summary>
        /// 执行单条SQL语句
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sql">数据操作语句</param>
        /// <returns>语句执行影响记录数量</returns>
        int Execute(ITrans trans, String sql);

        /// <summary>
        /// 执行多条SQL语句（事务执行）
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="sqls">数据操作语句集合</param>
        /// <returns>语句执行影响记录数量</returns>
        int Execute(ITrans trans, ICollection<String> sqls);

        #endregion

        #region 工具函数

        /// <summary>
        /// 有效值（消除特殊字符）
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>有效值</returns>
        String ValidValue(String value);
 
        #endregion

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        String ConnectionString
        {
            get;
        }

        /// <summary>
        /// 数据源工厂
        /// </summary>
        DbProviderFactory DbProviderFactory
        {
            get;
        }

        #endregion
    }

    /// <summary>
    /// 实现事务操作
    /// </summary>
    public interface ITrans : IDisposable
    {

        #region 方法

        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        #endregion

        #region 属性

        /// <summary>
        /// 数据库对象
        /// </summary>
        IDatabase Database
        {
            get;
        }

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        DbConnection DbConnection
        {
            get;
        }

        /// <summary>
        /// 事务对象
        /// </summary>
        DbTransaction DbTrans
        {
            get;
        }

        #endregion
        
    }
}
