use master
go

if exists(select * from sys.databases where name = 'KrustyBurger')
	drop database KrustyBurger
go

create database KrustyBurger
go

use KrustyBurger
go

create table Imagem(
	ID int identity primary key,
	Foto varbinary(MAX) not null
)
go

create table Usuario(
	ID int identity primary key,
	Nome varchar(80) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	Adm bit default 0
)
go

create table Pedido(
	ID int identity primary key,
	UsuarioID int references Usuario(ID) not null
)
go

create table Produto(
	ID int identity primary key,
	Nome varchar(100) not null,
	Descricao varchar(MAX) not null,
	Preco float not null,
	ImagemID int references Imagem(ID)
)
go

create table PedidoProduto(
	ID int identity primary key,
	ProdutoID int references Produto(ID),
	Quantidade int not null
);
go