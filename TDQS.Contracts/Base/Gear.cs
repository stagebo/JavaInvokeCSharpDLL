#region CLR版本 4.0.30319.225
// Gear 类
// 时间：2011-11-26 17:24:58
// 名称：齿轮
// 大纲：一些具有普遍用途的处理方法集
//
// 创建人：郭威
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2012/02/22 孙书涛 增加SetProperty方法
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TDQS.Win32;

namespace TDQS
{
    /// <summary>
    /// 处理齿轮，一些具有普遍用途的处理方法集
    /// </summary>
    internal static class Gear
    {
        /// <summary>
        /// 枚举祖级类型
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <returns>祖级类型的遍历</returns>
        internal static IEnumerable<Type> SeekBaseType(this Type type)
        {
            if (type == null
                || type.BaseType == null)
            {
                yield break;
            }
            yield return type.BaseType;
            foreach (Type baseType in SeekBaseType(type.BaseType))
            {
                yield return baseType;
            }
        }

        /// <summary>
        /// 按类型创建对象实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="args">可能的参数</param>
        /// <returns>实例</returns>
        internal static object New(this Type type, object[] args)
        {
            try
            {
                return Activator.CreateInstance(
                type,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                Type.DefaultBinder,
                args,
                CultureInfo.CurrentCulture
                );
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 枚举是否被蕴含
        /// </summary>
        /// <param name="flag">枚举值</param>
        /// <param name="value">枚举值总集</param>
        /// <returns>是否蕴含</returns>
        internal static bool In(this Enum flag, Enum value)
        {
            return value.HasFlag(flag);
        }
        /// <summary>
        /// 枚举是否被蕴含
        /// </summary>
        /// <param name="flag">枚举值</param>
        /// <param name="value">枚举值总集的整数表示</param>
        /// <returns>是否蕴含</returns>
        internal static bool In(this Enum flag, int value)
        {
            return value.HasFlag(flag);
        }


        /// <summary>
        /// 一整数形式是否蕴含某枚举值
        /// </summary>
        /// <param name="value">整数形式</param>
        /// <param name="flag">枚举值</param>
        /// <returns>是否蕴含</returns>
        internal static bool HasFlag(this int value, Enum flag)
        {
            int test = ToInt(flag);
            return (value & test) == test;
        }

        /// <summary>
        /// 将枚举值转换成整数形式
        /// </summary>
        /// <param name="flag">枚举值</param>
        /// <returns>整数形式</returns>
        internal static int ToInt(this Enum flag)
        {
            object box = flag;
            return (int)box;
        }

        /// <summary>
        /// 整型转换为指针
        /// </summary>
        /// <param name="value">整型</param>
        /// <returns>指针</returns>
        internal static IntPtr ToPointer(this int value)
        {
            return new IntPtr(value);
        }


        /// <summary>
        /// 整数转换为布尔值
        /// </summary>
        /// <param name="value">整数</param>
        /// <returns>布尔值</returns>
        internal static bool ToBoolean(this int value)
        {
            if (value == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 深度获取对象字段值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="name">字段名称</param>
        /// <returns>字段值</returns>
        internal static object GetField(this object obj, string name)
        {
            if (obj == null
                || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            Type type = obj.GetType();
            FieldInfo info = type.GetField(name, BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Public);
            if (info != null)
            {
                return info.GetValue(obj);
            }
            foreach (Type baseType in type.SeekBaseType())
            {
                info = baseType.GetField(name, BindingFlags.Instance
                    | BindingFlags.NonPublic | BindingFlags.Public);
                if (info == null)
                {
                    continue;
                }
                return info.GetValue(obj);
            }
            return null;
        }

        internal static ToolStripPanelRow GetRow(this ToolStrip strip)
        {
            if (strip.Parent == null
                || !(strip.Parent is ToolStripPanel))
            {
                return null;
            }
            ToolStripPanel parent = strip.Parent as ToolStripPanel;
            return parent.PointToRow(strip.Location);
        }
        /// <summary>
        /// 判断键是否按下
        /// </summary>
        /// <param name="state">虚拟键值</param>
        /// <returns>是否按下</returns>
        internal static bool IsPressed(this VirtualKeyStates state)
        {
            return (NativeMethods.GetKeyState((int)state) & 0x80).ToBoolean();
        }

        internal static int IndexOf(this ToolStrip strip)
        {
            ToolStripPanelRow row = strip.GetRow();
            if (row == null)
            {
                return -1;
            }
            return Array.IndexOf(row.Controls, strip);
        }

        internal static bool IsLeftGapped(this ToolStripPanelRow row)
        {
            if (row.Controls.Length < 1)
            {
                return false;
            }
            if (row.Controls[0].Left > row.ToolStripPanel.RowMargin.Left)
            {
                return true;
            }
            for (int index = 1; index < row.Controls.Length; index++)
            {
                if (row.Controls[index - 1].Left
                    + row.Controls[index - 1].Width
                    != row.Controls[index].Left)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void CloseLeft(this ToolStripPanelRow row)
        {
            (row.Controls[row.Controls.Length - 1] as ToolStrip).CloseLeft();
        }

        internal static void CloseLeft(this ToolStrip strip)
        {
            int index = strip.RowOf();
            if (index < 0)
            {
                return;
            }
            ToolStripPanelRow row = strip.GetRow();
            if (row == null)
            {
                return;
            }
            index = strip.IndexOf();
            if (index == 0)
            {
                strip.Left = row.ToolStripPanel.RowMargin.Left;
                return;
            }
            int unit = row.Controls[index - 1].Width;
            int left = strip.Left;
            row.ToolStripPanel.SuspendLayout();
            while (true)
            {
                strip.Left -= unit;
                if (left == strip.Left)
                {
                    break;
                }
                left = strip.Left;
            }
            row.ToolStripPanel.ResumeLayout(false);
            row.ToolStripPanel.PerformLayout();
        }
        internal static int RowOf(this ToolStrip strip)
        {
            ToolStripPanelRow row = strip.GetRow();
            if (row == null)
            {
                return -1;
            }
            ToolStripPanel parent = strip.Parent as ToolStripPanel;
            ToolStripPanel.ToolStripPanelRowCollection rows =
                parent.GetProperty("RowsInternal") as ToolStripPanel.ToolStripPanelRowCollection;
            return rows.IndexOf(row);
        }

        /// <summary>
        /// 获取对象属性值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="name">属性名</param>
        /// <param name="index">可能的索引值</param>
        /// <returns>属性值</returns>
        internal static object GetProperty(this object obj, string name, object[] index = null)
        {
            if (obj == null
                || string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            Type type = obj.GetType();
            try
            {
                return type.InvokeMember(name, BindingFlags.GetProperty, null, obj, index);
            }
            catch
            {
                PropertyInfo info = type.GetProperty(name, BindingFlags.Instance
                    | BindingFlags.Public | BindingFlags.NonPublic);
                if (info != null)
                {
                    if (!info.CanRead)
                    {
                        return null;
                    }
                    return info.GetValue(obj, index);
                }
                foreach (Type baseType in type.SeekBaseType())
                {
                    info = baseType.GetProperty(name, BindingFlags.Instance
                        | BindingFlags.Public | BindingFlags.NonPublic);
                    if (info == null)
                    {
                        continue;
                    }
                    return info.GetValue(obj, index);
                }
                return null;
            }
        }
    }
}
