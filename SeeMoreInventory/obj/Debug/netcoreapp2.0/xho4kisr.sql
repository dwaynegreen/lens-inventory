CREATE TABLE [MaterialType] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MaterialType] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Lenses] (
    [ProductLabel] nvarchar(30) NOT NULL,
    [AntiReflectiveCoating] bit NOT NULL,
    [Axis] int NULL,
    [Cylinder] decimal(18, 2) NOT NULL,
    [LowInventoryWarning] int NULL,
    [MaterialId] int NULL,
    [RemainingCount] int NULL,
    [Sphere] decimal(18, 2) NOT NULL,
    [Transitions] bit NOT NULL,
    CONSTRAINT [PK_Lenses] PRIMARY KEY ([ProductLabel]),
    CONSTRAINT [FK_Lenses_MaterialType_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [MaterialType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [LensHistory] (
    [Id] int NOT NULL IDENTITY,
    [AntiReflectiveCoating] bit NOT NULL,
    [Axis] int NULL,
    [Cylinder] decimal(18, 2) NOT NULL,
    [InsertDate] datetime2 NOT NULL,
    [MaterialId] int NULL,
    [ProductLabel] nvarchar(30) NOT NULL,
    [Quantity] int NOT NULL,
    [RemainingCount] int NULL,
    [Sphere] decimal(18, 2) NOT NULL,
    [Transitions] bit NOT NULL,
    CONSTRAINT [PK_LensHistory] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_LensHistory_MaterialType_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [MaterialType] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Lenses_MaterialId] ON [Lenses] ([MaterialId]);

GO

CREATE INDEX [IX_LensHistory_MaterialId] ON [LensHistory] ([MaterialId]);

GO


ALTER TABLE [Lenses] DROP CONSTRAINT [FK_Lenses_MaterialType_MaterialId];

GO

ALTER TABLE [LensHistory] DROP CONSTRAINT [FK_LensHistory_MaterialType_MaterialId];

GO

ALTER TABLE [MaterialType] DROP CONSTRAINT [PK_MaterialType];

GO

EXEC sp_rename N'MaterialType', N'Materials';

GO

ALTER TABLE [Materials] ADD CONSTRAINT [PK_Materials] PRIMARY KEY ([Id]);

GO

ALTER TABLE [Lenses] ADD CONSTRAINT [FK_Lenses_Materials_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [Materials] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [LensHistory] ADD CONSTRAINT [FK_LensHistory_Materials_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [Materials] ([Id]) ON DELETE NO ACTION;

GO





ALTER TABLE [Materials] ADD [Deleted] bit NOT NULL DEFAULT 0;

GO





ALTER TABLE [Lenses] DROP CONSTRAINT [FK_Lenses_Materials_MaterialId];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Materials') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Materials] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Materials] ALTER COLUMN [Name] nvarchar(max) NOT NULL;

GO

DROP INDEX [IX_Lenses_MaterialId] ON [Lenses];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'Lenses') AND [c].[name] = N'MaterialId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Lenses] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Lenses] ALTER COLUMN [MaterialId] int NOT NULL;
CREATE INDEX [IX_Lenses_MaterialId] ON [Lenses] ([MaterialId]);

GO

ALTER TABLE [Lenses] ADD CONSTRAINT [FK_Lenses_Materials_MaterialId] FOREIGN KEY ([MaterialId]) REFERENCES [Materials] ([Id]) ON DELETE CASCADE;

GO





