create Database ProductoDb
go

use ProductoDb
go


create table Producto
(
	ProductoId  int primary key identity,
	Descripcion varchar(30),
	Existencia decimal,
	Costo decimal,
	ValorInventario decimal,
)

select * from Producto