#region CLR版本 4.0.30319.269
// IAuthorizeService 接口
// 时间：2012-9-6 15:04:22
// 名称：授权服务接口
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
using System.Linq;
using System.Text;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 授权服务接口
    /// </summary>
    public interface IAuthorizeService : IService
    {
        #region 方法

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns>用户对象模型</returns>
        bool Login();

        /// <summary>
        /// 登出
        /// </summary>
        void Logout();

        /// <summary>
        /// 枚举用户关联的可用功能资源
        /// </summary>
        /// <returns>资源集</returns>
        IEnumerable<IResource> EnumFunctionResources();

        /// <summary>
        /// 枚举用户关联的可用数据资源
        /// </summary>
        /// <returns>资源集</returns>
        IEnumerable<IResource> EnumDataResources();

        /// <summary>
        /// 管理组织
        /// </summary>
        void ManageOrganizations();

        /// <summary>
        /// 管理用户
        /// </summary>
        void ManageUsers();

        /// <summary>
        /// 管理角色
        /// </summary>
        void ManageRoles();

        /// <summary>
        /// 管理权限
        /// </summary>
        void ManagePermission();

        /// <summary>
        /// 管理操作
        /// </summary>
        void ManageOperations();

        /// <summary>
        /// 管理数据资源
        /// </summary>
        void ManageDataResources();

        /// <summary>
        /// 管理功能资源
        /// </summary>
        void ManageFunctionResources();

        /// <summary>
        /// 管理在线用户
        /// </summary>
        void ManageOnlineUsers();

        /// <summary>
        /// 查看登录日志
        /// </summary>
        void CheckLog();

        /// <summary>
        /// 展示资源结构
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        void ShowResourceStruct(string resourceID);

        /// <summary>
        /// 隐藏被选中的资源结构
        /// </summary>
        void HideSelectedResourceStruct();

        /// <summary>
        /// 展示结构视图
        /// </summary>
        /// <param name="state">展示状态</param>
        void ShowStructView(bool state);

        /// <summary>
        /// 添加数据资源
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        /// <param name="parentID">父级标识</param>
        /// <param name="database">数据库操作对象</param>
        void AddDataResource(string resourceID, string parentID, string resourceName, IDatabase database);

        /// <summary>
        /// 资源是否锁定
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        /// <returns></returns>
        bool IsResourceLock(string resourceID);

        /// <summary>
        /// 资源是否被自己占用
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        bool IsResourceOwnLock(string resourceID);

        /// <summary>
        /// 锁定资源
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        bool LockResource(string resourceID);

        /// <summary>
        /// 解锁资源
        /// </summary>
        /// <param name="resourceID"></param>
        /// <returns></returns>
        bool UnlockResource(string resourceID);

        /// <summary>
        /// 获取最近使用的资源
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        DataTable GetRecentResources(int recordCount);

        /// <summary>
        /// 查看工程中是否具有自己签出的资源
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        bool ProjectHasOwnSignOutDocument(string projectID);

        /// <summary>
        /// 展示被锁定资源清单
        /// </summary>
        void ShowLockedResourceList();

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="resourceID">资源标识</param>
        /// <returns>是否删除成功</returns>
        bool DropResource(string resourceID);

        /// <summary>
        /// 获取当前用户真实姓名
        /// </summary>
        /// <returns></returns>
        string GetCurrentUserRealName();

        /// <summary>
        /// 判断是否存在用户锁定的资源
        /// </summary>
        /// <returns></returns>
        bool IsUserLock();

        /// <summary>
        /// 解锁用户的所有锁定资源
        /// </summary>
        void UnlockUserAllResource();

        /// <summary>
        /// 获得有签出项的工程 签出的可能是文件 也可能是工程，或者两者都有
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetSignOutItemProjects();

        /// <summary>
        /// 释放所有关联资源
        /// </summary>
        /// <param name="projectID"></param>
        void UnlockProjectAndDocumentsByProjectID(string projectID);

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取即将被签出签入资源的标志
        /// </summary>
        string CheckedResourceID
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

