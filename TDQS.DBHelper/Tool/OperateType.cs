using System;
using System.Collections.Generic;
using System.Text;

namespace TDQS.DBHelper
{
    /// <summary>
    /// 操作类型类枚举
    /// </summary>
    public enum OperateType { 
        
        /// <summary>
        /// 插入操作
        /// </summary>
        Insert = 0, 
        
        /// <summary>
        /// 更新操作
        /// </summary>
        Update = 1, 
        
        /// <summary>
        /// 删除操作
        /// </summary>
        Delete = 2, 

        /// <summary>
        /// 选择操作
        /// </summary>
        Select = 3 }
}
