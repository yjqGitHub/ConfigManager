using ConfigManager.Constant.EnumCollection;
using ConfigManager.Domain;
using ConfigManager.Repository;
using JQ.Dependency;
using JQ.Utils;
using JQ.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConfigManager.DomainService.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminOperateLogDomainService.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员操作记录业务逻辑处理
    /// 创建标识：template 2017-07-31 11:57:46
    /// </summary>
    public sealed class AdminOperateLogDomainService : IAdminOperateLogDomainService
    {
        private readonly IAdminOperateLogRepository _adminOperateLogRepository;

        public AdminOperateLogDomainService(IAdminOperateLogRepository adminOperateLogRepository)
        {
            _adminOperateLogRepository = adminOperateLogRepository;
        }

        /// <summary>
        /// 添加操作信息
        /// </summary>
        /// <param name="bizType">业务类型</param>
        /// <param name="operateContent">操作内容</param>
        /// <param name="operateUserID">操作人</param>
        public void AddOperateLog(BizType bizType, string operateContent, int operateUserID)
        {
            var operateInfo = new AdminOperateLogInfo()
            {
                FBizType = bizType,
                FCreateTime = DateTime.Now,
                FCreateUserID = operateUserID,
                FIsDeleted = false,
                FOperateContent = operateContent,
                FOperaterIP = WebUtil.GetRealIP()
            };
            _OperateQueue.EnqueueMessage(operateInfo);
        }



        #region 批量处理新增

        private static BufferQueue<AdminOperateLogInfo> _OperateQueue = new BufferQueue<AdminOperateLogInfo>(20000, MessageHandle, HaveNoCountHandle);

        /// <summary>
        /// 消息列表
        /// </summary>
        private static List<AdminOperateLogInfo> _OperateList = new List<AdminOperateLogInfo>();

        /// <summary>
        /// 信息处理的方法
        /// </summary>
        /// <param name="message">要处理的信息</param>
        private static void MessageHandle(AdminOperateLogInfo message)
        {
            if (_OperateList.Count > 200)
            {
                //插入数据库
                AddOperateListAsync().Wait();
                _OperateList.Clear();
            }
            _OperateList.Add(message);
        }

        /// <summary>
        /// 没有新消息的时候处理方法
        /// </summary>
        private static void HaveNoCountHandle()
        {
            AddOperateListAsync().Wait();
            _OperateList.Clear();
        }

        private async static Task AddOperateListAsync()
        {
            await ExceptionUtil.LogExceptionAsync(async () =>
            {
                using (var scope = ContainerManager.BeginLeftScope())
                {
                    var adminOperateLogRepository = scope.Resolve<IAdminOperateLogRepository>();
                    await adminOperateLogRepository.BulkInsertAsync(_OperateList);
                }
            }, memberName: "AdminOperateLogRepository-AddOperateListAsync");
        }

        #endregion 批量处理新增
    }
}