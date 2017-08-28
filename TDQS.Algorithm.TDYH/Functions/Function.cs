#region CLR版本 4.0.30319.239
// Function 类
// 时间：2014/2/14 9:16:09
// 名称：为可靠性计算相关功能提供入口
// 大纲：为可靠性计算相关功能提供入口
//
// 创建人：聂桂春
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.ComponentModel.Composition;
using TDQS.Contracts;
using System.Collections;

namespace TDYH
{
    /// <summary>
    /// 为可靠性计算相关功能提供入口
    /// </summary>
    //public static class Function
    //{

    //    #region 公有方法


    //    /// <summary>
    //    /// 启动可靠性计算设置
    //    /// </summary>
    //    /// <param name="sub">子系统</param>
    //    //[Export(typeof(Action<SubSystem>))]
    //    //[CommandMetadata(ID = 640031, EnableFunction = "IfEView", NameSpace = "TDYH")]
    //    public static void TDYH(SubSystem sub)
    //    {
    //        //测试停电优化
    //        //IProject project = sub.shell.ProjectManager.CurrentProject;
    //        //if (project == null)
    //        //{
    //        //    return;
    //        //}
    //        //TDYHDecorator tdyh = new TDYHDecorator();
    //        //tdyh.Do(XSystem.UserName, "_AAAA_201708230445411000000");
    //        return;

    //    }


    //    #endregion // 公有方法

    //    #region 保护方法
    //    #endregion // 保护方法

    //    #region 私有方法

    //    #endregion // 私有方法

    //    #region 属性及其私有变量
    //    #endregion // 属性及其私有变量

    //}
}