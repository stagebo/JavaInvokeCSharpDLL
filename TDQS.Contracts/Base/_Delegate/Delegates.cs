#region CLR版本 4.0.30319.225
// 委托集
// 时间：2011-11-16 11:33:27
// 名称：TDQS顶端委托集
// 大纲：为TDQS工具提供常见委托集
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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TDQS
{
    /// <summary>
    /// 值对照委托
    /// </summary>
    /// <typeparam name="T">值类型</typeparam>
    /// <param name="x">一个对象</param>
    /// <param name="y">一个对象</param>
    public delegate void Link<T>(T x, T y);
    public delegate bool MessageFilter(ref Message m);
    public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    /// <summary>
    /// 自生行为
    /// </summary>
    /// <returns>自生物</returns>
    public delegate object Autogeny();
    /// <summary>
    /// 自生行为
    /// </summary>
    /// <typeparam name="T">自生物类型</typeparam>
    /// <returns>自生物</returns>
    public delegate T Autogeny<out T>();
    /// <summary>
    /// 检索委托
    /// </summary>
    /// <typeparam name="TSite">场所类型</typeparam>
    /// <typeparam name="TIndex">索引类型</typeparam>
    /// <typeparam name="TResult">检索结果</typeparam>
    /// <param name="site">被检索的场所</param>
    /// <param name="index">索引</param>
    /// <returns>检索结果</returns>
    public delegate TResult Seeker<TSite, TIndex, TResult>(TSite site, TIndex index);
   
    public delegate int Comparison(object x, object y);
    /// <summary>
    /// 阅读
    /// </summary>
    /// <param name="obj">阅读对象</param>
    /// <returns>被阅读的文本</returns>
    public delegate string Reading(object obj);
    /// <summary>
    /// 事件泛型委托
    /// </summary>
    /// <typeparam name="TSender">事件发起者类型</typeparam>
    /// <typeparam name="TEventArgs">参数类型</typeparam>
    /// <param name="sender">事件发起者</param>
    /// <param name="e">事件参数</param>
    public delegate void EventHandler<TSender, TEventArgs>(TSender sender, TEventArgs e)
    where TEventArgs : EventArgs;
    /// <summary>
    /// 延迟回调
    /// </summary>
    /// <param name="state">状态值</param>
    public delegate void DelayCallback(object state);

    /// <summary>
    /// 异常回调
    /// </summary>
    /// <param name="exception">异常值</param>
    public delegate void ExceptionCallback(Exception exception);

    /// <summary>
    /// 项目事件委托
    /// </summary>
    /// <typeparam name="T">项目类型</typeparam>
    /// <param name="sender">事件发起者</param>
    /// <param name="e">项目事件参数</param>
    public delegate void ItemEventHandler<T>(object sender, ItemEventArgs<T> e);

    /// <summary>
    /// 匹配性判定委托
    /// </summary>
    /// <param name="x">一个对象</param>
    /// <param name="y">另一个对象</param>
    /// <returns>是否匹配</returns>
    public delegate bool Contrast(object x, object y);
    /// <summary>
    /// 匹配性判定委托
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="x">一个对象</param>
    /// <param name="y">另一个对象</param>
    /// <returns>是否匹配</returns>
    public delegate bool Contrast<T>(T x, T y);

    /// <summary>
    /// 装配工
    /// </summary>
    /// <typeparam name="T">产品类型</typeparam>
    /// <param name="args">装配原件</param>
    /// <returns>产品</returns>
    public delegate T Assembler<out T>(params object[] args);

    /// <summary>
    /// 同类原件装配工
    /// </summary>
    /// <typeparam name="TInput">原件类型</typeparam>
    /// <typeparam name="TOutput">产品类型</typeparam>
    /// <param name="args">装配原件</param>
    /// <returns>产品</returns>
    public delegate TOutput Assembler<in TInput, out TOutput>(params TInput[] args);


    /// <summary>
    /// 监视器泛型委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MonitorEventHandler<T>(object sender, MonitorEventArgs<T> e);
}
