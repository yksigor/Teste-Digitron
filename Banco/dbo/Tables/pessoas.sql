CREATE TABLE [dbo].[pessoas] (
    [IdPessoa] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (100) NOT NULL,
    [Telefone] BIGINT        NOT NULL,
    [CPF]      BIGINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdPessoa] ASC)
);

