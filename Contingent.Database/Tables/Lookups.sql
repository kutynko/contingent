CREATE TABLE [dbo].Lookups
(
	[Id] INT NOT NULL,
	[Description] nvarchar(2000) not null,
	[TypeId] int not null,
	constraint PK_Lookups primary key (Id, TypeId)
)
