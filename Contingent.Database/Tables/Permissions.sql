CREATE TABLE [dbo].[Permissions] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (2000) NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

