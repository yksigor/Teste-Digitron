CREATE DATABASE TesteDigitronDB;

CREATE TABLE pessoas(
	IdPessoa INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(100) NOT NULL,
	Telefone BIGINT NOT NULL,
	CPF BIGINT NOT NULL
);

INSERT INTO pessoas(Nome, Telefone, CPF) VALUES ('André Matos', 1155554444, 12345678912);
INSERT INTO pessoas(Nome, Telefone, CPF) VALUES ('Michael Romeo', 5599998888, 98765432100);
INSERT INTO pessoas(Nome, Telefone, CPF) VALUES ('Rafael Bittencourt', 3377776666, 12234456677);
INSERT INTO pessoas(Nome, Telefone, CPF) VALUES ('Michael Pinella', 7712345678, 32165498755);

CREATE TABLE enderecos(
	IdEndereco INT PRIMARY KEY IDENTITY(1,1),
	Logradouro VARCHAR(100) NOT NULL,
	CEP BIGINT NOT NULL,
	Cidade VARCHAR(100),
	Estado VARCHAR(100) NOT NULL,
	IdPessoa INT FOREIGN KEY REFERENCES pessoas(IdPessoa) ON DELETE CASCADE
);

INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa) VALUES ('Rua do Matão, nº14', 69875446, 'São Carlos', 'São Paulo', 1);
INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa) VALUES ('Rua do Winchester, nº12', 44512700, 'Curitiba', 'Paraná', 2);
INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa) VALUES ('Rua da Remmington, nº870', 96312550, 'Vitória', 'Espirito Santo', 3);
INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa) VALUES ('Rua do Heckler, nº5', 10045665, 'Joinville', 'Santa Catarina', 4);
INSERT INTO enderecos(Logradouro, CEP, Cidade, Estado, IdPessoa) VALUES ('Rua Springfield, nº1908', 30022812, 'São Caetano do Sul', 'São Paulo', 1);

SELECT * FROM pessoas;
SELECT * FROM enderecos;