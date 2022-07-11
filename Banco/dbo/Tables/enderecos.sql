CREATE TABLE [dbo].[enderecos] (
    [IdEndereco] INT           IDENTITY (1, 1) NOT NULL,
    [Logradouro] VARCHAR (100) NOT NULL,
    [CEP]        BIGINT        NOT NULL,
    [Cidade]     VARCHAR (100) NULL,
    [Estado]     VARCHAR (100) NOT NULL,
    [IdPessoa]   INT           NULL,
    PRIMARY KEY CLUSTERED ([IdEndereco] ASC),
    FOREIGN KEY ([IdPessoa]) REFERENCES [dbo].[pessoas] ([IdPessoa]) ON DELETE CASCADE
);

