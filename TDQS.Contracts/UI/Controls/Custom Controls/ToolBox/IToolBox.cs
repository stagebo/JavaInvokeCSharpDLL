#region CLR版本 4.0.30319.239
// IToolBox 接口
// 时间：2011-11-28 10:37:39
// 名称：工具箱
// 大纲：实现工具箱控件
//
// 创建人：夏禹
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TDQS.Contracts
{
	/// <summary>
	/// IToolBox 接口
	/// </summary>
	public interface IToolBox
	{
		#region 方法

		/// <summary>
		/// 保存工具箱配置
		/// </summary>
		/// <param name="path">配置文件路径</param>
		void SaveConfig(string path = null);
		
		/// <summary>
		/// 刷新工具箱界面
		/// </summary>
		/// <param name="path">配置文件路径</param>
		void RebuildControl(string path = null);

        /// <summary>
        /// 保存所有打开的工具的箱配置
        /// </summary>
        void SaveAllConfig();

        /// <summary>
        /// 刷新所有打开的工具的界面
        /// </summary>
        void RebuildAllControl();

		/// <summary>
		/// 移除项目
		/// </summary>
		/// <param name="ID">项目ID</param>
		void RemoveItem(string ID);

        /// <summary>
        /// 移除项目(包括所有子配置文件)
        /// </summary>
        /// <param name="ID">项目ID</param>
        void RemoveItemCascade(string ID);

        /// <summary>
        /// 保存项目（若项目不存在则添加， 包括所有子配置文件）
        /// </summary>
        /// <param name="item">待保存的项目</param>
        /// <param name="bandID">项目将被加入到哪个分组下</param>
        /// <param name="errText">错误提示信息</param>
        /// <param name="checkNameUnique">是否检查名字唯一性</param>
        /// <returns>保存是否成功</returns>
        bool SaveItemCascade(IToolBoxItem item, string bandID, out string errText, bool checkNameUnique = false);

        /// <summary>
        /// 获取一个工具箱项目
        /// </summary>
        /// <param name="ID">项目ID</param>
        /// <returns>工具箱项目</returns>
        IToolBoxItem GetItem(string ID);

        /// <summary>
        /// 保存项目（若项目不存在则添加）
        /// </summary>
        /// <param name="item">待保存的项目</param>
        /// <param name="bandID">项目将被加入到哪个分组下，若添加分组则该参数被忽略</param>
        /// <returns>保存是否成功</returns>
        bool SaveItem(IToolBoxItem item, string bandID);

        /// <summary>
        /// 得到工具箱的新实例
        /// </summary>
        /// <returns>工具箱的新实例</returns>
        IToolBox GetNewInstance();

        /// <summary>
        /// 更新缓存数据
        /// </summary>
        /// <param name="item"></param>
        /// <param name="bandID"></param>
        void UpdateCache(IToolBoxItem item, string bandID);

		#endregion // 方法

		#region 属性
		/// <summary>
		/// 获取控件基类
		/// </summary>
		UserControl Control 
		{
			get; 
		}

		/// <summary>
		/// 改变视图
		/// </summary>
		ToolBoxViewState View
		{
			get;
			set;
		}

		/// <summary>
		/// 图标方式
		/// </summary>
		ToolBoxIconView IconView
		{
			get;
			set;
		}

		/// <summary>
		/// 工具箱项目集合
		/// </summary>
		ToolBoxItemCollection Items
		{
			get;
		}

        /// <summary>
        /// 配置文件路径
        /// </summary>
        string ConfigPath
        {
            get;
        }

        /// <summary>
        /// 激活或置灰元件列表
        /// </summary>
        bool EnableList
        {
            get;
            set;
        }

        /// <summary>
        /// Emf文件路径
        /// </summary>
        string EmfRootPath
        {
            get;
            set;
        }

		#endregion // 属性

		#region 事件
		#endregion // 事件
	}

	/// <summary>
	/// 工具箱视图枚举
	/// </summary>
	public enum ToolBoxViewState
	{
        /// <summary>
        /// 通常视图
        /// </summary>
		Normal = 0,

        /// <summary>
        /// 树视图
        /// </summary>
		Tree
	}

	/// <summary>
	/// 工具箱图表枚举
	/// </summary>
	public enum ToolBoxIconView
	{
        /// <summary>
        /// 16 * 16
        /// </summary>
		Small = 0,

        /// <summary>
        /// 32 * 32
        /// </summary>
		Big
	}
}

