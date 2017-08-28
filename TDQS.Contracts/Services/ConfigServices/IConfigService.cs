#region CLR版本 4.0.30319.225
// IConfigService 接口
// 时间：2011-11-16 11:08:29
// 名称：配置服务
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 配置服务接口
    /// </summary>
    public interface IConfigService : IService
    {
        #region 方法
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取配置操作者
        /// </summary>
        IConfigHandler ConfigHandler
        {
            get;
        }

        /// <summary>
        /// 获取配置供应者
        /// </summary>
        IConfigProvider ConfigProvider
        {
            get;
        }

        /// <summary>
        /// 获取目录处理器
        /// </summary>
        IPathHandler PathHandler
        {
            get; 
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

