#region CLR版本 4.0.30319.269
// SubSystem 类
// 时间：2012-5-16 15:43:17
// 名称：SubSystem 类
// 大纲：子系统类，负责存储子系统全局对象
//
// 创建人：王津
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;


namespace TDQS.Contracts
{
    /// <summary>
    /// 子系统类，负责存储子系统全局对象
    /// </summary>
    public abstract class SubSystem
    {
        // TODO: Code Analysis Start(刘东亮 2012/10/24 16:27:36) (激活)
        // 类型: [流程可优化，代码结构混乱] 
        // 严重程度: [ 1  ] （1:非常严重  2:严重 3:一般） 
        // 详细说明:  
        // 1、明确IShellSpec与SubSystem的关系，1对1，subsystem记录ishellspec由构造传入，去除subsystem中的ishellspec属性定义
        // 2、Subsystem与工厂的关系方法整理，工厂不得的工具栏等对象，有subsystem间接访问
        // 3、Subsystem提供数据由MainShell访问操作
        // ======================================================= 
        //  日期		   修改人	    	描述 
        
        // Code Analysis End(刘东亮 2012/10/24 16:27:39)
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public SubSystem(SubSystemFactory subSystemFactory, IShellSpec spec)
        {
            m_SubSystemFactory = subSystemFactory;
            m_spec = spec;            
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
        /// 子系统名称
        /// </summary>
        private string m_Name;

        /// <summary>
        /// 子系统工厂
        /// </summary>
        protected SubSystemFactory m_SubSystemFactory = null;

        /// <summary>
        /// 壳
        /// </summary>
        private Shell m_Shell = null;

        /// <summary>
        /// 壳
        /// </summary>
        public Shell shell
        {
            get
            {
                return m_Shell;
            }
            set
            {
                m_Shell = value;
            }
        }

        /// <summary>
        /// 子系统名称(缩写，对应路径)
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        /// <summary>
        /// 子系统工厂
        /// </summary>
        public SubSystemFactory SubSystemFactory
        {
            get
            {
                return m_SubSystemFactory;
            }
        }

        /// <summary>
        /// 获取对应的子系统规格
        /// </summary>
        public IShellSpec Spec
        {
            get
            {
                return m_spec;
            }
        }

        /// <summary>
        /// 内部寄存的子系统规格
        /// </summary>
        private IShellSpec m_spec;

        /// <summary>
        /// 属性联动类
        /// </summary>
        public virtual ITriggerManager TriggerManager
        {
            get
            {
                return m_triggerManager;
            }
        }

        /// <summary>
        /// 属性联动类
        /// </summary>
        protected ITriggerManager m_triggerManager;

        #endregion // 属性及其私有变量
    }
}