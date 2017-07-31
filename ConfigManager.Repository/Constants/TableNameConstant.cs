namespace ConfigManager.Repository.Constants
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：TableNameConstant.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：
    /// 创建标识：yjq 2017/7/30 21:45:45
    /// </summary>
    public partial class RepositoryConstant
    {
        /// <summary>
        /// 管理员对应环境权限信息表名
        /// </summary>
        public const string TABLE_NAME_ADMINENVIROMENTROLE = "T_Admin_Enviroment_Role";

        /// <summary>
        /// 管理员信息表名
        /// </summary>
        public const string TABLE_NAME_ADMIN = "T_Admin";

        /// <summary>
        /// 当前应用配置信息表名
        /// </summary>
        public const string TABLE_NAME_APPLICATIONCONFIGINSTANCE = "T_Application_Config_Instance";

        /// <summary>
        /// 应用更新配置记录表名
        /// </summary>
        public const string TABLE_NAME_APPLICATIONCONFIGMODIFYRECORED = "T_Application_Config_Modify_Recored";

        /// <summary>
        /// 应用程序与公共配置关系表名
        /// </summary>
        public const string TABLE_NAME_APPLICATIONPUBCONFIGGROUPMAP = "T_Application_PubConfigGroup_Map";

        /// <summary>
        /// 应用程序信息表名
        /// </summary>
        public const string TABLE_NAME_APPLICATION = "T_Application";

        /// <summary>
        /// 配置故障转移信息表名
        /// </summary>
        public const string TABLE_NAME_CONFIGFAILOVER = "T_Config_FailOver";

        /// <summary>
        /// 配置信息历史记录表名
        /// </summary>
        public const string TABLE_NAME_CONFIGHISTORYRECORD = "T_Config_HistoryRecord";

        /// <summary>
        /// 配置负载均衡信息表名
        /// </summary>
        public const string TABLE_NAME_CONFIGLOADBALANCE = "T_Config_LoadBalance";

        /// <summary>
        /// 环境、项目公共配置组与配置关系表名
        /// </summary>
        public const string TABLE_NAME_CONFIGMAP = "T_Config_Map";

        /// <summary>
        /// 配置操作记录表名
        /// </summary>
        public const string TABLE_NAME_CONFIGOPERATELOG = "T_Config_OperateLog";

        /// <summary>
        /// 环境信息表名
        /// </summary>
        public const string TABLE_NAME_ENVIRONMENT = "T_Environment";

        /// <summary>
        /// 公共配置组信息表名
        /// </summary>
        public const string TABLE_NAME_PUBCONFIGGROUP = "T_PubConfigGroup";

        /// <summary>
        /// 发布记录表名
        /// </summary>
        public const string TABLE_NAME_RELEASERECORD = "T_ReleaseRecord";

        /// <summary>
        /// 发布内容表名
        /// </summary>
        public const string TABLE_NAME_RELEASE = "T_Release";

        /// <summary>
        /// 配置值信息表名
        /// </summary>
        public const string TABLE_NAME_CONFIG = "T_Config";

        /// <summary>
        /// 管理员操作记录表名
        /// </summary>
        public const string TABLE_NAME_ADMINOPERATELOG = "T_Admin_OperateLog";

        /// <summary>
        /// 管理员详细信息表名
        /// </summary>
        public const string TABLE_NAME_ADMINDETAIL = "T_Admin_Detail";
    }
}