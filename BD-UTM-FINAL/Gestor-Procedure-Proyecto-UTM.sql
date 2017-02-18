
/**********************************************************Gestion de Actividades******************************************************************  */  /*   * Insertar Actividades   */ 
use BDUTM 

/**************Agregar Actividad*************/
CREATE PROCEDURE InsertarActividades 
(         
@Nombre         varchar(50),     
@Descripcion    varchar(5000),     
@FechaIni       date,     
@FechaFin       date,
@HoraInicio     time(0),
@HoraFin        time(0)     ,
@CodUsuario     varchar(20) ,
@IDSitio        int    
 ) 
AS INSERT INTO Actividades ( Nombre, Descripcion,     FechaIni,     FechaFin,HoraInicio,HoraFin,CodUsuario,idsitio  ) VALUES ( @Nombre, @Descripcion, @FechaIni, @FechaFin,@HoraInicio,@HoraFin,@CodUsuario,@IDSitio) 

/**declare @id int set @id=(select max(idactividad) from Actividades) insert into ActividadUsuario(Asistencia,IDActividad,CodUsuario)values(@Asistencia,@id,@idusuario) **/

/********** Eliminar Actividades **********/  
CREATE PROCEDURE EliminarActividades 
( 
@IDActividad int )
AS SET NOCOUNT ON DELETE FROM Actividades  WHERE (@IDActividad=IDActividad) 

/*   * Modificar Actividades   */  
 CREATE PROCEDURE ModificarActividades 
 (     
@IDActividad int,
@Nombre  varchar(50), 
@Descripcion varchar(5000),
@FechaIni       date,     
@FechaFin       date,
@HoraInicio     time(0),
@HoraFin        time(0)  ,
@CodUsuario  varchar(50),
@IDSitio int
  ) 
AS SET NOCOUNT ON UPDATE Actividades 
SET Nombre=@Nombre, Descripcion=@Descripcion, fechaIni=@FechaIni,FechaFin=@FechaFin,HoraInicio=@HoraInicio,HoraFin=@HoraFin,idsitio=@idsitio, CodUsuario=@CodUsuario   WHERE IDActividad=@IDActividad   

/*   * Obtener Actividades   */  
CREATE PROCEDURE GetActividad AS SET NOCOUNT ON SELECT * FROM Actividades 

/**************Filtrar Actividad**************/
CREATE PROCEDURE FiltraActividad
(    
@IDActividad    int=null,     
@Nombre         varchar(50)=null,
@Descripcion    varchar(5000)=null,     
@FechaIni       date=null,     
@FechaFin       date=null)  AS  
SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM Actividades where 1 = 1 '     
if(@IDActividad <> 0)   
SET @sql=@sql+ ' and IDActividad = '+convert(varchar,@IDActividad)  
if(@Nombre is not null)    SET @sql=@sql+ ' and Nombre = '+Quotename(@Nombre,'''')  
if(@Descripcion is not null)    SET @sql=@sql+ ' and Descripcion = '+Quotename(@Descripcion,'''')   
if(@FechaIni is not null)    SET @sql=@sql+ ' and FechaIni = '+Quotename(@FechaIni, '''')
if(@FechaFin is not null)    SET @sql=@sql+ ' and FechaFin = '+Quotename(@FechaFin,'''')     
exec (@sql) 

/**********************************   Actividad Usuario *************************************/
CREATE PROCEDURE InsertarActividadUsuario(
@Asistencia bit,
@IDActividad int,
@IDUsuario varchar(20)
)
as insert into ActividadUsuario(Asistencia,IDActividad,CodUsuario)values(@Asistencia,@IDActividad,@IDUsuario) 

/**********Modificar*******/

CREATE PROCEDURE ModificarActividadUsuario(
@ID int,
@Asistencia bit
)
as SET NOCOUNT ON UPDATE ActividadUsuario SET Asistencia=@Asistencia WHERE ID=@ID	  

/*********************************************************Gestion de Publicacion******************************************************************  */  
/*   * Insertar Publicacion   */ 
select * from usuario
create procedure InsertarPublicacion (   
@Titulo           varchar(50),      
@Contenido        varchar(1000),   
@image            image=null,   
@IDTipo           int, 
@video            varbinary(max)=null,    
@CodUsuario       varchar(20) ) AS
INSERT INTO Publicacion (     Titulo,  Contenido,Image,  IDTipo, video,  CodUsuario ) VALUES ( @Titulo, @Contenido,@image, @IDTipo,@video, @CodUsuario) 

/*   * Eliminar Publicacion   */  
CREATE PROCEDURE EliminarPublicacion ( @IDPublicacion int )  AS SET NOCOUNT ON DELETE FROM Publicacion  WHERE (@IDPublicacion=IDPublicacion)

/*   * Modificar Publicacion   */   
CREATE PROCEDURE ModificarPublicacion (     
@IDPublicacion    int,     
@Titulo           varchar(50),     
@Contenido        varchar(1000),     
@image            image,
@IDTipo           int,     
@CodUsuario       varchar(20) ) 
AS SET NOCOUNT ON UPDATE Publicacion SET Titulo=@Titulo, Contenido=@Contenido,image=@image,idtipo=@IDTipo, CodUsuario=@CodUsuario WHERE IDPublicacion=@IDPublicacion 

/*   * Obtener Publicacion */
CREATE PROCEDURE GetPublicacion AS SET NOCOUNT ON SELECT * FROM Publicacion ORDER BY Fecha DESC

/*   * Filtra Publicacion   */ 
CREATE PROCEDURE FiltraPublicacion   (      
@IDPublicacion    int=null,       
@Titulo           varchar(50)=null,       
@Fecha            date=null,       
@Contenido        varchar(1000)=null,       
@IDTipo           int=null,       
@CodUsuario       varchar(20)=null  )  
AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM Publicacion where 1 = 1 '     
if(@IDPublicacion <> 0)    SET @sql=@sql+ ' and IDPublicacion = '+convert(varchar,@IDPublicacion)  
if(@Titulo is not null)    SET @sql=@sql+ ' and Titulo = '+Quotename(@Titulo,'''')  
if(@Fecha is not null)    SET @sql=@sql+ ' and Fecha = '+Quotename(@Fecha,'''')   
if(@Contenido is not null)    SET @sql=@sql+ ' and Contenido = '+Quotename(@Contenido,'''')  
if(@IDTipo <> 0)    SET @sql=@sql+ ' and IDTipo = '+Quotename(@IDTipo,'''')   
if(@CodUsuario is not null)    SET @sql=@sql+ ' and CodUsuario = '+Quotename(@CodUsuario,'''')  exec (@sql) 

/***********************************************************Gestion de Sitio******************************************************************  */ 

/*   * Insertar Sitio   */ 
create procedure InsertarSitio (     
    
@Nombre      varchar(50),    
@Planta      int,
@IDTipoSitio     int ) AS INSERT INTO Sitio (   Nombre,  Planta, IDTipo ) VALUES ( @Nombre, @Planta,@IDTipoSitio)

/*   * Eliminar Sitio   */  
CREATE PROCEDURE EliminarSitio ( @IDSitio int )  AS SET NOCOUNT ON DELETE FROM Sitio  WHERE (@IDSitio=IDSitio) 

/*   * Modificar Sitio   */   
CREATE PROCEDURE ModificarSitio (     
@IDSitio     int,     
@Nombre      varchar(50),       
@Planta      int,
@IDTIPO int ) AS SET NOCOUNT ON UPDATE Sitio SET Nombre=@Nombre, Planta=@Planta, IDTipo=@IDTIPO WHERE IDSitio=@IDSitio 

/*   * Obtener Sitio */
CREATE PROCEDURE GetSitio AS SET NOCOUNT ON SELECT * FROM sitio

/*   * Filtra Sitio   */ 
CREATE PROCEDURE FiltraSitio  (      
@IDSitio     int=null,       
@Nombre      varchar(50)=null,              
@Planta      int=null  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM getsitios where 1 = 1 '     
if(@IDSitio <> 0)    SET @sql=@sql+ ' and IDSitio = '+convert(varchar,@IDSitio)  
if(@Nombre is not null)    SET @sql=@sql+ ' and nombre = '+Quotename(@Nombre,'''')    
if(@Planta <> 0)    SET @sql=@sql+ ' and Planta = '+Quotename(@Planta,'''')  
exec (@sql)

/**********************************************Gestion de TipoPublicacion******************************************************************  */  

/*   * Insertar TipoPublicacion   */ 
create procedure InsertarTipoPublicacion (     
@IDTipo     int,     
@NomTipo    char(10) ) AS INSERT INTO TipoPublicacion
(IDTipo,     NomTipo ) VALUES (@IDTipo, @NomTipo) 

/*   * Eliminar TipoPublicacion   */  
CREATE PROCEDURE EliminarTipoPublicacion ( 
@IDTipo int )  AS SET NOCOUNT ON DELETE FROM TipoPublicacion  WHERE (@IDTipo=IDTipo) 

 /*   * Modificar TipoPublicacion   */  
 CREATE PROCEDURE ModificarTipoPublicacion (     
 @IDTipo     int,     
 @NomTipo    char(10) ) AS SET NOCOUNT ON UPDATE TipoPublicacion SET NomTipo=@NomTipo WHERE IDTipo=@IDTipo 

 /*   * Obtener TipoPublicacion   */  
 CREATE PROCEDURE GetTipoPublicacion AS SET NOCOUNT ON SELECT * FROM TipoPublicacion

 /*   * Filtra TipoPublicacion   */ 
 CREATE PROCEDURE FiltraTipoPublicacion  (     
@IDTipo     int=null,      
@NomTipo    char(10)=null  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM TipoPublicacion where 1 = 1 '     if(@IDTipo <> 0)    SET @sql=@sql+ ' and IDSitio = '+convert(varchar,@IDTipo)  if(@NomTipo is not null)    SET @sql=@sql+ ' and NomTipo = '+Quotename(@NomTipo,'''')  exec (@sql)


/***********************************************Gestion de TipoUsuario******************************************************************  */   

/*   * Insertar TipoUsuario   */ 
create procedure InsertarTipoUsuario (     
@CodigoTipo    int,     
@NomTipo       varchar(50) ) AS INSERT INTO TipoUsuario (CodigoTipo,     NomTipo ) VALUES (@CodigoTipo, @NomTipo) 

/*   * Eliminar TipoUsuario   */  
CREATE PROCEDURE EliminarTipoUsuario ( 
@CodigoTipo int )  AS SET NOCOUNT ON DELETE FROM TipoUsuario  WHERE (@CodigoTipo=CodigoTipo)

/*    * Modificar TipoUsuario   */  
CREATE PROCEDURE ModificarTipoUsuario (     
@CodigoTipo    int,     
@NomTipo       varchar(50) ) AS SET NOCOUNT ON UPDATE TipoUsuario SET NomTipo=@NomTipo WHERE CodigoTipo=@CodigoTipo 

/*   * Obtener TipoUsuario para usuarios   */  
CREATE PROCEDURE GetTipoUsuario AS SET NOCOUNT ON SELECT * FROM TipoUsuario where codigoTipo=1 or codigoTipo=2 

/*   * Obtener TipoUsuario para Administrador   */  
CREATE PROCEDURE GetTiposUsuarios AS SET NOCOUNT ON SELECT * FROM TipoUsuario 

/*   * Filtra TipoUsuario   */ 
CREATE PROCEDURE FiltraTipoUsuario  (      
@CodigoTipo    int=null,       
@NomTipo       varchar(50)=null  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM TipoUsuario where 1 = 1 '     if(@CodigoTipo <> 0)    SET @sql=@sql+ ' and CodigoTipo = '+convert(varchar,@CodigoTipo)  if(@NomTipo is not null)    SET @sql=@sql+ ' and NomTipo = '+Quotename(@NomTipo,'''')  exec (@sql)

/*   * **********************************************Gestion de Usuario********************************/
/**Insertar Usuario   */ 
create procedure InsertarUsuario (     
@CodUsuario    varchar(20),     
@Nombres       varchar(50),     
@ApePat        varchar(50),     
@ApeMat        varchar(50)=null,     
@Password      varchar(30),     
@CodigoTipo    int ) AS INSERT INTO Usuario (     CodUsuario,     Nombres,  ApePat,  ApeMat,  Password,  CodigoTipo ) VALUES (@CodUsuario, @Nombres, @ApePat, @ApeMat, @Password, @CodigoTipo) 
 
/*   * Eliminar Usuario   */  
CREATE PROCEDURE EliminarUsuario ( 
@CodUsuario    varchar(20) )  AS SET NOCOUNT ON DELETE FROM Usuario  WHERE (@CodUsuario=CodUsuario) 

/*   * Modificar Usuario   */  
CREATE PROCEDURE ModificarUsuario (     
@CodUsuario    varchar(20),     
@Nombres       varchar(50)=null,     
@ApePat        varchar(50)=null,     
@ApeMat        varchar(50)=null,     
@Password      varchar(30)=null,     
@CodigoTipo    int=null) 
AS SET NOCOUNT ON UPDATE Usuario SET Nombres=@Nombres, ApePat=@ApePat, ApeMat=@ApeMat, Password=@Password, CodigoTipo=@CodigoTipo WHERE CodUsuario=@CodUsuario 

/*   * Obtener Usuario   */  
CREATE PROCEDURE GetUsuario AS SET NOCOUNT ON SELECT Codusuario as 'Matricula', nombres as 'Nombre',apepat as 'Apellido_Paterno',apemat as 'Apellido_Materno',NomTipo as 'Tipo_Usuario' FROM Usuario,tipousuario where Usuario.CodigoTipo=tipousuario.CodigoTipo

/*   * Filtra Usuario   */ 
CREATE PROCEDURE FiltraUsuario  (      
@CodUsuario    varchar(20)=null,       
@Nombres       varchar(50)=null,       
@ApePat        varchar(50)=null,       
@ApeMat        varchar(50)=null,       
@tipouser varchar(50)=null,
@contraseña varchar(50)=null
  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM Usuarios where 1 = 1 '       
if(@CodUsuario is not null)   SET @sql=@sql+ ' and Matricula = '+Quotename(@CodUsuario,'''')  
if(@Nombres is not null)   SET @sql=@sql+ ' and Nombre = '+Quotename(@Nombres,'''')  
if(@ApePat is not null)   SET @sql=@sql+ ' and Apellido_Paterno = '+Quotename(@ApePat,'''')  
if(@ApeMat is not null)   SET @sql=@sql+ ' and Apellido_Materno = '+Quotename(@ApeMat,'''')  
if(@tipouser is not null)   SET @sql=@sql+ ' and Tipo_Usuario  = '+Quotename(@tipouser,'''')   
if(@contraseña is not null)   SET @sql=@sql+ ' and contraseña  = '+Quotename(@contraseña,'''')   
exec (@sql)

/*   * **********************************************Gestion de UsuarioHora******************************************************************  */

/*   * Insertar UsuarioHora   */ 
create procedure InsertarUsuarioHora (     
@CodHora       int,     
@CodUsuario    varchar(20),
@idsitio  int,
@dia varchar(20)
 ) AS INSERT INTO UsuarioHora (     CodHora,     CodUsuario,IDSitio,Dia ) VALUES (@CodHora, @CodUsuario,@idsitio,@dia) 

/*   * Eliminar UsuarioHora   */  
CREATE PROCEDURE EliminarUsuarioHora (  
@ID int
)  AS SET NOCOUNT ON DELETE FROM UsuarioHora  WHERE (ID=@ID) 

/*   * Modificar UsuarioHora   */    
CREATE PROCEDURE ModificarUsuarioHora (     
@ID   int,
@CodHora       int,     
@CodUsuario    varchar(20),
@idsitio  int,
@dia varchar(20)) AS SET NOCOUNT ON UPDATE UsuarioHora SET CodHora=@CodHora, CodUsuario=@CodUsuario, idsitio=@idsitio, Dia=@dia WHERE ID=@ID

/*   * Obtener UsuarioHora   */  
CREATE PROCEDURE GetUsuarioHora AS SET NOCOUNT ON SELECT * FROM UsuarioHora 

/*   * Filtra UsuarioHora   */ 
CREATE PROCEDURE FiltraUsuarioHora  (        
@CodUsuario    varchar(20)=null,
@dia varchar(20)=null)  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  
SET @sql = ' SELECT * FROM HorarioUsuarios where 1 = 1 ' 
if(@CodUsuario is not null)    SET @sql=@sql+ ' and CodUsuario = '+Quotename(@CodUsuario,'''') 
if(@dia is not null)    SET @sql=@sql+ ' and Dia = '+Quotename(@dia,'''')   
exec (@sql)

/*************************  Comprueba si la matricula existe ********************************/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ComprobarExistencia]
(
	@Matricula  varchar(20)
)
AS
select count(*) from Usuario where CodUsuario=@Matricula

/****** Validar usuario *****/
create procedure [dbo].[Loguin]
(
@Matricula varchar(20),
@Contraseña varchar(30)
)
as
select count(*) from Usuario where CodUsuario=@matricula and Password=@Contraseña


/***********  ViSTA USUARIOS***********/
CREATE VIEW Usuarios as(select top 1000 CodUsuario as Matricula,Nombres as Nombre,ApePat as Apellido_Paterno,ApeMat as Apellido_Materno,NomTipo as Tipo_Usuario,password from usuario,tipousuario where usuario.codigoTipo=tipousuario.codigotipo )


 /***************VISTA PUBLICACIONES********************/
CREATE VIEW ViewPublicaciones as(SELECT IDPublicacion,Titulo,Fecha,Contenido,nomtipo as Nombre_Tipo,(Nombres +' '+ ApePat) as Nombre FROM Publicacion,TipoPublicacion,Usuario where publicacion.IDTipo=TipoPublicacion.IDTipo and Publicacion.CodUsuario=Usuario.CodUsuario)


/***************VISTA Actividades**********/
CREATE VIEW ViewActividades as(SELECT top 1000 IDActividad,Nombre,Descripcion,FechaIni as Fecha_Inicio,FechaFin as Fecha_Final,(Nombres +' '+ ApePat) as Nombres FROM Actividades,Usuario where actividades.codUsuario=Usuario.CodUsuario)
select * from Publicacion
 
 /**********************************Vista Top 3 de publicaciones***************************/
create view TopPublicaciones as(select top 3  IDPublicacion,Titulo,Fecha,Contenido,image from publicacion order by fecha desc)

CREATE PROCEDURE GetTopPublicaciones AS SET NOCOUNT ON SELECT * FROM TopPublicaciones 

/**********************************Vista Top 3 de Actividades***************************/
create view TopActividades as(select top 3 IDActividad,Nombre,Descripcion,FechaIni ,FechaFin from actividades order by FechaIni desc) 

CREATE PROCEDURE GetTopActividades AS SET NOCOUNT ON SELECT * FROM TopActividades

/*******************Asistencia a actividades *********************/

 create procedure [dbo].[GetAsistencia]
(
@ID int
)
as
SELECT Nombres,ApePat FROM actividadUsuario,Usuario where ActividadUsuario.CodUsuario=Usuario.CodUsuario and Asistencia=1 and ActividadUsuario.idactividad=@id

/*****************************Verifica si el existe en la tabla***********************************/
create procedure [dbo].[Comprobar]
(
@ID1 int,
@ID2 varchar(20)
)
as
select count(*) from ActividadUsuario where idactividad=@id1 and ActividadUsuario.CodUsuario=@ID2 

/*******************************************Busqueda de comentarios********************************************************/
CREATE PROCEDURE FiltraComentario  (      
@idComentario   int=null,       
@Fecha       date=null,       
@Contenido        varchar(5000)=null,       
@idUsuario        varchar(50)=null,       
@idPub int=null
  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM UsuarioPublicacion where 1 = 1 '       
if(@idComentario is not null)   SET @sql=@sql+ ' and CodComentario = '+Quotename(@idComentario,'''')  
if(@Fecha is not null)   SET @sql=@sql+ ' and Fecha = '+Quotename(@Fecha,'''')  
if(@Contenido is not null)   SET @sql=@sql+ ' and Contenido = '+Quotename(@Contenido,'''')  
if(@idUsuario is not null)   SET @sql=@sql+ ' and  CodUsuario= '+Quotename(@idUsuario,'''')  
if(@idpub is not null)   SET @sql=@sql+ ' and IDPublicacion  = '+Quotename(@idpub,'''')   
exec (@sql)

/*************************************************Inserta comentarios**************************************************************************/
create procedure InsertarComentario (     
@Contenido     varchar(5000),     
@codPub int,
@CodUsuario    varchar(50)
 ) AS INSERT INTO UsuarioPublicacion(contenido,IDPublicacion,   CodUsuario ) VALUES (@contenido,@codpub,@codusuario) 

/*************************************************Obtiene comentarios**************************************************************************/
create procedure [dbo].[GetComentarios]
(
@ID int
)
as SELECT contenido,Fecha,Nombres,ApePat FROM UsuarioPublicacion,Usuario where Usuario.CodUsuario=UsuarioPublicacion.CodUsuario and IDPublicacion=@ID


create view HorarioUsuarios as (select ID, usuario.CodUsuario, horaini,horafin,Dia,nombres,ApePat,Nombre from usuariohora,Usuario,Horario,Sitio where UsuarioHora.CodHora=Horario.CodHora and UsuarioHora.CodUsuario=Usuario.CodUsuario and UsuarioHora.IDSitio=Sitio.IDSitio)

create proc Horarios as select * from HorarioUsuarios

create proc GetHorario as select * from hora

create view hora as (select CodHora, convert(varchar,convert(char(8),horaini,108) + ' - ' +convert(char(8),horafin,108)) as Hora from Horario)

create view GetNombreMaestro as (select CodUsuario,(Nombres+' '+ApePat) as Nombre from Usuario)

create proc GetUser as (select * from GetNombreMaestro)

create proc BuscarHora (
@id int
) as select * from UsuarioHora where ID=@id


create view TopPublicaciones2 as(select top 10  IDPublicacion,Titulo,Fecha,Contenido,image from publicacion order by fecha desc)

CREATE PROCEDURE GetTopPublicaciones2 AS SET NOCOUNT ON SELECT * FROM TopPublicaciones2 

/*****************    Publicidad   **********/
create view Publicidad as(select top 10000 idpublicacion, titulo,fecha,contenido,image,video,tipoPublicacion.IDTipo,CodUsuario from Publicacion,TipoPublicacion where  Publicacion.IDTipo=TipoPublicacion.IDTipo and NomTipo='Publicidad' order by  fecha  desc)

CREATE PROCEDURE GetPublicidad AS SET NOCOUNT ON SELECT * FROM publicidad 
/*****************    Aviso   **********/
create view Aviso as(select top 10000 idpublicacion, titulo,fecha,contenido,image,video,tipoPublicacion.IDTipo,CodUsuario from Publicacion,TipoPublicacion where  Publicacion.IDTipo=TipoPublicacion.IDTipo and NomTipo='Aviso' order by  fecha  desc)

CREATE PROCEDURE GetAviso AS SET NOCOUNT ON SELECT * FROM Aviso

/*****************    Reporte    **********/
create view Reporte as(select top 10000 idpublicacion, titulo,fecha,contenido,image,video,tipoPublicacion.IDTipo,CodUsuario from Publicacion,TipoPublicacion where  Publicacion.IDTipo=TipoPublicacion.IDTipo and NomTipo='Reporte' order by  fecha  desc)

CREATE PROCEDURE GetReporte AS SET NOCOUNT ON SELECT * FROM Reporte


/**********************************************Gestion de Horario**************************************************/   

/*   * Insertar Horario   */  
CREATE PROCEDURE InsertarHorario (     
@HoraIni    time(0),     
@HoraFin    time(0)
) AS INSERT INTO Horario (          HoraIni,  HoraFin ) VALUES ( @HoraIni, @HoraFin)

/*   * Eliminar Horario   */  
CREATE PROCEDURE EliminarHorario ( @CodHora int )  AS SET NOCOUNT ON DELETE FROM Horario  WHERE (@CodHora=CodHora) 

/*   * Modificar Horario   */   
CREATE PROCEDURE ModificarHorario (     
@CodHora    int,     
@HoraIni    time(0),     
@HoraFin    time(0) ) AS SET NOCOUNT ON UPDATE Horario SET HoraIni=@HoraIni, HoraFin=@HoraFin WHERE CodHora=@CodHora 

/* Obtener Horario */
CREATE PROCEDURE GetHorario AS SET NOCOUNT ON SELECT * FROM Horario 

/* Filtra Horario   */  
CREATE PROCEDURE FiltraHorario  (    
@CodHora    int=null,     
@HoraIni    time(0)=null,     
@HoraFin    time(0)=null  )  AS  SET NOCOUNT ON   DECLARE @sql nvarchar(4000)  SET @sql = ' SELECT * FROM Horario where 1 = 1 '     if(@CodHora <> 0)    SET @sql=@sql+ ' and CodHora = '+convert(varchar,@CodHora)  if(@HoraIni is not null)    SET @sql=@sql+ ' and HoraIni = '+Quotename(@HoraIni,'''')  if(@HoraFin is not null)    SET @sql=@sql+ ' and HoraFin = '+Quotename(@HoraFin,'''')   
exec (@sql) 
