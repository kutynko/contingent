CREATE PROCEDURE [dbo].[GetPermissions]
AS

	select p.Id, p.[Description]
	from [Permissions] p;

RETURN 0