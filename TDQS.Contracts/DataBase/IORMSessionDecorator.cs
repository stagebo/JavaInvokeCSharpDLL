#region CLR版本 4.0.30319.239
// IORMSessionDecorator  接口 类
// 时间：2012-11-21 10:06:20
// 名称：ORM Session装饰类
// 大纲：提供Session的相关处理接口
//
// 创建人：聂桂春
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
    /// ORM Session的接口对象
    /// </summary>
    public interface IORMSessionDecorator : IDisposable
    {
        #region 方法

        #region 工程相关


        
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="info">工程数据</param>
        /// <returns>插入是否成功</returns>
        bool Save(IProject info);

        /// <summary>
        /// 更新工程
        /// </summary>
        /// <param name="info">工程数据</param>
        /// <returns>更新结果</returns>
        bool Update(IProject info);

        /// <summary>
        /// 删除工程
        /// </summary>
        /// <param name="f_id">工程ID</param>
        void Delete(string f_id);

        /// <summary>
        /// 工程信息
        /// </summary>
        /// <param name="f_id">工程ID</param>
        /// <returns>工程数据对象</returns>
        IProject GetInfo(string f_id);

        #endregion
        /// <summary>
        /// 获得元件
        /// </summary>
        /// <param name="f_id">元件ID</param>
        /// <returns>元件对象</returns>
        IElement GetInfo<T>(string f_id) where T : IElement;

        /// <summary>
        /// 判断元件是否存在 
        /// </summary>
        /// <param name="f_id">元件ID</param>
        /// <param name="f_subgchid">工程ID</param>
        /// <returns>是否存在</returns>
        bool Exists<T>(string f_id, string f_subgchid) where T : IElement;

        /// <summary>
        /// 获得元件
        /// </summary>
        /// <param name="f_id">元件ID</param>
        /// <param name="f_subgchid">工程ID</param>
        /// <returns>元件对象</returns>
        IElement GetInfo<T>(string f_id, string f_subgchid) where T : IElement;

         /// <summary>
        /// 获得电网的该类元件集合
        /// </summary>
        /// <param name="f_subgchid">工程ID</param>
        /// <returns>元件集合</returns>
        IList<T> GetList<T>(string f_subgchid) where T : IElement;

        /// <summary>
        /// 获得电网的该类元件集合
        /// </summary>
        /// <param name="f_subgchid">工程ID</param>
        /// <returns>元件集合</returns>
        IList<IElmentFQRelation> GetList(string f_subgchid);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="relation"></param>
        void Save(IElmentFQRelation relation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relation"></param>
        void Update(IElmentFQRelation relation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="relation"></param>
        void Delete(IElmentFQRelation relation);

        /// <summary>
        /// 开启Session的事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交Session的事务
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚Session的事务
        /// </summary>
        void Rollback();

        /// <summary>
        /// 保存元件对象
        /// </summary>
        /// <param name="eml"></param>
        void Save(IElement eml);

        /// <summary>
        /// 保存一组元件
        /// </summary>
        /// <param name="elms">元件集合</param>
        void Save(IElement[] elms);

        /// <summary>
        /// 更新元件
        /// </summary>
        /// <param name="element">元件</param>
        void Update(IElement element);

        /// <summary>
        /// 解析来之图形业务对象（对象数组）操作：更新
        /// </summary>
        /// <param name="elms">元件集合</param>
        void Update(IElement[] elms);

        /// <summary>
        /// 更新元件
        /// </summary>
        /// <param name="elms">元件集合</param>
        void Update(ICollection<IElement> elms);

        /// <summary>
        /// 删除元件 
        /// </summary>
        /// <param name="elm">元件</param>
        void Delete(IElement elm);

        /// <summary>
        /// 解析来之图形业务对象（对象数组）操作：删除
        /// </summary>
        /// <param name="elms">元件集合</param>
        void Delete(IElement[] elms);

        /// <summary>
        /// 解析来之图形业务对象（对象数组）操作：删除
        /// </summary>
        /// <param name="ic">元件集合</param>
        void Delete(ICollection<IElement> ic);

        /// <summary>
        /// 执行增删改sql语句
        /// </summary>
        /// <param name="sql">要执行的sql语句（多个sql要用分号分隔）</param>
        /// <returns>返回最后一条命令影响的记录数</returns>
        int Execute(string sql);

        /// <summary>
        /// 执行增删改sql语句(内置事务处理)
        /// </summary>
        /// <param name="sql">要执行的sql语句（多个sql要用分号分隔）</param>
        /// <returns>返回最后一条命令影响的记录数</returns>
        int ExecuteWithTrans(string sql);

        /// <summary>
        /// 是否活动事务
        /// </summary>
        bool IsTranActive
        {
            get;
        }

        #endregion

    }
}
