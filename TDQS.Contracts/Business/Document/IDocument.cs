#region CLR版本 4.0.30319.239
// IDocument 接口
// 时间：2011-11-23 14:08:59
// 名称：IDocument
// 大纲：文档类接口，所有文档类实现该接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2011/12/26 15:07:57, 刘东亮, 删除名称、路径、是否被编辑和是否激活的方法，保留名称、路径、是否被编辑和是否激活的属性
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;

namespace TDQS.Contracts
{
    /// <summary>
    /// 文档数据接口
    /// </summary>
    public interface IDocument : ISavable, ILockable
    {
        #region 方法
        /// <summary>
        /// 在视图列表中新增一个工作区对象
        /// </summary>
        /// <param name="view"></param>
        void AddView(IView view);
        /// <summary>
        /// 在视图列表中移除一个视图对象 
        /// </summary>
        /// <param name="view"></param>
        void RemoveView(IView view);
        /// <summary>
        /// 移除所有View对象
        /// </summary>
        void RemoveAllViews();
        /// <summary>
        /// 更新所有视图对象
        /// </summary>
        void UpdateAllViews();
        /// <summary>
        /// 获取当前激活的视图对象
        /// </summary>
        /// <returns></returns>
        IView GetActiveView();
        /// <summary>
        /// 根据名字查找视图
        /// </summary>
        /// <param name="viewname"></param>
        /// <returns></returns>
        IView FindView(string viewname);
        /// <summary>
        /// 文档对象初始化
        /// </summary>
        void Initialize();
        /// <summary>
        /// 初始化数据源
        /// </summary>
        void InitData();
        /// <summary>
        /// 关闭数据源
        /// </summary>
        void CloseData();
        /// <summary>
        /// 更新数据源
        /// </summary>
        void UpdateData();
        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        Boolean CopyData(DocInfo di);
        /// <summary>
        /// 激活某一个View
        /// </summary>
        /// <param name="view">view</param>
        void SetActiveView(IView view);
       
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 工程
        /// </summary>
        IProject Project { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        IShellSpec Spec { get; set; }
        /// <summary>
        /// 路径名
        /// </summary>
        string PathName { get; set; }
        /// <summary>
        /// 地图全路径
        /// </summary>
        string MapPath { get; }
        /// <summary>
        /// 是否被编辑
        /// </summary>
        bool Modified { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        bool Active { get; set; }
        /// <summary>
        /// 获取从属的视图队列
        /// </summary>
        ReadOnlyCollection<IView> Views { get; }

        /// <summary>
        /// 电网
        /// </summary>
        IElement ENetworkElement 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 数据库对象
        /// </summary>
        IDatabase Database 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 获取或设置文档只读属性
        /// </summary>
        Boolean ReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// 标注业务接口
        /// </summary>
        INoteBuilder NoteBuilder
        {
            get;
            set;
        }

        /// <summary>
        /// 文档信息
        /// </summary>
        DocInfo DocInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 文档管理器
        /// </summary>
        IDocManager DocManager
        {
            get;
            set;
        }


        /// <summary>
        /// 算法锁字典
        /// </summary>
        Dictionary<string,bool> AlgorLockerDic { get; set; }

        /// <summary>
        /// 电网级参数表ID
        /// 20140222 可靠性版本新增
        /// </summary>
        string ParameterID { get; set; } 

        #endregion // 属性
        
        #region 事件
 
        /// <summary>
        /// 文档被激活后触发该事件
        /// </summary>
        event ActiveEventHandler OnActive;
        /// <summary>
        /// 关闭数据源触发后触发该事件
        /// </summary>
        event CloseDataHandler OnCloseData;
        /// <summary>
        /// 更新数据源后触发该事件
        /// </summary>
        event UpdateDataHandler OnUpdateData;
        #endregion // 事件

    }
    /// <summary>
    /// 文档激活事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ActiveEventHandler(IDocument sender, EventArgs e);
    /// <summary>
    /// 关闭数据来源事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CloseDataHandler(IDocument sender, EventArgs e);
    /// <summary>
    /// 更新数据来源事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void UpdateDataHandler(IDocument sender, EventArgs e);

}

