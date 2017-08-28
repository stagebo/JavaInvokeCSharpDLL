
//using System;
//using System.Diagnostics;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Configuration;
//using System.Data;
//using TDQS.DBHelper;

//namespace TDYH
//{
//    /// <summary>
//    /// 停电优化
//    /// </summary>
//    public class TDYHDecorator
//    {
//        #region 构造和析构

//        /// <summary>
//        /// 构造
//        /// </summary>
//        /// <param name="view">视图对象</param>
//        /// <param name="callType">可靠性计算类型</param>
//        public TDYHDecorator()
//        {
//            Console.WriteLine("step3");
//            m_message = "停电计划优化";
//        }

//        #endregion // 构造和析构

//        #region 公有方法

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        public string Do()
//        {
//            Console.WriteLine("do()");
//            return "success tdyh";
//        }
//        /// <summary>
//        /// 执行停电计划优化
//        /// </summary>
//        /// <param name="connStr"></param>
//        /// <param name="dept"></param>
//        /// <param name="gchid"></param>
//        /// <returns>执行是否成功</returns>
//        public string Do(string connStr, string dept, string gchid)
//        {

//            string errMsg = "";
//            try
//            {
//                m_database = new PostgreSqlDatabase(connStr);
//                m_gchid = gchid;
//                m_dept = dept;
//                DataTable planTable = Check(out errMsg);
//                if (planTable == null)
//                {
//                    return 0 + "|" + errMsg;
//                }
//                if (!ClearResult())
//                {
//                    errMsg = "清理" + m_message + "结果失败！";
//                    return 0 + "|" + errMsg;
//                }
//                //if (!SaveResult(planTable))
//                //{
//                //    errMsg = "保存" + m_message + "结果失败！";
//                //    return 0+"|"+errMsg;
//                //}
//                return "1";
//            }
//            catch
//            {
//                errMsg = m_message + "失败！";
//                return 0 + "|" + errMsg;
//            }
//        }

//        #endregion // 公有方法

//        #region 保护方法

//        #endregion // 保护方法

//        #region 私有方法

//        /// <summary>
//        /// 算法计算前校验
//        /// </summary>
//        /// <returns>校验结果</returns>
//        private DataTable Check(out string errMsg)
//        {
//            errMsg = "";
//            //1、校验是否已经导入生成作业计划
//            string sql = @"select work_location,plan_startdate,plan_enddate,operation_mode  from production_plan where apply_dept='{0}'";
//            DataTable planTable = m_database.QueryTable(string.Format(sql, m_dept));
//            if (planTable == null || planTable.Rows.Count == 0)
//            {
//                errMsg = "系统未查找到当前部门提报的生产作业计划。";
//                return null;
//            }
//            return planTable;
//        }

//        /// <summary>
//        /// 清理结果
//        /// </summary>
//        /// <returns></returns>
//        private bool ClearResult()
//        {
//            string delSql = "";
//            delSql = "delete from ta_kkx2_xtfwnyh_temp where f_subgchid='" + m_gchid + "';"
//                                + "delete from ta_kkx2_kxfwnyh_temp where f_subgchid='" + m_gchid + "';"
//                                + "delete from ta_kkx2_bdzhfwnyh_temp where f_subgchid='" + m_gchid + "';";

//            int result = m_database.Execute(delSql);
//            return result == -1 ? false : true;
//        }

//        /// <summary>
//        /// 保存敏感性结果
//        /// </summary>
//        /// <param name="mytran">事务</param>
//        /// <returns>保存结果</returns>
//        // private bool SaveResult(DataTable planTable)
//        // {
//        //     /*
//        //      1、	判断停电计划表中的“工作地点（停电设备）”的设备类型
//        //      （1）	若为断路器、负荷开关，则以“工作地点（停电设备）”为元件ID，在YFMEA表中筛选出对应的负荷点ID；
//        //      （2）	若为隔离开关、熔断器，则在YFMEA中找到故障隔离开关ID为该“工作地点（停电设备）”且上游恢复开关ID不为“-1”的任意一条记录，取其元件ID，筛选出对应的负荷点ID；
//        //      2、	根据所有负荷点ID，计算停电计划表中每个负荷的停电次数及时长（单位h，需折算为分钟），注意只统计“工作方式”为停电的记录；
//        //      3、	更新每个负荷点的预安排可靠性参数：
//        //      （1）	预安排停电率=总停电次数/系统各类设备总数或总长度*100；
//        //      （2）	预安排停电平均持续时间=∑单次停电时长/总停电次数*60；
//        //      4、	按原有可靠性结果表处理方式生成可靠性计算结果（系统表、变电站表、馈线表）
//        //     【注意事项】：
//        //      1、	计算预安排停电率时，开关、配变类使用总台数，电缆、架空线使用总长度，单位为km；
//        //     */

//        //    string query_yfma=@"SELECT f_subgchid,f_no,f_fhdno, f_gzhglkgno,
//        //f_shyhfkgno, f_entid, f_mch, f_type FROM ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}' ) and f_type >=4";
//        //     DataTable yfmea_table=m_database.QueryTable(string.Format(query_yfma,m_gchid));
//        //     if(yfmea_table ==null||yfmea_table .Rows.Count ==0)
//        //     {
//        //         return true ;
//        //     }
//        //     EnumerableRowCollection<DataRow> yfmea_rows= yfmea_table.AsEnumerable();
//        //     //名称、类型、编号、负荷点编号、故障隔离开关编号、上游恢复开关编号
//        //     ILookup<string, Tuple<string,int,int, int, int, int,string>> yfmeaLUP = yfmea_rows.Select
//        //         (r=> new Tuple<string,int, int, int, int, int,string>(
//        //             r["f_mch"].ToString(),
//        //             int.Parse(r["f_type"].ToString()),
//        //             int.Parse(r["f_no"].ToString()), 
//        //             int.Parse(r["f_fhdno"].ToString()),
//        //             int.Parse(r["f_gzhglkgno"].ToString()),
//        //             int.Parse(r["f_shyhfkgno"].ToString()),
//        //             r["f_subgchid"].ToString())).ToLookup(key => key.Item1);
//        //     IDictionary<int, string> yfmeaDic = 
//        //         yfmea_rows.ToDictionary(key => int.Parse(key["f_no"].ToString()), value => value["f_mch"].ToString());


//        //     IDictionary<int, Tuple<int, double,string>> fh_parmDic = new Dictionary<int, Tuple<int, double,string>>();

//        //     ILookup<string, Tuple<string, object, object>> plan_LUP = planTable.AsEnumerable().
//        //         Where(r => r["operation_mode"].ToString() == "停电").Select
//        //         (r => new Tuple<string, object, object>(
//        //             DealMCH(r["work_location"].ToString()), r["plan_startdate"], r["plan_enddate"])).ToLookup(key => key.Item1);

//        //     IEnumerator<IGrouping<string,Tuple<string, object, object>>> planEnumerator = plan_LUP.GetEnumerator();

//        //     while(planEnumerator.MoveNext())
//        //     {
//        //         IGrouping<string,Tuple<string, object, object>> plan= planEnumerator.Current;

//        //         Tuple<string, object, object> firstPlan = plan.FirstOrDefault();

//        //         if (firstPlan.Item2 == DBNull.Value)
//        //         {
//        //             continue;
//        //         }
//        //         DateTime begDate;
//        //         if (!DateTime.TryParse(firstPlan.Item2.ToString(), out begDate))
//        //         {
//        //             continue;
//        //         }
//        //         if (firstPlan.Item3 == DBNull.Value)
//        //         {
//        //             continue;
//        //         }
//        //         DateTime endDate;
//        //         if (!DateTime.TryParse(firstPlan.Item3.ToString(), out endDate))
//        //         {
//        //             continue;
//        //         }
//        //         //计算停电持续时间
//        //         TimeSpan ts = endDate - begDate;
//        //         double minutes = ts.TotalMinutes;

//        //         //名称、类型、编号、负荷点编号、故障隔离开关编号、上游恢复开关编号
//        //         Tuple<string, int, int, int, int, int,string> yFmeaInfo = yfmeaLUP[plan.Key].FirstOrDefault();
//        //         if (yFmeaInfo == null)
//        //         {
//        //             continue;
//        //         }

//        //         ElementTypeEx type = (ElementTypeEx)yFmeaInfo.Item2;
//        //         switch (type)
//        //         {
//        //             case ElementTypeEx.断路器:
//        //             case ElementTypeEx.负荷开关:
//        //                 //若为断路器、负荷开关，则以“工作地点（停电设备）”为元件ID，在YFMEA表中筛选出对应的负荷点ID；
//        //                 foreach (Tuple<string, int, int, int, int, int,string> yfmea in yfmeaLUP[plan.Key])
//        //                 {
//        //                     int fhdno = yFmeaInfo.Item4;
//        //                     Tuple<int, double,string> fh_parm;
//        //                     if (!fh_parmDic.TryGetValue(fhdno, out fh_parm))
//        //                     {
//        //                         fh_parm = new Tuple<int, double,string>(1, minutes,yfmea.Item7);
//        //                         fh_parmDic.Add(fhdno, fh_parm);
//        //                     }
//        //                     else
//        //                     {
//        //                         fh_parm = new Tuple<int, double,string>(fh_parm.Item1+1, fh_parm.Item2 + minutes,yfmea.Item7);
//        //                         fh_parmDic[fhdno] = fh_parm;
//        //                     }
//        //                 }
//        //                 break;
//        //             case ElementTypeEx.熔断器:
//        //             case ElementTypeEx.隔离开关:
//        //                 //若为隔离开关、熔断器，则在YFMEA中找到故障隔离开关ID为该“工作地点（停电设备）”且上游恢复开关ID不为“-1”的任意一条记录，取其元件ID，
//        //                 //筛选出对应的负荷点ID；
//        //                 int glkgno = yFmeaInfo.Item5;
//        //                 string glkgmch = "";
//        //                 if(!yfmeaDic.TryGetValue(glkgno,out glkgmch))
//        //                 {
//        //                     continue;
//        //                 }
//        //                 Tuple<string, int, int, int, int, int,string> yFmeaInfo_glkg = yfmeaLUP[glkgmch].Where(r => r.Item6 != -1).FirstOrDefault();
//        //                 if (yFmeaInfo_glkg==null)
//        //                 {
//        //                     continue;
//        //                 }
//        //                 int fhdno_glkg = yFmeaInfo_glkg.Item4;
//        //                 Tuple<int, double,string> fh_parm_glkg;
//        //                 if (!fh_parmDic.TryGetValue(fhdno_glkg, out fh_parm_glkg))
//        //                 {
//        //                     fh_parm_glkg = new Tuple<int, double,string>(1, minutes,yFmeaInfo_glkg.Item7);
//        //                     fh_parmDic.Add(fhdno_glkg, fh_parm_glkg);
//        //                 }
//        //                 else
//        //                 {
//        //                     fh_parm_glkg = new Tuple<int, double,string>(fh_parm_glkg.Item1 + 1, fh_parm_glkg.Item2 + minutes,yFmeaInfo_glkg.Item7);
//        //                     fh_parmDic[fhdno_glkg] = fh_parm_glkg;
//        //                 }
//        //                 break;
//        //             default:
//        //                 continue;
//        //         }

//        //     }
//        //     /*
//        //      3、	更新每个负荷点的预安排可靠性参数：
//        //      （1）	预安排停电率=总停电次数/系统各类设备总数或总长度*100；
//        //      （2）	预安排停电平均持续时间=∑单次停电时长/总停电次数*60；
//        //      */
//        //     string querySQL_allfhd=@"select count(a.f_count) from( 
//        // select count(f_id) as f_count from t_pb where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}' )
//        // union
//        // select count(f_id) as f_count from t_zhshb where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}' )
//        // union
//        // select count(f_id) as f_count from t_pdbyq_new where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}' ) 
//        // ) a";
//        //     double allFH=0;
//        //     DataTable allFHTable=m_database.QueryTable(string.Format(querySQL_allfhd,m_gchid));
//        //     if(allFHTable !=null&&allFHTable.Rows.Count >0)
//        //     {
//        //         if(!double.TryParse(allFHTable .Rows[0][0].ToString (),out allFH))
//        //         {
//        //             allFH=0;
//        //         }
//        //     }
//        //     string updateSQL_clearYFameValue = @"update ta_kkx2_yfmea set f_fhdyapgzhl=0 ,f_fhdyapgzhtdpjchxshj=0 where 
//        //         f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}' ) ";
//        //     if(m_database.Execute(string.Format(updateSQL_clearYFameValue,m_gchid))==-1)
//        //     {
//        //         return false;
//        //     }
//        //     string updateSQL_haveParm = "update ta_kkx2_yfmea set f_fhdyapgzhl={0} ,f_fhdyapgzhtdpjchxshj={1} where f_subgchid='{2}' and f_fhdno={3};";
//        //     StringBuilder updateBuilder = new StringBuilder();
//        //     foreach (int fhNo in fh_parmDic.Keys)
//        //     {
//        //         Tuple<int,double,string> fhInfo=fh_parmDic[fhNo];
//        //         //预安排停电率=总停电次数/系统各类设备总数或总长度*100；
//        //         double yaptdl=allFH==0?0:fhInfo.Item1/allFH;
//        //         //预安排停电平均持续时间=∑单次停电时长/总停电次数*60；
//        //         double yappjtdchxshj=fhInfo.Item1==0?0:fhInfo.Item2/fhInfo.Item1;
//        //         updateBuilder.Append(string.Format(updateSQL_haveParm, yaptdl, yappjtdchxshj, fhInfo.Item3, fhNo));
//        //     }
//        //     if (m_database.Execute(updateBuilder.ToString()) == -1)
//        //     {
//        //         return false;
//        //     }
//        //     //重新汇总结果
//        //     return SaveReliabilityResult();
//        // }


//        // <summary>
//        /// 保存可靠性结果
//        /// </summary>
//        /// <param name="mytran">事务</param>
//        /// <returns>保存结果</returns>
//        private bool SaveReliabilityResult()
//        {

//            #region 1、获取GFMEA统计值

//            #region 3.2、馈线

//            DataTable mgxyzh_kx = m_database.QueryTable(
//                string.Format(@"
//select  v1.f_kxid,v1.f_kxmch,v1.f_bdzhid,v1.f_bdzhmch,v1.f_fhdgzhl,v1.f_fhdyapgzhl,
//            v1.f_fhdnpjtdshj,v1.f_fhdyapnpjtdshj as f_fhdyapnpjtdshj,
//            v1.f_qgdl_yap,v1.f_qgdl_gzh,
//            v2.f_yhsh,case v2.f_yhsh when 0 then 0 else (v1.f_qgdl_yap+f_qgdl_gzh)/v2.f_yhsh end as f_pjqgdl  
//from 
//(select f_kxid,f_kxmch,f_bdzhid,f_bdzhmch,
//sum(f_fhdgzhl*f_fhdyhsh) as f_fhdgzhl,sum(f_fhdyapgzhl*f_fhdyhsh) as f_fhdyapgzhl,
//            sum(f_fhdnpjtdshj*f_fhdyhsh) as f_fhdnpjtdshj,
//            sum(f_fhdyapnpjtdshj*f_fhdyhsh) as f_fhdyapnpjtdshj ,
//            sum(f_fhdnpjtdshj*f_fhdygfh/60) as f_qgdl_gzh,sum(f_fhdyapnpjtdshj*f_fhdygfh/60) as f_qgdl_yap 
//from
//(select f_kxid,f_kxmch,f_bdzhid,f_bdzhmch,f_dqid,
//f_fhdgzhl, 0 as f_fhdyapgzhl,f_fhdnpjtdshj,0 as f_fhdyapnpjtdshj,f_fhdygfh,f_fhdyhsh  from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//union all 
//select f_kxid,f_kxmch,f_bdzhid,f_bdzhmch,f_dqid,
//0 as f_fhdgzhl,f_fhdyapgzhl,0 as f_fhdnpjtdshj,f_fhdyapnpjtdshj,f_fhdygfh ,f_fhdyhsh from ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}')  ) innerv
//group by f_kxid,f_kxmch ,f_bdzhid,f_bdzhmch)v1 ,
//(select  f_kxid,sum(f_fhdyhsh) as f_yhsh from
//(select f_kxid,f_fhdid,f_fhdyhsh from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}')  
//union 
//select f_kxid,f_fhdid,f_fhdyhsh  from ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') ) innerv 
//group by  f_kxid ) v2 
//where v1.f_kxid=v2.f_kxid ", m_gchid));
//            IDictionary<string, Tuple<string, string, kkxResult>> resultDic_kx = new Dictionary<string, Tuple<string, string, kkxResult>>();
//            foreach (DataRow row in mgxyzh_kx.Rows)
//            {
//                string kxid = row["f_kxid"].ToString();
//                if (resultDic_kx.ContainsKey(kxid))
//                {
//                    continue;
//                }
//                kkxResult mgxResult = new kkxResult();
//                string bdzhid = row["f_bdzhid"].ToString();
//                string bdzhmch = row["f_bdzhmch"].ToString();

//                mgxResult.mch = row["f_kxmch"].ToString();
//                mgxResult.tdpl_gzh = GetDoubleValue(row["f_fhdgzhl"]);
//                mgxResult.tdpl_yap = GetDoubleValue(row["f_fhdyapgzhl"]);
//                mgxResult.pjtdchxshj_gzh = GetDoubleValue(row["f_fhdnpjtdshj"]) / 60d;
//                mgxResult.pjtdchxshj_yap = GetDoubleValue(row["f_fhdyapnpjtdshj"]) / 60d;
//                mgxResult.qgdl_gzh = GetDoubleValue(row["f_qgdl_gzh"]);
//                mgxResult.qgdl_yap = GetDoubleValue(row["f_qgdl_yap"]);
//                mgxResult.yhsh = GetIntValue(row["f_yhsh"]);

//                resultDic_kx.Add(kxid, new Tuple<string, string, kkxResult>
//                    (bdzhid, bdzhmch, mgxResult));
//            }


//            #endregion 3.2、馈线

//            #region 3.3、变电站

//            DataTable mgxyzh_bdzh = m_database.QueryTable(
//                string.Format(@"
//select  v1.f_bdzhid,v1.f_bdzhmch,v1.f_fhdgzhl,v1.f_fhdyapgzhl,
//            v1.f_fhdnpjtdshj,v1.f_fhdyapnpjtdshj as f_fhdyapnpjtdshj,
//            v1.f_qgdl_yap,v1.f_qgdl_gzh,
//            v2.f_yhsh,case v2.f_yhsh when 0 then 0 else (v1.f_qgdl_yap+f_qgdl_gzh)/v2.f_yhsh end as f_pjqgdl  
//from 
//(select f_bdzhid,f_bdzhmch,
//sum(f_fhdgzhl*f_fhdyhsh) as f_fhdgzhl,sum(f_fhdyapgzhl*f_fhdyhsh) as f_fhdyapgzhl,
//            sum(f_fhdnpjtdshj*f_fhdyhsh) as f_fhdnpjtdshj,
//            sum(f_fhdyapnpjtdshj*f_fhdyhsh) as f_fhdyapnpjtdshj ,
//            sum(f_fhdnpjtdshj*f_fhdygfh/60) as f_qgdl_gzh,sum(f_fhdyapnpjtdshj*f_fhdygfh/60) as f_qgdl_yap 
//from
//(select f_bdzhid,f_bdzhmch,
//f_fhdgzhl, 0 as f_fhdyapgzhl,f_fhdnpjtdshj,0 as f_fhdyapnpjtdshj,f_fhdygfh,f_fhdyhsh  from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//union all 
//select f_bdzhid,f_bdzhmch,
//0 as f_fhdgzhl,f_fhdyapgzhl,0 as f_fhdnpjtdshj,f_fhdyapnpjtdshj,f_fhdygfh ,f_fhdyhsh from ta_kkx2_yfmea where f_subgchid  in (select f_subgchid from t_subgch where f_gchid='{0}')  ) innerv
//group by f_bdzhid,f_bdzhmch )v1 ,
//(select  f_bdzhid,sum(f_fhdyhsh) as f_yhsh from
//(select f_bdzhid,f_fhdid,f_fhdyhsh from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//union 
//select f_bdzhid,f_fhdid,f_fhdyhsh  from ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') ) innerv 
//group by  f_bdzhid ) v2 
//where v1.f_bdzhid=v2.f_bdzhid ", m_gchid));
//            IDictionary<string, kkxResult> resultDic_bdzh = new Dictionary<string, kkxResult>();
//            foreach (DataRow row in mgxyzh_bdzh.Rows)
//            {
//                string bdzhid = row["f_bdzhid"].ToString();
//                if (resultDic_bdzh.ContainsKey(bdzhid))
//                {
//                    continue;
//                }
//                kkxResult mgxResult = new kkxResult();
//                resultDic_bdzh.Add(bdzhid, mgxResult);
//                mgxResult.mch = row["f_bdzhmch"].ToString();
//                mgxResult.tdpl_gzh = GetDoubleValue(row["f_fhdgzhl"]);
//                mgxResult.tdpl_yap = GetDoubleValue(row["f_fhdyapgzhl"]);
//                mgxResult.pjtdchxshj_gzh = GetDoubleValue(row["f_fhdnpjtdshj"]) / 60d;
//                mgxResult.pjtdchxshj_yap = GetDoubleValue(row["f_fhdyapnpjtdshj"]) / 60d;
//                mgxResult.qgdl_gzh = GetDoubleValue(row["f_qgdl_gzh"]);
//                mgxResult.qgdl_yap = GetDoubleValue(row["f_qgdl_yap"]);
//                mgxResult.yhsh = GetIntValue(row["f_yhsh"]);
//            }

//            #endregion 3.3、变电站

//            #region 3.5、系统

//            DataTable mgxyzh_xt = m_database.QueryTable(
//                string.Format(@"
//            select  v1.f_subgchid,v1.f_fhdgzhl,v1.f_fhdyapgzhl,
//            v1.f_fhdnpjtdshj,v1.f_fhdyapnpjtdshj as f_fhdyapnpjtdshj,
//            v1.f_qgdl_yap,v1.f_qgdl_gzh,
//            v2.f_yhsh,case v2.f_yhsh when 0 then 0 else (v1.f_qgdl_yap+f_qgdl_gzh)/v2.f_yhsh end as f_pjqgdl 
//            from
//            (select f_subgchid, sum(f_fhdgzhl*f_fhdyhsh) as f_fhdgzhl,sum(f_fhdyapgzhl*f_fhdyhsh) as f_fhdyapgzhl,
//            sum(f_fhdnpjtdshj*f_fhdyhsh) as f_fhdnpjtdshj,
//            sum(f_fhdyapnpjtdshj*f_fhdyhsh) as f_fhdyapnpjtdshj ,
//            sum(f_fhdnpjtdshj*f_fhdygfh/60) as f_qgdl_gzh,sum(f_fhdyapnpjtdshj*f_fhdygfh/60) as f_qgdl_yap 
//            from
//            (select f_subgchid,f_fhdgzhl, 0 as f_fhdyapgzhl,f_fhdnpjtdshj,0 as f_fhdyapnpjtdshj,f_fhdygfh,f_fhdyhsh  from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//            union all 
//            select f_subgchid,0 as f_fhdgzhl,f_fhdyapgzhl,0 as f_fhdnpjtdshj,f_fhdyapnpjtdshj,f_fhdygfh ,f_fhdyhsh from ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//            ) innerv 
//            group by f_subgchid) v1,
//            (select  f_subgchid,sum(f_fhdyhsh) as f_yhsh from
//            (select f_subgchid,f_fhdid,f_fhdyhsh from ta_kkx2_gfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}')  
//            union 
//            select f_subgchid,f_fhdid,f_fhdyhsh  from ta_kkx2_yfmea where f_subgchid in (select f_subgchid from t_subgch where f_gchid='{0}') 
//            ) innerv 
//            group by  f_subgchid ) v2 
//            where v1.f_subgchid=v2.f_subgchid  ", m_gchid));
//            kkxResult result_xt = new kkxResult();
//            if (mgxyzh_xt != null && mgxyzh_xt.Rows.Count > 0)
//            {
//                DataRow tempRow = mgxyzh_xt.Rows[0];
//                result_xt.tdpl_gzh = GetDoubleValue(tempRow["f_fhdgzhl"]);
//                result_xt.tdpl_yap = GetDoubleValue(tempRow["f_fhdyapgzhl"]);
//                result_xt.pjtdchxshj_gzh = GetDoubleValue(tempRow["f_fhdnpjtdshj"]) / 60d;
//                result_xt.pjtdchxshj_yap = GetDoubleValue(tempRow["f_fhdyapnpjtdshj"]) / 60d;
//                result_xt.qgdl_gzh = GetDoubleValue(tempRow["f_qgdl_gzh"]);
//                result_xt.qgdl_yap = GetDoubleValue(tempRow["f_qgdl_yap"]);
//                result_xt.yhsh = GetIntValue(tempRow["f_yhsh"]);
//            }

//            #endregion 3.5、系统

//            #endregion 1、获取GFMEA统计值

//            #region 2、生成报表

//            #region 1、系统用户供电可靠性

//            //1、系统用户供电可靠性
//            /*
//                1	f_subgchid	电网ID
//                2	f_tdlx_no	停电序号
//                3	f_tdlx	停电类型
//                4	f_xtpjtdchxshjsaidi_h	系统平均停电持续时间SAIDI
//                5	f_xtpjtdchxshjsaidi_m	系统平均停电持续时间SAIDI
//                6	f_pjgdkylasai	平均供电可用率ASAI
//                7	f_xtpjtdplsaifi	系统平均停电频率SAIFI
//                8	f_xtqgdlens	系统缺供电量ENS
//                9	f_xtpjqgdlaens	系统平均缺供电量AENS
//                10	f_yhsh	用户总数

//            */

//            string insert_pre;
//            string insert_values;
//            int iIndex;
//            int iLength;
//            StringBuilder insertSql = new StringBuilder();

//            insert_pre = "insert into ta_kkx2_xtfwnyh_temp (f_subgchid,f_tdlx_no,f_tdlx,"
//                    + "f_xtpjtdchxshjsaidi_h,f_xtpjtdchxshjsaidi_m,f_pjgdkylasai,f_xtpjtdplsaifi,f_xtqgdlens,f_xtpjqgdlaens,f_yhsh,f_entid ) values";
//            insert_values = "('{0}', {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9},'{10}')";

//            insertSql.AppendLine(insert_pre);
//            IList<object> result_hj = new List<object>();
//            result_hj.Add(m_gchid);
//            result_hj.Add(0);
//            result_hj.Add("系统合计");

//            result_hj.Add(result_xt.pjtdchxshj_hj_h);
//            result_hj.Add(result_xt.pjtdchxshj_hj_h * 60d);
//            result_hj.Add(result_xt.pjgdkyl_hj_h);
//            result_hj.Add(result_xt.tdpl_hj_h);
//            result_hj.Add(result_xt.qgdl_hj);
//            result_hj.Add(result_xt.qgdl_hj_pj);
//            result_hj.Add(result_xt.yhsh);
//            result_hj.Add(m_gchid);

//            insertSql.Append(string.Format(insert_values, result_hj.ToArray()) + ",");

//            IList<object> result_gzh = new List<object>();
//            result_gzh.Add(m_gchid);
//            result_gzh.Add(1);
//            result_gzh.Add("故障停电");

//            //故障停电（注意字段对应），【系统平均停电持续时间】=	Gloadind.txt中∑（属于此系统的各负荷点【年停运时间】*对应负荷点的用户数）/各负荷点的用户数之和。
//            result_gzh.Add(result_xt.pjtdchxshj_gzh_h);
//            result_gzh.Add(result_xt.pjtdchxshj_gzh_h * 60d);
//            //故障停电（注意字段对应），【平均供电可用率】=（1-（故障停电的【系统平均停电持续时间】）/8760）*100%。
//            result_gzh.Add(1 - result_xt.pjtdchxshj_gzh_h / 8760d);
//            //故障停电（注意字段对应），【系统平均停电频率】= Gloadind.txt中∑（属于此系统的各负荷点【年停运率】*对应负荷点的用户数）/各负荷点的用户数之和。
//            result_gzh.Add(result_xt.tdpl_gzh_h);
//            //故障停电（注意字段对应），【系统缺供电量】= Gloadind.txt中属于此系统的各负荷点【平均电量不足】之和。
//            result_gzh.Add(result_xt.qgdl_gzh);
//            result_gzh.Add(result_xt.qgdl_gzh_pj);
//            result_gzh.Add(result_xt.yhsh);
//            result_gzh.Add(m_gchid);

//            insertSql.Append(string.Format(insert_values, result_gzh.ToArray()) + ",");

//            IList<object> result_yap = new List<object>();
//            result_yap.Add(m_gchid);
//            result_yap.Add(2);
//            result_yap.Add("预安排停电");

//            //预安排停电（注意字段对应），【系统平均停电持续时间】= 	Yloadind.txt中∑（属于此系统的各负荷点【年停运时间】*对应负荷点的用户数）/各负荷点的用户数之和。
//            result_yap.Add(result_xt.pjtdchxshj_yap_h);
//            result_yap.Add(result_xt.pjtdchxshj_yap_h * 60d);
//            //预安排停电（注意字段对应），【平均供电可用率】=（1-∑（预安排停电的【系统平均停电持续时间】）/8760）*100%。
//            result_yap.Add(1 - result_xt.pjtdchxshj_yap_h / 8760d);
//            //预安排停电（注意字段对应），【系统平均停电频率】= Yloadind.txt中∑（属于此系统的各负荷点【年停运率】*对应负荷点的用户数）/各负荷点的用户数之和。
//            result_yap.Add(result_xt.tdpl_yap_h);
//            //预安排停电（注意字段对应），【系统缺供电量】= Yloadind.txt中属于此系统的各负荷点【平均电量不足】之和，注意单位为“万*kWh”，1万*kWh=10000kWh。
//            result_yap.Add(result_xt.qgdl_yap);
//            result_yap.Add(result_xt.qgdl_yap_pj);
//            result_yap.Add(result_xt.yhsh);
//            result_yap.Add(m_gchid);
//            insertSql.Append(string.Format(insert_values, result_yap.ToArray()) + ";");

//            if (insertSql.Length > 0 &&
//                m_database.Execute(insertSql.ToString()) == -1)
//            {
//                return false;
//            }
//            insertSql.Clear();

//            #endregion 1、系统用户供电可靠性

//            #region 2、变电站范围内用户可靠性

//            //3、变电站范围内用户可靠性
//            /*
//                1	f_subgchid	电网ID
//                2	f_id	变电站ID
//                3	f_gdfqid	供电分区ID
//                4	f_mch	变电站名称
//                5	f_gdkyl	平均供电可用率ASAI
//                6	f_hj_pjtdchxshjsaidi_h	合计|平均停电持续时间SAIDI
//                7	f_hj_pjtdchxshjsaidi_m	合计|平均停电持续时间SAIDI
//                8	f_hj_pjtdplsaifi	合计|平均停电频率SAIFI
//                9	f_hj_qgdlens	合计|缺供电量ENS
//                10	f_hj_pjqgdlaens	合计|平均缺供电量AENS
//                11	f_gzh_pjgzhtdchxshjsaidi_h	故障停电|平均故障停电持续时间SAIDI
//                12	f_gzh_pjgzhtdchxshjsaidi_m	故障停电|平均故障停电持续时间SAIDI
//                13	f_gzh_pjgzhtdplsaifi	故障停电|平均故障停电频率SAIFI
//                14	f_gzh_qgdlens	故障停电|缺供电量ENS
//                15	f_gzh_pjqgdlaens	故障停电|平均缺供电量AENS
//                16	f_yap_pjyaptdchxshjsaidi_h	预安排停电|平均预安排停电持续时间SAIDI
//                17	f_yap_pjyaptdchxshjsaidi_m	预安排停电|平均预安排停电持续时间SAIDI
//                18	f_yap_pjyaptdplsaifi	预安排停电|平均预安排停电频率SAIFI
//                19	f_yap_qgdlens	预安排停电|缺供电量ENS
//                20	f_yap_pjqgdlaens	预安排停电|平均缺供电量AENS
//                21	f_yhsh	用户总数
//             */
//            //
//            if (resultDic_bdzh != null && resultDic_bdzh.Count > 0)
//            {
//                insert_pre = "insert into ta_kkx2_bdzhfwnyh_temp (f_subgchid,f_id,f_mch,f_gdkyl,"
//                  + "f_hj_pjtdchxshjsaidi_h,f_hj_pjtdchxshjsaidi_m,f_hj_pjtdplsaifi,f_hj_qgdlens,f_hj_pjqgdlaens,"
//                  + "f_gzh_pjgzhtdchxshjsaidi_h,f_gzh_pjgzhtdchxshjsaidi_m,f_gzh_pjgzhtdplsaifi,f_gzh_qgdlens,f_gzh_pjqgdlaens,"
//                  + "f_yap_pjyaptdchxshjsaidi_h,f_yap_pjyaptdchxshjsaidi_m,f_yap_pjyaptdplsaifi,f_yap_qgdlens,f_yap_pjqgdlaens,"
//                  + " f_yhsh,f_entid )values ";
//                insert_values = @"('{0}', '{1}', '{2}', {3}, {4}, {5}, {6}, {7},{8},{9},{10},{11},
//            {12},{13},{14},{15},{16},{17},{18},{19},'{20}')";
//                iIndex = 0;
//                iLength = resultDic_bdzh.Count;
//                insertSql.Append(insert_pre);
//                foreach (KeyValuePair<string, kkxResult> result in resultDic_bdzh)
//                {
//                    iIndex++;
//                    object[] args =
//                    {
//                        m_gchid,result.Key,result.Value .mch,
//                        result.Value.pjgdkyl_hj_h,
//                        result.Value .pjtdchxshj_hj_h,
//                        result.Value .pjtdchxshj_hj_h*60,
//                        result.Value.tdpl_hj_h,
//                        result.Value.qgdl_hj,
//                        result.Value.qgdl_hj_pj,

//                        result.Value .pjtdchxshj_gzh_h,
//                        result.Value .pjtdchxshj_gzh_h*60,
//                        result.Value.tdpl_gzh_h,
//                        result.Value.qgdl_gzh,
//                        result.Value.qgdl_gzh_pj,

//                        result.Value .pjtdchxshj_yap_h,
//                        result.Value .pjtdchxshj_yap_h*60,
//                        result.Value.tdpl_yap_h,
//                        result.Value.qgdl_yap,
//                        result.Value.qgdl_yap_pj,

//                        result.Value.yhsh,m_gchid
//                    };
//                    //ReliabilityAlgorithmUtility.InitSqlObjectValues(args);
//                    insertSql.Append(string.Format(insert_values, args) + ((iIndex == iLength) ? ";" : ","));
//                }
//            }

//            if (insertSql.Length > 0 &&
//                m_database.Execute(insertSql.ToString()) == -1)
//            {
//                return false;
//            }
//            insertSql.Clear();

//            #endregion 2、变电站范围内用户可靠性

//            #region 3、馈线范围内用户可靠性

//            //4、馈线范围内用户可靠性
//            /*
//                1	f_subgchid	电网ID
//                2	f_id	馈线ID
//                3	f_bdzhid	变电站ID
//                4	f_gdfqid	供电分区ID
//                5	f_mch	馈线名称
//                6	f_gdkyl	平均供电可用率ASAI
//                7	f_hj_pjtdchxshjsaidi_h	合计|平均停电持续时间SAIDI
//                8	f_hj_pjtdchxshjsaidi_m	合计|平均停电持续时间SAIDI
//                9	f_hj_pjtdplsaifi	合计|平均停电频率SAIFI
//                10	f_hj_qgdlens	合计|缺供电量ENS
//                11	f_hj_pjqgdlaens	合计|平均缺供电量AENS
//                12	f_gzh_pjgzhtdchxshjsaidi_h	故障停电|平均故障停电持续时间SAIDI
//                13	f_gzh_pjgzhtdchxshjsaidi_m	故障停电|平均故障停电持续时间SAIDI
//                14	f_gzh_pjgzhtdplsaifi	故障停电|平均故障停电频率SAIFI
//                15	f_gzh_qgdlens	故障停电|缺供电量ENS
//                16	f_gzh_pjqgdlaens	故障停电|平均缺供电量AENS
//                17	f_yap_pjyaptdchxshjsaidi_h	预安排停电|平均预安排停电持续时间SAIDI
//                18	f_yap_pjyaptdchxshjsaidi_m	预安排停电|平均预安排停电持续时间SAIDI
//                19	f_yap_pjyaptdplsaifi	预安排停电|平均预安排停电频率SAIFI
//                20	f_yap_qgdlens	预安排停电|缺供电量ENS
//                21	f_yap_pjqgdlaens	预安排停电|平均缺供电量AENS
//                22	f_yhsh	用户总数
//                23	f_sshbdzh	所属变电站

//             */
//            //
//            if (resultDic_kx != null && resultDic_kx.Count > 0)
//            {
//                insert_pre = "insert into ta_kkx2_kxfwnyh_temp (f_subgchid,f_id,f_bdzhid,f_gdfqid,f_mch,f_gdkyl,"
//                  + "f_hj_pjtdchxshjsaidi_h,f_hj_pjtdchxshjsaidi_m,f_hj_pjtdplsaifi,f_hj_qgdlens,f_hj_pjqgdlaens,"
//                  + "f_gzh_pjgzhtdchxshjsaidi_h,f_gzh_pjgzhtdchxshjsaidi_m,f_gzh_pjgzhtdplsaifi,f_gzh_qgdlens,f_gzh_pjqgdlaens,"
//                  + "f_yap_pjyaptdchxshjsaidi_h,f_yap_pjyaptdchxshjsaidi_m,f_yap_pjyaptdplsaifi,f_yap_qgdlens,f_yap_pjqgdlaens,"
//                  + " f_yhsh,f_sshbdzh,f_entid )values ";
//                insert_values = @"('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7},{8},{9},{10},{11},
//            {12},{13},{14},{15},{16},{17},{18},{19},{20},{21},'{22}','{23}' )";
//                iIndex = 0;
//                iLength = resultDic_kx.Count;
//                insertSql.Append(insert_pre);
//                foreach (KeyValuePair<string, Tuple<string, string, kkxResult>> result in resultDic_kx)
//                {
//                    iIndex++;
//                    object[] args =
//                    {

//                        m_gchid,result.Key,result.Value.Item1,"", result.Value.Item3 .mch,
//                        result.Value.Item3 .pjgdkyl_hj_h,
//                        result.Value.Item3  .pjtdchxshj_hj_h,
//                        result.Value.Item3  .pjtdchxshj_hj_h*60,
//                        result.Value.Item3 .tdpl_hj_h,
//                        result.Value.Item3 .qgdl_hj,
//                        result.Value.Item3 .qgdl_hj_pj,

//                        result.Value.Item3  .pjtdchxshj_gzh_h,
//                        result.Value.Item3  .pjtdchxshj_gzh_h*60,
//                        result.Value.Item3 .tdpl_gzh_h,
//                        result.Value.Item3 .qgdl_gzh,
//                        result.Value.Item3 .qgdl_gzh_pj,

//                        result.Value .Item3 .pjtdchxshj_yap_h,
//                        result.Value .Item3 .pjtdchxshj_yap_h*60,
//                        result.Value.Item3 .tdpl_yap_h,
//                        result.Value.Item3 .qgdl_yap,
//                        result.Value.Item3 .qgdl_yap_pj,

//                        result.Value.Item3 .yhsh,result.Value.Item2, m_gchid
//                    };
//                    //ReliabilityAlgorithmUtility.InitSqlObjectValues(args);
//                    insertSql.Append(string.Format(insert_values, args) + ((iIndex == iLength) ? ";" : ","));
//                }
//            }

//            if (insertSql.Length > 0 &&
//                m_database.Execute(insertSql.ToString()) == -1)
//            {
//                return false;
//            }

//            #endregion 3、馈线范围内用户可靠性

//            #endregion 2、生成报表

//            return true;
//        }

//        private string DealMCH(string name)
//        {
//            int firstKH = name.LastIndexOfAny(new Char[2] { '(', '（' });
//            if (firstKH != -1)
//            {
//                int length = name.Length;
//                name = name.Substring(0, firstKH);
//            }
//            return name;
//        }

//        /// <summary>
//        /// 获得数值数据
//        /// </summary>
//        /// <param name="value">数据</param>
//        /// <returns>数值数据</returns>
//        private double GetDoubleValue(object value)
//        {
//            if (value == null || value == DBNull.Value)
//            {
//                return 0;
//            }
//            return GetDoubleValue(value.ToString());
//        }

//        /// <summary>
//        /// 获得数值数据
//        /// </summary>
//        /// <param name="sValue">数据</param>
//        /// <returns>数值数据</returns>
//        private double GetDoubleValue(string sValue)
//        {
//            double tempValue = 0;
//            double.TryParse(sValue, out tempValue);
//            return tempValue;
//        }

//        /// <summary>
//        /// 获得数值数据
//        /// </summary>
//        /// <param name="sValue">数据</param>
//        /// <returns>数值数据</returns>
//        private int GetIntValue(string sValue)
//        {
//            int tempValue = 0;
//            int.TryParse(sValue, out tempValue);
//            return tempValue;
//        }

//        /// <summary>
//        /// 获得数值数据
//        /// </summary>
//        /// <param name="value">数据</param>
//        /// <returns>数值数据</returns>
//        private int GetIntValue(object value)
//        {
//            if (value == null || value == DBNull.Value)
//            {
//                return 0;
//            }
//            return GetIntValue(value.ToString());
//        }

//        #endregion // 私有方法

//        #region 属性及其私有变量


//        /// <summary>
//        /// 工程ID
//        /// </summary>
//        private string m_gchid;

//        /// <summary>
//        /// 部门名称
//        /// </summary>
//        private string m_dept;

//        /// <summary>
//        /// 消息标题
//        /// </summary>
//        private string m_message;

//        /// <summary>
//        /// 数据库对象
//        /// </summary>
//        private PostgreSqlDatabase m_database;

//        #endregion // 属性及其私有变量

//    }

//    class kkxResult
//    {
//        /// <summary>
//        /// 名称
//        /// </summary>
//        public string mch { get; set; }

//        #region 平均供电可用率ASAI-LP

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_hj_h
//        {
//            get
//            {
//                return 1 - pjtdchxshj_hj_h / 8760d;
//            }
//        }

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_gzh_h
//        {
//            get
//            {
//                return 1 - pjtdchxshj_gzh_h / 8760d;
//            }
//        }

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_yap_h
//        {
//            get
//            {
//                return 1 - pjtdchxshj_yap_h / 8760d;
//            }
//        }

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_hj
//        {
//            get
//            {
//                return 1 - pjtdchxshj_hj / 8760d;
//            }
//        }

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_gzh
//        {
//            get
//            {
//                return 1 - pjtdchxshj_gzh / 8760d;
//            }
//        }

//        /// <summary>
//        /// 平均供电可用率ASAI-LP（%）
//        /// 1-平均停电持续时间/8760
//        /// </summary>
//        public double pjgdkyl_yap
//        {
//            get
//            {
//                return 1 - pjtdchxshj_yap / 8760d;
//            }
//        }

//        #endregion 平均供电可用率ASAI-LP

//        #region 平均停电持续时间SAIDI-LP

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/年）
//        /// </summary>
//        public double pjtdchxshj_gzh { get; set; }

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/户.年）
//        /// </summary>
//        public double pjtdchxshj_gzh_h
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : pjtdchxshj_gzh / yhsh;
//            }
//        }

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/年）
//        /// </summary>
//        public double pjtdchxshj_yap { get; set; }

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/户.年）
//        /// </summary>
//        public double pjtdchxshj_yap_h
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : pjtdchxshj_yap / yhsh;
//            }
//        }

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/年）
//        /// </summary>
//        public double pjtdchxshj_hj
//        {
//            get
//            {
//                return pjtdchxshj_gzh + pjtdchxshj_yap;
//            }
//        }

//        /// <summary>
//        /// 平均停电持续时间SAIDI-LP（h/户.年）
//        /// </summary>
//        public double pjtdchxshj_hj_h
//        {
//            get
//            {
//                return pjtdchxshj_gzh_h + pjtdchxshj_yap_h;
//            }
//        }

//        #endregion 平均停电持续时间SAIDI-LP

//        #region 停电频率SAIFI-LP

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/年）
//        /// </summary>
//        public double tdpl_gzh { get; set; }

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/户.年）
//        /// </summary>
//        public double tdpl_gzh_h
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : tdpl_gzh / yhsh;
//            }
//        }

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/年）
//        /// </summary>
//        public double tdpl_yap { get; set; }

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/户.年）
//        /// </summary>
//        public double tdpl_yap_h
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : tdpl_yap / yhsh;
//            }
//        }

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/年）
//        /// </summary>
//        public double tdpl_hj
//        {
//            get
//            {
//                return tdpl_gzh + tdpl_yap;
//            }
//        }

//        /// <summary>
//        /// 停电频率SAIFI-LP（次/户.年）
//        /// </summary>
//        public double tdpl_hj_h
//        {
//            get
//            {
//                return tdpl_gzh_h + tdpl_yap_h;
//            }
//        }

//        #endregion 停电频率SAIFI-LP

//        #region 缺供电量ENS-LP

//        /// <summary>
//        /// 缺供电量ENS-LP（kWh/年）
//        /// </summary>
//        public double qgdl_gzh { get; set; }

//        /// <summary>
//        /// 缺供电量ENS-LP（kWh/年）
//        /// </summary>
//        public double qgdl_yap { get; set; }

//        /// <summary>
//        /// 缺供电量ENS-LP（kWh/年）
//        /// </summary>
//        public double qgdl_hj
//        {
//            get
//            {
//                return qgdl_gzh + qgdl_yap;
//            }
//        }

//        #endregion 缺供电量ENS-LP

//        #region 平均缺供电量AENS

//        /// <summary>
//        /// 平均缺供电量AENS(kWh/户·年)
//        /// </summary>
//        public double qgdl_hj_pj
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : qgdl_hj / yhsh;
//            }
//        }

//        /// <summary>
//        /// 平均缺供电量AENS(kWh/户·年)
//        /// </summary>
//        public double qgdl_gzh_pj
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : qgdl_gzh / yhsh;
//            }
//        }

//        /// <summary>
//        /// 平均缺供电量AENS(kWh/户·年)
//        /// </summary>
//        public double qgdl_yap_pj
//        {
//            get
//            {
//                return yhsh == 0 ? 0 : qgdl_yap / yhsh;
//            }
//        }


//        #endregion 平均缺供电量AENS

//        /// <summary>
//        /// 用户数
//        /// </summary>
//        public int yhsh { get; set; }


//    }

//    enum ElementTypeEx : int
//    {
//        母线 = 0,
//        电缆线 = 1,
//        架空绝缘线 = 2,
//        架空裸导线 = 3,
//        断路器 = 4,
//        负荷开关 = 5,
//        熔断器 = 6,
//        隔离开关 = 7,
//        配变 = 8,
//    }
//}