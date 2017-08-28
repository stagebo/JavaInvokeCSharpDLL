using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Win32
{
    public static class CONST
    {
        #region AC
        /// <summary>
        /// currentlly defined blend function.
        /// </summary>
        public const byte AC_SRC_OVER = 0x00;
        /// <summary>
        /// alpha format flags.
        /// </summary>
        public const byte AC_SRC_ALPHA = 0x01;
        #endregion

        #region ASFW
        public const int ASFW_ANY = -1;
        #endregion

        #region CDDS
        public const int CDDS_PREPAINT = 0x00000001;
        public const int CDDS_POSTPAINT = 0x00000002;
        public const int CDDS_PREERASE = 0x00000003;
        public const int CDDS_POSTERASE = 0x00000004;
        // the 0x000010000 bit means it's individual item specific
        public const int CDDS_ITEM = 0x00010000;
        public const int CDDS_ITEMPREPAINT = (CDDS_ITEM | CDDS_PREPAINT);
        public const int CDDS_ITEMPOSTPAINT = (CDDS_ITEM | CDDS_POSTPAINT);
        public const int CDDS_ITEMPREERASE = (CDDS_ITEM | CDDS_PREERASE);
        public const int CDDS_ITEMPOSTERASE = (CDDS_ITEM | CDDS_POSTERASE);

#if (_WIN32_IE0400) //>= 0x0400
        public const int CDDS_SUBITEM = 0x00020000;
#endif
        #endregion

        #region CDRF
        public const int CDRF_DODEFAULT = 0x0;
        public const int CDRF_NEWFONT = 0x2;
        public const int CDRF_SKIPDEFAULT = 0x4;
        public const int CDRF_NOTIFYPOSTPAINT = 0x10;
        public const int CDRF_NOTIFYITEMDRAW = 0x20;

#if (_WIN32_IE0400) //>= 0x0400
        public const int CDRF_NOTIFYSUBITEMDRAW = 0x20; // flags are the same, we can distinguish by context
#endif
        public const int CDRF_NOTIFYPOSTERASE = 0x40;
        public const int CDRF_NOTIFYITEMERASE = 0x80;
        #endregion

        #region GWL
        public const int GWL_WNDPROC = -4;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        #endregion

        #region HWND
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;
        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        #endregion

        #region ICC
        /// <summary>
        /// listview, header
        /// </summary>
        public const int ICC_LISTVIEW_CLASSES = 0x00000001;

        /// <summary>
        /// treeview, tooltips
        /// </summary>
        public const int ICC_TREEVIEW_CLASSES = 0x00000002;

        /// <summary>
        /// 注册工具栏、状态栏、Trackbar和Tooltip类。
        /// </summary>
        public const int ICC_BAR_CLASSES = 0x00000004;

        /// <summary>
        /// tab, tooltips
        /// </summary>
        public const int ICC_TAB_CLASSES = 0x00000008;

        /// <summary>
        /// updown
        /// </summary>
        public const int ICC_UPDOWN_CLASS = 0x00000010;

        /// <summary>
        /// progress
        /// </summary>
        public const int ICC_PROGRESS_CLASS = 0x00000020;

        /// <summary>
        /// hotkey
        /// </summary>
        public const int ICC_HOTKEY_CLASS = 0x00000040;

        /// <summary>
        /// animate
        /// </summary>
        public const int ICC_ANIMATE_CLASS = 0x00000080;

        public const int ICC_WIN95_CLASSES = 0x000000FF;

        /// <summary>
        /// month picker, date picker, time picker, updown
        /// </summary>
        public const int ICC_DATE_CLASSES = 0x00000100;

        /// <summary>
        /// comboex
        /// </summary>
        public const int ICC_USEREX_CLASSES = 0x00000200;

        /// <summary>
        ///注册Rebar类。
        /// </summary>
        public const int ICC_COOL_CLASSES = 0x00000400;

#if (_WIN32_IE0400) //>= 0x0400)
        public const int ICC_INTERNET_CLASSES = 0x00000800;

        /// <summary>
        /// page scroller
        /// </summary>
        public const int ICC_PAGESCROLLER_CLASS = 0x00001000;

        /// <summary>
        /// native font control
        /// </summary>
        public const int ICC_NATIVEFNTCTL_CLASS = 0x00002000;
#endif

#if (_WIN32_WINNT501)  //>= 0x501
        public const int ICC_STANDARD_CLASSES = 0x00004000;
        public const int ICC_LINK_CLASS = 0x00008000;
#endif
        #endregion

        #region LPSTR
        public static readonly IntPtr LPSTR_TEXTCALLBACK = (-1).ToPointer();
        #endregion

        public static readonly IntPtr TRUE = (1).ToPointer();
        public static readonly IntPtr FALSE = (0).ToPointer();
        public const int HOVER_SIGNALED = 3;
        public const int FADER_SIGNALED = 6;
        public const int TIMER_FADE = 77;

        #region MA
        public const uint MA_ACTIVATE = 1;
        public const uint MA_ACTIVATEANDEAT = 2;
        public const uint MA_NOACTIVATE = 3;
        public const uint MA_NOACTIVATEANDEAT = 4;
        #endregion

        #region MF
        public const int MF_BYPOSITION = 0x0400;
        public const int MF_REMOVE = 0x1000;
        #endregion

        #region NM
        public const int NM_FIRST = 0;
        public const int NM_OUTOFMEMORY = (NM_FIRST - 1);
        public const int NM_CLICK = (NM_FIRST - 2);    // uses NMCLICK struct
        public const int NM_DBLCLK = (NM_FIRST - 3);
        public const int NM_RETURN = (NM_FIRST - 4);
        public const int NM_RCLICK = (NM_FIRST - 5);    // uses NMCLICK struct
        public const int NM_RDBLCLK = (NM_FIRST - 6);
        public const int NM_SETFOCUS = (NM_FIRST - 7);
        public const int NM_KILLFOCUS = (NM_FIRST - 8);
        public const int NM_CUSTOMDRAW = (NM_FIRST - 12);

#if (_WIN32_IE0300) //>= 0x0300
        public const int NM_CUSTOMDRAW = (NM_FIRST-12);
        public const int NM_HOVER = (NM_FIRST-13);
#endif

#if (_WIN32_IE0400) //>= 0x0400
        public const int NM_NCHITTEST = (NM_FIRST-14);   // uses NMMOUSE struct
        public const int NM_KEYDOWN  = (NM_FIRST-15);   // uses NMKEY struct
        public const int NM_RELEASEDCAPTURE = (NM_FIRST-16);
        public const int NM_SETCURSOR = (NM_FIRST-17);   // uses NMMOUSE struct
        public const int NM_CHAR = (NM_FIRST-18);   // uses NMCHAR struct
#endif

#if (_WIN32_IE0401) //>= 0x0401
        public const int NM_TOOLTIPSCREATED = (NM_FIRST-19);   // notify of when the tooltips window is create
#endif

#if (_WIN32_IE0500) //>= 0x0500
        public const int NM_LDOWN = (NM_FIRST-20);
        public const int NM_RDOWN = (NM_FIRST-21);
        public const int NM_THEMECHANGED = (NM_FIRST-22);
#endif
        #endregion

        #region SW
        public const int SW_HIDE = 0; //隐藏窗口，活动状态给另一个窗口 
        /// <summary>
        /// 用原来的大小和位置显示一个窗口，同时令其进入活动状态
        /// </summary>
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4; //用最近的大小和位置显示一个窗口，同时不改变活动窗口
        public const int SW_SHOW = 5;//用当前的大小和位置显示一个窗口，同时令其进入活动状态
        public const int SW_MINIMIZE = 6;//最小化窗口，活动状态给令一个窗口
        public const int SW_SHOWMINNOACTIVE = 7;//最小化一个窗口，同时不改变活动窗口
        public const int SW_SHOWNA = 8;//用当前的大小和位置显示一个窗口，不改变活动窗口
        public const int SW_RESTORE = 9; //与 SW_SHOWNORMAL  1 相同
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_MAX = 11;
        #endregion

        #region SWP
        public const uint SWP_NOSIZE = 0x0001;
        public const uint SWP_NOMOVE = 0x0002;
        public const uint SWP_NOZORDER = 0x0004;
        public const uint SWP_NOREDRAW = 0x0008;
        public const uint SWP_NOACTIVATE = 0x0010;
        public const uint SWP_FRAMECHANGED = 0x0020;//The frame changed: send WM_NCCALCSIZE
        public const uint SWP_SHOWWINDOW = 0x0040;
        public const uint SWP_HIDEWINDOW = 0x0080;
        public const uint SWP_NOCOPYBITS = 0x0100;
        public const uint SWP_NOOWNERZORDER = 0x0200;//Don't do owner Z ordering
        public const uint SWP_NOSENDCHANGING = 0x0400;//Don't send WM_WINDOWPOSCHANGING

        public const uint SWP_DRAWFRAME = SWP_FRAMECHANGED;
        public const uint SWP_NOREPOSITION = SWP_NOOWNERZORDER;

#if(WINVER0400) //>= 0x0400
        public const uint SWP_DEFERERASE = 0x2000;
        public const uint SWP_ASYNCWINDOWPOS = 0x4000;
#endif
        #endregion

        #region TTDT
        public const int TTDT_AUTOMATIC = 0;
        public const int TTDT_RESHOW = 1;
        public const int TTDT_AUTOPOP = 2;
        public const int TTDT_INITIAL = 3;
        #endregion

        #region TTF
        public const int TTF_IDISHWND = 0x0001;
        // Use this to center around trackpoint in trackmode
        // -OR- to center around tool in normal mode.
        // Use TTF_ABSOLUTE to place the tip exactly at the track coords when
        // in tracking mode.  TTF_ABSOLUTE can be used in conjunction with TTF_CENTERTIP
        // to center the tip absolutely about the track point.
        public const int TTF_CENTERTIP = 0x0002;
        public const int TTF_RTLREADING = 0x0004;
        public const int TTF_SUBCLASS = 0x0010;
        public const int TTF_TRACK = 0x0020;
        public const int TTF_ABSOLUTE = 0x0080;
        public const int TTF_TRANSPARENT = 0x0100;
        public const int TTF_PARSELINKS = 0x1000;
        public const int TTF_DI_SETITEM = 0x8000;// valid only on the TTN_NEEDTEXT callback
        #endregion

        #region TTI
        // ToolTip Icons possible wParam values for TTM_SETTITLE message.

        public const int TTI_NONE = 0;
        public const int TTI_INFO = 1; //(32512)
        public const int TTI_WARNING = 2;
        public const int TTI_ERROR = 3;

        //// values larger thant TTI_ERROR are assumed to be an HICON value
        public const int TTI_INFO_LARGE = 4;
        public const int TTI_WARNING_LARGE = 5;
        public const int TTI_ERROR_LARGE = 6;
        #endregion

        #region TTM
        public const int TTM_ACTIVATE = (WM_USER + 1);
        public const int TTM_SETDELAYTIME = (WM_USER + 3);
        public const int TTM_RELAYEVENT = (WM_USER + 7);
        public const int TTM_GETTOOLCOUNT = (WM_USER + 13);
        public const int TTM_WINDOWFROMPOINT = (WM_USER + 16);
        public const int TTM_TRACKACTIVATE = (WM_USER + 17);
        public const int TTM_TRACKPOSITION = (WM_USER + 18);
        public const int TTM_SETTIPBKCOLOR = (WM_USER + 19);
        public const int TTM_SETTIPTEXTCOLOR = (WM_USER + 20);
        public const int TTM_GETDELAYTIME = (WM_USER + 21);
        public const int TTM_GETTIPBKCOLOR = (WM_USER + 22);
        public const int TTM_GETTIPTEXTCOLOR = (WM_USER + 23);
        public const int TTM_SETMAXTIPWIDTH = (WM_USER + 24);
        public const int TTM_GETMAXTIPWIDTH = (WM_USER + 25);
        public const int TTM_SETMARGIN = (WM_USER + 26);
        public const int TTM_GETMARGIN = (WM_USER + 27);
        public const int TTM_POP = (WM_USER + 28);
        public const int TTM_UPDATE = (WM_USER + 29);
        public const int TTM_POPUP = (WM_USER + 34);
        public const int TTM_ADJUSTRECT = (WM_USER + 31);
        // ansi
        public const int TTM_ADDTOOLA = (WM_USER + 4);
        public const int TTM_DELTOOLA = (WM_USER + 5);
        public const int TTM_NEWTOOLRECTA = (WM_USER + 6);
        public const int TTM_GETTOOLINFOA = (WM_USER + 8);
        public const int TTM_SETTOOLINFOA = (WM_USER + 9);
        public const int TTM_HITTESTA = (WM_USER + 10);
        public const int TTM_GETTEXTA = (WM_USER + 11);
        public const int TTM_UPDATETIPTEXTA = (WM_USER + 12);
        public const int TTM_GETCURRENTTOOLA = (WM_USER + 15);
        public const int TTM_ENUMTOOLSA = (WM_USER + 14);
        public const int TTM_SETTITLEA = (WM_USER + 32);
        // unicode
        public const int TTM_ADDTOOLW = (WM_USER + 50);
        public const int TTM_DELTOOLW = (WM_USER + 51);
        public const int TTM_NEWTOOLRECTW = (WM_USER + 52);
        public const int TTM_GETTOOLINFOW = (WM_USER + 53);
        public const int TTM_SETTOOLINFOW = (WM_USER + 54);
        public const int TTM_HITTESTW = (WM_USER + 55);
        public const int TTM_GETTEXTW = (WM_USER + 56);
        public const int TTM_UPDATETIPTEXTW = (WM_USER + 57);
        public const int TTM_ENUMTOOLSW = (WM_USER + 58);
        public const int TTM_GETCURRENTTOOLW = (WM_USER + 59);
        public const int TTM_SETTITLEW = (WM_USER + 33);
        #endregion

        #region TTN
        public const int TTN_FIRST = (-520);
        public const int TTN_GETDISPINFOA = (TTN_FIRST - 0);
        public const int TTN_GETDISPINFOW = (TTN_FIRST - 10);
        public const int TTN_SHOW = (TTN_FIRST - 1);
        public const int TTN_POP = (TTN_FIRST - 2);
        public const int TTN_LINKCLICK = (TTN_FIRST - 3);
        public const int TTN_NEEDTEXTA = TTN_GETDISPINFOA;
        public const int TTN_NEEDTEXTW = TTN_GETDISPINFOW;
        public const int TTN_LAST = (-549);
        #endregion

        #region TTS
        public const int TTS_ALWAYSTIP = 0x01;
        public const int TTS_NOPREFIX = 0x02;
        public const int TTS_NOANIMATE = 0x10;
        public const int TTS_NOFADE = 0x20;
        public const int TTS_BALLOON = 0x40;
        public const int TTS_CLOSE = 0x80;
        public const int TTS_USEVISUALSTYLE = 0x100;
        #endregion

        #region WA
        public const int WA_INACTIVE = 0;
        public const int WA_ACTIVE = 1;
        public const int WA_CLICKACTIVE = 2;
        #endregion

        #region WS
        public const int WS_OVERLAPPED = 0x00000000;
        public const int WS_POPUP = unchecked((int)0x80000000);
        public const int WS_CHILD = 0x40000000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_DISABLED = 0x08000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_MAXIMIZE = 0x01000000;
        public const int WS_CAPTION = 0x00C00000;
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;
        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_MAXIMIZEBOX = 0x00010000;
        public const int WS_TILED = WS_OVERLAPPED;
        public const int WS_ICONIC = WS_MINIMIZE;
        public const int WS_SIZEBOX = WS_THICKFRAME;
        public const int WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;
        public const int WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU |
                                WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX);
        public const int WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU);
        public const int WS_CHILDWINDOW = (WS_CHILD);
        #endregion

        #region WS_EX
        public const int WS_EX_DLGMODALFRAME = 0x00000001;
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_ACCEPTFILES = 0x00000010;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_MDICHILD = 0x00000040;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_WINDOWEDGE = 0x00000100;
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        public const int WS_EX_CONTEXTHELP = 0x00000400;
        public const int WS_EX_RIGHT = 0x00001000;
        public const int WS_EX_LEFT = 0x00000000;
        public const int WS_EX_RTLREADING = 0x00002000;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        public const int WS_EX_CONTROLPARENT = 0x00010000;
        public const int WS_EX_STATICEDGE = 0x00020000;
        public const int WS_EX_APPWINDOW = 0x00040000;
        public const int WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
        public const int WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
        public const int WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
        public const int WS_EX_COMPOSITED = 0x02000000;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        #endregion

        #region SPI
        public const int
        SPI_GETBEEP = 0x0001,
        SPI_SETBEEP = 0x0002,
        SPI_GETMOUSE = 0x0003,
        SPI_SETMOUSE = 0x0004,
        SPI_GETBORDER = 0x0005,
        SPI_SETBORDER = 0x0006,
        SPI_GETKEYBOARDSPEED = 0x000A,
        SPI_SETKEYBOARDSPEED = 0x000B,
        SPI_LANGDRIVER = 0x000C,
        SPI_ICONHORIZONTALSPACING = 0x000D,
        SPI_GETSCREENSAVETIMEOUT = 0x000E,
        SPI_SETSCREENSAVETIMEOUT = 0x000F,
        SPI_GETSCREENSAVEACTIVE = 0x0010,
        SPI_SETSCREENSAVEACTIVE = 0x0011,
        SPI_GETGRIDGRANULARITY = 0x0012,
        SPI_SETGRIDGRANULARITY = 0x0013,
        SPI_SETDESKWALLPAPER = 0x0014,
        SPI_SETDESKPATTERN = 0x0015,
        SPI_GETKEYBOARDDELAY = 0x0016,
        SPI_SETKEYBOARDDELAY = 0x0017,
        SPI_ICONVERTICALSPACING = 0x0018,
        SPI_GETICONTITLEWRAP = 0x0019,
        SPI_SETICONTITLEWRAP = 0x001A,
        SPI_GETMENUDROPALIGNMENT = 0x001B,
        SPI_SETMENUDROPALIGNMENT = 0x001C,
        SPI_SETDOUBLECLKWIDTH = 0x001D,
        SPI_SETDOUBLECLKHEIGHT = 0x001E,
        SPI_GETICONTITLELOGFONT = 0x001F,
        SPI_SETDOUBLECLICKTIME = 0x0020,
        SPI_SETMOUSEBUTTONSWAP = 0x0021,
        SPI_SETICONTITLELOGFONT = 0x0022,
        SPI_GETFASTTASKSWITCH = 0x0023,
        SPI_SETFASTTASKSWITCH = 0x0024,
        SPI_SETDRAGFULLWINDOWS = 0x0025,
        SPI_GETDRAGFULLWINDOWS = 0x0026,
        SPI_GETNONCLIENTMETRICS = 0x0029,
        SPI_SETNONCLIENTMETRICS = 0x002A,
        SPI_GETMINIMIZEDMETRICS = 0x002B,
        SPI_SETMINIMIZEDMETRICS = 0x002C,
        SPI_GETICONMETRICS = 0x002D,
        SPI_SETICONMETRICS = 0x002E,
        SPI_SETWORKAREA = 0x002F,
        SPI_GETWORKAREA = 0x0030,
        SPI_SETPENWINDOWS = 0x0031,
        SPI_GETHIGHCONTRAST = 0x0042,
        SPI_SETHIGHCONTRAST = 0x0043,
        SPI_GETKEYBOARDPREF = 0x0044,
        SPI_SETKEYBOARDPREF = 0x0045,
        SPI_GETSCREENREADER = 0x0046,
        SPI_SETSCREENREADER = 0x0047,
        SPI_GETANIMATION = 0x0048,
        SPI_SETANIMATION = 0x0049,
        SPI_GETFONTSMOOTHING = 0x004A,
        SPI_SETFONTSMOOTHING = 0x004B,
        SPI_SETDRAGWIDTH = 0x004C,
        SPI_SETDRAGHEIGHT = 0x004D,
        SPI_SETHANDHELD = 0x004E,
        SPI_GETLOWPOWERTIMEOUT = 0x004F,
        SPI_GETPOWEROFFTIMEOUT = 0x0050,
        SPI_SETLOWPOWERTIMEOUT = 0x0051,
        SPI_SETPOWEROFFTIMEOUT = 0x0052,
        SPI_GETLOWPOWERACTIVE = 0x0053,
        SPI_GETPOWEROFFACTIVE = 0x0054,
        SPI_SETLOWPOWERACTIVE = 0x0055,
        SPI_SETPOWEROFFACTIVE = 0x0056,
        SPI_SETCURSORS = 0x0057,
        SPI_SETICONS = 0x0058,
        SPI_GETDEFAULTINPUTLANG = 0x0059,
        SPI_SETDEFAULTINPUTLANG = 0x005A,
        SPI_SETLANGTOGGLE = 0x005B,
        SPI_GETWINDOWSEXTENSION = 0x005C,
        SPI_SETMOUSETRAILS = 0x005D,
        SPI_GETMOUSETRAILS = 0x005E,
        SPI_SETSCREENSAVERRUNNING = 0x0061,
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
        SPI_GETFILTERKEYS = 0x0032,
        SPI_SETFILTERKEYS = 0x0033,
        SPI_GETTOGGLEKEYS = 0x0034,
        SPI_SETTOGGLEKEYS = 0x0035,
        SPI_GETMOUSEKEYS = 0x0036,
        SPI_SETMOUSEKEYS = 0x0037,
        SPI_GETSHOWSOUNDS = 0x0038,
        SPI_SETSHOWSOUNDS = 0x0039,
        SPI_GETSTICKYKEYS = 0x003A,
        SPI_SETSTICKYKEYS = 0x003B,
        SPI_GETACCESSTIMEOUT = 0x003C,
        SPI_SETACCESSTIMEOUT = 0x003D,
        SPI_GETSERIALKEYS = 0x003E,
        SPI_SETSERIALKEYS = 0x003F,
        SPI_GETSOUNDSENTRY = 0x0040,
        SPI_SETSOUNDSENTRY = 0x0041,
        SPI_GETSNAPTODEFBUTTON = 0x005F,
        SPI_SETSNAPTODEFBUTTON = 0x0060,
        SPI_GETMOUSEHOVERWIDTH = 0x0062,
        SPI_SETMOUSEHOVERWIDTH = 0x0063,
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,
        SPI_SETMOUSEHOVERHEIGHT = 0x0065,
        SPI_GETMOUSEHOVERTIME = 0x0066,
        SPI_SETMOUSEHOVERTIME = 0x0067,
        SPI_GETWHEELSCROLLLINES = 0x0068,
        SPI_SETWHEELSCROLLLINES = 0x0069,
        SPI_GETMENUSHOWDELAY = 0x006A,
        SPI_SETMENUSHOWDELAY = 0x006B,
        SPI_GETWHEELSCROLLCHARS = 0x006C,
        SPI_SETWHEELSCROLLCHARS = 0x006D,
        SPI_GETSHOWIMEUI = 0x006E,
        SPI_SETSHOWIMEUI = 0x006F,
        SPI_GETMOUSESPEED = 0x0070,
        SPI_SETMOUSESPEED = 0x0071,
        SPI_GETSCREENSAVERRUNNING = 0x0072,
        SPI_GETDESKWALLPAPER = 0x0073,
        SPI_GETAUDIODESCRIPTION = 0x0074,
        SPI_SETAUDIODESCRIPTION = 0x0075,
        SPI_GETSCREENSAVESECURE = 0x0076,
        SPI_SETSCREENSAVESECURE = 0x0077,
        SPI_GETHUNGAPPTIMEOUT = 0x0078,
        SPI_SETHUNGAPPTIMEOUT = 0x0079,
        SPI_GETWAITTOKILLTIMEOUT = 0x007A,
        SPI_SETWAITTOKILLTIMEOUT = 0x007B,
        SPI_GETWAITTOKILLSERVICETIMEOUT = 0x007C,
        SPI_SETWAITTOKILLSERVICETIMEOUT = 0x007D,
        SPI_GETMOUSEDOCKTHRESHOLD = 0x007E,
        SPI_SETMOUSEDOCKTHRESHOLD = 0x007F,
        SPI_GETPENDOCKTHRESHOLD = 0x0080,
        SPI_SETPENDOCKTHRESHOLD = 0x0081,
        SPI_GETWINARRANGING = 0x0082,
        SPI_SETWINARRANGING = 0x0083,
        SPI_GETMOUSEDRAGOUTTHRESHOLD = 0x0084,
        SPI_SETMOUSEDRAGOUTTHRESHOLD = 0x0085,
        SPI_GETPENDRAGOUTTHRESHOLD = 0x0086,
        SPI_SETPENDRAGOUTTHRESHOLD = 0x0087,
        SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088,
        SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089,
        SPI_GETPENSIDEMOVETHRESHOLD = 0x008A,
        SPI_SETPENSIDEMOVETHRESHOLD = 0x008B,
        SPI_GETDRAGFROMMAXIMIZE = 0x008C,
        SPI_SETDRAGFROMMAXIMIZE = 0x008D,
        SPI_GETSNAPSIZING = 0x008E,
        SPI_SETSNAPSIZING = 0x008F,
        SPI_GETDOCKMOVING = 0x0090,
        SPI_SETDOCKMOVING = 0x0091,
        SPI_GETACTIVEWINDOWTRACKING = 0x1000,
        SPI_SETACTIVEWINDOWTRACKING = 0x1001,
        SPI_GETMENUANIMATION = 0x1002,
        SPI_SETMENUANIMATION = 0x1003,
        SPI_GETCOMBOBOXANIMATION = 0x1004,
        SPI_SETCOMBOBOXANIMATION = 0x1005,
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,
        SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,
        SPI_GETGRADIENTCAPTIONS = 0x1008,
        SPI_SETGRADIENTCAPTIONS = 0x1009,
        SPI_GETKEYBOARDCUES = 0x100A,
        SPI_SETKEYBOARDCUES = 0x100B,
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,
        SPI_GETACTIVEWNDTRKZORDER = 0x100C,
        SPI_SETACTIVEWNDTRKZORDER = 0x100D,
        SPI_GETHOTTRACKING = 0x100E,
        SPI_SETHOTTRACKING = 0x100F,
        SPI_GETMENUFADE = 0x1012,
        SPI_SETMENUFADE = 0x1013,
        SPI_GETSELECTIONFADE = 0x1014,
        SPI_SETSELECTIONFADE = 0x1015,
        SPI_GETTOOLTIPANIMATION = 0x1016,
        SPI_SETTOOLTIPANIMATION = 0x1017,
        SPI_GETTOOLTIPFADE = 0x1018,
        SPI_SETTOOLTIPFADE = 0x1019,
        SPI_GETCURSORSHADOW = 0x101A,
        SPI_SETCURSORSHADOW = 0x101B,
        SPI_GETMOUSESONAR = 0x101C,
        SPI_SETMOUSESONAR = 0x101D,
        SPI_GETMOUSECLICKLOCK = 0x101E,
        SPI_SETMOUSECLICKLOCK = 0x101F,
        SPI_GETMOUSEVANISH = 0x1020,
        SPI_SETMOUSEVANISH = 0x1021,
        SPI_GETFLATMENU = 0x1022,
        SPI_SETFLATMENU = 0x1023,
        SPI_GETDROPSHADOW = 0x1024,
        SPI_SETDROPSHADOW = 0x1025,
        SPI_GETBLOCKSENDINPUTRESETS = 0x1026,
        SPI_SETBLOCKSENDINPUTRESETS = 0x1027,
        SPI_GETUIEFFECTS = 0x103E,
        SPI_SETUIEFFECTS = 0x103F,
        SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040,
        SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041,
        SPI_GETCLIENTAREAANIMATION = 0x1042,
        SPI_SETCLIENTAREAANIMATION = 0x1043,
        SPI_GETCLEARTYPE = 0x1048,
        SPI_SETCLEARTYPE = 0x1049,
        SPI_GETSPEECHRECOGNITION = 0x104A,
        SPI_SETSPEECHRECOGNITION = 0x104B,
        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
        SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,
        SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,
        SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,
        SPI_GETCARETWIDTH = 0x2006,
        SPI_SETCARETWIDTH = 0x2007,
        SPI_GETMOUSECLICKLOCKTIME = 0x2008,
        SPI_SETMOUSECLICKLOCKTIME = 0x2009,
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,
        SPI_SETFONTSMOOTHINGTYPE = 0x200B,
        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,
        SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,
        SPI_GETFOCUSBORDERWIDTH = 0x200E,
        SPI_SETFOCUSBORDERWIDTH = 0x200F,
        SPI_GETFOCUSBORDERHEIGHT = 0x2010,
        SPI_SETFOCUSBORDERHEIGHT = 0x2011,
        SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,
        SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
        SPI_GETMINIMUMHITRADIUS = 0x2014,
        SPI_SETMINIMUMHITRADIUS = 0x2015,
        SPI_GETMESSAGEDURATION = 0x2016,
        SPI_SETMESSAGEDURATION = 0x2017;
        #endregion

        #region SPIF
        public const int
        SPIF_UPDATEINIFILE = 0x01,
        SPIF_SENDWININICHANGE = 0x02;
        #endregion

        #region OF
        public const int
        OF_SHARE_COMPAT = 0x0,
        OF_READ = 0x0,
        OF_WRITE = 0x1,
        OF_READWRITE = 0x2,
        OF_SHARE_EXCLUSIVE = 0x10,
        OF_SHARE_DENY_WRITE = 0x20,
        OF_SHARE_DENY_READ = 0x30,
        OF_SHARE_DENY_NONE = 0x40,
        OF_PARSE = 0x100,
        OF_DELETE = 0x200,
        OF_CREATE = 0x1000,
        OF_PROMPT = 0x2000,
        OF_EXIST = 0x4000,
        OF_REOPEN = 0x8000;
        #endregion

        #region SHGFI
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0;
        public const uint SHGFI_SMALLICON = 0x1;
        #endregion

        #region STARTF
        public const int STARTF_USESHOWWINDOW = 0x00000001;
        public const int STARTF_USESTDHANDLES = 0x00000100;
        #endregion

        /*无效句柄*/
        public const int INVALID_HANDLE_VALUE = -1;
        public static readonly IntPtr HFILE_ERROR = (-1).ToPointer();
        /**/
        public const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

        #region CB
        public const int CB_GETEDITSEL = 0x0140;
        public const int CB_LIMITTEXT = 0x0141;
        public const int CB_SETEDITSEL = 0x0142;
        public const int CB_ADDSTRING = 0x0143;
        public const int CB_DELETESTRING = 0x0144;
        public const int CB_DIR = 0x0145;
        public const int CB_GETCOUNT = 0x0146;
        public const int CB_GETCURSEL = 0x0147;
        public const int CB_GETLBTEXT = 0x0148;
        public const int CB_GETLBTEXTLEN = 0x0149;
        public const int CB_INSERTSTRING = 0x014A;
        public const int CB_RESETCONTENT = 0x014B;
        public const int CB_FINDSTRING = 0x014C;
        public const int CB_SELECTSTRING = 0x014D;
        public const int CB_SETCURSEL = 0x014E;
        public const int CB_SHOWDROPDOWN = 0x014F;
        public const int CB_GETITEMDATA = 0x0150;
        public const int CB_SETITEMDATA = 0x0151;
        public const int CB_GETDROPPEDCONTROLRECT = 0x0152;
        public const int CB_SETITEMHEIGHT = 0x0153;
        public const int CB_GETITEMHEIGHT = 0x0154;
        public const int CB_SETEXTENDEDUI = 0x0155;
        public const int CB_GETEXTENDEDUI = 0x0156;
        public const int CB_GETDROPPEDSTATE = 0x0157;
        public const int CB_FINDSTRINGEXACT = 0x0158;
        public const int CB_MULTIPLEADDSTRING = 0x0163;
        public const int CB_GETCOMBOBOXINFO = 0x0164;
        public const int CB_MSGMAX_501 = 0x0165;
        public const int CB_MSGMAX_WCE400 = 0x0163;
        public const int CB_MSGMAX_400 = 0x0162;
        public const int CB_MSGMAX_PRE400 = 0x015B;
        public const int CB_SETLOCALE = 345;
        public const int CB_GETLOCALE = 346;
        public const int CB_GETTOPINDEX = 347;
        public const int CB_SETTOPINDEX = 348;
        public const int CB_GETHORIZONTALEXTENT = 349;
        public const int CB_SETHORIZONTALEXTENT = 350;
        public const int CB_GETDROPPEDWIDTH = 351;
        public const int CB_SETDROPPEDWIDTH = 352;
        public const int CB_INITSTORAGE = 353;
        public const int CB_MSGMAX = 354;
        #endregion

        /**/
        public const uint CERT_CONTEXT_REVOCATION_TYPE = 1;
        public const uint CERT_REQUEST_V1 = 0;

        #region COLOR
        public const int
        COLOR_SCROLLBAR = 0,
        COLOR_BACKGROUND = 1,
        COLOR_DESKTOP = 1,
        COLOR_ACTIVECAPTION = 2,
        COLOR_INACTIVECAPTION = 3,
        COLOR_MENU = 4,
        COLOR_WINDOW = 5,
        COLOR_WINDOWFRAME = 6,
        COLOR_MENUTEXT = 7,
        COLOR_WINDOWTEXT = 8,
        COLOR_CAPTIONTEXT = 9,
        COLOR_ACTIVEBORDER = 10,
        COLOR_INACTIVEBORDER = 11,
        COLOR_APPWORKSPACE = 12,
        COLOR_HIGHLIGHT = 13,
        COLOR_HIGHLIGHTTEXT = 14,
        COLOR_BTNFACE = 15,
        COLOR_3DFACE = 15,
        COLOR_BTNSHADOW = 16,
        COLOR_3DSHADOW = 16,
        COLOR_GRAYTEXT = 17,
        COLOR_BTNTEXT = 18,
        COLOR_INACTIVECAPTIONTEXT = 19,
        COLOR_BTNHIGHLIGHT = 20,
        COLOR_3DHIGHLIGHT = 20,
        COLOR_3DHILIGHT = 20,
        COLOR_BTNHILIGHT = 20,
        COLOR_3DDKSHADOW = 21,
        COLOR_3DLIGHT = 22,
        COLOR_INFOTEXT = 23,
        COLOR_INFOBK = 24;
        #endregion

        /**/
        public const int CRED_TYPE_GENERIC = 1;
        public const int CRED_TYPE_DOMAIN_PASSWORD = 2;
        public const int CRED_TYPE_DOMAIN_CERTIFICATE = 3;
        public const int CRED_TYPE_DOMAIN_VISIBLE_PASSWORD = 4;
        public const int CRED_TYPE_MAXIMUM = 5;
        /**/
        public const int X509_ASN_ENCODING = 0x00000001;
        public const int PKCS_7_ASN_ENCODING = 0x00010000;
        /**/
        public const int CERT_SIMPLE_NAME_STR = 1;
        public const int CERT_OID_NAME_STR = 2;
        public const int CERT_X500_NAME_STR = 3;
        /**/
        public const Int32 DRIVER_PACKAGE_REPAIR = 0x00000001;
        public const Int32 DRIVER_PACKAGE_SILENT = 0x00000002;
        public const Int32 DRIVER_PACKAGE_FORCE = 0x00000004;
        public const Int32 DRIVER_PACKAGE_ONLY_IF_DEVICE_PRESENT = 0x00000008;
        public const Int32 DRIVER_PACKAGE_LEGACY_MODE = 0x00000010;
        public const Int32 DRIVER_PACKAGE_DELETE_FILES = 0x00000020;
        /**/
        public const int DI_MASK = 0x0001;
        public const int DI_IMAGE = 0x0002;
        public const int DI_NORMAL = 0x0003;
        public const int DI_COMPAT = 0x0004;
        public const int DI_DEFAULTSIZE = 0x0008;
        public const int DI_NOMIRROR = 0x0010;

        #region EMR
        public const int
        EMR_HEADER = 1,
        EMR_POLYBEZIER = 2,
        EMR_POLYGON = 3,
        EMR_POLYLINE = 4,
        EMR_POLYBEZIERTO = 5,
        EMR_POLYLINETO = 6,
        EMR_POLYPOLYLINE = 7,
        EMR_POLYPOLYGON = 8,
        EMR_SETWINDOWEXTEX = 9,
        EMR_SETWINDOWORGEX = 10,
        EMR_SETVIEWPORTEXTEX = 11,
        EMR_SETVIEWPORTORGEX = 12,
        EMR_SETBRUSHORGEX = 13,
        EMR_EOF = 14,
        EMR_SETPIXELV = 15,
        EMR_SETMAPPERFLAGS = 16,
        EMR_SETMAPMODE = 17,
        EMR_SETBKMODE = 18,
        EMR_SETPOLYFILLMODE = 19,
        EMR_SETROP2 = 20,
        EMR_SETSTRETCHBLTMODE = 21,
        EMR_SETTEXTALIGN = 22,
        EMR_SETCOLORADJUSTMENT = 23,
        EMR_SETTEXTCOLOR = 24,
        EMR_SETBKCOLOR = 25,
        EMR_OFFSETCLIPRGN = 26,
        EMR_MOVETOEX = 27,
        EMR_SETMETARGN = 28,
        EMR_EXCLUDECLIPRECT = 29,
        EMR_INTERSECTCLIPRECT = 30,
        EMR_SCALEVIEWPORTEXTEX = 31,
        EMR_SCALEWINDOWEXTEX = 32,
        EMR_SAVEDC = 33,
        EMR_RESTOREDC = 34,
        EMR_SETWORLDTRANSFORM = 35,
        EMR_MODIFYWORLDTRANSFORM = 36,
        EMR_SELECTOBJECT = 37,
        EMR_CREATEPEN = 38,
        EMR_CREATEBRUSHINDIRECT = 39,
        EMR_DELETEOBJECT = 40,
        EMR_ANGLEARC = 41,
        EMR_ELLIPSE = 42,
        EMR_RECTANGLE = 43,
        EMR_ROUNDRECT = 44,
        EMR_ARC = 45,
        EMR_CHORD = 46,
        EMR_PIE = 47,
        EMR_SELECTPALETTE = 48,
        EMR_CREATEPALETTE = 49,
        EMR_SETPALETTEENTRIES = 50,
        EMR_RESIZEPALETTE = 51,
        EMR_REALIZEPALETTE = 52,
        EMR_EXTFLOODFILL = 53,
        EMR_LINETO = 54,
        EMR_ARCTO = 55,
        EMR_POLYDRAW = 56,
        EMR_SETARCDIRECTION = 57,
        EMR_SETMITERLIMIT = 58,
        EMR_BEGINPATH = 59,
        EMR_ENDPATH = 60,
        EMR_CLOSEFIGURE = 61,
        EMR_FILLPATH = 62,
        EMR_STROKEANDFILLPATH = 63,
        EMR_STROKEPATH = 64,
        EMR_FLATTENPATH = 65,
        EMR_WIDENPATH = 66,
        EMR_SELECTCLIPPATH = 67,
        EMR_ABORTPATH = 68,
        EMR_GDICOMMENT = 70,
        EMR_FILLRGN = 71,
        EMR_FRAMERGN = 72,
        EMR_INVERTRGN = 73,
        EMR_PAINTRGN = 74,
        EMR_EXTSELECTCLIPRGN = 75,
        EMR_BITBLT = 76,
        EMR_STRETCHBLT = 77,
        EMR_MASKBLT = 78,
        EMR_PLGBLT = 79,
        EMR_SETDIBITSTODEVICE = 80,
        EMR_STRETCHDIBITS = 81,
        EMR_EXTCREATEFONTINDIRECTW = 82,
        EMR_EXTTEXTOUTA = 83,
        EMR_EXTTEXTOUTW = 84,
        EMR_POLYBEZIER16 = 85,
        EMR_POLYGON16 = 86,
        EMR_POLYLINE16 = 87,
        EMR_POLYBEZIERTO16 = 88,
        EMR_POLYLINETO16 = 89,
        EMR_POLYPOLYLINE16 = 90,
        EMR_POLYPOLYGON16 = 91,
        EMR_POLYDRAW16 = 92,
        EMR_CREATEMONOBRUSH = 93,
        EMR_CREATEDIBPATTERNBRUSHPT = 94,
        EMR_EXTCREATEPEN = 95,
        EMR_POLYTEXTOUTA = 96,
        EMR_POLYTEXTOUTW = 97,
        EMR_SETICMMODE = 98,
        EMR_CREATECOLORSPACE = 99,
        EMR_SETCOLORSPACE = 100,
        EMR_DELETECOLORSPACE = 101,
        EMR_GLSRECORD = 102,
        EMR_GLSBOUNDEDRECORD = 103,
        EMR_PIXELFORMAT = 104,
        EMR_RESERVED_105 = 105,
        EMR_RESERVED_106 = 106,
        EMR_RESERVED_107 = 107,
        EMR_RESERVED_108 = 108,
        EMR_RESERVED_109 = 109,
        EMR_RESERVED_110 = 110,
        EMR_COLORCORRECTPALETTE = 111,
        EMR_SETICMPROFILEA = 112,
        EMR_SETICMPROFILEW = 113,
        EMR_ALPHABLEND = 114,
        EMR_SETLAYOUT = 115,
        EMR_TRANSPARENTBLT = 116,
        EMR_RESERVED_117 = 117,
        EMR_GRADIENTFILL = 118,
        EMR_RESERVED_119 = 119,
        EMR_RESERVED_120 = 120,
        EMR_COLORMATCHTOTARGETW = 121,
        EMR_CREATECOLORSPACEW = 122;
        #endregion

        public const int
        FO_DELETE = 3,
        FOF_SILENT = 0x0004,
        FOF_NOCONFIRMATION = 0x0010,
        FOF_ALLOWUNDO = 0x0040,
        FOF_NOCONFIRMMKDIR = 0x0200,
        FOF_NOERRORUI = 0x0400;
        /**/
        public const int ERROR_ACCESS_DENIED = 5;
        /**/
        public const UInt32 EWX_LOGOFF = 0x00000000;
        public const UInt32 EWX_SHUTDOWN = 0x00000001;
        public const UInt32 EWX_FORCE = 0x00000004;
        public const UInt32 EWX_POWEROFF = 0x00000008;
        public const UInt32 EWX_FORCEIFHUNG = 0x00000010;
        /**/
        public const int E_FAIL = unchecked((int)0x80004005);
        /**/
        public const int LF_FACESIZE = 32;
        /**/
        public const int
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
            /// <summary>
            /// 绘制
            /// </summary>
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUERYOPEN = 0x0013,
        WM_ENDSESSION = 0x0016,
        WM_QUIT = 0x0012,
            /// <summary>
            /// 擦拭背景
            /// </summary>
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_SHOWWINDOW = 0x0018,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_DELETEITEM = 0x002D,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
            /// <summary>
            /// 设置字体
            /// </summary>
        WM_SETFONT = 0x0030,
            /// <summary>
            /// 获取字体
            /// </summary>
        WM_GETFONT = 0x0031,
            /// <summary>
            /// 设置热键
            /// </summary>
        WM_SETHOTKEY = 0x0032,
            /// <summary>
            /// 获取热键
            /// </summary>
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_REFLECT = 0x2000,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_SYNCPAINT = 0x0088,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_NCXBUTTONDOWN = 0x00AB,
        WM_NCXBUTTONUP = 0x00AC,
        WM_NCXBUTTONDBLCLK = 0x00AD,
        WM_INPUT = 0x00FF,
        WM_KEYFIRST = 0x0100,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_UNICHAR = 0x0109,
        WM_KEYLAST_NT501 = 0x0109,
        UNICODE_NOCHAR = 0xFFFF,
        WM_KEYLAST_PRE501 = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
            /// <summary>
            /// 横滚
            /// </summary>
        WM_HSCROLL = 0x0114,
            /// <summary>
            /// 纵滚
            /// </summary>
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_MENURBUTTONUP = 0x0122,
        WM_MENUDRAG = 0x0123,
        WM_MENUGETOBJECT = 0x0124,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_MENUCOMMAND = 0x0126,
        WM_CHANGEUISTATE = 0x0127,
        WM_UPDATEUISTATE = 0x0128,
        WM_QUERYUISTATE = 0x0129,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
            /// <summary>
            /// 鼠标开始
            /// </summary>
        WM_MOUSEFIRST = 0x0200,
            /// <summary>
            /// 鼠标移动
            /// </summary>
        WM_MOUSEMOVE = 0x0200,
            /// <summary>
            /// 左键按下
            /// </summary>
        WM_LBUTTONDOWN = 0x0201,
            /// <summary>
            /// 左键释放
            /// </summary>
        WM_LBUTTONUP = 0x0202,
            /// <summary>
            /// 左键双击
            /// </summary>
        WM_LBUTTONDBLCLK = 0x0203,
            /// <summary>
            /// 右键按下
            /// </summary>
        WM_RBUTTONDOWN = 0x0204,
            /// <summary>
            /// 右键释放
            /// </summary>
        WM_RBUTTONUP = 0x0205,
            /// <summary>
            /// 右键双击
            /// </summary>
        WM_RBUTTONDBLCLK = 0x0206,
            /// <summary>
            /// 中键按下
            /// </summary>
        WM_MBUTTONDOWN = 0x0207,
            /// <summary>
            /// 中键释放
            /// </summary>
        WM_MBUTTONUP = 0x0208,
            /// <summary>
            /// 中键双击
            /// </summary>
        WM_MBUTTONDBLCLK = 0x0209,
            /// <summary>
            /// 滚轮滚动
            /// </summary>
            /// <remarks>WINNT4.0以上才支持此消息</remarks>
        WM_MOUSEWHEEL = 0x020A,
        WM_XBUTTONDOWN = 0x020B,
        WM_XBUTTONUP = 0x020C,
        WM_XBUTTONDBLCLK = 0x020D,
        WM_MOUSELAST_5 = 0x020D,
        WM_MOUSELAST_4 = 0x020A,
        WM_MOUSELAST_PRE_4 = 0x0209,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_POWERBROADCAST = 0x0218,
        WM_DEVICECHANGE = 0x0219,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_REQUEST = 0x0288,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
            /// <summary>
            /// 鼠标盘旋
            /// </summary>
        WM_MOUSEHOVER = 0x02A1,
            /// <summary>
            /// 鼠标离开
            /// </summary>
        WM_MOUSELEAVE = 0x02A3,
        WM_NCMOUSEHOVER = 0x02A0,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_WTSSESSION_CHANGE = 0x02B1,
        WM_TABLET_FIRST = 0x02c0,
        WM_TABLET_LAST = 0x02df,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
            /// <summary>
            /// 打印输出
            /// </summary>
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_APPCOMMAND = 0x0319,
        WM_THEMECHANGED = 0x031A,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_APP = 0x8000,
        WM_USER = 0x0400,
            /**/
        EM_GETSEL = 0x00B0,
        EM_SETSEL = 0x00B1,
        EM_GETRECT = 0x00B2,
        EM_SETRECT = 0x00B3,
        EM_SETRECTNP = 0x00B4,
        EM_SCROLL = 0x00B5,
        EM_LINESCROLL = 0x00B6,
        EM_SCROLLCARET = 0x00B7,
        EM_GETMODIFY = 0x00B8,
        EM_SETMODIFY = 0x00B9,
        EM_GETLINECOUNT = 0x00BA,
        EM_LINEINDEX = 0x00BB,
        EM_SETHANDLE = 0x00BC,
        EM_GETHANDLE = 0x00BD,
        EM_GETTHUMB = 0x00BE,
        EM_LINELENGTH = 0x00C1,
        EM_REPLACESEL = 0x00C2,
        EM_GETLINE = 0x00C4,
        EM_LIMITTEXT = 0x00C5,
        EM_CANUNDO = 0x00C6,
        EM_UNDO = 0x00C7,
        EM_FMTLINES = 0x00C8,
        EM_LINEFROMCHAR = 0x00C9,
        EM_SETTABSTOPS = 0x00CB,
        EM_SETPASSWORDCHAR = 0x00CC,
        EM_EMPTYUNDOBUFFER = 0x00CD,
        EM_GETFIRSTVISIBLELINE = 0x00CE,
        EM_SETREADONLY = 0x00CF,
        EM_SETWORDBREAKPROC = 0x00D0,
        EM_GETWORDBREAKPROC = 0x00D1,
        EM_GETPASSWORDCHAR = 0x00D2,
        EM_SETMARGINS = 0x00D3,
        EM_GETMARGINS = 0x00D4,
        EM_SETLIMITTEXT = EM_LIMITTEXT,
        EM_GETLIMITTEXT = 0x00D5,
        EM_POSFROMCHAR = 0x00D6,
        EM_CHARFROMPOS = 0x00D7,
        EM_SETIMESTATUS = 0x00D8,
        EM_GETIMESTATUS = 0x00D9,
            /**/
        BM_GETCHECK = 0x00F0,
        BM_SETCHECK = 0x00F1,
        BM_GETSTATE = 0x00F2,
        BM_SETSTATE = 0x00F3,
        BM_SETSTYLE = 0x00F4,
        BM_CLICK = 0x00F5,
        BM_GETIMAGE = 0x00F6,
        BM_SETIMAGE = 0x00F7,
            /**/
        STM_SETICON = 0x0170,
        STM_GETICON = 0x0171,
        STM_SETIMAGE = 0x0172,
        STM_GETIMAGE = 0x0173,
        STM_MSGMAX = 0x0174,
            /**/
        DM_GETDEFID = (WM_USER + 0),
        DM_SETDEFID = (WM_USER + 1),
        DM_REPOSITION = (WM_USER + 2),
            /**/
        LB_ADDSTRING = 0x0180,
        LB_INSERTSTRING = 0x0181,
        LB_DELETESTRING = 0x0182,
        LB_SELITEMRANGEEX = 0x0183,
        LB_RESETCONTENT = 0x0184,
        LB_SETSEL = 0x0185,
        LB_SETCURSEL = 0x0186,
        LB_GETSEL = 0x0187,
        LB_GETCURSEL = 0x0188,
        LB_GETTEXT = 0x0189,
        LB_GETTEXTLEN = 0x018A,
        LB_GETCOUNT = 0x018B,
        LB_SELECTSTRING = 0x018C,
        LB_DIR = 0x018D,
        LB_GETTOPINDEX = 0x018E,
        LB_FINDSTRING = 0x018F,
        LB_GETSELCOUNT = 0x0190,
        LB_GETSELITEMS = 0x0191,
        LB_SETTABSTOPS = 0x0192,
        LB_GETHORIZONTALEXTENT = 0x0193,
        LB_SETHORIZONTALEXTENT = 0x0194,
        LB_SETCOLUMNWIDTH = 0x0195,
        LB_ADDFILE = 0x0196,
        LB_SETTOPINDEX = 0x0197,
        LB_GETITEMRECT = 0x0198,
        LB_GETITEMDATA = 0x0199,
        LB_SETITEMDATA = 0x019A,
        LB_SELITEMRANGE = 0x019B,
        LB_SETANCHORINDEX = 0x019C,
        LB_GETANCHORINDEX = 0x019D,
        LB_SETCARETINDEX = 0x019E,
        LB_GETCARETINDEX = 0x019F,
        LB_SETITEMHEIGHT = 0x01A0,
        LB_GETITEMHEIGHT = 0x01A1,
        LB_FINDSTRINGEXACT = 0x01A2,
        LB_SETLOCALE = 0x01A5,
        LB_GETLOCALE = 0x01A6,
        LB_SETCOUNT = 0x01A7,
        LB_INITSTORAGE = 0x01A8,
        LB_ITEMFROMPOINT = 0x01A9,
        LB_MULTIPLEADDSTRING = 0x01B1,
        LB_GETLISTBOXINFO = 0x01B2,
        LB_MSGMAX_501 = 0x01B3,
        LB_MSGMAX_WCE4 = 0x01B1,
        LB_MSGMAX_4 = 0x01B0,
        LB_MSGMAX_PRE4 = 0x01A8,
            /**/
        SB_LINEUP = 0,
        SB_LINELEFT = 0,
        SB_LINEDOWN = 1,
        SB_LINERIGHT = 1,
        SB_PAGEUP = 2,
        SB_PAGELEFT = 2,
        SB_PAGEDOWN = 3,
        SB_PAGERIGHT = 3,
        SB_THUMBPOSITION = 4,
        SB_THUMBTRACK = 5,
        SB_TOP = 6,
        SB_LEFT = 6,
        SB_BOTTOM = 7,
        SB_RIGHT = 7,
        SB_ENDSCROLL = 8,
            /**/
        SBM_SETPOS = 0x00E0,
        SBM_GETPOS = 0x00E1,
        SBM_SETRANGE = 0x00E2,
        SBM_SETRANGEREDRAW = 0x00E6,
        SBM_GETRANGE = 0x00E3,
        SBM_ENABLE_ARROWS = 0x00E4,
        SBM_SETSCROLLINFO = 0x00E9,
        SBM_GETSCROLLINFO = 0x00EA,
        SBM_GETSCROLLBARINFO = 0x00EB,

        #region SC
 SC_CLOSE = 0xF060,
        SC_CONTEXTHELP = 0xF180,
        SC_DEFAULT = 0xF160,
        SC_HOTKEY = 0xF150,
        SC_HSCROLL = 0xF080,
        SC_KEYMENU = 0xF100,
        SC_MAXIMIZE = 0xF030,
        SC_MINIMIZE = 0xF020,
        SC_MONITORPOWER = 0xF170,
        SC_MOUSEMENU = 0xF090,
        SC_MOVE = 0xF010,
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_RESTORE = 0xF120,
        SC_SCREENSAVE = 0xF140,
        SC_SIZE = 0xF000,
        SC_TASKLIST = 0xF130,
        SC_VSCROLL = 0xF070,
        SCF_ISSECURE = 0x00000001,
        #endregion

            /**/
        LVM_FIRST = 0x1000,
        #region TV
 TV_FIRST = 0x1100,
        TVM_GETNEXTITEM = (TV_FIRST + 10),
        TVM_SETBKCOLOR = (TV_FIRST + 29),
        TVM_SETEXTENDEDSTYLE = (TV_FIRST + 44),
        TVGN_CARET = 0x0009,
        TVGN_NEXTSELECTED = 0x000B,
        TVS_EX_MULTISELECT = 0x0002,
        TVS_EX_DOUBLEBUFFER = 0x0004,
        SPACE_IL = 3,
        #endregion
 HDM_FIRST = 0x1200,
        TCM_FIRST = 0x1300,
        PGM_FIRST = 0x1400,
        ECM_FIRST = 0x1500,
        BCM_FIRST = 0x1600,
        CBM_FIRST = 0x1700,
        CCM_FIRST = 0x2000,
            /**/
        DBT_DEVTYP_DEVICEINTERFACE = 0x00000005,
        DBT_DEVNODES_CHANGED = 0x0007,
        DBT_QUERYCHANGECONFIG = 0x0017,
        DBT_CONFIGCHANGED = 0x0018,
        DBT_CONFIGCHANGECANCELED = 0x0019,
            /// <summary>
            /// 设备插入
            /// </summary>
        DBT_DEVICEARRIVAL = 0x8000,
        DBT_DEVICEQUERYREMOVE = 0x8001,
        DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
        DBT_DEVICEREMOVEPENDING = 0x8003,
            /// <summary>
            /// 移除完成
            /// </summary>
        DBT_DEVICEREMOVECOMPLETE = 0x8004,
        DBT_DEVICETYPESPECIFIC = 0x8005,
        DBT_CUSTOMEVENT = 0x8006,
        DBT_USERDEFINED = 0xFFFF,
            /**/
        CCM_LAST = (CCM_FIRST + 0x200),
        CCM_SETBKCOLOR = (CCM_FIRST + 1),
        CCM_SETCOLORSCHEME = (CCM_FIRST + 2),
        CCM_GETCOLORSCHEME = (CCM_FIRST + 3),
        CCM_GETDROPTARGET = (CCM_FIRST + 4),
        CCM_SETUNICODEFORMAT = (CCM_FIRST + 5),
        CCM_GETUNICODEFORMAT = (CCM_FIRST + 6),
        CCM_SETVERSION = (CCM_FIRST + 0x7),
        CCM_GETVERSION = (CCM_FIRST + 0x8),
        CCM_SETNOTIFYWINDOW = (CCM_FIRST + 0x9),
        CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb),
        CCM_DPISCALE = (CCM_FIRST + 0xc),
            /**/
        HDM_GETITEMCOUNT = (HDM_FIRST + 0),
        HDM_INSERTITEMA = (HDM_FIRST + 1),
        HDM_INSERTITEMW = (HDM_FIRST + 10),
        HDM_DELETEITEM = (HDM_FIRST + 2),
        HDM_GETITEMA = (HDM_FIRST + 3),
        HDM_GETITEMW = (HDM_FIRST + 11),
        HDM_SETITEMA = (HDM_FIRST + 4),
        HDM_SETITEMW = (HDM_FIRST + 12),
        HDM_LAYOUT = (HDM_FIRST + 5),
        HDM_HITTEST = (HDM_FIRST + 6),
        HDM_GETITEMRECT = (HDM_FIRST + 7),
        HDM_SETIMAGELIST = (HDM_FIRST + 8),
        HDM_GETIMAGELIST = (HDM_FIRST + 9),
        HDM_ORDERTOINDEX = (HDM_FIRST + 15),
        HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16),
        HDM_GETORDERARRAY = (HDM_FIRST + 17),
        HDM_SETORDERARRAY = (HDM_FIRST + 18),
        HDM_SETHOTDIVIDER = (HDM_FIRST + 19),
        HDM_SETBITMAPMARGIN = (HDM_FIRST + 20),
        HDM_GETBITMAPMARGIN = (HDM_FIRST + 21),
        HDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        HDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,
        HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22),
        HDM_EDITFILTER = (HDM_FIRST + 23),
        HDM_CLEARFILTER = (HDM_FIRST + 24),
            /**/
        TB_ENABLEBUTTON = (WM_USER + 1),
        TB_CHECKBUTTON = (WM_USER + 2),
        TB_PRESSBUTTON = (WM_USER + 3),
        TB_HIDEBUTTON = (WM_USER + 4),
        TB_INDETERMINATE = (WM_USER + 5),
        TB_MARKBUTTON = (WM_USER + 6),
        TB_ISBUTTONENABLED = (WM_USER + 9),
        TB_ISBUTTONCHECKED = (WM_USER + 10),
        TB_ISBUTTONPRESSED = (WM_USER + 11),
        TB_ISBUTTONHIDDEN = (WM_USER + 12),
        TB_ISBUTTONINDETERMINATE = (WM_USER + 13),
        TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14),
        TB_SETSTATE = (WM_USER + 17),
        TB_GETSTATE = (WM_USER + 18),
        TB_ADDBITMAP = (WM_USER + 19),
        TB_ADDBUTTONSA = (WM_USER + 20),
        TB_INSERTBUTTONA = (WM_USER + 21),
        TB_ADDBUTTONS = (WM_USER + 20),
        TB_INSERTBUTTON = (WM_USER + 21),
        TB_DELETEBUTTON = (WM_USER + 22),
        TB_GETBUTTON = (WM_USER + 23),
        TB_BUTTONCOUNT = (WM_USER + 24),
        TB_COMMANDTOINDEX = (WM_USER + 25),
        TB_SAVERESTOREA = (WM_USER + 26),
        TB_SAVERESTOREW = (WM_USER + 76),
        TB_CUSTOMIZE = (WM_USER + 27),
        TB_ADDSTRINGA = (WM_USER + 28),
        TB_ADDSTRINGW = (WM_USER + 77),
        TB_GETITEMRECT = (WM_USER + 29),
        TB_BUTTONSTRUCTSIZE = (WM_USER + 30),
        TB_SETBUTTONSIZE = (WM_USER + 31),
        TB_SETBITMAPSIZE = (WM_USER + 32),
        TB_AUTOSIZE = (WM_USER + 33),
        TB_GETTOOLTIPS = (WM_USER + 35),
        TB_SETTOOLTIPS = (WM_USER + 36),
        TB_SETPARENT = (WM_USER + 37),
        TB_SETROWS = (WM_USER + 39),
        TB_GETROWS = (WM_USER + 40),
        TB_SETCMDID = (WM_USER + 42),
        TB_CHANGEBITMAP = (WM_USER + 43),
        TB_GETBITMAP = (WM_USER + 44),
        TB_GETBUTTONTEXTA = (WM_USER + 45),
        TB_GETBUTTONTEXTW = (WM_USER + 75),
        TB_REPLACEBITMAP = (WM_USER + 46),
        TB_SETINDENT = (WM_USER + 47),
        TB_SETIMAGELIST = (WM_USER + 48),
        TB_GETIMAGELIST = (WM_USER + 49),
        TB_LOADIMAGES = (WM_USER + 50),
        TB_GETRECT = (WM_USER + 51),
        TB_SETHOTIMAGELIST = (WM_USER + 52),
        TB_GETHOTIMAGELIST = (WM_USER + 53),
        TB_SETDISABLEDIMAGELIST = (WM_USER + 54),
        TB_GETDISABLEDIMAGELIST = (WM_USER + 55),
        TB_SETSTYLE = (WM_USER + 56),
        TB_GETSTYLE = (WM_USER + 57),
        TB_GETBUTTONSIZE = (WM_USER + 58),
        TB_SETBUTTONWIDTH = (WM_USER + 59),
        TB_SETMAXTEXTROWS = (WM_USER + 60),
        TB_GETTEXTROWS = (WM_USER + 61),
        TB_GETOBJECT = (WM_USER + 62),
        TB_GETHOTITEM = (WM_USER + 71),
        TB_SETHOTITEM = (WM_USER + 72),
        TB_SETANCHORHIGHLIGHT = (WM_USER + 73),
        TB_GETANCHORHIGHLIGHT = (WM_USER + 74),
        TB_MAPACCELERATORA = (WM_USER + 78),
        TB_GETINSERTMARK = (WM_USER + 79),
        TB_SETINSERTMARK = (WM_USER + 80),
        TB_INSERTMARKHITTEST = (WM_USER + 81),
        TB_MOVEBUTTON = (WM_USER + 82),
        TB_GETMAXSIZE = (WM_USER + 83),
        TB_SETEXTENDEDSTYLE = (WM_USER + 84),
        TB_GETEXTENDEDSTYLE = (WM_USER + 85),
        TB_GETPADDING = (WM_USER + 86),
        TB_SETPADDING = (WM_USER + 87),
        TB_SETINSERTMARKCOLOR = (WM_USER + 88),
        TB_GETINSERTMARKCOLOR = (WM_USER + 89),
        TB_SETCOLORSCHEME = CCM_SETCOLORSCHEME,
        TB_GETCOLORSCHEME = CCM_GETCOLORSCHEME,
        TB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        TB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,
        TB_MAPACCELERATORW = (WM_USER + 90),
        TB_GETBITMAPFLAGS = (WM_USER + 41),
        TB_GETBUTTONINFOW = (WM_USER + 63),
        TB_SETBUTTONINFOW = (WM_USER + 64),
        TB_GETBUTTONINFOA = (WM_USER + 65),
        TB_SETBUTTONINFOA = (WM_USER + 66),
        TB_INSERTBUTTONW = (WM_USER + 67),
        TB_ADDBUTTONSW = (WM_USER + 68),
        TB_HITTEST = (WM_USER + 69),
        TB_SETDRAWTEXTFLAGS = (WM_USER + 70),
        TB_GETSTRINGW = (WM_USER + 91),
        TB_GETSTRINGA = (WM_USER + 92),
        TB_GETMETRICS = (WM_USER + 101),
        TB_SETMETRICS = (WM_USER + 102),
        TB_SETWINDOWTHEME = CCM_SETWINDOWTHEME,
            /**/
        RB_INSERTBANDA = (WM_USER + 1),
        RB_DELETEBAND = (WM_USER + 2),
        RB_GETBARINFO = (WM_USER + 3),
        RB_SETBARINFO = (WM_USER + 4),
        RB_GETBANDINFO = (WM_USER + 5),
        RB_SETBANDINFOA = (WM_USER + 6),
        RB_SETPARENT = (WM_USER + 7),
        RB_HITTEST = (WM_USER + 8),
        RB_GETRECT = (WM_USER + 9),
        RB_INSERTBANDW = (WM_USER + 10);
        /**/
        public const long PRF_CHECKVISIBLE = 0x00000001L,
        PRF_NONCLIENT = 0x00000002L,
        PRF_CLIENT = 0x00000004L,
        PRF_ERASEBKGND = 0x00000008L,
        PRF_CHILDREN = 0x00000010L,
        PRF_OWNED = 0x00000020L;
        /*DrawFrameControl*/
        /*标题按钮*/
        public const int DFC_CAPTION = 1,
            /*菜单*/
        DFC_MENU = 2,
            /*滚动条按钮*/
        DFC_SCROLL = 3,
            /*标准按钮*/
        DFC_BUTTON = 4,
            /*弹出菜单*/
        DFC_POPUPMENU = 5,
            /*针对 DFC_CAPTION*/
        DFCS_CAPTIONCLOSE = 0,
        DFCS_CAPTIONMIN = 1,
        DFCS_CAPTIONMAX = 2,
        DFCS_CAPTIONRESTORE = 3,
        DFCS_CAPTIONHELP = 4,
            /*针对 DFC_MENU*/
        DFCS_MENUARROW = 0,
        DFCS_MENUCHECK = 1,
        DFCS_MENUBULLET = 2,
        DFCS_MENUARROWRIGHT = 4,
            /*针对 DFC_SCROLL*/
        DFCS_SCROLLUP = 0,
        DFCS_SCROLLDOWN = 1,
        DFCS_SCROLLLEFT = 2,
        DFCS_SCROLLRIGHT = 3,
        DFCS_SCROLLCOMBOBOX = 5,
        DFCS_SCROLLSIZEGRIP = 8,
        DFCS_SCROLLSIZEGRIPRIGHT = 0x10,
            /*针对 DFC_BUTTON*/
        DFCS_BUTTONCHECK = 0,
        DFCS_BUTTONRADIOIMAGE = 1,
        DFCS_BUTTONRADIOMASK = 2,
        DFCS_BUTTONRADIO = 4,
        DFCS_BUTTON3STATE = 8,
        DFCS_BUTTONPUSH = 0x10,
            /*通用状态*/
        DFCS_INACTIVE = 0x100,
        DFCS_PUSHED = 0x200,
        DFCS_CHECKED = 0x400,
        DFCS_TRANSPARENT = 0x800,
        DFCS_HOT = 0x1000,
        DFCS_ADJUSTRECT = 0x2000,
        DFCS_FLAT = 0x4000,
        DFCS_MONO = 0x8000;
        /*设备*/
        public const int DIGCF_ALLCLASSES = 0x00000004,
        DIGCF_PRESENT = 0x00000002,
        SPDRP_DEVICEDESC = 0x00000000,
        MAX_DEV_LEN = 1000,
        DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000,
        DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001,
        DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 0x00000004,
        DIF_PROPERTYCHANGE = 0x00000012,
        DICS_FLAG_GLOBAL = 0x00000001,
        DICS_FLAG_CONFIGSPECIFIC = 0x00000002,
        DICS_ENABLE = 0x00000001,
        DICS_DISABLE = 0x00000002;


        public const string TOOLTIPS_CLASS = "tooltips_class32";
        public const string SHELL_TRAYWND = "Shell_TrayWnd";

        #region ULW
        public const int ULW_COLORKEY = 0x00000001;
        public const int ULW_ALPHA = 0x00000002;
        public const int ULW_OPAQUE = 0x00000004;
        #endregion
    }
}
