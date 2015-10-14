CREATE TABLE [dbo].[Reasons]
(
	[Id] INT NOT NULL identity(1,1),
	[Description] nvarchar(300) not null,
	Fields xml,
	constraint PK_Reasons primary key clustered (Id asc)
)
