CREATE DATABASE travel
GO

USE [travel]
GO

/****** Object:  Table [dbo].[roles]    Script Date: 11/16/2016 20:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[roles]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[usuarios]    Script Date: 11/16/2016 20:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuarios]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Email] [varchar](100) NULL,
	[Genero] [varchar](1) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[destinos]    Script Date: 11/16/2016 20:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[destinos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Imagen] [varchar](100) NULL,
	[Descripcion] [varchar](100) NULL,
	[Coordenada_X] [decimal](6, 2) NOT NULL,
	[Coordenada_Y] [decimal](6, 2) NOT NULL,
	[Tipo] [int] NOT NULL,
	[IdUsuarioAgrega] [int] NOT NULL,
 CONSTRAINT [PK_destinos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[aristas]    Script Date: 11/16/2016 20:49:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[aristas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDestinoInicial] [int] NOT NULL,
	[IdDestinoFinal] [int] NOT NULL,
	[Distancia] [decimal](6, 2) NOT NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_aristas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

/****** Object:  ForeignKey [FK_arista_destinoinicial]    Script Date: 11/16/2016 20:49:40 ******/
ALTER TABLE [dbo].[aristas]  WITH CHECK ADD  CONSTRAINT [FK_arista_destinoinicial] FOREIGN KEY([IdDestinoInicial])
REFERENCES [dbo].[destinos] ([Id])
GO
ALTER TABLE [dbo].[aristas] CHECK CONSTRAINT [FK_arista_destinoinicial]
GO

/****** Object:  ForeignKey [FK_aristas_destinofinal]    Script Date: 11/16/2016 20:49:40 ******/
ALTER TABLE [dbo].[aristas]  WITH CHECK ADD  CONSTRAINT [FK_aristas_destinofinal] FOREIGN KEY([IdDestinoFinal])
REFERENCES [dbo].[destinos] ([Id])
GO
ALTER TABLE [dbo].[aristas] CHECK CONSTRAINT [FK_aristas_destinofinal]
GO

/****** Object:  ForeignKey [FK_destino_usuarioagrega]    Script Date: 11/16/2016 20:49:40 ******/
ALTER TABLE [dbo].[destinos]  WITH CHECK ADD  CONSTRAINT [FK_destino_usuarioagrega] FOREIGN KEY([IdUsuarioAgrega])
REFERENCES [dbo].[usuarios] ([Id])
GO
ALTER TABLE [dbo].[destinos] CHECK CONSTRAINT [FK_destino_usuarioagrega]
GO

/****** Object:  ForeignKey [FK_usuario_rol]    Script Date: 11/16/2016 20:49:40 ******/
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[roles] ([Id])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuario_rol]
GO