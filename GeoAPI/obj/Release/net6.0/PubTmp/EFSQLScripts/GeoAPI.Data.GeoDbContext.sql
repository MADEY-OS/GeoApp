IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117184246_init')
BEGIN
    CREATE TABLE [GeoMarkers] (
        [Id] uniqueidentifier NOT NULL,
        [Latitude] float NOT NULL,
        [Longitude] float NOT NULL,
        [Type] nvarchar(max) NULL,
        [Question] nvarchar(max) NULL,
        [Answear] nvarchar(max) NULL,
        CONSTRAINT [PK_GeoMarkers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221117184246_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221117184246_init', N'7.0.0');
END;
GO

COMMIT;
GO

