#region CLR版本 4.0.30319.239
// DocInfo 类
// 时间：2012-4-18 11:39:28
// 名称：DocInfo
// 大纲：文档信息类
//
// 创建人：王津
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
using System.IO;

namespace TDQS.Contracts
{
    /// <summary>
    /// 文档信息类
    /// </summary>
    public class DocInfo
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public DocInfo()
        {
        }

        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 文档名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 文档路径名称(全名，包括文件名)
        /// </summary>
        public string PathFullName;

        /// <summary>
        /// 文档路径名
        /// </summary>
        public string PathName;

        /// <summary>
        /// 电网ID
        /// </summary>
        public string DWID;
        
        /// <summary>
        /// 电网名称
        /// </summary>
        public string DWName;

        /// <summary>
        /// 工程名称
        /// </summary>
        public string ProjectName;

        /// <summary>
        /// 工程ID
        /// </summary>
        public string ProjectID;

        /// <summary>
        /// 子系统规格
        /// </summary>
        public IShellSpec spec;

        /// <summary>
        /// 是否新建文件
        /// </summary>
        public bool flagCreateFile;

        /// <summary>
        /// 文件信息
        /// </summary>
        public FileInfo subSystemFile;

        #region 备份电网  张增平

        /// <summary>
        /// 是否正常关闭电网
        /// </summary>
        public bool IsExceptionClose;

        /// <summary>
        /// 备份电网ID列表
        /// </summary>
        public List<string> BackUpFiles;

        /// <summary>
        /// 累计活动时间
        /// </summary>
        public int SumSecounds;

        #endregion

        #endregion // 属性及其私有变量

    }
}