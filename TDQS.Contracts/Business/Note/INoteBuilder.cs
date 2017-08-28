#region CLR版本 4.0.30319.269
// INoteBuilder 接口
// 时间：2012-09-25 9:03:37
// 名称：标注创建接口
// 大纲：处理标注创建逻辑和更新逻辑
//
// 创建人：夏禹
// 版权：Copyright (C) 2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 标注创建接口
    /// </summary>
    public interface INoteBuilder
    {
        #region 方法
        ///// <summary>
        ///// 刷新所有元件标注
        ///// </summary>
        ///// <param name="doc">文档</param>
        //void RefreshAllElementNotes(IDocument doc);

        ///// <summary>
        // /// 刷新组样式
        // /// </summary>
        // /// <param name="noteGroup"></param>
        // void SetGroupStyle(NoteGroup grp);
        /// <summary>
        /// 刷新元件标注内容
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="propName"></param>
        void UpdateElementNote(IElement elem, string propName);

        /// <summary>
        /// 创建短路标注
        /// </summary>
        void BuildShortNotes();

        /// <summary>
        /// 创建元件标注
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        IDrawObject BuildElementNote(IElement elem);

        /// <summary>
        /// 创建潮流标注
        /// </summary>
        void BuildFlowNotes();

        /// <summary>
        /// 得到元件标注文本
        /// </summary>
        /// <param name="elem">元件</param>
        /// <returns>标注文本</returns>
        string GetElementNoteText(IElement elem);

        /// <summary>
        /// 保存标注配置
        /// </summary>
        void SaveConfig();
        /// <summary>
        /// 检查不存在图元的元件（效验方式需要改进）
        /// </summary>
        void CheckElementToShape();

        /// <summary>
        /// 构造附加标注（故障点，并网点等）
        /// </summary>
        /// <param name="additionalInfo">附加标注信息</param>
        /// <returns>是否成功</returns>
        bool BuildAdditionalNote(object additionalInfo);

        /// <summary>
        /// 更新附加标注（故障点，并网点等）
        /// </summary>
        /// <param name="additionalInfo">附加标注信息</param>
        void UpdateAdditionalNote(object additionalInfo);

        /// <summary>
        /// 删除附加标注（故障点，并网点等）
        /// </summary>
        /// <param name="additionalInfo">附加标注信息</param>
        void DeleteAdditionalNote(object additionalInfo);

        /// <summary>
        /// 删除所有附加标注
        /// </summary>
        /// <param name="additionalInfos">附加标注信息</param>
        void DeleteAllAdditionalNote(object additionalInfos);

        /// <summary>
        /// 创建可靠性标注
        /// </summary>
        void BuildReliabilityNotes();

        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取或设置标注显示状态
        /// </summary>
        bool IsNoteVisible
        {
            get;
            set;
        }
        #endregion // 属性

        #region 事件
        #endregion // 事件
    }
}

