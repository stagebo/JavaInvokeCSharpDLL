#region CLR版本 4.0.30319.239
// ElementType 类
// 时间：2011-11-9 17:54:55
// 名称：ElementType 类
// 大纲：元件类型
//
// 创建人：王津
// 版权：2011 天津天大求实电力新技术股份有限公司 版权所有
// 备注：
// ========================================================
//  日期		修改人		描述
#endregion
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace TDQS.Contracts
{
    /// <summary>
    /// 元件类型
    /// </summary>
    public enum ElementType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,

        /// <summary>
        /// 节点
        /// </summary>
        Node = 1,

        /// <summary>
        /// 连接点
        /// </summary>
        ConnectionNode = 2,

        /// <summary>
        /// 线段
        /// </summary>
        Line = 4,

        /// <summary>
        /// 配电变压器
        /// </summary>
        DistributionTransformer = 5,

        /// <summary>
        /// 开关
        /// </summary>
        Switch = 6,

        /// <summary>
        /// 变电站
        /// </summary>
        Substation = 8,

        /// <summary>
        /// 环网柜
        /// </summary>
        RingMainUnit = 9,

        /// <summary>
        /// 出线端子
        /// </summary>
        FeederNode = 10,

        /// <summary>
        /// 母线
        /// </summary>
        BusBarSection = 12,

        /// <summary>
        /// 变电站 站内母线
        /// </summary>
        SubstationBusBar = 13,

        /// <summary>
        /// 开闭站
        /// </summary>
        SwitchStation = 14,

        /// <summary>
        /// 二卷变
        /// </summary>
        DoubleWTransformer = 15,

        /// <summary>
        /// 三卷变
        /// </summary>
        ThreeWTransformer = 16,

        /// <summary>
        /// 等值点
        /// </summary>
        IsoNode = 20,

        /// <summary>
        /// 连接线
        /// </summary>
        Connector = 21,

        /// <summary>
        /// 母线联络开关
        /// </summary>
        BusTieSwitch = 22,

        /// <summary>
        /// 开关两侧端子
        /// </summary>
        SwitchTerminal = 23,

        /// <summary>
        /// 配电室
        /// </summary>
        DistributionRoom = 25,

        /// <summary>
        /// 箱式站
        /// </summary>
        BoxSubstation = 26,

        /// <summary>
        /// 分支箱
        /// </summary>
        BranchBox = 27,

        /// <summary>
        /// 负荷
        /// </summary>
        Load = 30,

        /// <summary>
        /// 发电机
        /// </summary>
        Generator = 31,

        //变电站模型更新 孙冠男 2008-1-31
        /// <summary>
        /// 高压变电站
        /// </summary>
        HighVoltageSubstation = 32,


        /// <summary>
        /// 大区
        /// </summary>
        WideArea = 40,

        /// <summary>
        /// 中区
        /// </summary>
        MidArea = 41,

        /// <summary>
        /// 小区
        /// </summary>
        SmallArea = 42,

        /// <summary>
        /// 中区负荷
        /// </summary>
        MidAreaLoad = 43,

        /// <summary>
        /// 小区负荷
        /// </summary>
        SmallAreaLoad = 44,

        /// <summary>
        /// 点负荷
        /// </summary>
        DotLoad = 45,

        /// <summary>
        /// 分区
        /// </summary>
        SubArea = 46,

        /// <summary>
        /// 分级分区
        /// </summary>
        HierachicalArea = 47,

        /// <summary>
        /// 管线
        /// </summary>
        PipeLine = 50,

        /// <summary>
        /// 电缆井
        /// </summary>
        CableDrawPit = 51,

        /// <summary>
        /// 不参加优化送电站
        /// </summary>
        UnConstructedTransmissionSubstation = 52,

        /// <summary>
        /// 隧道
        /// </summary>
        Tunnel = 53,

        /// <summary>
        /// 电缆沟
        /// </summary>
        CableTunnel = 54,

        /// <summary>
        /// 终端场
        /// </summary>
        Terminal = 55,

        /// <summary>
        /// 规划控制电缆走廊
        /// </summary>
        CableCorridor = 56,

        /// <summary>
        /// 发电厂
        /// </summary>
        PowerPlant = 57,

        /// <summary>
        /// 直埋电缆
        /// </summary>
        DirectBurialCable = 58,

        /// <summary>
        /// 新建变电站
        /// </summary>
        NewSubstation500 = 60,
        NewSubstation220 = 61,
        NewSubstation110 = 62,

        /// <summary>
        /// 已有变电站
        /// </summary>
        ExistingSubstation500 = 63,
        ExistingSubstation220 = 64,
        ExistingSubstation110 = 65,

        /// <summary>
        /// 母联
        /// 日期:2008.06.09 王雍修改
        /// </summary>
        BusBarSwitch = 80,
        /// <summary>
        /// 母联端子
        /// 日期:2008.06.09 王雍修改
        /// </summary>
        BusBarSwitchTerminal = 81,

        /// <summary>
        /// 电网
        /// </summary>
        ElectrifiedNetwork = 100,

        /// <summary>
        /// 馈线
        /// </summary>
        FeederLine = 101,

        /// <summary>
        /// 平衡节点
        /// </summary>
        BalancingBus = 102,

        /// <summary>
        /// 供电分区
        /// </summary>
        PowerSS = 103,

        /// <summary>
        /// 行政分区
        /// </summary>
        AdministrativeD = 104,

        /// <summary>
        /// 光伏电源
        /// </summary>
        PVPowerBoard = 105,

        /// <summary>
        /// 光伏等值负荷
        /// </summary>
        PVLoad = 106,

        /// <summary>
        /// 光伏接入模块
        /// </summary>
        PVAccessModule = 107,

        /// <summary>
        /// 并联电抗器
        /// </summary>
        ShuntReactor = 108,

        /// <summary>
        /// 并联电容器
        /// </summary>
        ShuntCapacitor = 109,

        /// <summary>
        /// 有源开关
        /// </summary>
        DNASElectricSwitch = 110,

        /// <summary>
        /// 串联电抗器
        /// </summary>
        SeriesReactor = 150,//聂桂春 2013-12-09	
        /// <summary>
        /// 串联电容器
        /// </summary>
        SeriesCapacitor = 151,//聂桂春 2013-12-09

        /// <summary>
        /// 有源负荷
        /// </summary>
        dnas_fh = 111,

        /// <summary>
        /// 有源平衡节点 
        /// </summary>
        dnas_phjd = 112,

        /// <summary>
        /// 有源直流电流源
        /// </summary>
        dnas_zldly = 113,

        /// <summary>
        /// 有源PI节点
        /// </summary>
        dnas_pijd = 114,

        /// <summary>
        /// 有源电容器 
        /// </summary>
        dnas_drq = 115,

        /// <summary>
        /// 有源PV节点
        /// </summary>
        dnas_pvjd = 116,

        /// <summary>
        /// 有源PQ节点
        /// </summary>
        dnas_pqjd = 117,

        /// <summary>
        /// 有源PQV节点
        /// </summary>
        dnas_pqvjd = 118,

        /// <summary>
        /// 有源变压器
        /// </summary>
        dnas_byq = 119,

        /// <summary>
        /// 换流器
        /// </summary>
        dnas_hlq = 120,

        /// <summary>
        /// 直流线路
        /// </summary>
        dnas_zlxl = 121,

        /// <summary>
        /// 交流线路
        /// </summary>
        dnas_jlxl = 122,

        /// <summary>
        /// 有源连接线
        /// </summary>
        dnas_ljx = 123,

        /// <summary>
        /// 交流母线
        /// </summary>
        dnas_jlmx = 124,

        /// <summary>
        /// 直流母线
        /// </summary>
        dnas_zlmx = 125,

        /// <summary>
        ///  同步电机
        /// </summary>
        dnas_tbdj = 126,

        /// <summary>
        /// 异步电机
        /// </summary>
        dnas_ybdj = 127,

        /// <summary>
        /// 光伏电池
        /// </summary>
        dnas_gfdch = 128,

        /// <summary>
        /// 负荷开关
        /// </summary>
        dnas_fhkg = 129,

        /// <summary>
        /// 隔离开关
        /// </summary>
        dnas_glkg = 130,

        /// <summary>
        /// 同步电机_测试
        /// </summary>
        dnas_tbdj_test = 131,

        /// <summary>
        /// 异步电机_测试
        /// </summary>
        dnas_ybdj_test = 132,

        /// <summary>
        /// 光伏电池_测试
        /// </summary>
        dnas_gfdch_test = 133,

        /// <summary>
        /// 交流断路器
        /// </summary>
        dnas_jldlq = 134,

        /// <summary>
        /// 交流隔离开关
        /// </summary>
        dnas_jlglkg = 135,

        // 典型接线元件 夏禹 2013-9-17
        /// <summary>
        /// 典型接线
        /// </summary>
        GroupDevice = 201,

        /// <summary>
        /// 交流连接线
        /// </summary>
        dnas_ljx_jl = 136,

        /// <summary>
        /// 交流负荷
        /// </summary>
        dnas_fh_jl = 137,

        /// <summary>
        /// 新配变
        /// </summary>
        DistributionTransformer_New = 138,

        // 李睿, 2013/8/29 9:44:02, 添加：接入新元件 低压光伏电源（PVPowerBoardLow）
        /// <summary>
        /// 低压光伏电源
        /// </summary>
        PVPowerBoardLow = 139,

        /// <summary>
        /// 地理信息模型
        /// </summary>
        dnas_geographicinfo=140,
        /// <summary>
        /// 有源系统三绕组变压器
        /// </summary>
        dnas_3byq=141,

        /// <summary>
        /// 电抗器
        /// </summary>
        dnas_dkq=142,
        /// <summary>
        /// 光伏系统
        /// </summary>
        dnas_pvsystem =143,

        /// <summary>
        /// 风力发电机
        /// </summary>
        dnas_windfdj = 144,

        /// <summary>
        /// 内燃机
        /// </summary>
        dnas_combustionengine = 145,

        //2014-10-23 13:33:29 孔轩 添加 储能模型，充电桩，充换电站 新接入元件类别
        /// <summary>
        /// 储能模型
        /// </summary>
        Storage = 146,

        /// <summary>
        /// 充电桩
        /// </summary>
        Chargingpile = 147,

        /// <summary>
        /// 充换电站
        /// </summary>
        Fillingstation = 148,


        End

    }

}