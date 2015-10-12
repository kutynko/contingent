CREATE PROCEDURE [dbo].[GetRoles]
	@roleId int = null
AS

	select r.Id as roleId, r.Name as roleName, p2r.PermissionId as permissionId
	from Roles r left join Permissions_2_Roles p2r on r.Id = p2r.RoleId
	where @roleId is null or @roleId = r.Id;

RETURN 0