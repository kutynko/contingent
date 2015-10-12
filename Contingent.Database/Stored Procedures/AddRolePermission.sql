CREATE PROCEDURE [dbo].AddRolePermission
	@roleId int,
	@permissionId int
AS
	insert into Permissions_2_Roles(PermissionId, RoleId)
	values (@permissionId, @roleId);
RETURN 0
