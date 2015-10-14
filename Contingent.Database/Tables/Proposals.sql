﻿CREATE TABLE [dbo].[Proposals]
(
	Id uniqueidentifier not null,
	Status int,
	CreatedBy nvarchar(100) not null,
	CreatedOn datetime2 not null DEFAULT GetDate(),

	constraint PK_Proposals primary key clustered (Id asc)
)
