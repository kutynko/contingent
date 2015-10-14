CREATE TABLE [dbo].[Roles] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (300)   NOT NULL,
    [Description] NVARCHAR (2000) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

