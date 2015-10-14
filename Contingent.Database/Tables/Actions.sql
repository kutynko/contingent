CREATE TABLE [dbo].[Actions]
(
	[Id] INT NOT NULL identity(1,1),
	[Description] nvarchar(300) not null,
	[IsBatch] bit not null default(0),
	Fields xml,
	constraint PK_Actions primary key clustered (Id asc)
)
