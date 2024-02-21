CREATE DATABASE TESTE123
GO

USE TESTE123
GO

CREATE TABLE TB_Cliente(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome varchar(100) NULL
)
GO


CREATE TABLE TB_LOG(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	LogText text NOT NULL,
	LogDate datetime NOT NULL,
) 
GO

USE [master];
GO

CREATE LOGIN userTeste01
    WITH PASSWORD    = N'123456',
    CHECK_POLICY     = OFF,
    CHECK_EXPIRATION = OFF;
GO

EXEC sp_addsrvrolemember 
    @loginame = N'userTeste01', 
    @rolename = N'sysadmin';