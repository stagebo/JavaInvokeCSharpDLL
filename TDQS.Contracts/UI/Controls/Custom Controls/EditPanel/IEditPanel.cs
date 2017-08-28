#region CLR版本 4.0.30319.239
// IEditPanel 接口
// 时间：2011-11-10 14:04:17
// 名称：IEditPanel 
// 大纲：所有数据编辑项应继承与BaseLib的ctlEditPanel自定义控件，并实现本接口
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 所有数据编辑项应继承与BaseLib的ctlEditPanel自定义控件，并实现本接口。
    /// </summary>
    public interface IEditPanel
    {
        #region 方法
        /// <summary>
        /// 初始化控件
        /// </summary>
        void mInit();
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        bool mLoad();
        /// <summary>
        /// 保存数据,确定
        /// </summary>
        /// <returns></returns>
        bool mSave();
        /// <summary>
        /// 取消保存，取消
        /// </summary>
        void mCancel();
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <returns></returns>
        bool mValidate();
        /// <summary>
        /// 设置恢复默认值
        /// </summary>
        void mDefault();
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 用户控件实例
        /// </summary>
        UserControl View { get; }

        /// <summary>
        /// 传递外部初始化参数对象
        /// </summary>
        object DataObj { get; set; }

        /// <summary>
        /// 是否加载
        /// </summary>
        bool IfLoad { get; }

        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

