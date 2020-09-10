IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [Status] nvarchar(max) NULL,
    [OrderDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(max) NULL,
    [Preco] real NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PedidosItens] (
    [Id] uniqueidentifier NOT NULL,
    [IdPedido] uniqueidentifier NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_PedidosItens] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidosItens_Pedidos_IdPedido] FOREIGN KEY ([IdPedido]) REFERENCES [Pedidos] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PedidosItens_IdPedido] ON [PedidosItens] ([IdPedido]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200910031955_InitialCreate', N'3.1.7');

GO

