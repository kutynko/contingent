CREATE PROCEDURE [dbo].[DeleteUserRole]
	@userId int,
	@roleId int
AS
	delete from Roles_2_Users
	where UserId = @userId and  RoleId = @roleId;
RETURN 0
