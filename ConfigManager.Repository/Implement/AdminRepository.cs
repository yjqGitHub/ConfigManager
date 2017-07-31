using JQ.DataAccess;
using JQ.DataAccess.Repositories;
using ConfigManager.Domain;
using ConfigManager.Constant.Constants;
using ConfigManager.Repository.Constants;
using ConfigManager.TransDto.TransDto;
using System.Threading.Tasks;
using JQ.DataAccess.DbClient;

namespace ConfigManager.Repository.Implement
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：AdminRepository.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：管理员信息数据访问类
    /// 创建标识：template 2017-07-30 22:11:48
    /// </summary>
    public sealed class AdminRepository : BaseDataRepository<AdminInfo>, IAdminRepository
    {
        public AdminRepository(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory, RepositoryConstant.TABLE_NAME_ADMIN, ConfigurationConstant.CONNECTION_NAME_CONFIGMANAGER)
        {
        }

        /// <summary>
        /// 异步获取管理员信息（传输对象）
        /// </summary>
        /// <param name="adminId">管理员ID</param>
        /// <returns>管理员信息（传输对象）</returns>
        public Task<AdminDto> GetAdminTransInfo(int adminId)
        {
            string sql = "SELECT A.FID,A.FMobile,A.FName,A.FUserName,A.FState,A.FIsSuperAdmin,B.FLastLoginAddress,B.FLastLoginIP,B.FLastLoginPort,B.FLastLoginTime,B.FLastLoginUserAgent FROM " + RepositoryConstant.TABLE_NAME_ADMIN + " A WITH(NOLOCK) LEFT JOIN " + RepositoryConstant.TABLE_NAME_ADMINDETAIL + " B WITH(NOLOCK) ON A.FID=B.FUserID AND B.FIsDeleted=0 WHERE A.FID=@FID AND A.FIsDeleted=0";
            SqlQuery sqlQuery = new SqlQuery();
            sqlQuery.AddParameter("FID", adminId.ToString()).ChangeCommandText(sql);
            return GetDtoAsync<AdminDto>(sqlQuery);
        }
    }
}
