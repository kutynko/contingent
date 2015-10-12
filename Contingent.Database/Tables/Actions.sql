CREATE TABLE [dbo].[Actions]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Description] nvarchar(300) not null,
	[IsPrimary] bit not null
)
