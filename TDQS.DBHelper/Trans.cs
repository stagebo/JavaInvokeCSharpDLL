#region CLR版本 4.0.30319.239
// Trans 类
// 时间：2012/11/15 11:59:05
// 名称：事务 类
// 大纲：
//
// 创建人：聂桂春
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDQS.Contracts;
using System.Data.Common;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 事务 类
    /// </summary>
    /// <summary>
    /// 名称: 事务 类
    /// 功能: 实现事务操作
    /// </summary>   
    [CLSCompliant(false)]
    public class Trans : ITrans
    {

        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="database">数据库接口</param>
        public Trans(IDatabase database)
        {
            m_database = database;
            m_conn = m_database.CreateConnection();
            try
            {
                m_conn.Open();
                m_dbTrans = m_conn.BeginTransaction();
            }
            catch
            {
                XSystem.LogHandler.Error("数据库连接打开失败");
                Debug.Assert(false, "数据库连接打开失败");
            }
        }

        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            m_dbTrans.Commit();
            this.Close();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            try
            {
                m_dbTrans.Rollback();
                this.Close();
            }
            catch (Exception ex)
            {
                XSystem.LogHandler.Error( "回滚事务失败！" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (m_conn.State == System.Data.ConnectionState.Open)
            {
                m_conn.Close();
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 属性及其私有变量

        /// <summary>
        /// 数据库对象
        /// </summary>
        [CLSCompliant(false)]
        public IDatabase Database
        {
            get
            {
                return m_database;
            }
        }
        private IDatabase m_database;


        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public DbConnection DbConnection
        {
            get
            {
                return this.m_conn;
            }
        }
        private DbConnection m_conn;

        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction DbTrans
        {
            get
            {
                return this.m_dbTrans;
            }
        }
        private DbTransaction m_dbTrans;

        #endregion // 属性及其私有变量

    }
}