use master
go

if exists(select * from sys.databases where name = 'KrustyBurgerDB')
	drop database KrustyBurgerDB
go

create database KrustyBurgerDB
go

use KrustyBurgerDB
go

create table Imagem(
	ID int identity primary key,
	Foto varbinary(MAX) not null
)
go

create table Usuario(
	ID int identity primary key,
	Nome varchar(80) not null,
	Cpf varchar(20) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	Adm bit default 0
)
go

create table Pedido(
	ID int identity primary key,
	UsuarioID int references Usuario(ID) not null,
	HoraPedido datetime not null,
	HoraEntregue datetime,
	PedidoPronto bit default 0
)
go

create table Produto(
	ID int identity primary key,
	Nome varchar(100) not null,
	Descricao varchar(MAX) not null,
	Preco float not null,
	Tipo varchar(20) not null,
	ImagemID int references Imagem(ID)
)
go

create table Promocao(
	ID int identity primary key,
	ProdutoID int references Produto(ID),
	Preco float not null
)
go

create table PedidoProduto(
	ID int identity primary key,
	ProdutoID int references Produto(ID),
	PromocaoID int references Promocao(ID),
	Quantidade int not null
);
go

select p.Nome 'Nome', p.Preco 'Preco antigo', pm.Preco 'Preco novo' from Promocao pm
left join Produto p
on pm.ProdutoID = p.ID