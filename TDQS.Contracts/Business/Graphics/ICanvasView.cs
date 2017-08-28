#region CLR版本 4.0.30319.239
// ICanvasView 接口
// 时间：2011-12-6 13:25:08
// 名称：ICanvasView
// 大纲：画布视图
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//     日期		               修改人   描述
//1、2011年12月08日   孙书涛   增加对视野操作的定义
//2、2012年06月25日   孙书涛   增加分类选择操作的定义

#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace TDQS.Contracts
{
    /// <summary>
    /// 画布视图接口
    /// </summary>
    public interface ICanvasView : IView
    {
        #region 方法

        #region 视野

        /// <summary>
        /// 初始化视野管理
        /// </summary>
        void InitialVisionMng();

        /// <summary>
        /// 保存视野管理
        /// </summary>
        void SaveVisionMng();

        /// <summary>
        /// 显示前景视图
        /// </summary>
        /// <returns>是否包含前景</returns>
        bool Previous();

        /// <summary>
        /// 显示后景视图
        /// </summary>
        /// <returns>是否包含后景</returns>
        bool Next();

        /// <summary>
        /// 设置全景
        /// </summary>
        void FullExtent();

        /// <summary>
        /// 地图全景
        /// </summary>
        void FullMapExtent();

        /// <summary>
        /// 加载视野信息
        /// </summary>
        /// <returns></returns>
        bool LoadVisionInfo();

        #endregion

        #region 命令

        /// <summary>
        /// 改变大小命令，可由图形平台提供功能替代
        /// </summary>
        /// <param name="resizedItems"></param>
        /// <param name="old"></param>
        /// <param name="newP"></param>
        /// <param name="handle"></param>
        void ResizeCommand(IDrawObject resizedItems, PointF old, PointF newP, int handle);

        /// <summary>
        /// 移动命令，可由图形平台提供功能替代
        /// </summary>
        /// <param name="movedItemsList"></param>
        /// <param name="delta"></param>
        void MoveCommand(IList<object> movedItemsList, PointF delta);

        /// <summary>
        /// 根据实例名称获得对应的命令名称
        /// </summary>
        /// <param name="InstanceName">元件实例名称</param>
        /// <returns>命令名称</returns>
        string GetCommandName(string InstanceName);

        #endregion

        #region 工具

        /// <summary>
        /// 空操作
        /// </summary>
        void BlankTool(bool clearSelection=true);

        /// <summary>
        /// 剪切
        /// </summary>
        void CutTool();

        /// <summary>
        /// 移动
        /// </summary>
        void MoveTool();

        /// <summary>
        /// 拉伸
        /// </summary>
        void PathTool();

        /// <summary>
        /// 路径调整
        /// </summary>
        void PathChangeTool();

        /// <summary>
        /// 复制
        /// </summary>
        void CopyTool();

        /// <summary>
        /// 粘贴
        /// </summary>
        void PasteTool();

        /// <summary>
        /// 粘贴到原坐标
        /// </summary>
        void PasteToTool();


        /// <summary>
        /// 组合
        /// </summary>
        /// <param name="bUnGroup">是否取消</param>
        void GroupTool(bool bUnGroup = false);
        
        /// <summary>
        /// 删除
        /// </summary>
        void DeleteTool();

        /// <summary>
        /// 全选
        /// </summary>
        void SelectAllTool();

        /// <summary>
        /// 激活制定的操作工具
        /// </summary>
        /// <param name="aToolName">操作工具名</param>
        /// <param name="isPersistence">是否连续操作</param>
        void SequenceActiveTool(string aToolName, bool isPersistence = false);

        /// <summary>
        /// 激活制定的操作工具
        /// </summary>
        /// <param name="aTool">操作工具</param>
        /// <param name="isPersistence">是否连续</param>
        void SequenceActiveTool(IToolObject aTool, bool isPersistence = false);

        #endregion

        /// <summary>
        /// 获得模板对象
        /// </summary>
        /// <param name="tempID">模板ID</param>
        /// <returns></returns>
        object GetTempObj(string tempID);

        /// <summary>
        /// 激活子视图
        /// </summary>
        /// <param name="Sub">子网根对象</param>
        /// <returns>是否成功激活</returns>
        bool ActiveSubView(IElement Sub);

        /// <summary>
        /// 展示元件属性
        /// </summary>
        /// <param name="ele"></param>
        void ShowElementProperty(IElement ele);

        /// <summary>
        /// 显示注记
        /// </summary>
        void ShowNote();

        /// <summary>
        /// 已包含选择集
        /// </summary>
        /// <returns></returns>
        bool IsSelection();

        /// <summary>
        /// 导出CAD文件
        /// </summary>
        bool ExportDXF();

        /// <summary>
        /// 导出PIC文件
        /// </summary>
        /// <returns></returns>
        bool ExportPIC();
        
        /// <summary>
        /// 元件另存为模板
        /// </summary>
        /// <returns></returns>
        bool ElementSaveToTemplate();

        #region Renderable

        /// <summary>
        /// 对指定ID设置颜色
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <param name="color">颜色</param>
        void SetColor(ICollection<string> ids, System.Drawing.Color color);

        /// <summary>
        /// 对指定ID设置颜色
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <param name="color">颜色</param>
        /// <param name="isSetParentColor">是否对父设备染色</param>
        void SetColor(ICollection<string> ids, System.Drawing.Color color, bool isSetParentColor);

        /// <summary>
        /// 恢复默认样式
        /// </summary>
        void Recover();
        /// <summary>
        /// 恢复指定元件集合默认样式
        /// </summary>
        /// <param name="elements"></param>
        void Recover(List<IElement> elements);
        /// <summary>
        /// 刷新
        /// </summary>
        void Refresh();

        #endregion

        #region MapControlable

        #region 定位

        /// <summary>
        /// 元件ID定位
        /// </summary>
        /// <param name="ElementID">ID定位</param>
        void Locate(string ElementID, bool isAddSelection = true);

        /// <summary>
        /// 元件ID集合定位
        /// </summary>
        /// <param name="sIDCollection">ID集合</param>
        void Locate(ICollection<string> sIDCollection, bool isAddSelection = true);

        #endregion

        #region 闪烁

        /// <summary>
        /// 闪烁指定ID的实体
        /// </summary>
        /// <param name="id">待闪烁实体ID</param>
        /// <param name="nFlashes">闪烁次数</param>
        /// <param name="flashInterval">每次闪烁时间，单位为毫秒</param>
        void LocateAndFlash(string id, int nFlashes, int flashInterval);

        /// <summary>
        /// 闪烁指定ID的实体
        /// </summary>
        /// <param name="ids">待闪烁实体ID集合</param>
        /// <param name="nFlashes">闪烁次数</param>
        /// <param name="flashInterval">每次闪烁时间，单位为毫秒</param>
        void LocateAndFlash(ICollection<string> ids, int nFlashes, int flashInterval);

        #endregion

        #endregion

        #endregion // 方法

        #region 属性

        #region 元件

        /// <summary>
        /// 元件集合 (当前视图中的元件集合,如果是地理图为电网集合，如果是子图为子元件集合)
        /// </summary>
        IElementCollection ElementCollection 
        { 
            get; 
        }

        /// <summary>
        /// 元件处理对象
        /// </summary>
        IElementHandler ElementHandler 
        { 
            get; 
        }

        /// <summary>
        /// ToolBox中当前激活的元件原型
        /// </summary>
        string ActiveElement 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// ToolBox中当前激活的元件类型
        /// </summary>
        ElementType ActiveElementType 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// ToolBox中当前激活的元件实例ID
        /// </summary>
        string ActiveElementID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取该视图所对应的电网元件的起点
        /// </summary>
        IElement ViewRoot
        {
            get;
            set;
        }

        /// <summary>
        /// 创建元件
        /// </summary>
        IElementBuilder ElementBuilder
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// 获得或设置控件背景颜色
        /// </summary>
        Color BackGroundColor 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 画布
        /// </summary>
        ICanvas Canvas 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 撤销重做堆栈
        /// </summary>
        IUndoRedo UndoRedo 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 视野管理对象
        /// </summary>
        IVisionBusiness VisionMng 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 背景图管理对象
        /// </summary>
        IBackgroundBusiness BackgroundBusiness 
        { 
            get; 
            set; 
        }

        #region 工具

        /// <summary>
        /// 激活的Tool
        /// </summary>
        IToolObject ActiveTool 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 默认的指示器Tool
        /// </summary>
        IToolObject DefaultTool 
        { 
            get; 
            set; 
        }

        #endregion

        /// <summary>
        /// 画布视图显示类型
        /// </summary>
        CanvasViewOpenType CanvasViewOpenType 
        { 
            get; 
        }

        /// <summary>
        /// 当前视图视野名
        /// </summary>
        string CurrentVisionName
        {
            get;
            set;
        }

        #region 固定工具状态

        // TODO: Code Analysis Start(刘东亮 2012/10/26 16:38:46)
        // 类型: [违反扩展原则] 
        // 严重程度: [ 2 ] （1:非常严重  2:严重 3:一般） 
        // 详细说明:  
        // 这些bool值的含义，是否要在view上开放。           
        // ======================================================= 
        //  日期		   修改人	    	描述 

        /// <summary>
        /// 是否开启移动
        /// </summary>
        bool bMove
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可以粘贴
        /// </summary>
        bool bPaste
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可以粘贴到原坐标
        /// </summary>
        bool bPasteTo
        {
            get;
            set;
        }


        /// <summary>
        /// 是否可以拉伸
        /// </summary>
        bool bPath
        {
            get;
            set;
        }

 
        /// <summary>
        /// 路径调整
        /// </summary>
        bool bPathChange
        {
            get;
            set;
        }

        /// <summary>
        /// 是否开启连续删除模式
        /// </summary>
        bool bContinuateDelete
        {
            get;
            set;
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        bool bDelete
        {
            get;
            set;
        }

        /// <summary>
        /// 是否组合
        /// </summary>
        bool bGroup
        {
            get;
            set;
        }

        // Code Analysis End(刘东亮 2012/10/26 16:38:54)

        #endregion
       
        #region 分类选择

        /// <summary>
        /// 元件类型字典
        /// </summary>
        Dictionary<ElementType, string> ElementTypes
        {
            get;
        }

        /// <summary>
        /// 当前视图能被选择的元件类型
        /// </summary>
        List<ElementType> SelectedElementTypes
        {
            get;
            set;
        }

        /// <summary>
        /// 当前视图能被选择的元件类型
        /// </summary>
        ElementType SelectedElementType
        {
            get;
            set;
        }

        /// <summary>
        /// 元件选择方式
        /// </summary>
        FilerType ElementFilerType
        {
            get;
            set;
        }

        /// <summary>
        /// 过滤开关
        /// </summary>
        bool FilterSwitch
        {
            get;
            set;
        }

        /// <summary>
        /// tip显示开关
        /// </summary>
        bool TipDis
        {
            get;
            set;
        }
        
        #endregion

        /// <summary>
        /// 被选中的图元
        /// </summary>
        List<FeatureLite> SelectedFeatures
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示标注
        /// </summary>
        bool IsNoteShow
        {
            get;
            set;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

