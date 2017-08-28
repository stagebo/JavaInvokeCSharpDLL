#region CLR版本 4.0.30319.269
// SystemConfigXML 类
// 时间：6/10/2012 3:57:22 PM
// 名称：系统设置辅助的XML操作类
// 大纲：系统设置辅助的XML操作类
//
// 创建人：王东云
// 版权：2012 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
// 2012/11/19 13:42:23, 刘东亮, 整理代码添加region标签，添加中高压界限属性（临时方案）
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace TDQS.Contracts
{
    /// <summary>
    /// 系统设置辅助的XML操作类
    /// </summary>
    public interface ISystemConfig
    {
        #region 公有方法

        /// <summary>
        ///  获取配置
        /// </summary>
        /// <param name="node">配置名</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.GetCofig("Node", "")
         * SystemConfigXML.GetCofig("Node", "Attribute")
         ************************************************/
        string[] GetCofig(string name, string attribute);

        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="node">标签名称</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.Read("Node", "")
         * SystemConfigXML.Read("Node", "Attribute")
         ************************************************/
        string Read(string node, string attribute);

        /// <summary>
        /// 用几点名称获取第一个节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>获取的节点</returns>
        XmlNode getNode(string node);

        /// <summary>
        /// 用几点名称获取第一个节点下的某个节点
        /// </summary>
        /// <param name="nodeName">父节点</param>
        /// <param name="pName">子节点</param>
        /// <returns></returns>
        string getNode(string nodeName, string pName);
        /// <summary>
        /// 用几点名称获取第一个节点
        /// </summary>
        /// <param name="node">节点名称</param>
        /// <returns>获取的节点</returns>
        XmlNode RecoverNode(string node);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.Insert("/Node", "Element", "", "Value")
         * SystemConfigXML.Insert("/Node", "Element", "Attribute", "Value")
         * SystemConfigXML.Insert("/Node", "", "Attribute", "Value")
         ************************************************/
        void Insert(string node, string element, string attribute, string value);

        /// <summary>
        ///  插入文本格式的项 默认为选中
        /// </summary>
        /// <param name="node">父节点</param>
        /// <param name="nodetxt">子节点text</param>
        /// <param name="value">子节点值</param>
        void Insert(string node, string nodetxt, string value);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.Update("/Node", "", "Value")
         * SystemConfigXML.Update("/Node", "Attribute", "Value")
         ************************************************/
        void Update(string node, string attribute, string value);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.UpdateSingle("Node", "", "Value")
         * SystemConfigXML.UpdateSingle("Node", "Attribute", "Value")
         ************************************************/
        bool UpdateSingle(string node, string attribute, string value);

        /// <summary>
        /// 根据项的属性值查找项
        /// </summary>
        /// <param name="node">父节点</param>
        /// <param name="nodetxt">子节点text</param>
        /// <param name="attribute">子节点属性名称</param>
        /// <param name="value">子节点属性值</param>
        /// <returns>是否更新成功</returns>
        bool UpdateItem(string node, string nodetxt, string attribute, string value);

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="path">节点text</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool UpdateSingle(string node, string nodetxt, string text, string value);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * SystemConfigXML.Delete("/Node", "")
         * SystemConfigXML.Delete("/Node", "Attribute")
         ************************************************/
        void Delete(string node, string attribute);

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodetxt"></param>
        void DeleteSingle(string node, string nodetxt);


        /// <summary>
        /// 还原默认值
        /// </summary>
        void OverWrite();

        /// <summary>
        /// 保存
        /// </summary>
        void Save();
        #endregion // 公有方法

        #region 属性

        /// <summary>
        /// 电压分界值
        /// </summary>
        double VoltageBoundary
        {
            get;
            set;
        }

        /// <summary>
        /// 是否启用正交
        /// </summary>
        bool Orthogon { get; set; }

        #region 自动布线

        /// <summary>
        /// 是否自动布线
        /// </summary>
        bool AutoConn { get; set; }

        /// <summary>
        /// 自动布线方式
        /// manualMode(非自动布线设置): 0 => 站内接线图, 1 => 右键菜单
        /// </summary>
        int manualMode { get; set; }

        #endregion

        #region 捕捉

        /// <summary>
        /// 是否启用捕捉
        /// </summary>
        bool EnableCaptrue { get; set; }

        /// <summary>
        /// 捕捉半径
        /// </summary>
        int SnapRadius { get; set; }

        #endregion

        #endregion
    }
}