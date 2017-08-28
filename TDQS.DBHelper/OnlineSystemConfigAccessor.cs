#region CLR版本 4.0.30319.269
// OnlineSystemConfigAccessor 类
// 时间：2012-9-6 11:11:30
// 名称：网络系统配置访问器
// 大纲：
//
// 创建人：郭威
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TDQS.Contracts;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 网络系统配置访问器
    /// </summary>
    public static class OnlineSystemConfigAccessor
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        static OnlineSystemConfigAccessor()
        {
            m_database = new PostgreSqlDatabase(ConfigurationManager.ConnectionStrings["postgres"].ToString());
        }

        #endregion // 构造和析构

        #region 公有方法

        public static IDatabase New()
        {
            return new PostgreSqlDatabase(ConfigurationManager.ConnectionStrings["postgres"].ToString()); 
        }

        public static KeyValuePair<int, string> GetConfigDataPair(string fileName)
        {
            string sql = "select f_id,f_data from ts_config_file where f_filename = '"
                + fileName + "' and f_projectid is NULL";
            DataTable table = m_database.QueryTable(sql);
            int key = (int)table.Rows[0]["f_id"];
            string value = (string)table.Rows[0]["f_data"];
            return new KeyValuePair<int, string>(key, value);
        }

        public static KeyValuePair<int, string> GetConfigDataPair(string fileName, string projectID)
        {
            if (string.IsNullOrWhiteSpace(projectID))
            {
                return GetConfigDataPair(fileName);
            }
            string sql = "select f_id,f_data from ts_config_file where f_filename = '"
                + fileName + "' and f_projectid = '" + projectID + "'";
            DataTable table = m_database.QueryTable(sql);
            int key = (int)table.Rows[0]["f_id"];
            string value = (string)table.Rows[0]["f_data"];
            return new KeyValuePair<int, string>(key, value);
        }

        public static string GetConfigData(int key)
        {
            string sql = "select f_data from ts_config_file where f_id=" + key;
            DataTable table = m_database.QueryTable(sql);
            return (string)table.Rows[0]["f_data"];
        }

        /// <summary>
        /// 最为常用的配置文件内容获取方式
        /// </summary>
        /// <param name="fileName">原始文件名前缀，如"Element.default"</param>
        /// <returns>配置文件内容</returns>
        public static string GetConfigData(string fileName)
        {
            return GetConfigDataPair(fileName).Value;
        }

        public static int SetConfigData(int key, string data)
        {
            string sql = "update ts_config_file set f_data ='"
                 + data + "' where f_id = " + key;
            return m_database.Execute(sql);
        }

        /// <summary>
        /// 最为常用的配置文件内容设置方式
        /// </summary>
        /// <param name="fileName">原始文件名前缀，如"Element.default"</param>
        /// <param name="data">配置文件内容</param>
        /// <returns>执行状态</returns>
        public static int SetConfigData(string fileName, string data)
        {
            string sql;
            if (Count(fileName) < 1)
            {
                sql = "insert into ts_config_file (f_filename,f_projectid,f_data) values ('"
                    + fileName + "',NULL,'" + data + "')";
            }
            else
            {
                sql = "update ts_config_file set f_data ='" + data + "' where f_filename = '"
                    + fileName + "' and f_projectid is NULL";
            }
            return m_database.Execute(sql);
        }

        /// <summary>
        /// 最为常用的配置文件内容设置方式
        /// </summary>
        /// <param name="fileName">原始文件名前缀，如"Element.default"</param>
        /// <param name="projectID">关联工程号</param>
        /// <param name="data">配置文件内容</param>
        /// <returns>执行状态</returns>
        public static int SetConfigData(string fileName, string projectID, string data)
        {
            if (string.IsNullOrWhiteSpace(projectID))
            {
                return SetConfigData(fileName, data);
            }
            string sql;
            if (Count(fileName, projectID) < 1)
            {
                sql = "insert into ts_config_file (f_filename,f_projectid,f_data) values ('"
                    + fileName + "','" + projectID + "','" + data + "')";
            }
            else
            {
                sql = "update ts_config_file set f_data ='" + data + "' where f_filename = '"
                    + fileName + "' and f_projectid = '" + projectID + "'";
            }
            return m_database.Execute(sql);
        }

        /// <summary>
        /// 获取文件类型
        /// </summary>
        /// <param name="fileID">文件编号</param>
        /// <returns>类型</returns>
        public static int GetFileType(string fileID)
        {
            string sql = "select f_type from ts_file_struct where f_id = '" + fileID + "'";
            DataTable table = m_database.QueryTable(sql);
            if (table.Rows.Count < 1)
            {
                return -1;
            }
            return (int)table.Rows[0]["f_type"];
        }

        public static string GetFileStructData(string fileID)
        {
            return GetFileStructData(fileID, 0);
        }

        public static string GetFileStructData(string fileID, int type)
        {
            string sql = "select f_data from ts_file_struct where f_id = '" 
                + fileID + "' and f_type = " + type;
            DataTable table = m_database.QueryTable(sql);
            if (table.Rows.Count < 1)
            {
                return null;
            }
            return (string)table.Rows[0]["f_data"];
        }

        /// <summary>
        /// 更新文件结构数据
        /// </summary>
        /// <param name="fileID">文件标识</param>
        /// <param name="data">Xml结构数据</param>
        /// <returns>影响行数</returns>
        public static int SetFileStructData(string fileID, string data)
        {
            return SetFileStructData(fileID, data, m_database);
        }

        /// <summary>
        /// 更新文件结构数据
        /// </summary>
        /// <param name="fileID">文件标识</param>
        /// <param name="data">Xml结构数据</param>
        /// <param name="database">数据库操作器</param>
        /// <returns>影响行数</returns>
        public static int SetFileStructData(string fileID, string data, IDatabase database)
        {
            
            string sql = @" select * from ts_file_struct where f_id = '{0}'";

            DataTable dbStructData = database.QueryTable(string.Format(sql, fileID));

            if (dbStructData.Rows.Count > 0)
            {
                sql = @" update ts_file_struct set f_data = '{1}' where f_id='{0}'";

                return database.Execute(string.Format(sql, fileID, data));
            }
            else
            {
                sql = @" insert into ts_file_struct
                        (
	                        f_id,
	                        f_data,
	                        f_type
                        )
                        values
                        (
	                        '{0}',
	                        '{1}',
	                        {2}
                        )";

                return database.Execute(string.Format(sql, fileID, data, 0));
            }
        }

        /// <summary>
        /// 根据工程ID，删除工程文件结构
        /// </summary>
        /// <param name="projectID">工程ID</param>
        /// <param name="database">数据库操作器</param>
        /// <returns>影响行数</returns>
        public static int DeleteFileStructByProjectID(string projectID, IDatabase database)
        {
            string sql = @" delete from ts_file_struct where f_id = '{0}'";

            return database.Execute(string.Format(sql, projectID));
        }

        /// <summary>
        /// 获取工程数据
        /// </summary>
        /// <returns>编号、名称、结构数据</returns>
        public static DataTable GetProjectData()
        {
            string sql = "select ts_file_struct.f_id as f_id,t_gch.f_gchmch as f_name, ts_file_struct.f_data as f_data " +
                "from ts_file_struct,t_gch where ts_file_struct.f_id = t_gch.f_gchid and ts_file_struct.f_type = 0 order by t_gch.f_gchmch asc";
            return m_database.QueryTable(sql);
        }

        /// <summary>
        /// 获取确定工程数据
        /// </summary>
        /// <param name="projectID">工程标识</param>
        /// <returns>名称、结构数据</returns>
        public static KeyValuePair<string, string> GetProjectData(string projectID)
        {
            string sql = "select t_gch.f_gchmch as f_name, ts_file_struct.f_data as f_data " +
                "from ts_file_struct,t_gch where ts_file_struct.f_id = '" + projectID
                + "' and ts_file_struct.f_id = t_gch.f_gchid and ts_file_struct.f_type = 0";
            DataTable table = m_database.QueryTable(sql);
            if (table.Rows.Count < 1)
            {
                return default(KeyValuePair<string, string>);
            }
            return new KeyValuePair<string, string>((string)table.Rows[0][0], (string)table.Rows[0][1]);
        }

        /// <summary>
        /// 插入工程
        /// </summary>
        /// <param name="projectID">工程标识</param>
        /// <param name="projectName">工程名称</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>影响行数</returns>
        public static int InsertProject(string projectID, string projectName, IDatabase database)
        {
            string sql = string.Format("insert into t_gch (f_gchid,f_gchmch,f_cjrq,f_cshid,f_pjtid,f_pgtid) values ('{0}','{1}','{2}','{3}',{4},{5})",
                projectID, projectName, DateTime.Now, "_0000_000000000000000000000000", 1, 1);
            return database.Execute(sql);            
        }

        /// <summary>
        /// 根据工程ID，修改工程名称
        /// </summary>
        /// <param name="projectID">工程标识</param>
        /// <param name="projectName">工程名称</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>影响行数</returns>
        public static int UpdateProjectNameByID(string projectID, string projectName, IDatabase database)
        {
            string sql = @"update t_gch set f_gchmch = '{1}' where f_gchid = '{0}'";

            return database.Execute(string.Format(sql, projectID, projectName));
        }

        /// <summary>
        /// 根据工程ID，删除工程
        /// </summary>
        /// <param name="projectID">工程ID</param>
        /// <param name="database"></param>
        /// <returns></returns>
        public static int DeleteProjectByID(string projectID, IDatabase database)
        {
            string sql = @" delete from t_gch where f_gchid = '{0}'";

            return database.Execute(string.Format(sql, projectID));
        }

        /// <summary>
        /// 获得最近访问的资源
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="recordCount">取记录的行数</param>
        /// <returns>结果集</returns>
        public static DataTable GetRecentResources(string userID, int recordCount)
        {
            string sql = @"select f_projectid, f_gchmch, f_recordtime
                            from
                            (
                            select ts_recent_projects.f_projectid,
                                    t_gch.f_gchmch,
                                    ts_recent_projects.f_recordtime
                            from ts_recent_projects
                            inner join t_gch on ts_recent_projects.f_projectid = t_gch.f_gchid
                            where ts_recent_projects.f_userid = '{0}'
                            order by ts_recent_projects.f_recordtime desc
                            ) as a limit {1}";

            return m_database.QueryTable(string.Format(sql, userID, recordCount));
        }

        /// <summary>
        /// 插入电网
        /// </summary>
        /// <param name="docID">电网标志</param>
        /// <param name="docName">电网名称</param>
        /// <param name="projectID">工程标识</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>指令</returns>
        public static int InsertDocument(string docID, 
            string docName, string projectID, IDatabase database)
        {
            string sql = string.Format("insert into t_subgch (f_subgchid,f_subgchtypeid,f_gchid,f_subgchname,f_tm,f_th,f_dq,f_sshgs,f_ghxzh,f_gchmch,f_xmbh,f_hzhr,f_pzhr,f_jhr,f_shhr,f_hzhrq,f_xmfzr,f_wtdw,f_hzhdw,f_wd,f_bz,f_sshgsid,f_ghxzhid,f_readonly,f_nf,f_maxid) "
                + "values ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',{19},'{20}',{21},{22},{23},{24},{25})",
                docID, 1, projectID, docName, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty
                , string.Empty, DateTime.Now, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0);
            return database.Execute(sql);
        }

        /// <summary>
        /// 根据文件ID，修改文件名称
        /// </summary>
        /// <param name="docID">电网标志</param>
        /// <param name="docName">电网名称</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>影响行数</returns>
        public static int UpdateDocumentNameByID(string docID, string docName, IDatabase database)
        {
            string sql = @" Update t_subgch set f_subgchname = '{1}' where f_subgchid = '{0}'";

            return database.Execute(string.Format(sql, docID, docName));
        }

        /// <summary>
        /// 根据工程ID，删除工程包含的文件
        /// </summary>
        /// <param name="projectID">工程ID</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>影响行数</returns>
        public static int DeleteDocumentByProjectID(string projectID, IDatabase database)
        {
            string sql = @" delete from t_subgch where f_gchid = '{0}'";

            return database.Execute(string.Format(sql, projectID));
        }

        /// <summary>
        /// 根据文件ID，删除文件数据
        /// </summary>
        /// <param name="documentID">文件ID</param>
        /// <param name="database">数据库操作者</param>
        /// <returns>影响行数</returns>
        public static int DeleteDocumentByID(string documentID, IDatabase database)
        {
            string sql = @" delete from t_subgch where f_subgchid = '{0}'";

            return database.Execute(string.Format(sql, documentID));
        }


        /// <summary>
        /// 根据文件ID，获得文件信息
        /// </summary>
        /// <param name="docID">文件ID</param>
        /// <returns></returns>
        public static DataTable GetDocumentInfoByID(string docID)
        { 
            string sql = @" select f_subgchid as f_documentID,
	                                f_gchid as f_projectID,
	                                f_subgchname as f_documentName
                                from t_subgch
                                where f_subgchid = '{0}'";
            return m_database.QueryTable(string.Format(sql, docID));
        }

        /// <summary>
        /// 插入工程结构
        /// </summary>
        /// <param name="projectID">工程标识</param>
        /// <param name="data">结构数据</param>
        /// <param name="database">结构数据</param>
        /// <returns>指令</returns>
        public static int InsertProjectStruct(string projectID, 
            string data, IDatabase database)
        {
            string sql = null;
            return database.Execute(sql);
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        /// <returns>资源信息表</returns>
        public static DataTable GetResourceInfo(string resourceID)
        {
            string sql = "select * from ts_resource where f_id = '" + resourceID + "'";
            return m_database.QueryTable(sql);
        }

        /// <summary>
        /// 是否包含某资源
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        /// <returns>是否包含</returns>
        public static bool ContainsResource(string resourceID)
        {
            return GetResourceInfo(resourceID).Rows.Count > 0;
        }

        /// <summary>
        /// 根据用户ID，获得该用户有签出项的工程 签出的可能是文件 也可能是工程，或者两者都有
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public static IEnumerable<string> GetSignOutItemProjectsByUserID(string userID)
        {
            string sql = @" select t_gch.f_gchid
                            from t_gch
                            inner join 
                            (
	                            select f_resourceid
	                            from ts_lock
	                            where f_userid = '{0}'
                            ) as a
                            on t_gch.f_gchid = a.f_resourceid
                            union
                            select t_subgch.f_gchid
                            from t_subgch
                            inner join 
                            (
	                            select f_resourceid
	                            from ts_lock
	                            where f_userid = '{0}'
                            ) as b
                            on  t_subgch.f_subgchid = b.f_resourceid";

            DataTable dbProject = m_database.QueryTable(string.Format(sql, userID));

            List<string> projects = new List<string>();

            foreach (DataRow dr in dbProject.Rows)
            {
                projects.Add(dr["f_gchid"].ToString());
            }

            return projects;
        }

        /// <summary>
        /// 是否包含该工程名称
        /// </summary>
        /// <param name="projectID">工程ID</param>
        /// <param name="projectName">工程名称</param>
        /// <returns>是否包含</returns>
        public static bool ContainsProjectName(string projectID, string projectName)
        {
            string sql = "select t_gch.f_gchmch from t_gch,ts_resource where t_gch.f_gchid = ts_resource.f_id and t_gch.f_gchmch = '" + projectName + "' and t_gch.f_gchid != '" + projectID + "'";
            return m_database.QueryTable(sql).Rows.Count > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public static DataTable GetDocumentInfo(string projectID)
        {
            string sql = "select f_subgchid as f_id,f_subgchname as f_name from t_subgch where f_gchid = '" + projectID + "'";
            return m_database.QueryTable(sql);
        }

        public static bool ContainsDocument(string projectID, string documentID, string docName)
        {
            string sql = "select f_subgchname from t_subgch where f_gchid = '"
                + projectID + "' and f_subgchname = '" + docName + "' and f_subgchid != '" + documentID + "'";
            return m_database.QueryTable(sql).Rows.Count > 0;
        }

        public static bool ContainsDocument(string docID)
        {
            return GetDocumentType(docID) > 0;
        }

        public static bool ProjectHasOwnSignOutDocument(string projectID, string userID)
        {
            string sql = @"select t_subgch.f_subgchid as f_id
                            from t_subgch
                            inner join ts_lock
                            on t_subgch.f_subgchid = ts_lock.f_resourceID
                            where t_subgch.f_gchid = '{0}' and ts_lock.f_userID = '{1}'";

            return m_database.QueryTable(string.Format(sql, projectID, userID)).Rows.Count > 0;
        }

        public static bool ProjectHasUnSignOutDocument(string projectID)
        {
            string sql = @"select t_subgch.f_subgchid as f_id
                            from t_subgch
                            left join ts_lock
                            on t_subgch.f_subgchid = ts_lock.f_resourceID
                            where t_subgch.f_gchid = '{0}' and  ts_lock.f_resourceID is null";

            return m_database.QueryTable(string.Format(sql, projectID)).Rows.Count > 0;
        }

        public static int GetDocumentType(string docID)
        {
            string sql = string.Format("select f_subgchtypeid from t_subgch where f_subgchid = '{0}'", docID);
            DataTable table = m_database.QueryTable(sql);
            if (table.Rows.Count < 1)
            {
                return -1;
            }
            return (int)table.Rows[0]["f_subgchtypeid"];
        }

        /// <summary>
        /// 得到图符表对象
        /// </summary>
        /// <param name="projectID">工程编号</param>
        /// <param name="documentID">电网编号</param>
        /// <param name="columnName">字段名称</param>
        /// <returns>对象</returns>
        public static object GetSymbolLib(string projectID, string documentID,string columnName)
        {
            object obj = null;
            if (!string.IsNullOrEmpty(projectID)
                && !string.IsNullOrEmpty(documentID)
                && !string.IsNullOrEmpty(columnName))
            {
                //string sql = string.Format("select {0} from tp_symbol where ");
                string sql = string.Format("select f_background from tp_symbol");
                obj = m_database.QueryScalar(sql);
            }
            return obj;
        }

        /// <summary>
        /// 新建配置表数据
        /// </summary>
        /// <param name="projectID">工程号</param>
        /// <param name="documentID">电网号</param>
        public static void CreateSymbolRecord(string projectID, string documentID)
        {
            if (!string.IsNullOrEmpty(projectID)
                && !string.IsNullOrEmpty(documentID))
            {
                string sql = string.Format(
                    "insert into tp_symbol(f_projectid,f_documentid) values ('{0}','{1}')", projectID, documentID);
                int result = m_database.Execute(sql);
            }
            else
            {
                throw new ArgumentNullException("projectID,documentID");
            }
        }

        /// <summary>
        /// 删除配置表数据
        /// </summary>
        /// <param name="projectID">工程号</param>
        /// <param name="documentID">电网号</param>
        public static void RemoveSymbolRecord(string projectID, string documentID)
        {
            if (!string.IsNullOrEmpty(projectID)
                && !string.IsNullOrEmpty(documentID))
            {
                string sql = string.Format(
                    "delete from tp_symbol where f_projectid='{0}' and f_documentid='{1}'", projectID, documentID);
                int result = m_database.Execute(sql);
            }
            else
            {
                throw new ArgumentNullException("projectID,documentID");
            }
        }

        /// <summary>
        /// 将登陆用户签出的工程和工程下文档签入
        /// </summary>
        /// <param name="projectID">工程ID</param>
        /// <param name="userID">用户ID</param>
        public static void UnlockProjectAndDocumentsByProjectID(string projectID, string userID)
        {
            string sql = @" delete
                            from ts_lock
                            where f_resourceid in 
                            (
	                            select f_subgchid as f_id
	                            from t_subgch
	                            where f_gchid = '{0}'
	                            union
	                            select f_gchid as f_id
	                            from t_gch
	                            where f_gchid = '{0}'
                            )
                            and f_userid = '{1}'";

            m_database.Execute(string.Format(sql, projectID, userID));
        }

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法

        /// <summary>
        /// 根据关键字获取计数
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>计数</returns>
        private static int Count(int key)
        {
            string sql = "select count(f_id) from ts_config_file where f_id = " + key;
            DataTable table = m_database.QueryTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        /// <summary>
        /// 根据文件名获取计数
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>计数</returns>
        private static int Count(string fileName)
        {
            string sql = "select count(f_id) from ts_config_file where f_filename = '" 
                + fileName + "' and f_projectid is NULL";
            DataTable table = m_database.QueryTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        /// <summary>
        /// 根据文件名、工程号获取计数
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="projectID">工程号</param>
        /// <returns>计数</returns>
        private static int Count(string fileName, string projectID)
        {
            if (string.IsNullOrWhiteSpace(projectID))
            {
                return Count(fileName);
            }
            string sql = "select count(f_id) from ts_config_file where f_filename = '"
                + fileName + "' and f_projectid = '" + projectID + "'";
            DataTable table = m_database.QueryTable(sql);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        #endregion // 私有方法

        #region 属性及其私有变量

        public static IDatabase Database
        {
            get
            {
                if (m_database == null)
                {
                    m_database = new PostgreSqlDatabase(ConfigurationManager.ConnectionStrings["postgres"].ToString());
                }
                return m_database;
            }
        }

        private static IDatabase m_database;

        #endregion // 属性及其私有变量

    }
}