CREATE PROCEDURE [dbo].[AddUpdateUser]
	@id int = null,
	@name nvarchar(300),
	@login varchar(300),
	@isActive bit = 1
AS
	
	if (@id is null) begin
		insert into Users(Name, [Login], IsActive) values (@name, @login, @isActive);
		set @id = SCOPE_IDENTITY();
	end else
		update Users set Name = @name, [Login] = @login, IsActive = @isActive where Id = @id;

	select @id;

RETURN 0
