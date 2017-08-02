/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/8/2 22:19:15                            */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('T_Admin')
            and   type = 'U')
   drop table T_Admin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Admin_Detail')
            and   type = 'U')
   drop table T_Admin_Detail
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Admin_Environment_Role')
            and   type = 'U')
   drop table T_Admin_Environment_Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Admin_OperateLog')
            and   type = 'U')
   drop table T_Admin_OperateLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Application')
            and   type = 'U')
   drop table T_Application
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Application_Config_Instance')
            and   type = 'U')
   drop table T_Application_Config_Instance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Application_Config_Modify_Recored')
            and   type = 'U')
   drop table T_Application_Config_Modify_Recored
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Application_PubConfigGroup_Map')
            and   type = 'U')
   drop table T_Application_PubConfigGroup_Map
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config')
            and   type = 'U')
   drop table T_Config
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config_FailOver')
            and   type = 'U')
   drop table T_Config_FailOver
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config_HistoryRecord')
            and   type = 'U')
   drop table T_Config_HistoryRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config_LoadBalance')
            and   type = 'U')
   drop table T_Config_LoadBalance
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config_Map')
            and   type = 'U')
   drop table T_Config_Map
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Config_OperateLog')
            and   type = 'U')
   drop table T_Config_OperateLog
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Environment')
            and   type = 'U')
   drop table T_Environment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_PubConfigGroup')
            and   type = 'U')
   drop table T_PubConfigGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_Release')
            and   type = 'U')
   drop table T_Release
go

if exists (select 1
            from  sysobjects
           where  id = object_id('T_ReleaseRecord')
            and   type = 'U')
   drop table T_ReleaseRecord
go

/*==============================================================*/
/* Table: T_Admin                                               */
/*==============================================================*/
create table T_Admin (
   FID                  int                  identity(1,1),
   FName                nvarchar(50)         null,
   FUserName            varchar(50)          null,
   FEmail               varchar(50)          null,
   FMobile              varchar(11)          null,
   FPwdSalt             varchar(10)          null,
   FPwd                 char(32)             null,
   FIsSuperAdmin        bit                  not null,
   FState               int                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_ADMIN primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Admin') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Admin' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员信息', 
   'user', @CurrentUser, 'table', 'T_Admin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '管理员ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名字',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FUserName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FUserName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FUserName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEmail')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FEmail'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '邮箱',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FEmail'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FMobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FMobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '手机号',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FMobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FPwdSalt')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FPwdSalt'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码盐值',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FPwdSalt'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FPwd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FPwd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '密码',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FPwd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsSuperAdmin')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FIsSuperAdmin'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否为超级管理员',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FIsSuperAdmin'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FState')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FState'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户状态(0:正常,1:禁用)',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FState'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Admin', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Admin_Detail                                        */
/*==============================================================*/
create table T_Admin_Detail (
   FAdminID             int                  not null,
   FLastLoginTime       datetime             null,
   FLastLoginIP         varchar(15)          null,
   FLastLoginPort       int                  null,
   FLastLoginAddress    varchar(50)          null,
   FLastLoginUserAgent  varchar(500)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Admin_Detail') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Admin_Detail' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员详细信息', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FAdminID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FAdminID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '管理员ID（管理员表主键）',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FAdminID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastLoginTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后登录时间',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastLoginIP')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginIP'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后登录IP',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginIP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastLoginPort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginPort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后登录端口(1:后台,2:IOS,3:Android,4:Wechat,9:其它)',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginPort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastLoginAddress')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginAddress'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后登录地址',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginAddress'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastLoginUserAgent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginUserAgent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后登录客户端信息',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastLoginUserAgent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Detail')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Admin_Detail', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Admin_Environment_Role                              */
/*==============================================================*/
create table T_Admin_Environment_Role (
   FID                  int                  identity(1,1),
   FAdminID             int                  not null,
   FEnvironmentID       int                  not null,
   FCreateUserID        INT                  not null,
   FCreateTime          datetime             not null,
   FLastModifyUserID    int                  null,
   FLastModifyTime      datetime             null,
   constraint PK_T_ADMIN_ENVIRONMENT_ROLE primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Admin_Environment_Role') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员对应环境权限信息', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FAdminID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FAdminID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '管理员ID',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FAdminID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人ID',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FLastModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FLastModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_Environment_Role')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Admin_Environment_Role', 'column', 'FLastModifyTime'
go

/*==============================================================*/
/* Table: T_Admin_OperateLog                                    */
/*==============================================================*/
create table T_Admin_OperateLog (
   FID                  int                  identity(1,1),
   FBizType             int                  not null,
   FOperateContent      varchar(max)         null,
   FOperaterIP          varchar(15)          null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_ADMIN_OPERATELOG primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Admin_OperateLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '管理员操作记录', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FBizType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FBizType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作模块(枚举,1:用户,2:配置,3:发布,4:环境,5:项目)',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FBizType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FOperateContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FOperateContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作内容',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FOperateContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FOperaterIP')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FOperaterIP'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作人IP',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FOperaterIP'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Admin_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Admin_OperateLog', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Application                                         */
/*==============================================================*/
create table T_Application (
   FID                  int                  identity(1,1),
   FEnvironmentID       int                  not null,
   FName                varchar(100)         null,
   FCode                varchar(50)          null,
   FVersion             varchar(15)          null,
   FComment             varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_APPLICATION primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Application') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Application' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '应用程序信息', 
   'user', @CurrentUser, 'table', 'T_Application'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属环境',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用名称',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编码(环境中唯一)',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Application', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Application_Config_Instance                         */
/*==============================================================*/
create table T_Application_Config_Instance (
   FID                  int                  identity,
   FEnvironmentID       int                  not null,
   FApplicationID       int                  not null,
   FConfigContent       varchar(max)         null,
   FReleaseRecordID     int                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_APPLICATION_CONFIG_INSTAN primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Application_Config_Instance') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '当前应用配置信息', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID（主键、自增）',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FApplicationID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FApplicationID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FApplicationID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FConfigContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置内容',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FConfigContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FReleaseRecordID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FReleaseRecordID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布记录ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FReleaseRecordID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Instance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Application_Config_Instance', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Application_Config_Modify_Recored                   */
/*==============================================================*/
create table T_Application_Config_Modify_Recored (
   FID                  int                  identity(1,1),
   FEnvironmentID       int                  not null,
   FApplicationID       int                  not null,
   FVersion             varchar(15)          null,
   FGetType             int                  not null,
   FCreateTime          datetime             not null,
   FLastModifyTime      datetime             null,
   FIsDeleted           bit                  not null,
   constraint PK_T_APPLICATION_CONFIG_MODIFY primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Application_Config_Modify_Recored') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '应用更新配置记录', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FApplicationID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FApplicationID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用ID',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FApplicationID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FGetType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FGetType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '获取类型(1:主动获取,2::服务端更新通知后获取)',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FGetType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_Config_Modify_Recored')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Application_Config_Modify_Recored', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Application_PubConfigGroup_Map                      */
/*==============================================================*/
create table T_Application_PubConfigGroup_Map (
   FID                  int                  identity(1,1),
   FApplicationID       int                  not null,
   FPubConfigGroupID    int                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_APPLICATION_PUBCONFIGGROU primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Application_PubConfigGroup_Map') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '应用程序与公共配置关系', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FApplicationID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FApplicationID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用程序ID',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FApplicationID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FPubConfigGroupID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FPubConfigGroupID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '基础公共配置组ID',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FPubConfigGroupID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Application_PubConfigGroup_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Application_PubConfigGroup_Map', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config                                              */
/*==============================================================*/
create table T_Config (
   FID                  int                  identity(1,1),
   FConfigMapID         int                  not null,
   FVersion             varchar(15)          not null,
   FValue               varchar(100)         null,
   FFailOverID          int                  not null,
   FLoadBalanceAlgorithmType int                  not null,
   FComment             varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '配置值信息', 
   'user', @CurrentUser, 'table', 'T_Config'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigMapID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FConfigMapID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置关系记录ID(T_Config_Map主键,同一个版本号只能有一条)',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FConfigMapID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置值',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FFailOverID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FFailOverID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障转移ID',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FFailOverID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLoadBalanceAlgorithmType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLoadBalanceAlgorithmType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '负载均衡算法类型(1:轮询法,2:随机法,3:原地址哈希法,4:加权轮循法,5:加权随机发,6:最小连接数法)',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLoadBalanceAlgorithmType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config_FailOver                                     */
/*==============================================================*/
create table T_Config_FailOver (
   FID                  int                  identity(1,1),
   FConfigID            int                  not null,
   FVersion             varchar(15)          not null,
   FValue               varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG_FAILOVER primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config_FailOver') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config_FailOver' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '配置故障转移信息', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障转移ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FConfigID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置ID',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FConfigID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '转移值',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_FailOver')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config_FailOver', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config_HistoryRecord                                */
/*==============================================================*/
create table T_Config_HistoryRecord (
   FID                  int                  identity(1,1),
   FConfigID            int                  not null,
   FConfigMapID         int                  not null,
   FVersion             varchar(15)          not null,
   FType                int                  not null,
   FKey                 varchar(50)          null,
   FValue               varchar(100)         null,
   FFailOverID          int                  not null,
   FLoadBalanceAlgorithmType int                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG_HISTORYRECORD primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config_HistoryRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '配置信息历史记录', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FConfigID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置值ID',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FConfigID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigMapID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FConfigMapID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置关系记录ID(T_Config_Map主键,同一个版本号只能有一条)',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FConfigMapID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置类型(1:默认配置,2:负载均衡配置,3:故障转移)',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FKey')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FKey'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置Key',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置值',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FFailOverID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FFailOverID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '故障转移ID',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FFailOverID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLoadBalanceAlgorithmType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLoadBalanceAlgorithmType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '负载均衡算法类型(1:轮询法,2:随机法,3:原地址哈希法,4:加权轮循法,5:加权随机发,6:最小连接数法)',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLoadBalanceAlgorithmType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_HistoryRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config_HistoryRecord', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config_LoadBalance                                  */
/*==============================================================*/
create table T_Config_LoadBalance (
   FID                  int                  identity(1,1),
   FConfigID            int                  not null,
   FVersion             varchar(15)          not null,
   FWeight              int                  not null,
   FValue               varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG_LOADBALANCE primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config_LoadBalance') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '配置负载均衡信息', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '负载均衡ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FConfigID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置ID',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FConfigID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FVersion')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FVersion'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '版本号',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FVersion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FWeight')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FWeight'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '权重',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FWeight'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FValue')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FValue'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置值',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FValue'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_LoadBalance')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config_LoadBalance', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config_Map                                          */
/*==============================================================*/
create table T_Config_Map (
   FID                  int                  identity(1,1),
   FEnvironmentID       int                  not null,
   FApplicationID       INT                  not null,
   FPubConfigGroupID    int                  not null,
   FKey                 varchar(50)          null,
   FType                int                  not null,
   FComment             varchar(100)         null,
   FCreateUserID        int                  not null,
   FCreateTime          datetime             not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG_MAP primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config_Map') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config_Map' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '环境、项目公共配置组与配置关系', 
   'user', @CurrentUser, 'table', 'T_Config_Map'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属环境',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FApplicationID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FApplicationID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '应用ID',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FApplicationID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FPubConfigGroupID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FPubConfigGroupID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '公共配置组ID',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FPubConfigGroupID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FKey')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FKey'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置Key(同一环境下，相同的应用或配置组不能重复)',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FKey'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置类型(1:默认配置,2:负载均衡配置,3:故障转移)',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_Map')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config_Map', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Config_OperateLog                                   */
/*==============================================================*/
create table T_Config_OperateLog (
   FID                  int                  identity(1,1),
   FConfigID            int                  not null,
   FOperareContent      varchar(500)         null,
   FOperateType         int                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_CONFIG_OPERATELOG primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Config_OperateLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Config_OperateLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '配置操作记录', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FConfigID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置ID',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FConfigID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FOperareContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FOperareContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作内容',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FOperareContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FOperateType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FOperateType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '操作类型(1:新增、2:修改、3:删除、4:发布)',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FOperateType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Config_OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Config_OperateLog', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Environment                                         */
/*==============================================================*/
create table T_Environment (
   FID                  int                  identity(1,1),
   FName                varchar(50)          null,
   FCode                varchar(50)          null,
   FSecret              varchar(50)          null,
   FComment             varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_ENVIRONMENT primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Environment') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Environment' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '环境信息', 
   'user', @CurrentUser, 'table', 'T_Environment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '名称',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编码(全局唯一)',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FSecret')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FSecret'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置访问密钥',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FSecret'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Environment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Environment', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_PubConfigGroup                                      */
/*==============================================================*/
create table T_PubConfigGroup (
   FID                  int                  identity(1,1),
   FName                varchar(50)          null,
   FCode                varchar(50)          null,
   FEnvironmentID       int                  not null,
   FComment             varchar(100)         null,
   FIsEnabled           bit                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_PUBCONFIGGROUP primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_PubConfigGroup') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_PubConfigGroup' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '公共配置组信息', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置组ID',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置组名字',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '编码（环境中唯一）',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '所属环境',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsEnabled')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FIsEnabled'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否启用(1表示启用)',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FIsEnabled'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_PubConfigGroup')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_PubConfigGroup', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_Release                                             */
/*==============================================================*/
create table T_Release (
   FID                  int                  identity(1,1),
   FReleaseRecordID     int                  not null,
   FEnvironmentID       int                  not null,
   FApplicationID       int                  not null,
   FConfigGroupID       int                  not null,
   FReleaseContent      varchar(max)         null,
   FIsAbandoned         bit                  not null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_RELEASE primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_Release') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_Release' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '发布内容', 
   'user', @CurrentUser, 'table', 'T_Release'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID(主键、自增)',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FReleaseRecordID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FReleaseRecordID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布记录ID（相同记录表示同义次发布）',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FReleaseRecordID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnvironmentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FEnvironmentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FEnvironmentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FApplicationID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FApplicationID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '项目ID',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FApplicationID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FConfigGroupID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FConfigGroupID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '配置组ID',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FConfigGroupID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FReleaseContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FReleaseContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布内容',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FReleaseContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsAbandoned')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FIsAbandoned'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否废弃(被回滚则视为废弃)',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FIsAbandoned'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_Release')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_Release', 'column', 'FIsDeleted'
go

/*==============================================================*/
/* Table: T_ReleaseRecord                                       */
/*==============================================================*/
create table T_ReleaseRecord (
   FID                  int                  identity,
   FEnviromentID        int                  not null,
   FIsAbandoned         bit                  not null,
   FPreviousReleaseId   int                  null,
   FReleaseType         int                  not null,
   FComment             varchar(100)         null,
   FCreateTime          datetime             not null,
   FCreateUserID        int                  not null,
   FLastModifyTime      datetime             null,
   FLaseModifyUserID    INT                  null,
   FIsDeleted           bit                  not null,
   constraint PK_T_RELEASERECORD primary key (FID)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('T_ReleaseRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'T_ReleaseRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '发布记录', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '记录ID（主键、自增）',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FEnviromentID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FEnviromentID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '环境ID',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FEnviromentID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsAbandoned')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FIsAbandoned'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否废弃（回滚则视为废弃）',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FIsAbandoned'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FPreviousReleaseId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FPreviousReleaseId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '前一次发布记录ID（未被回滚的,第一次发布则为空）',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FPreviousReleaseId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FReleaseType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FReleaseType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '发布类型（1:普通发布,2:回滚发布）',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FReleaseType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FComment')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FComment'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '备注',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FComment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FCreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建时间',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FCreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FCreateUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FCreateUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '创建人',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FCreateUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLastModifyTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FLastModifyTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改时间',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FLastModifyTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FLaseModifyUserID')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FLaseModifyUserID'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '最后修改人`',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FLaseModifyUserID'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('T_ReleaseRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FIsDeleted')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FIsDeleted'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否已删除',
   'user', @CurrentUser, 'table', 'T_ReleaseRecord', 'column', 'FIsDeleted'
go

