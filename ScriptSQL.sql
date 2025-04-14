CREATE DATABASE cartoriocivil;

CREATE TABLE Nascimento (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataNascimento DATE NOT NULL,
    NomeRegistrado VARCHAR(255) NOT NULL,
    NomePai VARCHAR(255) NOT NULL,
    NomeMae VARCHAR(255) NOT NULL,
    DataNascimentoPai DATE NOT NULL,
    DataNascimentoMae DATE NOT NULL,
    CpfPai VARCHAR(14) NOT NULL,
    CpfMae VARCHAR(14) NOT NULL
);

CREATE TABLE Conjuge (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    NomePai VARCHAR(255),
    NomeMae VARCHAR(255),
    DataNascimentoPai DATE,
    DataNascimentoMae DATE,
    CpfPai VARCHAR(14),
    CpfMae VARCHAR(14)
);

CREATE TABLE Casamento (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataCasamento DATE NOT NULL,
    IdConjuge1 INTEGER REFERENCES Conjuge(Id),
    IdConjuge2 INTEGER REFERENCES Conjuge(Id)
);

CREATE TABLE Obito (
    Id SERIAL PRIMARY KEY,
    DataRegistro DATE NOT NULL,
    DataObito DATE NOT NULL,
    NomeFalecido VARCHAR(255) NOT NULL,
    DataNascimento DATE NOT NULL,
    NomePai VARCHAR(255) NOT NULL,
    NomeMae VARCHAR(255) NOT NULL,
    DataNascimentoPai DATE NOT NULL,
    DataNascimentoMae DATE NOT NULL
);