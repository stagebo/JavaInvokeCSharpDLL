using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 显示类型枚举
    /// </summary>
    public enum DisplayType : int
    {
        //隐藏
        Hide = -1,
        //反置，原来隐藏则显示，原来显示则隐藏
        Invert = 0,
        //显示
        Show = 1,
    }
}
