#region CLR版本 4.0.30319.225
// IDocManager 接口
// 时间：2012-2-15 11:01:40
// 名称：IDocManager
// 大纲：文档管理
//
// 创建人：刘振伟
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 20120509 王津        重构名称等
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 文档/视图管理器
    /// </summary>
    public interface IDocManager
    {
        #region 方法

        /// <summary>
        /// 打开当前的Document对象
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        IDocument OpenDocument(IProject Project,string pathName);

        /// <summary>
        /// Document另存为
        /// </summary>
        /// <param name="olddi">旧的文档信息</param>
        /// <param name="newdi">新的文档信息</param>
        /// <returns></returns>
        Boolean SaveAsDocument(DocInfo  olddi, DocInfo newdi);

        /// <summary>
        /// 打开电网
        /// </summary>
        /// <param name="shell">系统框架</param>
        /// <param name="fileName">电网文件</param>
        /// <param name="viewType">视图类型</param>
        /// <returns>是否打开</returns>
        Boolean OpenView(Shell shell, string fileName, String viewType);

        /// <summary>
        /// 创建视图
        /// </summary>
        /// <param name="viewName">视图名称</param>
        /// <param name="sub">子元件</param>
        /// <returns>视图</returns>
        IView CreateView(string viewName, IElement sub = null);

        /// <summary>
        /// 创建视图
        /// </summary>
        /// <param name="doc">文档对象</param>
        /// <param name="viewName">视图名称</param>
        /// <param name="sub">子元件</param>
        /// <returns>视图</returns>
        IView CreateView(IDocument doc, string ViewName, IElement Sub = null);

        #endregion // 方法

        /// <summary>
        /// 销毁
        /// </summary>
        void Dispose();

        /// <summary>
        /// 通过文档名称判断是否存在
        /// </summary>
        /// <param name="titlename"></param>
        /// <returns></returns>
        bool HasDocument(string PathName);


        /// <summary>
        /// 通过文档后缀来找是否有相同类型的文档
        /// </summary>
        /// <param name="titlename"></param>
        /// <returns></returns>
        IDocument FindCNPXDocument(string fileExtenion);

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool SaveDocument(string fileName);

        /// <summary>
        /// 增加一个文档
        /// </summary>
        /// <param name="doc">文档</param>
        void AddDocument(IDocument doc);

        /// <summary>
        /// 设置文档为激活状态
        /// </summary>
        /// <param name="doc"></param>
        void SetActiveDocument(IDocument doc);

          /// <summary>
        /// 通过文档名称查找文档
        /// </summary>
        /// <param name="titlename"></param>
        /// <returns></returns>
        IDocument FindDocument(string titlename);


        /// <summary>
        /// 关闭一个文档
        /// </summary>
        /// <param name="doc"></param>
        void CloseDocument(IDocument doc);

        /// <summary>
        /// 关闭工程所有文档
        /// </summary>
        void CloseProjectDocuments(IProject Project);

        /// <summary>
        /// 保存工程所有文档
        /// </summary>
        void SaveProjectDocuments(IProject Project);

        /// <summary>
        /// 关闭所有文档
        /// </summary>
        void CloseAllDocuments();

        /// <summary>
        /// 保存所有文档
        /// </summary>
        void SaveAllDocuments();

        /// <summary>
        /// 移除文档
        /// </summary>
        /// <param name="doc"></param>
        void RemoveDocument(IProject project,IDocument doc);

        /// <summary>
        /// 获得当前激活的文档对象
        /// </summary>
        /// <returns></returns>
        IDocument GetActiveDocument();

        /// <summary>
        /// 获得当前激活的工作区对象 
        /// </summary>
        /// <returns></returns>
        IView GetActiveView();

        /// <summary>
        /// 不选中所有文档
        /// </summary>
        void UnselectAllDocument();

        #region 属性

        /// <summary>
        /// 已打开文档列表
        /// </summary>
        List<IDocument> OpenedDocuments { get; }

        /// <summary>
        /// 是否全部保存
        /// </summary>
        bool IsSaved { get; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        bool Locked { get; }

        #endregion // 属性

        #region 事件 /// <summary>

        /// <summary>
        /// 保存文档后触发该事件
        /// </summary>
        event SaveDocumentEventHandler SavedDocument;

        /// <summary>
        /// 关闭文档后触发该事件
        /// </summary>
        event CloseEventHandler ClosedDocument;

        #endregion // 事件
    }

    /// 新建文档事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CreateDocumentEventHandler(IDocument sender, EventArgs e);

    /// <summary>
    /// 打开文档事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OpenDocumentEventHandler(IDocument sender, EventArgs e);

    /// <summary>
    /// 保存文档事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SaveDocumentEventHandler(IDocument sender, EventArgs e);

    /// <summary>
    /// 关闭文档事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CloseEventHandler(IDocument sender, EventArgs e);
      
}

