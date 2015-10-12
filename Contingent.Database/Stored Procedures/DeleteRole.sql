CREATE PROCEDURE [dbo].[DeleteRole]
	@id int
AS
	
	begin tran

	delete from Permissions_2_Roles where RoleId = @id;
	delete from Roles where Id = @id;

	commit

RETURN 0
