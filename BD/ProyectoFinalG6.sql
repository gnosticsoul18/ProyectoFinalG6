USE [ProyectoFinalG6]
GO
/****** Object:  Table [dbo].[asignaciones]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asignaciones](
	[asignacionid] [int] IDENTITY(1,1) NOT NULL,
	[reparacionid] [int] NULL,
	[tecnicoid] [int] NULL,
	[fechaAsignacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[asignacionid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[clienteid] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[correoElectronico] [varchar](50) NOT NULL,
	[telefono] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[clienteid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[correoElectronico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detallesReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallesReparacion](
	[detallesid] [int] IDENTITY(1,1) NOT NULL,
	[reparacionid] [int] NULL,
	[descripcion] [varchar](50) NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFin] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[detallesid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipos]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipos](
	[equipoid] [int] IDENTITY(1,1) NOT NULL,
	[tipoEquipo] [varchar](50) NOT NULL,
	[modelo] [varchar](50) NULL,
	[clienteid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[equipoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reparaciones]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reparaciones](
	[reparacionid] [int] IDENTITY(1,1) NOT NULL,
	[equipoid] [int] NULL,
	[fechaSolicitud] [datetime] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[reparacionid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tecnicos]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tecnicos](
	[tecnicoid] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[especialidad] [varchar](50) NULL,
	[correoElectronico] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[tecnicoid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioCorreo] [nvarchar](255) NOT NULL,
	[Contraseña] [nvarchar](255) NULL,
	[RolID] [int] NOT NULL,
	[TipoUsuario] [nvarchar](50) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Telefono] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_reparacionid1] FOREIGN KEY([reparacionid])
REFERENCES [dbo].[reparaciones] ([reparacionid])
GO
ALTER TABLE [dbo].[asignaciones] CHECK CONSTRAINT [fk_reparacionid1]
GO
ALTER TABLE [dbo].[asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_tecnicoid1] FOREIGN KEY([tecnicoid])
REFERENCES [dbo].[tecnicos] ([tecnicoid])
GO
ALTER TABLE [dbo].[asignaciones] CHECK CONSTRAINT [fk_tecnicoid1]
GO
ALTER TABLE [dbo].[detallesReparacion]  WITH CHECK ADD  CONSTRAINT [fk_reparacionid] FOREIGN KEY([reparacionid])
REFERENCES [dbo].[reparaciones] ([reparacionid])
GO
ALTER TABLE [dbo].[detallesReparacion] CHECK CONSTRAINT [fk_reparacionid]
GO
ALTER TABLE [dbo].[equipos]  WITH CHECK ADD  CONSTRAINT [fk_usuarioid] FOREIGN KEY([clienteid])
REFERENCES [dbo].[clientes] ([clienteid])
GO
ALTER TABLE [dbo].[equipos] CHECK CONSTRAINT [fk_usuarioid]
GO
ALTER TABLE [dbo].[reparaciones]  WITH CHECK ADD  CONSTRAINT [fk_equipoid] FOREIGN KEY([equipoid])
REFERENCES [dbo].[equipos] ([equipoid])
GO
ALTER TABLE [dbo].[reparaciones] CHECK CONSTRAINT [fk_equipoid]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([RolID])
REFERENCES [dbo].[Roles] ([RolID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAsignacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- actualizar asignación
CREATE PROCEDURE [dbo].[ActualizarAsignacion]
   @AsignacionID INT,
   @ReparacionID INT,
   @TecnicoID INT,
   @FechaAsignacion DATETIME
AS 
BEGIN 
   UPDATE asignaciones SET reparacionid = @ReparacionID, tecnicoid = @TecnicoID, fechaAsignacion = @FechaAsignacion WHERE asignacionid = @AsignacionID
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCliente]
    @ClienteID INT,
    @Nombre NVARCHAR(MAX),
    @CorreoElectronico NVARCHAR(MAX),
    @Telefono NVARCHAR(MAX)
AS
BEGIN
    UPDATE clientes
    SET nombre = @Nombre,
        correoElectronico = @CorreoElectronico,
        telefono = @Telefono
    WHERE clienteid = @ClienteID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarDetallesReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- actualizar detalles de reparación
CREATE PROCEDURE [dbo].[ActualizarDetallesReparacion]
   @DetallesID INT,
   @ReparacionID INT,
   @Descripcion VARCHAR(50),
   @FechaInicio DATETIME,
   @FechaFin DATETIME
AS 
BEGIN 
   UPDATE detallesReparacion SET reparacionid = @ReparacionID, descripcion = @Descripcion, fechaInicio = @FechaInicio, fechaFin = @FechaFin WHERE detallesid = @DetallesID
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEquipo]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarEquipo]
    @EquipoID INT,
    @TipoEquipo NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @ClienteID INT
AS
BEGIN
    UPDATE equipos
    SET tipoEquipo = @TipoEquipo, modelo = @Modelo, clienteid = @ClienteID
    WHERE equipoid = @EquipoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- actualizar reparación
CREATE PROCEDURE [dbo].[ActualizarReparacion]
   @ReparacionID INT,
   @EquipoID INT,
   @FechaSolicitud DATETIME,
   @Estado CHAR(1)
AS 
BEGIN 
   UPDATE reparaciones SET equipoid = @EquipoID, fechaSolicitud = @FechaSolicitud, estado = @Estado WHERE reparacionid = @ReparacionID
END
GO
/****** Object:  StoredProcedure [dbo].[ActualizarTecnico]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarTecnico]
    @TecnicoID INT,
    @Nombre NVARCHAR(MAX),
    @Especialidad NVARCHAR(MAX),
    @CorreoElectronico NVARCHAR(MAX)
AS
BEGIN
    UPDATE tecnicos
    SET nombre = @Nombre,
        especialidad = @Especialidad,
        correoElectronico = @CorreoElectronico
    WHERE tecnicoID = @TecnicoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarUsuario]
    @UsuarioID INT,
    @Nombre NVARCHAR(255),
    @UsuarioCorreo NVARCHAR(255),
    @Contrasena NVARCHAR(255),
    @TipoUsuario NVARCHAR(50) -- Agregamos el nuevo parámetro para TipoUsuario
AS
BEGIN
    UPDATE usuarios
    SET Nombre = @Nombre,
        UsuarioCorreo = @UsuarioCorreo,
        Contraseña = @Contrasena,
        TipoUsuario = @TipoUsuario -- Actualizamos el campo TipoUsuario
    WHERE UsuarioID = @UsuarioID;
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarAsignacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTOS ASIGNACIONES
-- agregar asignación
CREATE PROCEDURE [dbo].[AgregarAsignacion]
   @ReparacionID INT,
   @TecnicoID INT,
   @FechaAsignacion DATETIME
AS 
BEGIN 
   INSERT INTO asignaciones (reparacionid, tecnicoid, fechaAsignacion) VALUES (@ReparacionID, @TecnicoID, @FechaAsignacion)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarCliente]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarCliente]
    @Nombre NVARCHAR(MAX),
    @CorreoElectronico NVARCHAR(MAX),
    @Telefono NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO clientes (nombre, correoElectronico, telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarDetallesReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTOS DETALLESREPARACION
-- agregar detalles de reparación
CREATE PROCEDURE [dbo].[AgregarDetallesReparacion]
   @ReparacionID INT,
   @Descripcion VARCHAR(50),
   @FechaInicio DATETIME,
   @FechaFin DATETIME
AS 
BEGIN 
   INSERT INTO detallesReparacion (reparacionid, descripcion, fechaInicio, fechaFin) VALUES (@ReparacionID, @Descripcion, @FechaInicio, @FechaFin)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarEquipo]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEquipo]
    @TipoEquipo NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @ClienteID INT
AS
BEGIN
    INSERT INTO equipos (tipoEquipo, modelo, clienteid)
    VALUES (@TipoEquipo, @Modelo, @ClienteID);
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTOS REPARACIONES
-- agregar reparación
CREATE PROCEDURE [dbo].[AgregarReparacion]
   @EquipoID INT,
   @FechaSolicitud DATETIME,
   @Estado CHAR(1)
AS 
BEGIN 
   INSERT INTO reparaciones (equipoid, fechaSolicitud, estado) VALUES (@EquipoID, @FechaSolicitud, @Estado)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarTecnico]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarTecnico]
    @Nombre NVARCHAR(MAX),
    @Especialidad NVARCHAR(MAX),
    @CorreoElectronico NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO tecnicos (nombre, especialidad, correoElectronico)
    VALUES (@Nombre, @Especialidad, @CorreoElectronico);
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarAsignaciones]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar todas las asignaciones
CREATE PROCEDURE [dbo].[ConsultarAsignaciones]
AS 
BEGIN 
   SELECT * FROM asignaciones
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarAsignacionPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar por ID (filtro)
CREATE PROCEDURE [dbo].[ConsultarAsignacionPorID]
   @AsignacionID INT
AS 
BEGIN 
   SELECT * FROM asignaciones WHERE asignacionid = @AsignacionID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCliente]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ConsultarCliente]
AS
BEGIN
    SELECT clienteid, nombre, correoElectronico, telefono
    FROM clientes;
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarClientePorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarClientePorID]
    @ClienteID INT
AS
BEGIN
    SELECT clienteid, nombre, correoElectronico, telefono
    FROM clientes
    WHERE clienteid = @ClienteID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetallesReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar todos los detalles de reparación
CREATE PROCEDURE [dbo].[ConsultarDetallesReparacion]
AS 
BEGIN 
   SELECT * FROM detallesReparacion
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetallesReparacionPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar por ID (filtro)
CREATE PROCEDURE [dbo].[ConsultarDetallesReparacionPorID]
   @DetallesID INT
AS 
BEGIN 
   SELECT * FROM detallesReparacion WHERE detallesid = @DetallesID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEquipoPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar por ID (filtro)
CREATE PROCEDURE [dbo].[ConsultarEquipoPorID]
   @EquipoID INT
AS 
BEGIN 
   SELECT * FROM equipos WHERE equipoid = @EquipoID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEquipos]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar todos los equipos
CREATE PROCEDURE [dbo].[ConsultarEquipos]
AS 
BEGIN 
   SELECT * FROM equipos
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarReparaciones]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar todas las reparaciones
CREATE PROCEDURE [dbo].[ConsultarReparaciones]
AS 
BEGIN 
   SELECT * FROM reparaciones
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarReparacionPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar por ID (filtro)
CREATE PROCEDURE [dbo].[ConsultarReparacionPorID]
   @ReparacionID INT
AS 
BEGIN 
   SELECT * FROM reparaciones WHERE reparacionid = @ReparacionID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTecnicoPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar por ID (filtro)
CREATE PROCEDURE [dbo].[ConsultarTecnicoPorID]
   @TecnicoID INT
AS 
BEGIN 
   SELECT * FROM tecnicos WHERE tecnicoid = @TecnicoID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTecnicos]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- consultar todos los técnicos
CREATE PROCEDURE [dbo].[ConsultarTecnicos]
AS 
BEGIN 
   SELECT * FROM tecnicos
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuarioPorID]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuarioPorID]
    @UsuarioID INT
AS
BEGIN
    SELECT UsuarioID, Nombre, UsuarioCorreo, Contraseña
    FROM usuarios
    WHERE UsuarioID = @UsuarioID;
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarAsignacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- eliminar asignación
CREATE PROCEDURE [dbo].[EliminarAsignacion]
   @AsignacionID INT
AS 
BEGIN 
   DELETE asignaciones WHERE asignacionid = @AsignacionID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarCliente]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarCliente]
    @ClienteID INT
AS
BEGIN
    DELETE FROM clientes WHERE clienteid = @ClienteID;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarDetallesReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- eliminar detalles de reparación
CREATE PROCEDURE [dbo].[EliminarDetallesReparacion]
   @DetallesID INT
AS 
BEGIN 
   DELETE detallesReparacion WHERE detallesid = @DetallesID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEquipo]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- eliminar equipo
CREATE PROCEDURE [dbo].[EliminarEquipo]
   @EquipoID INT
AS 
BEGIN 
   DELETE equipos WHERE equipoid = @EquipoID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarReparacion]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- eliminar reparación
CREATE PROCEDURE [dbo].[EliminarReparacion]
   @ReparacionID INT
AS 
BEGIN 
   DELETE reparaciones WHERE reparacionid = @ReparacionID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarTecnico]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- eliminar técnico
CREATE PROCEDURE [dbo].[EliminarTecnico]
   @TecnicoID INT
AS 
BEGIN 
   DELETE tecnicos WHERE tecnicoid = @TecnicoID
END
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuario]    Script Date: 10/12/2023 18:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarUsuario]
    @Correo NVARCHAR(MAX),
    @Clave NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UsuarioID INT;

    -- Buscar el usuario por correo y contraseña
    SELECT @UsuarioID = UsuarioID
    FROM usuarios
    WHERE UsuarioCorreo = @Correo AND Contraseña = @Clave;

    -- Devolver el resultado
    IF @UsuarioID IS NOT NULL
    BEGIN
        SELECT 'Exito' AS Estado, @UsuarioID AS UsuarioID;
    END
    ELSE
    BEGIN
        SELECT 'Error' AS Estado, NULL AS UsuarioID;
    END
END;
GO
