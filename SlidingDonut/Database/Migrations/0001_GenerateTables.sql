-- <Migration ID="87c7ce55-c7a6-43f6-8bc1-1e113b031ec7" />
GO

PRINT N'Creating [dbo].[Donuts]'
GO
CREATE TABLE [dbo].[Donuts]
(
[Id] [int] NOT NULL,
[Name] [nvarchar] (50) NOT NULL
)
GO
PRINT N'Creating primary key [PK__Donuts__3214EC0797E8B609] on [dbo].[Donuts]'
GO
ALTER TABLE [dbo].[Donuts] ADD CONSTRAINT [PK__Donuts__3214EC0797E8B609] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Creating [dbo].[Toppings]'
GO
CREATE TABLE [dbo].[Toppings]
(
[Id] [int] NOT NULL,
[Name] [nvarchar] (50) NOT NULL,
[DonutId] [int] NULL
)
GO
PRINT N'Creating primary key [PK__Toppings__3214EC07F7C7AD23] on [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] ADD CONSTRAINT [PK__Toppings__3214EC07F7C7AD23] PRIMARY KEY CLUSTERED  ([Id])
GO
PRINT N'Adding foreign keys to [dbo].[Toppings]'
GO
ALTER TABLE [dbo].[Toppings] ADD CONSTRAINT [FK__Toppings__DonutI__38996AB5] FOREIGN KEY ([DonutId]) REFERENCES [dbo].[Donuts] ([Id])
GO
