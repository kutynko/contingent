CREATE PROCEDURE [dbo].[GetUsers]
	@userId int = null
AS

	select u.Id, u.Name, u.[Login],  r2u.RoleId as RoleId
	from Users u left join Roles_2_Users r2u on u.Id = r2u.UserId
	where u.IsActive = 1 and (@userId is null or @userId = u.Id);

RETURN 0