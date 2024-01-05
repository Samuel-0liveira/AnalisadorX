CREATE TABLE analisador (
	id serial NOT NULL,
	nome varchar (60) NOT NULL,
	usuario varchar (30) NOT NULL,
	email varchar (100) NOT NULL,
	senha varchar (50) NOT NULL,
	salt bytea,
	primary key (usuario)
);

CREATE TYPE classificacao_mutante AS ENUM('Ômega', 'Alfa', 'Beta', 'Gama', 'Delta', 'Épsilon');

CREATE TABLE mutante (
	id serial NOT NULL,
	nome varchar (60) NOT NULL,
	alterego varchar (60) NOT NULL,
	idade int NOT NULL,
	filiacao varchar (25) NOT NULL,
	habilidade varchar (150) NOT NULL,
	classificacao classificacao_mutante, 
	primary key (id)
);