CREATE TABLE [dbo].[Roles_2_Users] (
    [RoleId] INT NOT NULL,
    [UserId] INT NOT NULL,
    CONSTRAINT [FK_Roles_2_Users_PermissionId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Roles_2_Users_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [UQ_Roles_2_Users_RoleId_PermissionId] UNIQUE NONCLUSTERED ([RoleId] ASC, [UserId] ASC)
);


GO

CREATE clustered INDEX [IX_Roles_2_Users_RoleId_UserId] ON [dbo].[Roles_2_Users] (RoleId, UserId)
