#region CLR版本 4.0.30319.239
// IProjectManager 接口
// 时间：2012/2/19 14:30:14
// 名称：管理系统打开的工程
// 大纲：
//
// 创建人：刘振伟
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2013-6-6     李睿      修改Bug NO.[Z34#-b-510]
//                          添加方法void ReleaseProject(IProject project);
// --------------------------------------------------------


#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 管理系统打开的工程
    /// </summary>
    public interface IProjectManager : IDisposable
    {
        #region 方法
        /// <summary>
        /// 设置工程为激活状态
        /// </summary>
        /// <param name="doc"></param>
        void SetActiveProject(IProject project);
        /// <summary>
        /// 建立一个工程对象
        /// </summary>
        /// <param name="DocName"></param>
        /// <returns></returns>
        IProject CreateProject(string PathName);

        /// <summary>
        /// 依据名称新建一个工程
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>工程对象</returns>
        IProject CreateProjectByName(string name);

        /// <summary>
        /// 建立一个工程对象
        /// </summary>
        /// <param name="PathName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        IProject CreateProject(string PathName, string ID);
        /// <summary>
        /// 添加一个已存在的工程对象
        /// </summary>
        /// <param name="doc"></param>
        void AddProject(IProject project);
        /// <summary>
        /// 通过工程名称判断是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool HasProject(string PathName);
        /// <summary>
        /// 通过工程名称查找工程
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        IProject FindProject(string pathName);
        /// <summary>
        /// 通过文档信息查找工程
        /// </summary>
        /// <param name="info">文档信息</param>
        /// <returns>工程对象</returns>
        IProject FindProject(DocInfo info);        
        /// <summary>
        /// 是否包含Document
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        bool HasDocument(string pathName);
		/// <summary>
		/// 查找包含CNPX的Document
		/// </summary>
		/// <param name="pathName"></param>
		/// <returns></returns>
		IDocument FindCNPXDocument(string FileExtetion);
        /// <summary>
        /// 查询Document
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        IDocument FindDocument(string pathName);
        /// <summary>
        /// 激活对应的Project
        /// </summary>
        /// <param name="pathName"></param>
        void SetActiveProject(string pathName);
        /// <summary>
        /// 激活对应的Document
        /// </summary>
        /// <param name="pathName"></param>
        void SetActiveDocument(string pathName);
        /// <summary>
        /// 关闭一个工程
        /// </summary>
        /// <param name="doc"></param>
        void CloseProject(IProject project);
        /// <summary>
        /// 释放一个工程
        /// </summary>
        /// <param name="project">工程</param>
        void ReleaseProject(IProject project);
        /// <summary>
        /// 关闭所有工程
        /// </summary>
        void CloseAllProjects();
        /// <summary>
        /// 获得当前激活的工程对象
        /// </summary>
        /// <returns></returns>
        IProject GetActiveProject();
        /// <summary>
        /// 移除一个工程
        /// </summary>
        /// <param name="project"></param>
        void RemoveProject(IProject project);
        
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取被管理的工程数量
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// 获取被管理的工程序列
        /// </summary>
        IEnumerable<IProject> Projects
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

