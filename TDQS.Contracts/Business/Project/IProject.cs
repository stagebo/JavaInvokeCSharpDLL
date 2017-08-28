#region CLR版本 4.0.30319.239
// IProjectFactory 接口
// 时间：2011-11-25 9:41:13
// 名称：IProjectFactory
// 大纲：工程工厂接口, 负责创建于管理Doc/View结构
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
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
    /// 工程接口，包含文档
    /// </summary>
    public interface IProject : ISavable, ILockable
    {
        #region 方法

        /// <summary>
        /// 绑定一个文档管理器
        /// </summary>
        /// <param name="key"></param>
        void BindDocManager(string key);

        /// <summary>
        /// 建立一个文档对象
        /// </summary>
        /// <param name="pathName">文档路径</param>
        /// <param name="name">文档名称</param>
        /// <param name="spec">文档类型信息</param>
        /// <param name="tempPath">模板路径</param>
        /// <returns>文档对象</returns>
        DocInfo CreateDocInfo(string pathName, String name, IShellSpec spec, string tempPath="");

  
        /// <summary>
        /// 返回文档信息
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        DocInfo FindDocInfo(string pathName);

        /// <summary>
        /// 移除绑定文档信息
        /// </summary>
        /// <param name="info"></param>
        void RemoveDocInfo(DocInfo info);

        /// <summary>
        /// 获得当前激活的工作区对象 
        /// </summary>
        /// <returns></returns>
        IView GetActiveView();

        /// <summary>
        /// 刷新参数
        /// </summary>
        void RefreshParms();

        /// <summary>
        /// 验证电网数据是否有效
        /// </summary>
        /// <param name="pathName">文档路径</param>
        /// <returns>是否有效</returns>
        bool ValidateDocumentData(string pathName);

        /// <summary>
        /// 获得当前激活的文档对象
        /// </summary>
        /// <returns></returns>
        IDocument GetActiveDocument();

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取唯一识别编号
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// 参数ID
        /// </summary>
        string ParmsId { get; set; }

        /// <summary>
        /// 工程名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 工程创建日期
        /// </summary>
        System.Nullable<System.DateTime> CreateDate { get; set; }

        /// <summary>
        /// 工程当前判据套ID
        /// </summary>   
        int PJTId { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// 路径名
        /// </summary>
        string PathName { get; set; }

        /// <summary>
        /// 工程下的电网集合(只读)
        /// </summary>   
        List<IElement> ENetworkElements { get; }

        // Start Bug No.[        ]  (李睿 2013/7/15 14:18:55) [质检提测]
        // 问题描述:  
        //            
        // 修改说明:  
        //            
        // ======================================================= 

        /// <summary>
        /// 获取已经打开的文档列表
        /// </summary>
        List<IDocument> OpenedDocuments { get; }

        // End Bug No.[        ] (李睿 2013/7/15 14:19:06)

        /// <summary>
        /// 获取文件集
        /// </summary>
        IEnumerable<DocInfo> Documents { get; }
        /// <summary>
        /// 当前激活文档信息
        /// </summary>
        DocInfo DocInfo { get; set; }

        /// <summary>
        /// 数据库对象
        /// </summary>
        IDatabase database { get; set; }

        /// <summary>
        /// 工程级Session
        /// 聂桂春20121120增加
        /// </summary>
        IORMSessionDecorator Session { get; }


        /// <summary>
        /// 文档管理器
        /// </summary>
        IDocManager DocManager { get; }

        #endregion // 属性

        #region 事件

        /// <summary>
        /// 激活状态改变
        /// </summary>
        event EventHandler ActivedStateChanged;

        /// <summary>
        /// 工程保存完成
        /// </summary>
        event EventHandler Saved;
        #endregion // 事件
    }
   
}

