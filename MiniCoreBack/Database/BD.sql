CREATE DATABASE MiniCore
USE MiniCore

DROP TABLE IF EXISTS  Clientes
CREATE TABLE Clientes(
    idCliente int identity (1,1) NOT NULL,
    NombreCliente varchar (50),
    CONSTRAINT idCliente_PK PRIMARY KEY (idCliente)
)


DROP TABLE IF EXISTS Contratos
CREATE TABLE Contratos(
	idContrato int IDENTITY(1,1) NOT NULL,
	idCliente_FK int NULL,
	NombreContrato varchar(50) NULL,
	Montos float NULL,
	Fecha date NULL,
 CONSTRAINT idContrato_PK PRIMARY KEY (idContrato) 
)

GO
ALTER TABLE [dbo].[Contratos]  WITH CHECK ADD  CONSTRAINT [idClienteFK] FOREIGN KEY([idCliente_FK])
REFERENCES [dbo].[Clientes] ([idCliente])
GO
ALTER TABLE [dbo].[Contratos] CHECK CONSTRAINT [idClienteFK]
GO


GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([idCliente], [NombreCliente]) VALUES (1, N'Udla')
INSERT [dbo].[Clientes] ([idCliente], [NombreCliente]) VALUES (2, N'Supermaxi')
INSERT [dbo].[Clientes] ([idCliente], [NombreCliente]) VALUES (3, N'Cigarra')
INSERT [dbo].[Clientes] ([idCliente], [NombreCliente]) VALUES (4, N'Fybeca')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO


GO
SET IDENTITY_INSERT [dbo].[Contratos] ON 

INSERT [dbo].[Contratos] ([idContrato], [idCliente_FK], [NombreContrato], [Montos], [Fecha]) VALUES (1, 1, N'Tour Virtual Udla', 4000, '2023-01-21')
INSERT [dbo].[Contratos] ([idContrato], [idCliente_FK], [NombreContrato], [Montos], [Fecha]) VALUES (2, 2, N'SEO Website', 2000, '2023-01-22')
INSERT [dbo].[Contratos] ([idContrato], [idCliente_FK], [NombreContrato], [Montos], [Fecha]) VALUES (3, 3, N'SEO Website', 6000, '2023-01-23')
INSERT [dbo].[Contratos] ([idContrato], [idCliente_FK], [NombreContrato], [Montos], [Fecha]) VALUES (4, 1, N'SEO Website', 2500, '2023-01-24')
SET IDENTITY_INSERT [dbo].[Contratos] OFF
GO
