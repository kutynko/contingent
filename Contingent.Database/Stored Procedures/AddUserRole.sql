CREATE PROCEDURE [dbo].[AddUserRole]
	@userId int,
	@roleId int
AS
	insert into Roles_2_Users(RoleId, UserId)
	values (@roleId, @userId);
RETURN 0
