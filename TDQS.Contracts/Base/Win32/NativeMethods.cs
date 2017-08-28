using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TDQS.Win32
{
    /// <summary>
    /// Win32所提供的原始API方法集
    /// </summary>
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hWnd">窗体句柄</param>
        /// <param name="nCmdShow">显示类型</param>
        /// <returns>是否成功</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
       

        #region 全局原子操作
        [DllImport("kernel32.dll")]
        public static extern uint GlobalAddAtom(string lpString);
        [DllImport("kernel32.dll")]
        public static extern long GlobalGetAtomName(int atom, StringBuilder lpBuffer, int size);
        [DllImport("kernel32.dll")]
        public static extern uint GlobalFindAtom(string lpString);
        [DllImport("kernel32.dll")]
        public static extern uint GlobalDeleteAtom(uint nAtom);
        #endregion

        /// <summary>
        /// 释放场景
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int DeleteObject(System.IntPtr hObject);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst,
            ref SIZE psize, IntPtr hdcSrc, ref POINT pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);
  

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        /// <summary>
        /// 获取当前系统的用户名
        /// </summary>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll")]
        public static extern int GetUserName(StringBuilder lpBuffer, ref int nSize);

        /// <summary>
        /// 获取键盘状态
        /// </summary>
        /// <param name="vKey">键值</param>
        /// <returns>状态值</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetKeyState(int vKey);
        /// <summary>
        /// 指定的消息发送到一个或多个窗体，直到窗体程序处理完消息再返回
        /// </summary>
        /// <param name="hWnd">接收消息的窗体的句柄，如果此参数为hWnd_BROADCAST，则消息将被发送到系统中所有顶层窗体，
        /// 包括无效或不可见的非自身拥有的窗体和被覆盖的窗体以及弹出式窗体，但消息不被发送到子窗体</param>
        /// <param name="Msg">被发送的消息</param>
        /// <param name="wParam">附加消息</param>
        /// <param name="lParam">附加消息</param>
        /// <returns>消息处理的结果，依赖于被发送的消息</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        /// <summary>
        /// 获取窗体矩形
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <param name="lpRect">矩形</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int GetWindowRect(IntPtr hWnd, out RECT lpRect);


        /// <summary>
        /// 将一个消息寄送到与指定窗体创建的线程相联系消息队列里，不等待线程处理消息就返回，
        /// 消息队列里的消息通过调用GetMessage和PeekMessage取得
        /// </summary>
        /// <param name="hWnd">接收消息的窗体的句柄</param>
        /// <param name="Msg">被寄送的消息</param>
        /// <param name="wParam">附加消息</param>
        /// <param name="lParam">附加消息</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 获取屏幕坐标点处的窗体的句柄
        /// </summary>
        /// <param name="xPoint">横坐标</param>
        /// <param name="yPoint">纵坐标</param>
        /// <returns>窗体句柄值</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern int WindowFromPoint(int xPoint, int yPoint);
   }
}
