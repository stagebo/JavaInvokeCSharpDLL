#region CLR版本 4.0.30319.239
// IWorkarea 接口
// 时间：2011-11-23 15:17:16
// 名称：IWorkarea
// 大纲：工作区接口，所有工作区实现该接口
//
// 创建人： 王津
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
    /// 视图接口，文档的一种展示方法
    /// </summary>
    public interface IView : IDockWindow
    {
        #region 方法

        /// <summary>
        /// 将该工作区绑定到一个文档对象上
        /// </summary>
        /// <param name="doc"></param>
        void BindDocument(IDocument doc);

        /// <summary>
        /// 返回当前文档对象
        /// </summary>
        /// <returns></returns>
        IDocument GetDocument();

        /// <summary>
        /// 应用文档对象更新工作区数据
        /// </summary>
        void UpdateData();

        /// <summary>
        /// 保存
        /// </summary>
        void Save();

        #endregion // 方法

        #region 属性

        /// <summary>
        /// 文档
        /// </summary>
        IDocument Document
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为文档的默认视图
        /// </summary>
        bool IsDefaultView 
        { 
            get; 
        }

        /// <summary>
        /// 获取或设置视图只读属性
        /// </summary>
        Boolean ReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置视图关闭方式
        /// </summary>
        ViewCloseMode CloseMode
        {
            get;
            set;
        }


        /// <summary>
        /// 是否激活视图
        /// </summary>
        bool Active
        {
            get;
            set;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

