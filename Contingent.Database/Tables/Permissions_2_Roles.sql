CREATE TABLE [dbo].[Permissions_2_Roles] (
    [RoleId]       INT NOT NULL,
    [PermissionId] INT NOT NULL,
    CONSTRAINT [FK_Roles_2_Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permissions] ([Id]),
    CONSTRAINT [FK_Roles_2_Permissions_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);

GO

CREATE clustered INDEX [IX_Permissions_2_Roles_RoleId_PermissionId] ON [dbo].[Permissions_2_Roles] (RoleId, PermissionId)
