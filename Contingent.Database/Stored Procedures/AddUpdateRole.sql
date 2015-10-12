CREATE PROCEDURE [dbo].AddUpdateRole
	@id int = null,
	@name varchar(300),
	@description nvarchar(2000) = null
AS
	
	if (@id is null) begin
		insert Into Roles(Name, [Description]) values (@name, @description);
		set @id = SCOPE_IDENTITY();
	end else
		update Roles set Name = @name, [Description] = @description where Id = @id;
		
	select @id;

RETURN 0