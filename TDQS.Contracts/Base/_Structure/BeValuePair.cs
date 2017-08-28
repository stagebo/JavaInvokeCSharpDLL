#region CLR版本 4.0.30319.225
// BeValuePair 类
// 时间：2012-3-21 11:17:36
// 名称：
// 大纲：
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
    public struct BeValuePair
    {
        public BeValuePair(bool be, object value)
        {
            m_be = be;
            m_value = value;
        }

        public static BeValuePair New(bool be, object value)
        {
            return new BeValuePair(be, value);
        }

        public KeyValuePair<bool, object> ToKeyValuePair()
        {
            return new KeyValuePair<bool, object>(m_be, m_value);
        }

        public override string ToString()
        {
            return m_value == null ? "[" + m_be.ToString() + ",Null]"
                : "[" + m_be.ToString() + "," + m_value.ToString() + "]";
        }

        public bool Be
        {
            get
            {
                return m_be;
            }
        }

        public object Value
        {
            get
            {
                return m_value;
            }
        }

        private bool m_be;
        private object m_value;
    }

    public struct BeValuePair<T>
    {
        public BeValuePair(bool be, T value)
        {
            m_be = be;
            m_value = value;
        }

        public static BeValuePair<T> New(bool be, T value)
        {
            return new BeValuePair<T>(be, value);
        }

        public KeyValuePair<bool, T> ToKeyValuePair()
        {
            return new KeyValuePair<bool, T>(m_be, m_value);
        }

        public override string ToString()
        {
            return m_value == null ? "[" + m_be.ToString() + ",Null]"
                : "[" + m_be.ToString() + "," + m_value.ToString() + "]";
        }

        public bool Be
        {
            get
            {
                return m_be;
            }
        }

        public T Value
        {
            get
            {
                return m_value;
            }
        }

        private bool m_be;
        private T m_value;
    }
}