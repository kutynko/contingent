CREATE TABLE [dbo].[Users] (
    [Id]                INT              IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (300)   NOT NULL,
	[Login] varchar(300) not null,
    [IsActive]          BIT              DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

