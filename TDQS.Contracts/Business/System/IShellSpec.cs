#region CLR版本 4.0.30319.225
// IShellSpec 接口
// 时间：2011-12-12 9:41:53
// 名称：壳规格
// 大纲：
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.Drawing;
using System.ComponentModel.Composition;

namespace TDQS.Contracts
{
    /// <summary>
    /// 壳规格
    /// </summary>
    public interface IShellSpec
    {
        #region 方法
        #endregion // 方法

        #region 属性

        /// <summary>
        /// 获取组件目录
        /// </summary>
        string ComponentsDirectory
        {
            get;
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 获取简称
        /// </summary>
        string ShortName
        {
            get;
        }

        /// <summary>
        /// 获取图标
        /// </summary>
        Icon Icon
        {
            get;
        }

        /// <summary>
        /// 获取小图标
        /// </summary>
        Image SmallIcon
        {
            get;
        }

        /// <summary>
        /// 获取大图标
        /// </summary>
        Image LargeIcon 
        { 
            get;
        }

        /// <summary>
        /// 获取许可图标
        /// </summary>
        Image UnbanIcon
        {
            get;
        }

        /// <summary>
        /// 获取禁止图标
        /// </summary>
        Image BanIcon
        {
            get;
        }

		/// <summary>
		/// 当前地区
		/// </summary>
		string Area
		{
			get;
			set;
		}

		/// <summary>
		/// 当前年份
		/// </summary>
		uint Year
		{
			get;
			set;
		}

        /// <summary>
        /// 获取默认文档名称
        /// </summary>
        string DefaultDocName 
        {
            get; 
        }

        /// <summary>
        /// 获取近期文档记录路径
        /// </summary>
        string RecentFilesRecord
        {
            get;
        }

        /// <summary>
        /// 获取适应的文件扩展名
        /// </summary>
        string FileExtension
        {
            get;
        }

        /// <summary>
        /// 获取支持的格式
        /// </summary>
        string[] SupportedFormats
        {
            get;
        }

        /// <summary>
        /// 获取或设置适合的文件扩展名
        /// </summary>
        string SpecVersion { get; }

        /// <summary>
        /// 系统模板路径
        /// </summary>
        string AppTemplatePath
        {
            get;
        }

        /// <summary>
        /// 系统类型
        /// </summary>
        byte SubgchtypeID
        {
            get;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }

    /// <summary>
    /// 壳规格元数据
    /// </summary>
    [MetadataAttribute]
    public class ShellSpecMetadata : Attribute
    {
        /// <summary>
        /// 获取或设置组件目录
        /// </summary>
        public string ComponentsDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置简称
        /// </summary>
        public string ShortName
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置图标
        /// </summary>
        public Icon Icon
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置小图标
        /// </summary>
        public Image SmallIcon
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置大图标
        /// </summary>
        public Image LargeIcon
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置许可图标
        /// </summary>
        public Image UnbanIcon
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置禁止图标
        /// </summary>
        public Image BanIcon
        {
            get;
            set;
        }

		/// <summary>
		/// 当前地区
		/// </summary>
		public string Area
		{
			get;
			set;
		}

		/// <summary>
		/// 当前年份
		/// </summary>
		public int Year
		{
			get;
			set;
		}

        /// <summary>
        /// 获取或设置默认文档名称
        /// </summary>
        public string DefaultDocName
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置近期文档记录路径
        /// </summary>
        public string RecentFilesRecord
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置适合的文件扩展名
        /// </summary>
        public string FileExtension
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置支持的格式
        /// </summary>
        public string[] SupportedFormats
        {
            get;
            set;
        }

        /// <summary>
        /// 子系统编号
        /// </summary>
        public long ID
        {
            get;
            set;
        }

    }

    /// <summary>
    /// 壳规格元数据View
    /// </summary>
    public interface IShellSpecMetadataView
    {
        /// <summary>
        /// 获取或设置组件目录
        /// </summary>
        string ComponentsDirectory { get; }
        /// <summary>
        /// 获取或设置名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 获取或设置简称
        /// </summary>
        string ShortName { get; }
        /// <summary>
        /// 获取或设置图标
        /// </summary>
        Icon Icon { get; }
        /// <summary>
        /// 获取或设置小图标
        /// </summary>
        Image SmallIcon { get; }
        /// <summary>
        /// 获取或设置大图标
        /// </summary>
        Image LargeIcon { get; }
        /// <summary>
        /// 获取许可图标
        /// </summary>
        Image UnbanIcon { get; }
        /// <summary>
        /// 获取禁止图标
        /// </summary>
        Image BanIcon { get; }
		/// <summary>
		/// 当前地区
		/// </summary>
		string Area
		{
			get;
			//set;
		}
		/// <summary>
		/// 当前年份
		/// </summary>
		int Year
		{
			get;
			//set;
		}
        /// <summary>
        /// 获取默认文档名称
        /// </summary>
        string DefaultDocName { get; }
        /// <summary>
        /// 获取近期文档记录路径
        /// </summary>
        string RecentFilesRecord { get; }
        /// <summary>
        /// 获取适合的文件扩展名
        /// </summary>
        string FileExtension { get; }
        /// <summary>
        /// 获取支持的格式
        /// </summary>
        string[] SupportedFormats { get; }
        /// <summary>
        /// 子系统编号
        /// </summary>
        long ID { get; }
      }
}

