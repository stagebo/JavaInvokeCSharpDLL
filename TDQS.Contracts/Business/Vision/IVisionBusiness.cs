#region CLR版本 4.0.30319.239
// IVisionBusiness 接口
// 时间：2011/12/8 10:51:51
// 名称：视野管理接口
// 大纲：
//
// 创建人：孙书涛
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TDQS.Contracts
{
    /// <summary>
    /// 视野管理接口
    /// </summary>
    public interface IVisionBusiness
    {
        #region 方法
        /// <summary>
        /// 增加视野模型
        /// </summary>
        /// <param name="vml"></param>
        void VisionModelAppend(IVisionModel vml);
        /// <summary>
        /// 增加视野模型
        /// </summary>
        /// <param name="visionname"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void VisionAppend(string visionname, string x1, string y1, string x2, string y2);
        /// <summary>
        /// 替换视野信息
        /// </summary>
        /// <param name="visionname"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void VisionReplace(string visionname, string x1, string y1, string x2, string y2);
        /// <summary>
        /// 根据名称得到视野模型
        /// </summary>
        /// <param name="name">视野名称</param>
        /// <returns></returns>
        IVisionModel GetVisionModelLayerByName(string name);
        /// <summary>
        /// 得到指定位置的视野模型对象
        /// </summary>
        /// <param name="index">序号</param>
        /// <returns></returns>
        IVisionModel GetVisionModelAtIndex(int index);

        /// <summary>
        /// 确定视野模型是否存在
        /// </summary>
        /// <param name="vml"></param>
        /// <returns></returns>
        bool VisionModelLayerExist(IVisionModel vml);
        /// <summary>
        /// 确定指定名称的视野是否存在
        /// </summary>
        /// <param name="name">视野名称</param>
        /// <returns>是否存在</returns>
        bool VisionModelLayerExist(string name);
        /// <summary>
        /// 向指定位置插入视野模型
        /// </summary>
        /// <param name="vml"></param>
        /// <param name="index"></param>
        void VisionModelInsert(IVisionModel vml, int index = 0);
        /// <summary>
        /// 根据名称删除视野
        /// </summary>
        /// <param name="name"></param>
        void VisionModelRemove(string name);
        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTable();
        #endregion // 方法

        #region 属性
        /// <summary>
        /// 获取已存在视野
        /// </summary>
        int Count
        {
            get;
        }

        /// <summary>
        /// 得到模型集合
        /// </summary>
        /// <returns></returns>
        List<IVisionModel> GetVisionModelList
        {
            get;
        }
        #endregion // 属性

        #region 事件
        /// <summary>
        /// 增加项事件
        /// </summary>
        event EventHandler VisionNewItem;
        #endregion // 事件
    }
}

