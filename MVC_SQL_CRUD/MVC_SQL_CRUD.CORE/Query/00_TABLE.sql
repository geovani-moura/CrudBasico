CREATE DATABASE MVC_SQL_CRUD

CREATE TABLE TB_Pedido(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	NumeroPedido INT NOT NULL
)

CREATE LOGIN MVC_SQL_CRUD_USER
    WITH PASSWORD    = N'123456',
    CHECK_POLICY     = OFF,
    CHECK_EXPIRATION = OFF;
GO

EXEC sp_addsrvrolemember 
    @loginame = N'MVC_SQL_CRUD_USER', 
    @rolename = N'sysadmin';
