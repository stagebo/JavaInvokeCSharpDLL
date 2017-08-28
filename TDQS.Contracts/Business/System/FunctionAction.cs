#region CLR版本 4.0.30319.269
// FunctionAction 类
// 时间：2012-5-16 17:03:49
// 名称：FunctionAction
// 大纲：功能执行动作
//
// 创建人：王津
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

namespace TDQS.Contracts
{
    /// <summary>
    /// 功能执行动作
    /// </summary>
    public sealed class FunctionAction
    {
        #region 构造和析构

        /// <summary>
        ///构造
        /// </summary>
        /// <param name="funcStruct">功能的数据结构</param>
        public FunctionAction(FunctionStruct funcStruct)
        {
            m_funcStruct = funcStruct;
        }
        
        #endregion // 构造和析构

        #region 公有方法
        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量
        /// <summary>
        /// 功能数据结构
        /// </summary>
        private FunctionStruct m_funcStruct;

        /// <summary>
        /// 功能数据结构
        /// </summary>
        public FunctionStruct FuncStruct
        {
            get
            {
                return m_funcStruct;
            }
        }
        #endregion // 属性及其私有变量

    }

    /// <summary>
    /// 功能类型枚举
    /// </summary>
    public enum FunctionType
    {
        Category,
        Item
    }
    
    #region  Struct
    /// <summary>
    /// 功能数据结构
    /// </summary>
    public struct FunctionStruct
    {
        /// <summary>
        /// 动作
        /// </summary>
        public Action<SubSystem> Action;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 工具栏所在行号
        /// </summary>
        public int Row;
        /// <summary>
        /// 类型
        /// </summary>
        public FunctionType Type;

        /// <summary>
        /// 子系统
        /// </summary>
        public SubSystem SubSystem;

        /// <summary>
        /// 功能名称
        /// </summary>
        public string FuntionText;

        /// <summary>
        /// 处理者 (菜单或者工具栏项)
        /// </summary>
        public object Handler;

        /// <summary>
        /// Check处理方法名
        /// </summary>
        public string CheckFunction;

        /// <summary>
        /// Enable处理方法名
        /// </summary>
        public string EnableFunction;

        /// <summary>
        /// Visible处理方法名
        /// </summary>
        public string VisibleFunction;

        /// <summary>
        /// 处理方法所在的命名空间
        /// </summary>
        public string Namespace;

        /// <summary>
        /// 双击处理方法名
        /// </summary>
        public string DBClickFunction;

        /// <summary>
        /// 快捷键定义
        /// </summary>
        public string ShortcutKey;

        /// <summary>
        /// 快捷命令定义
        /// </summary>
        public string ShortcutCommand;

        /// <summary>
        /// 是否为全局性热键
        /// </summary>
        public bool GlobalShortcut;
    }

    #endregion
}