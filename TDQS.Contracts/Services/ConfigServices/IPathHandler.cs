#region CLR版本 4.0.30319.239
// IPathServicesHandler 接口
// 时间：2011/11/16 10:43:52
// 名称：
// 大纲：
//
// 创建人：刘振伟
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
    /// 目录服务处理器
    /// </summary>
    public interface IPathHandler
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取基目录
        /// </summary>
        string BaseDirectory
        {
            get;
        }
        /// <summary>
        /// 配置文件路径
        /// </summary>
        string AppConfigPath
        {
            get;
        }
        /// <summary>
        /// 数据文件路径
        /// </summary>
        string AppDataPath
        {
            get;
        }
        /// <summary>
        /// 模板路径
        /// </summary>
        string AppTemplatePath
        {
            get;
        }
        /// <summary>
        /// 电网模板路径
        /// </summary>
        string AppDWTemplatePath
        {
            get;
        }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

