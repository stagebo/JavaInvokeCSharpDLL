#region CLR版本 4.0.30319.225
// LevelValuePair 类
// 时间：2012-3-15 16:00:08
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
    public struct LevelValuePair : IOnLevel
    {
        public LevelValuePair(int level, object value)
        {
            m_level = level;
            m_value = value;
        }

        public static LevelValuePair New(int level, object value)
        {
            return new LevelValuePair(level, value);
        }

        public KeyValuePair<int, object> ToKeyValuePair()
        {
            return new KeyValuePair<int, object>(m_level, m_value);
        }

        public override string ToString()
        {
            return m_value == null ? "[" + m_level + ",Null]" :
                "[" + m_level + "," + m_value.ToString() + "]";
        }

        public int Level
        {
            get
            {
                return m_level;
            }
        }

        public object Value
        {
            get
            {
                return m_value;
            }
        }

        private int m_level;
        private object m_value;
    }

    public struct LevelValuePair<T> : IOnLevel
    {
        public LevelValuePair(int level, T value)
        {
            m_level = level;
            m_value = value;
        }

        public static LevelValuePair<T> New(int level, T value)
        {
            return new LevelValuePair<T>(level, value);
        }

        public KeyValuePair<int, T> ToKeyValuePair()
        {
            return new KeyValuePair<int, T>(m_level, m_value);
        }

        public override string ToString()
        {
            return m_value == null ? "[" + m_level + ",Null]" :
                "[" + m_level + "," + m_value.ToString() + "]";
        }

        public int Level
        {
            get
            {
                return m_level;
            }
        }

        public T Value
        {
            get
            {
                return m_value;
            }
        }

        private int m_level;
        private T m_value;
    }
}