#region CLR版本 4.0.30319.269
// Excel 类
// 时间：6/29/2012 1:30:12 PM
// 名称：Excel数据库对象
// 大纲：
//
// 创建人：王东云
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace TDQS.DBHelper
{
    /// <summary>
    /// Excel数据库对象
    /// </summary>
    [CLSCompliant(false)]
    public class ExcelDatabase : Database
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="FilePath">数据文件位置</param>
        public ExcelDatabase(string FilePath)
        {
            Debug.Assert(!string.IsNullOrEmpty(FilePath), "数据库路径 " + FilePath + " 不存在！");
            m_connString = "Provider=Microsoft.Ace.OleDb.12.0; data source=" + FilePath + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'";
            m_olecon = new OleDbConnection(m_connString);
        }
        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <returns>数据表</returns>
        public DataTable GetDataByTableName(string tableName)
        {
            DataSet myds = new DataSet();
            try
            {
                if (m_olecon.State == ConnectionState.Closed)
                {
                    m_olecon.Open();
                }
                //抓多張Sheet1
                System.Data.DataTable dt = m_olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (dt.Rows[0]["TABLE_Name"].ToString().IndexOf("$") < 0)
                {
                    dt.Rows[0]["TABLE_Name"] += "$";
                }
                string dtname = "";
                foreach(DataRow row in dt.Rows)
                {
                    string tempTableName = row["TABLE_Name"].ToString();
                    if (tempTableName.IndexOf(tableName) < 0)
                    {
                        continue;
                    }
                    dtname = tempTableName;
                    break;
                }
                
                string strSelect = string.Format("Select * From [{0}] ", dtname);
                OleDbDataAdapter da = new OleDbDataAdapter(strSelect, m_olecon);

                da.Fill(myds, dtname);
                da.Dispose();
                m_olecon.Close();
                m_olecon.Dispose();
                m_olecon = null;
                return myds.Tables[dtname];
            }
            catch(Exception ex)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
#endif

                throw new Exception("获取数据表错误！");
            }
            finally
            {
                if (m_olecon != null)
                {
                    m_olecon.Close();
                    m_olecon.Dispose();
                    m_olecon = null;
                }
            }
        }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 数据源连接对象
        /// </summary>
        private OleDbConnection m_olecon;

        #endregion // 属性及其私有变量

    }
}