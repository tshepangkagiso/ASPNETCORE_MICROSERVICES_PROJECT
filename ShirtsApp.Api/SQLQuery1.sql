CREATE DATABASE ShirtsDB;
GO
USE ShirtsDB;
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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250209125129_Init'
)
BEGIN
    CREATE TABLE [Shirts] (
        [ShirtID] int NOT NULL IDENTITY,
        [Brand] nvarchar(max) NOT NULL,
        [Color] nvarchar(max) NOT NULL,
        [Size] int NOT NULL,
        CONSTRAINT [PK_Shirts] PRIMARY KEY ([ShirtID])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250209125129_Init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ShirtID', N'Brand', N'Color', N'Size') AND [object_id] = OBJECT_ID(N'[Shirts]'))
        SET IDENTITY_INSERT [Shirts] ON;
    EXEC(N'INSERT INTO [Shirts] ([ShirtID], [Brand], [Color], [Size])
    VALUES (1, N''Polo'', N''Black'', 30),
    (2, N''Nike'', N''Gray'', 50),
    (3, N''D&G'', N''Red'', 28),
    (4, N''Puma'', N''Blue'', 14)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ShirtID', N'Brand', N'Color', N'Size') AND [object_id] = OBJECT_ID(N'[Shirts]'))
        SET IDENTITY_INSERT [Shirts] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250209125129_Init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250209125129_Init', N'9.0.1');
END;

COMMIT;
GO
