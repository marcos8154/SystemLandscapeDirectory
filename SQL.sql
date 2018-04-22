create table Licenca
(
	ContratoId varchar(100) not null,
	ClienteId varchar(100) not null,
	CPUID varchar(100) not null,
	OS varchar(100) not null
);

create table ItemLicenca
(
	Id int identity(1,1) not null,
	ProdutoId int not null,
	ProdutoDescricao varchar(100) not null,
	Usuarios varchar(100) not null,

	primary key(Id)
);

create table FaturaItemLicenca
(
	Id int not null,
	ItemLicencaId int not null,
	DataVencimento varchar(100) not null,
	CodigoPagamento int not null default 0,

	primary key(Id)
);

create table Ambiente
(
    Nome varchar(100) not null,
	Servidor varchar(100) not null,
	Usuario varchar(30) not null,
	Senha varchar(50) not null,
	Versao varchar(80) not null,
	Online bit not null default 1,

	primary key(Nome)
);