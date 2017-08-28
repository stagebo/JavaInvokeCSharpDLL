#region CLR版本 4.0.30319.269
// IProjectManagerFrm 接口
// 时间：2012-5-17 8:51:03
// 名称：IProjectManagerFrm
// 大纲：工程管理器窗体
//
// 创建人：王津
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 工程管理器窗体接口
    /// </summary>
    public interface IProjectManagerFrm
    {
        #region 方法
        /// <summary>
        ///打开工程
        /// </summary>
        /// <param name="projectFile">工程文件</param>
        IProject OpenProject(string projectFile);

        /// <summary>
        /// 打开子系统文件
        /// </summary>
        /// <param name="subFile">子系统文件</param>
        void OpenFile(string subFile);

        /// <summary>
        /// 新建工程
        /// </summary>
        /// <param name="fileName">工程文件名</param>
        /// <param name="specs">规格集</param>
        void NewFile(string fileName, IEnumerable<IShellSpec> specs);

        /// <summary>
        /// 新建子系统文件
        /// </summary>
        /// <param name="fileName">工程文件名</param>
        /// <param name="spec">子系统规格</param>
        /// <param name="initialName">初始名称</param>
        void NewFile(string fileName, IShellSpec spec, string initialName);

        /// <summary>
        /// 新建子系统文件
        /// </summary>
        /// <param name="project">工程对象</param>
        /// <param name="spec">子系统规格</param>
        /// <param name="initialName">初始名称</param>
        void NewFile(IProject project, IShellSpec spec, string initialName);

        /// <summary>
        /// 关闭工程
        /// </summary>
        /// <param name="fileName">文件名称</param>
        void CloseFile(string fileName);

        /// <summary>
        /// 另存文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        void SaveAsFile(string fileName);

        /// <summary>
        /// 另存文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        void SaveAsENet(string fileName);

        /// <summary>
        /// 打开历史备份电网
        /// 作者：张增平
        /// </summary>
        /// <param name="Project">当前工程</param>
        /// <param name="OrgCnpFilePath">原始电网路径</param>
        /// <param name="itemName">备份电网名称</param>
        /// <param name="itemCode">备份电网标识</param>
        /// <param name="itemPath">备份电网路径</param>
        void OpenBackUpFile(String specId, IProject Project, string OrgCnpFilePath, string itemName, string itemCode, string itemPath);

        /// <summary>
        /// 检查是否可以打开
        /// </summary>
        /// <param name="ErrorMessage">错误信息</param>
        /// <returns>返回是否可以打开</returns>
        bool canOpen(out string ErrorMessage);

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取被选中的工程项
        /// </summary>
        IProject SelectedProject
        {
            get;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

