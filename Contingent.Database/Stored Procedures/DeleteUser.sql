CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS

	begin tran

	delete from Roles_2_Users where UserId = @id;
	delete from Users where Id = @id;

	commit

RETURN 0
