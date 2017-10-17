-- <Migration ID="35d7821e-cc85-405d-92d7-ba0dbf01d64a" />
GO

PRINT N'Dropping foreign keys from [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] DROP CONSTRAINT [FK__Toppings__DonutI__38996AB5]
GO
PRINT N'Dropping constraints from [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] DROP CONSTRAINT [PK__Toppings__3214EC07F7C7AD23]
GO
PRINT N'Rebuilding [dbo].[Toppings]'
GO
CREATE TABLE [dbo].[RG_Recovery_1_Toppings]
(
[Id] [int] NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[DonutId] [int] NULL,
[Color] [nvarchar] (50) NOT NULL
)
GO
INSERT INTO [dbo].[RG_Recovery_1_Toppings]([Id], [Name], [DonutId]) SELECT [Id], [Name], [DonutId] FROM [dbo].[Toppings]
GO
DROP TABLE [dbo].[Toppings]
GO
EXEC sp_rename N'[dbo].[RG_Recovery_1_Toppings]', N'Toppings', N'OBJECT'
GO
PRINT N'Creating primary key [PK__Toppings__3214EC07F7C7AD23] on [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] ADD CONSTRAINT [PK__Toppings__3214EC07F7C7AD23] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] ADD CONSTRAINT [FK__Toppings__DonutI__38996AB5] FOREIGN KEY ([DonutId]) REFERENCES [dbo].[Donuts] ([Id])
GO
