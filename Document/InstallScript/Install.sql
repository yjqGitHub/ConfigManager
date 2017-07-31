--创建超级管理员
declare @adminID int;
INSERT INTO T_Admin(FName,FUserName,FEmail,FMobile,FPwdSalt,FPwd,FIsSuperAdmin,FState,FCreateTime,FCreateUserID,FIsDeleted)
VALUES('yjq','yjq','425527169@qq.com','15888888888','1234567890','7bbbac2ba6c2a9456e919e8e275bded3',1,0,GETDATE(),1,0);
set @adminID=( select @@IDENTITY);
INSERT INTO T_Admin_Detail(FAdminID,FCreateTime,FCreateUserID,FIsDeleted)VALUES(@adminID,GETDATE(),1,0);

