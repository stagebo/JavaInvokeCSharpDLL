#region CLR版本 4.0.30319.225
// NameValuePair 类
// 时间：2012-2-27 11:24:25
// 名称：名值对类型
// 大纲：用于存储名称和值的配对容器
//
// 创建人：郭威
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS
{
    /// <summary>
    /// 名值对类型，用于存储名称和值的配对容器
    /// </summary>
    public struct NameValuePair
    {
        #region 构造和析构

        /// <summary>
        /// 构造
        /// </summary>
        public NameValuePair(string name, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "名称不能为空。");
            }
            m_name = name;
            m_value = value;
        }

        #endregion // 构造和析构

        #region 公有方法

        /// <summary>
        /// 新建一个名值对
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static NameValuePair New(string name, object value)
        {
            return new NameValuePair(name, value);
        }

        /// <summary>
        /// 转化成键值对
        /// </summary>
        /// <returns>键值对</returns>
        public KeyValuePair<string, object> ToKeyValuePair()
        {
            return new KeyValuePair<string, object>(m_name, m_value);
        }   

        #endregion // 公有方法

        #region 保护方法
        #endregion // 保护方法

        #region 私有方法
        #endregion // 私有方法

        #region 属性及其私有变量

        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        public object Value
        {
            get
            {
                return m_value;
            }
        }

        //名称
        private string m_name;
        //值
        private object m_value;

        #endregion // 属性及其私有变量

    }
}