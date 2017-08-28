#region CLR版本 4.0.30319.239
// IToolObject 接口
// 时间：2011-11-8 16:24:40
// 名称：ToolObject
// 大纲：所有绘制对象操作接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 操作工具接口
    /// </summary>
    public interface IToolObject
    {

        #region 方法
        /// <summary>
        /// 激活当前工具
        /// </summary>
        /// <param name="aCanvas">画布</param>
        /// <param name="isPersistence">是否以连续的方式激活</param>
        /// <returns>指示是否成功激活</returns>
        bool Active(ICanvasView canvasView, bool isPersistence = false);

        /// <summary>
        /// 取消工具
        /// </summary>
        /// <returns>该工具是否已经被取消</returns>
        bool Cancel();

        /// <summary>
        ///  卸载工具
        /// </summary>
        /// <returns></returns>
        bool Deactive();


        #endregion // 公有方法

        #region 属性及其私有变量
        /// <summary>
        /// 是否已完成
        /// </summary>
        Boolean IsComplete
        {
            get;
        }
        /// <summary>
        /// 是否已激活
        /// </summary>
        Boolean IsActive
        {
            get;
        }

        /// <summary>
        /// 是否运行中（不可以中止、不可以撤销回退命令
        /// </summary>
        Boolean IsRunning
        {
            get;
        }
        /// <summary>
        /// 工具完成事件
        /// </summary>
        event EventHandler Done;

        /// <summary>
        /// 工具进行事件
        /// </summary>
        event EventHandler Doing;

        /// <summary>
        /// 工具开始事件
        /// </summary>
        event EventHandler Start;

        /// <summary>
        /// 是否以连续的方式激活
        /// </summary>
        bool IsPersistence
        {
            get;
            set;
        }
        #endregion // 属性及其私有变量

    }
}

