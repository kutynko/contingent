CREATE PROCEDURE [dbo].[DeleteRolePermission]
	@roleId int,
	@permissionId int
AS
	delete from Permissions_2_Roles
	where RoleId = @roleId and PermissionId = @permissionId;
RETURN 0
